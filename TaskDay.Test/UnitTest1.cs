using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDay.Core;
using TaskDay.Model;
using System.Linq;

namespace TaskDay.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TaskManager_AddGroup_Test()
        {
            TaskManager.ClearGroups();
            ITaskGroup doingTasks = new DoingTasks();
            TaskDay.Core.TaskManager.AddGroup(doingTasks);
            Assert.IsTrue(TaskManager.GetTaskGroups().Count == 1);
        }

        [TestMethod]
        public void TaskManager_AddTask_Test()
        {
            TaskManager.ClearGroups();
            ITaskGroup doingTasks = new DoingTasks();
            TaskDay.Core.TaskManager.AddTask(doingTasks, new DailyTask { Title = "Test" });
            Assert.IsTrue(TaskManager.GetTaskGroups().Count == 1);
            Assert.IsTrue(TaskManager.GetTaskGroup(doingTasks.GroupId).DailyTasks.Count == 1);
        }

        [TestMethod]
        public void TaskManger_AddTask_Test2()
        {
            TaskManager.ClearGroups();
            DailyTask task = new DailyTask() { Title = "Title", Content = "Content", Date = DateTime.Now };
            ITaskGroup doingTasks = new DoingTasks();
            ITaskGroup deletedTasks = new DeletedTasks();
            TaskManager.AddGroup(doingTasks);
            TaskManager.AddGroup(deletedTasks);
            TaskManager.AddTask(doingTasks, task);
            TaskManager.MoveTask(doingTasks, deletedTasks, task);

            Assert.IsTrue(TaskManager.GetTaskGroups().Count == 2, TaskManager.GetTaskGroups().Count.ToString());
            Assert.IsNotNull(TaskManager.GetTaskGroup(task.GroupId));
            Assert.IsTrue(TaskManager.GetTaskGroup(task.GroupId).DailyTasks.Count == 1);
            Assert.IsTrue(TaskManager.GetTaskGroup(task.GroupId).GroupName == "已删除");
        }
    }
}
