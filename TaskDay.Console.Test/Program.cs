using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using TaskDay.Core;

namespace TaskDay.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();
            ListenForStart();
            ListenForStop();
            ListenForEx();
            //Timer_Test2();
            Console.ReadLine();
        }


        private static void ListenForStart()
        {
            JobManager.JobStart += (info) => Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "[job start]", info.Name);
        }

        private static void ListenForStop()
        {
            JobManager.JobEnd += (info) => Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "[job end]", info.Name);
        }

        private static void ListenForEx()
        {
            JobManager.JobException += (info) => Console.WriteLine("{0} [job exception]", DateTime.Now.ToString("yyyy-MM-dd h:mm:ss.fff"), info.Exception.Message);
        }

        private static void Initialize()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss.fff"));
            JobManager.AddJob(() =>
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssss") + "[late]", "This was added after the initialize call.");
            },
            s => { s.ToRunOnceAt(DateTime.Now.AddSeconds(30)); });
            JobManager.AddJob(() =>
            {
                Console.WriteLine(DateTime.Now.ToString("h:mm:ss.fff") + "[late2]", "This was added after the initialize call.");
            },
            s => { s.ToRunEvery(new TimeSpan(0, 0, 0, 2)); });
        }
        [SecuritySafeCritical]
        private static TaskDay.Core.Common.Timer Timer_Test2()
        {
            Console.WriteLine("[{0}] start.", DateTime.Now.ToString("h:mm:ss.fff"));
            int i = 0;
            TaskDay.Core.Common.Timer timer = new Core.Common.Timer(t =>
            {
                Console.WriteLine("[{0}] timer running {1,2}.", DateTime.Now.ToString("h:mm:ss.fff"), (i++).ToString());
                Random r = new Random();
                double d = r.NextDouble() * 10000;
                t.Change((int)d);
                Console.WriteLine("Changed timer : {0,5}", d);
            }, 2000);
            return timer;
        }

        private static TaskDay.Core.Common.Timer Timer_Test()
        {
            int i = 0;
            TaskDay.Core.Common.Timer timer = new Core.Common.Timer(t =>
            {
                Console.WriteLine(DateTime.Now.ToString() + ": " + (i++).ToString());
            }, 10000);

            return timer;
        }
    }
}
