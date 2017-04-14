using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskDay.Core;

namespace TaskDay.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer_Test();
            Console.ReadLine();
        }

        private static void Timer_Test()
        {
            int i = 0;
            TaskDay.Core.Timer timer = new Core.Timer(()=> {
                Console.WriteLine(i++);
            }, 3, 10);
        }

        private static void NotifySchedule_Test()
        {
            NotifySchedule nm = new NotifySchedule();
            NotifyMessage message = new NotifyMessage(3) { Title = "m1", Message = "TestNotify" };
            NotifyMessage message1 = new NotifyMessage(2) { Title = "m2", Message = "TestNotify" };
            NotifyMessage message2 = new NotifyMessage(10) { Title = "m3", Message = "TestNotify" };
            Stopwatch sw = new Stopwatch();
            sw.Start();
            nm.AddNotify(message, () =>
            {
                Console.WriteLine("消息：{0}， 提醒间隔{1}", message.Title, sw.Elapsed.TotalMilliseconds);
            }, TaskScheduler.Current);
            nm.AddNotify(message2, () =>
            {
                Console.WriteLine("消息：{0}， 提醒间隔{1}", message2.Title, sw.Elapsed.TotalMilliseconds);
            }, TaskScheduler.Current);
            nm.AddNotify(message1, () =>
            {
                Console.WriteLine("消息：{0}， 提醒间隔{1}", message1.Title, sw.Elapsed.TotalMilliseconds);
            }, TaskScheduler.Current);

            Console.WriteLine("主线程运行结束...");
            Console.ReadLine();
        }

        private static void doWork()
        {
        }
    }
}
