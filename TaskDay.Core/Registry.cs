using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay.Core
{
    /// <summary>
    /// A registry of job schedules.
    /// </summary>
    public class Registry
    {
        private bool _allJobsConfiguredAsNonReentrant;

        internal bool UtcTime { get; private set; }

        internal List<NotifySchedule> NotifySchedules { get; private set; }

        /// <summary>
        /// Default ctor.
        /// </summary>
        public Registry()
        {
            _allJobsConfiguredAsNonReentrant = false;
            NotifySchedules = new List<NotifySchedule>();
        }

        /// <summary>
        /// Sets all jobs in this schedule as non reentrant.
        /// </summary>
        public void NonReentrantAsDefault()
        {
            _allJobsConfiguredAsNonReentrant = true;
            lock (((ICollection)NotifySchedules).SyncRoot)
            {
                foreach (var schedule in NotifySchedules)
                    schedule.NonReentrant();
            }
        }

        /// <summary>
        /// Use UTC time rather than local time.
        /// </summary>
        public void UseUtcTime()
        {
            UtcTime = true;
        }

        /// <summary>
        /// NotifySchedules a new job in the registry.
        /// </summary>
        /// <param name="job">Job to run.</param>
        public NotifySchedule NotifySchedule(Action job)
        {
            if (job == null)
                throw new ArgumentNullException("job");

            return NotifySchedule(job, null);
        }

        public NotifySchedule NotifySchedule(Action action, string name)
        {
            var schedule = new NotifySchedule(action);

            if (_allJobsConfiguredAsNonReentrant)
                schedule.NonReentrant();

            lock (((ICollection)NotifySchedules).SyncRoot)
            {
                NotifySchedules.Add(schedule);
            }

            schedule.Name = name;

            return schedule;
        }

        public NotifySchedule NotifySchedule(NotifySchedule schedule)
        {
            lock (((ICollection)NotifySchedules).SyncRoot)
            {
                NotifySchedules.Add(schedule);
            }
            return schedule;
        }

        public void RemoveNotifySchedule(string name)
        {
            NotifySchedules.Remove(NotifySchedules.SingleOrDefault(p => p.Name == name));
        }
    }
}
