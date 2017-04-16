using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay.Core
{
    /// <summary>
    /// 通知时间调度集合类
    /// </summary>
    public class NotifyScheduleCollection
    {
        private List<NotifySchedule> _schedules = new List<NotifySchedule>();

        private object _lock = new object();

        internal bool Any()
        {
            lock (_lock)
            {
                return _schedules.Any();
            }
        }

        internal void Sort()
        {
            lock (_lock)
            {
                _schedules.Sort((x, y) => DateTime.Compare(x.NextRun, y.NextRun));
            }
        }

        internal IEnumerable<NotifySchedule> All()
        {
            lock (_lock)
            {
                return _schedules;
            }
        }

        internal void Add(NotifySchedule schedule)
        {
            lock (_lock)
            {
                _schedules.Add(schedule);
            }
        }

        internal bool Remove(string name)
        {
            lock (_lock)
            {
                var schedule = Get(name);
                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    _schedules.Remove(schedule);
                    return true;
                }
            }
        }

        internal bool Remove(NotifySchedule schedule)
        {
            lock (_lock)
            {
                return _schedules.Remove(schedule);
            }
        }

        internal NotifySchedule First()
        {
            lock (_lock)
            {
                return _schedules.FirstOrDefault();
            }
        }

        internal NotifySchedule Get(string name)
        {
            lock (_lock)
            {
                return _schedules.FirstOrDefault(x => x.Name == name);
            }
        }
    }
}
