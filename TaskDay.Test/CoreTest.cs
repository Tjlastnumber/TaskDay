using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDay.Core;
using TaskDay.Model;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskDay.Test
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void TaskManager_AddGroup_Test()
        {
            TaskManager.ClearGroups();
            CustomTasks doingTasks = new DoingTasks();
            TaskDay.Core.TaskManager.AddGroup(doingTasks);
            Assert.IsTrue(TaskManager.GetTaskGroups().Count == 1);
        }

        [TestMethod]
        public void TaskManager_AddTask_Test()
        {
            TaskManager.ClearGroups();
            CustomTasks doingTasks = new DoingTasks();
            TaskDay.Core.TaskManager.AddTask(doingTasks, new DailyTask { Title = "Test" });
            Assert.IsTrue(TaskManager.GetTaskGroups().Count == 1);
            Assert.IsTrue(TaskManager.GetTaskGroup(doingTasks.GroupId).DailyTasks.Count == 1);
        }

        [TestMethod]
        public void TaskManger_AddTask_Test2()
        {
            TaskManager.ClearGroups();
            DailyTask task = new DailyTask() { Title = "Title", Content = "Content", Date = DateTime.Now };
            CustomTasks doingTasks = new DoingTasks();
            CustomTasks deletedTasks = new DeletedTasks();
            TaskManager.AddGroup(doingTasks);
            TaskManager.AddGroup(deletedTasks);
            TaskManager.AddTask(doingTasks, task);
            TaskManager.MoveTask(doingTasks, deletedTasks, task);

            Assert.IsTrue(TaskManager.GetTaskGroups().Count == 2, TaskManager.GetTaskGroups().Count.ToString());
            Assert.IsNotNull(TaskManager.GetTaskGroup(task.GroupId));
            Assert.IsTrue(TaskManager.GetTaskGroup(task.GroupId).DailyTasks.Count == 1);
            Assert.IsTrue(TaskManager.GetTaskGroup(task.GroupId).GroupName == "已删除");
        }

        Stopwatch sw = new Stopwatch();
        [TestMethod]
        public void NotifyManager_True_Test()
        {
            NotifyMessage m = new NotifyMessage();
            m.Message = "Test";

            NotifySchedule nm = new NotifySchedule();
            sw.Start();
            nm.AddNotify(m, doWrok);
            sw.Stop();
            Assert.AreEqual(m.NotifyInterval.Seconds, sw.Elapsed.Seconds);
        }

        [TestMethod]
        public void NotifyManager_False_Test()
        {
            NotifyMessage m = new NotifyMessage();
            m.Message = "Test";

            NotifySchedule nm = new NotifySchedule();
            sw.Start();
            doAsyncNotify(nm, m);
            sw.Stop();
            Assert.AreNotEqual(m.NotifyInterval.Seconds, sw.Elapsed.Seconds);
        }

        [TestMethod]
        public void NotifyManger_True_Test2()
        {
            NotifyMessage m = new NotifyMessage();
            m.Message = "Test";
            m.NotifyInterval = new TimeSpan(0, 0, 10);

            NotifySchedule nm = new NotifySchedule();
            sw.Start();
            nm.AddNotify(m, doWrok);
            Assert.AreEqual(m.NotifyInterval.Seconds, sw.Elapsed.Seconds);
        }

        [TestMethod]
        public void NotifyManager_BatchNotify_Test()
        {
            NotifyMessage m1 = new NotifyMessage();
            m1.Message = "Test";
            m1.NotifyInterval = new TimeSpan(0, 0, 3);
            NotifyMessage m2 = new NotifyMessage();
            m2.Message = "Test";
            m2.NotifyInterval = new TimeSpan(0, 0, 20);

            NotifySchedule nm = new NotifySchedule();
            sw.Start();
            nm.AddNotify(m1, doWrok);
            nm.AddNotify(m2, doWrok);
            sw.Stop();
            Assert.AreEqual(m1.NotifyInterval.Seconds, sw.Elapsed.Seconds);
            sw.Start();
            Assert.AreEqual(m2.NotifyInterval.Seconds, sw.Elapsed.Seconds);
        }

        private void doAsyncNotify(NotifySchedule nm, NotifyMessage m)
        {
            nm.AddNotify(m, doWrok);
        }

        private void doWrok()
        {
            sw.Stop();
        }
    }
}
