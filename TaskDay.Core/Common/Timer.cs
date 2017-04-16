using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDay.Core.Common
{
    public class Timer
    {
        private Action _callback;
        private int _period;

        [SecuritySafeCritical]
        public Timer(Action callback, int period)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            _period = period;
            _callback = callback;
            this.Start();
        }

        public void Change(int period)
        {
            this._period = period;
        }

        private void Start()
        {
            Task.Factory.StartNew(
                () =>
                {
                    _callback();
                }
                ).ContinueWith(t =>
                {
                    Task.Delay(_period).Wait();
                    Start();
                });
        }
    }
}
