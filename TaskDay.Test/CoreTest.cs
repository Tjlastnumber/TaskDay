using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDay.Core;
using TaskDay.Model;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

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
            Assert.AreEqual(1, TaskManager.GetTaskGroups().Count);
            Assert.IsTrue(TaskManager.GetTaskGroup(doingTasks.GroupId).DailyTasks.Count == 1);
        }

        [TestMethod]
        public void TaskManger_AddTask_Test2()
        {
            TaskManager.ClearGroups();
            DailyTask task = new DailyTask() { Title = "Title", Content = "Content", Date = DateTime.Now };
            CustomTasks doingTasks = new DoingTasks();
            CustomTasks deletedTasks = new FinishTasks();

            TaskManager.AddGroup(doingTasks);
            TaskManager.AddGroup(deletedTasks);
            TaskManager.AddTask(doingTasks, task);

            Assert.IsTrue(TaskManager.GetTaskGroups().Count == 2, TaskManager.GetTaskGroups().Count.ToString());
            Assert.IsNotNull(TaskManager.GetTaskGroup(task.GroupId));
            Assert.AreEqual(TaskManager.GetTaskGroup(task.GroupId).DailyTasks.Count, 1);

            TaskManager.MoveTask(deletedTasks, task);
            Assert.AreEqual(TaskManager.GetTaskGroup(task.GroupId).GroupId, FinishTasks.GUID);
        }
    }
}
