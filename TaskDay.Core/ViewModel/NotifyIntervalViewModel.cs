using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDay.Model;

namespace TaskDay.Core.ViewModel
{
    public class NotifyIntervalViewModel
    {
        public List<NotifyInterval> NotifyIntervals { get; set; }

        public NotifyIntervalViewModel()
        {
            NotifyIntervals = new List<NotifyInterval> { 
                new NotifyInterval{ IntervalText="15分钟", ItervalTimeSpan = new TimeSpan(0,15,0)},
                new NotifyInterval{ IntervalText="30分钟", ItervalTimeSpan = new TimeSpan(0,30,0)},
                new NotifyInterval{ IntervalText="45分钟", ItervalTimeSpan = new TimeSpan(0,45,0)},
                new NotifyInterval{ IntervalText="60分钟", ItervalTimeSpan = new TimeSpan(1,0,0)},
            };
        }
    }
}
