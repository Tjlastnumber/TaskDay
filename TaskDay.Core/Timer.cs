using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDay.Core
{
    public class Timer
    {
        private Action _callback;
        private int _period;
        private int dueTime;

        [SecuritySafeCritical]
        public Timer(Action callback, int dueTime, int period)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            _callback = callback;
            this.Start();
        }

        private void Start()
        {
            Task.Factory.StartNew(
                () =>
                {
                    while (true)
                    {
                        _callback();
                    }
                }
                );
        }
    }
}
