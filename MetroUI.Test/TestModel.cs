using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDay.Core;
using TaskDay.Model;

namespace MetroUI.Test
{
    public class TestModel
    {
        public TestModel()
        {
            CustomTasks doingGroup = DoingTasks.Instance;
            CustomTasks deleteGroup = FinishTasks.Instance; 

            TaskManager.AddGroup(doingGroup);
            TaskManager.AddGroup(deleteGroup);

            DailyTask dt1 = new DailyTask() { Title = "Task1", TaskItems =new List<TaskItem>{ new TaskItem{ Content = "Content1\r\nContent_1" }}};
            DailyTask dt2 = new DailyTask() { Title = "Task2", TaskItems =new List<TaskItem>{ new TaskItem{ Content = "Content2" }}};
            DailyTask dt3 = new DailyTask() { Title = "Task3", TaskItems =new List<TaskItem>{ new TaskItem{ Content = "Content3" }}};
            DailyTask dt4 = new DailyTask() { Title = "Task4", TaskItems =new List<TaskItem>{ new TaskItem{ Content = "Content4" }}};

            TaskManager.AddTask(doingGroup, dt1);
            TaskManager.AddTask(doingGroup, dt2);
            TaskManager.AddTask(doingGroup, dt3);
            TaskManager.AddTask(doingGroup, dt4);
        }
    }
}
