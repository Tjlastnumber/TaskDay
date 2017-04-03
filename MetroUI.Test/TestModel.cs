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
            ITaskGroup doingGroup = new DoingTasks();
            ITaskGroup deleteGroup = new DeletedTasks();

            TaskManager.AddGroup(doingGroup);
            TaskManager.AddGroup(deleteGroup);

            DailyTask dt1 = new DailyTask() { Title = "Task1" };
            DailyTask dt2 = new DailyTask() { Title = "Task2" };
            DailyTask dt3 = new DailyTask() { Title = "Task3" };
            DailyTask dt4 = new DailyTask() { Title = "Task4" };

            TaskManager.AddTask(doingGroup, dt1);
            TaskManager.AddTask(doingGroup, dt2);
            TaskManager.AddTask(doingGroup, dt3);
            TaskManager.AddTask(doingGroup, dt4);
        }
    }
}
