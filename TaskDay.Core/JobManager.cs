using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay.Core
{
    public static class JobManager
    {
        private static bool _userUtc = false;

        private static NotifyScheduleCollection _schedules = new NotifyScheduleCollection();

        internal static DateTime Now
        {
            get { return _userUtc ? DateTime.UtcNow : DateTime.Now; }
        }

        /// <summary>
        /// Starts the job manager.
        /// </summary>
        public static void Start()
        {
            ScheduleJobs();
        }

        private static void ScheduleJobs()
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<NotifySchedule> CalculateNextRun(IEnumerable<NotifySchedule> schedules)
        {
            foreach (var schedule in schedules)
            {
                if(schedule.CalculateNextRun == null)
                {

                }
                else
                {
                    yield return schedule;
                }

            }
        }
    }
}
