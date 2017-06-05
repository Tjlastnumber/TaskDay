using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDay.Core;
using TaskDay.Model;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace TaskDay.Test
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void TaskManager_AddGroup_Test()
        {
            TaskManager.ClearGroups();
            CustomTasks doingTasks = DoingTasks.Instance;
            TaskDay.Core.TaskManager.AddGroup(doingTasks);
            Assert.IsTrue(TaskManager.GetTaskGroups().Count == 1);
        }

        [TestMethod]
        public void TaskManager_AddTask_Test()
        {
            TaskManager.ClearGroups();
            CustomTasks doingTasks = DoingTasks.Instance;
            TaskDay.Core.TaskManager.AddTask(doingTasks, new DailyTask { Title = "Test" });
            Assert.AreEqual(1, TaskManager.GetTaskGroups().Count);
            Assert.IsTrue(TaskManager.GetTaskGroup(doingTasks.GroupId).DailyTasks.Count == 1);
        }

        [TestMethod]
        public void TaskManger_AddTask_Test2()
        {
            TaskManager.ClearGroups();
            DailyTask task = new DailyTask() { Title = "Title", TaskItems = new List<TaskItem> { new TaskItem { Content = "Content" } }, Date = DateTime.Now };
            CustomTasks doingTasks = DoingTasks.Instance;
            CustomTasks deletedTasks = FinishTasks.Instance;

            TaskManager.AddGroup(doingTasks);
            TaskManager.AddGroup(deletedTasks);
            TaskManager.AddTask(doingTasks, task);

            Assert.IsTrue(TaskManager.GetTaskGroups().Count == 2, TaskManager.GetTaskGroups().Count.ToString());
            Assert.IsNotNull(TaskManager.GetTaskGroup(task.GroupId));
            Assert.AreEqual(1, TaskManager.GetTaskGroup(task.GroupId).DailyTasks.Count);

            TaskManager.MoveTask(deletedTasks, task);
            Assert.AreEqual(TaskManager.GetTaskGroup(task.GroupId).GroupId, FinishTasks.GUID);
        }

        [TestMethod]
        public void TaskManager_SaveTaskItems_Test()
        {
            TaskManager.ClearGroups();
            TaskManager.InitGroup();
            DailyTask task = new DailyTask
            {
                Title = "Title",
                TaskItems = new List<TaskItem>
                {
                    new TaskItem
                    {
                        Content ="TaskItemContent",
                        IsFinish = false,
                    }, 
                    new TaskItem
                    {
                        Content ="TaskItemContent2",
                        IsFinish = false,
                    }, 
                },
                Date = DateTime.Now
            };

            var value = true;
            var result = TaskManager.AddTask(DoingTasks.GUID, task);

            Assert.AreEqual(value, result);
        }
    }
}
