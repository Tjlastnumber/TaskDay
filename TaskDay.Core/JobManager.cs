using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskDay.Core.Common;
using TaskDay.Core.Event;
using TaskDay.Core.CoreCollectionExpand;
using System.Diagnostics;

namespace TaskDay.Core
{
    public static class JobManager
    {
        private const uint _maxTimerInterval = (uint)0xfffffffe;

        private static bool _userUtc = false;

        private static NotifyScheduleCollection _schedules = new NotifyScheduleCollection();

        private static Timer _timer = new Timer(t => { ScheduleJobs(); }, Timeout.Infinite);

        private static readonly ISet<Tuple<NotifySchedule, Task>> _running = new HashSet<Tuple<NotifySchedule, Task>>();

        internal static DateTime Now
        {
            get { return _userUtc ? DateTime.UtcNow : DateTime.Now; }
        }

        #region Event handling

        /// <summary>
        /// Event raised when an exception occurs in a job.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly",
            Justification = "Using strong-typed GenericEventHandler<TSender, TEventArgs> event handler pattern.")]
        public static event Action<JobExceptionInfo> JobException;

        /// <summary>
        /// Event raised when a job starts.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly",
            Justification = "Using strong-typed GenericEventHandler<TSender, TEventArgs> event handler pattern.")]
        public static event Action<JobStartInfo> JobStart;

        /// <summary>
        /// Evemt raised when a job ends.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly",
            Justification = "Using strong-typed GenericEventHandler<TSender, TEventArgs> event handler pattern.")]
        public static event Action<JobEndInfo> JobEnd;

        #endregion


        #region Start & Stop

        /// <summary>
        /// Starts the job manager.
        /// </summary>
        public static void Start()
        {
            ScheduleJobs();
        }

        public static void Stop()
        {
            _timer.Change(Timeout.Infinite);
        }

        public static void StopAndBlock()
        {
            Stop();

            var tasks = new Task[0];

            do
            {
                lock (_running)
                {
                    tasks = _running.Select(t => t.Item2).ToArray();
                }

                Task.WaitAll(tasks);
            } while (tasks.Any());
        }

        #endregion

        #region add & remove Notify
        /// <summary>
        /// Adds a job schedule to the job manager.
        /// </summary>
        /// <param name="job">Job to run.</param>
        /// <param name="schedule">Job schedule to add.</param>
        public static void AddJob(Action job, Action<NotifySchedule> schedule)
        {
            if (job == null)
                throw new ArgumentNullException("job");

            if (schedule == null)
                throw new ArgumentNullException("schedule");

            AddJob(schedule, new NotifySchedule(job));
        }

        private static void AddJob(Action<NotifySchedule> jobSchedule, NotifySchedule schedule)
        {
            jobSchedule(schedule);
            CalculateNextRun(new NotifySchedule[] { schedule }).ToList().ForEach(SendNotify);
            ScheduleJobs();
        }

        /// <summary>
        /// Removes the schedule of the given name.
        /// </summary>
        /// <param name="name">Name of the schedule.</param>
        public static void RemoveJob(string name)
        {
            _schedules.Remove(name);
        }
        #endregion


        #region running & sending

        private static IEnumerable<NotifySchedule> CalculateNextRun(IEnumerable<NotifySchedule> schedules)
        {
            foreach (var schedule in schedules)
            {
                if (schedule.CalculateNextRun == null)
                {
                    if (schedule.DelayRunFor > TimeSpan.Zero)
                    {
                        // delayed job
                        schedule.NextRun = Now.Add(schedule.DelayRunFor);
                        _schedules.Add(schedule);
                    }
                    else
                    {
                        // run immediately
                        yield return schedule;
                    }
                    //var hasAdded = false;
                    //foreach (var child in schedule.AdditionalSchedules.Where(x => x.CalculateNextRun != null))
                    //{
                    //    var nextRun = child.CalculateNextRun(Now.Add(child.DelayRunFor).AddMilliseconds(1));
                    //    if (!hasAdded || schedule.NextRun > nextRun)
                    //    {
                    //        schedule.NextRun = nextRun;
                    //        hasAdded = true;
                    //    }
                    //}
                }
                else
                {
                    schedule.NextRun = schedule.CalculateNextRun(Now.Add(schedule.DelayRunFor));
                    _schedules.Add(schedule);
                }

                //foreach (var childSchedule in schedule.AdditionalSchedules)
                //{
                //    if (childSchedule.CalculateNextRun == null)
                //    {
                //        if (childSchedule.DelayRunFor > TimeSpan.Zero)
                //        {
                //            // delayed job
                //            childSchedule.NextRun = Now.Add(childSchedule.DelayRunFor);
                //            _schedules.Add(childSchedule);
                //        }
                //        else
                //        {
                //            // run immediately
                //            yield return childSchedule;
                //            continue;
                //        }
                //    }
                //    else
                //    {
                //        childSchedule.NextRun = childSchedule.CalculateNextRun(Now.Add(childSchedule.DelayRunFor));
                //        _schedules.Add(childSchedule);
                //    }
                //}
            }
        }

        public static void SendNotify(NotifySchedule schedule)
        {
            lock (_running)
            {
                if (schedule.Reentrant != null &&
                    _running.Any(t => ReferenceEquals(t.Item1.Reentrant, schedule.Reentrant)))
                    return;
            }

            Tuple<NotifySchedule, Task> tuple = null;

            var task = new Task(() =>
            {
                var start = Now;

                if (JobStart != null)
                    Task.Factory.StartNew(() =>
                    {
                        JobStart(
                            new JobStartInfo
                            {
                                Name = schedule.Name,
                                StartTime = start,
                            }
                        );
                    }, TaskCreationOptions.PreferFairness);

                var stopwatch = new Stopwatch();

                try
                {
                    stopwatch.Start();
                    schedule.Notifies.ForEach(action => Task.Factory.StartNew(action, TaskCreationOptions.AttachedToParent).Wait());
                    //schedule.Notifies.ForEach(action => action());
                }
                catch (Exception e)
                {
                    if (JobException != null)
                        JobException(
                           new JobExceptionInfo
                           {
                               Name = schedule.Name,
                               Exception = e,
                           }
                       );
                }
                finally
                {
                    lock (_running)
                    {
                        _running.Remove(tuple);
                    }

                    if (JobEnd != null)
                        Task.Factory.StartNew(() =>
                        {
                            JobEnd(
                                new JobEndInfo
                                {
                                    Name = schedule.Name,
                                    StartTime = start,
                                    Duration = stopwatch.Elapsed,
                                    NextRun = schedule.NextRun,
                                }
                            );
                        }, TaskCreationOptions.PreferFairness);
                }
            }, TaskCreationOptions.PreferFairness);

            tuple = new Tuple<NotifySchedule, Task>(schedule, task);

            lock (_running)
            {
                _running.Add(tuple);
            }

            task.Start();
        }

        private static void ScheduleJobs()
        {
            _timer.Change(Timeout.Infinite);

            if (!_schedules.Any())
                return;

            _schedules.Sort();

            var firstJob = _schedules.First();
            if (firstJob.NextRun <= Now)
            {
                SendNotify(firstJob);
                if (firstJob.CalculateNextRun == null)
                {
                    // probably a ToRunNow().DelayFor() job, there's no CalculateNextRun
                }
                else
                {
                    firstJob.NextRun = firstJob.CalculateNextRun(Now.AddMilliseconds(1));
                }

                if (firstJob.NextRun <= Now || firstJob.PendingRunOnce)
                {
                    _schedules.Remove(firstJob);
                }

                firstJob.PendingRunOnce = false;
                ScheduleJobs();
                return;
            }

            var interval = firstJob.NextRun - Now;

            if (interval <= TimeSpan.Zero)
            {
                ScheduleJobs();
                return;
            }
            else
            {
                if (interval.TotalMilliseconds > _maxTimerInterval)
                    interval = TimeSpan.FromMilliseconds(_maxTimerInterval);

                _timer.Change(interval);
            }
        }
        #endregion

    }
}
