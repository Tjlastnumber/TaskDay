using System;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDay.Core.Common
{
    public class Timer
    {
        private Action<Timer> _callback;
        private double _period;
        private static CancellationTokenSource _cancel = new CancellationTokenSource();

        [SecuritySafeCritical]
        public Timer(Action<Timer> callback, int period) : this(callback, (long)period) { }

        [SecuritySafeCritical]
        public Timer(Action<Timer> callback, uint period) : this(callback, (long)period) { }

        [SecuritySafeCritical]
        public Timer(Action<Timer> callback, TimeSpan period) : this(callback, (long)period.TotalMilliseconds) { }

        [SecuritySafeCritical]
        public Timer(Action<Timer> callback, long period)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            _period = period;
            _callback = callback;
            this.Start();
        }

        public void Change(uint period)
        {
            Change((long)period);
        }

        public void Change(int period)
        {
            Change((long)period);
        }

        public void Change(TimeSpan period)
        {
            Change((long)period.TotalMilliseconds);
        }

        public void Change(long period)
        {
            this._period = period;
            _cancel.Cancel();
            _cancel = null;
            _cancel = new CancellationTokenSource();
            Start();
        }

        private void Start()
        {
            Task.Factory.StartNew(
                () =>
                {
                    lock (this)
                    {
                        while (!_cancel.IsCancellationRequested)
                        {
                            Task.Delay((int)_period, _cancel.Token).Wait();
                            _callback(this);
                        }
                    }
                },
                cancellationToken: _cancel.Token,
                creationOptions: TaskCreationOptions.LongRunning,
                scheduler: TaskScheduler.Default);
        }
    }
}
