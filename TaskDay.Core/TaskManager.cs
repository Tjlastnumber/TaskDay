using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using TaskDay.Model;

namespace TaskDay.Core
{
    public static class TaskManager
    {
        static object managerLock = new object();
        internal static List<ITaskGroup> TaskGroups = new List<ITaskGroup>();

        public static void ClearGroups()
        {
            TaskGroups.Clear();
        }

        public static void AddGroup(ITaskGroup group)
        {
            lock (managerLock)
            {
                if (GetTaskGroup(group.GroupId) == null)
                {
                    TaskGroups.Add(group);
                }
            }
            Debug.WriteLine(group.GroupName, "Add Group");
        }

        public static void AddTask(ITaskGroup group, DailyTask task)
        {
            lock (managerLock)
            {
                if (TaskGroups.SingleOrDefault(p => p.GroupId.Equals(group.GroupId)) == null)
                {
                    AddGroup(group);
                }
                group.DailyTasks.Add(task);
                task.GroupId = group.GroupId;
            }
            Debug.WriteLine(task.Title, "Add Task");
        }

        public static void RemoveTask(ITaskGroup group, DailyTask task)
        {
            lock (managerLock)
            {
                if (TaskGroups.SingleOrDefault(p => p == group) != null)
                {
                    group.DailyTasks.Remove(task);

                    Debug.WriteLine(task.Title, "Remove Task");
                }
            }
        }

        public static void MoveTask(ITaskGroup fromGroup, ITaskGroup toGroup, DailyTask dailyTask)
        {
            lock (managerLock)
            {
                if (TaskGroups.SingleOrDefault(p => p.GroupId.Equals(fromGroup.GroupId)) != null &&
            TaskGroups.SingleOrDefault(p => p.GroupId.Equals(toGroup.GroupId)) != null)
                {
                    fromGroup.DailyTasks.Remove(dailyTask);
                    toGroup.DailyTasks.Add(dailyTask);
                    dailyTask.GroupId = toGroup.GroupId;
                }
                
            }
        }

        public static List<ITaskGroup> GetTaskGroups()
        {
            return TaskGroups;
        }

        public static ITaskGroup GetTaskGroup(string groupId)
        {
            return TaskGroups.SingleOrDefault(p => p.GroupId.Equals(groupId));
        }

        public static string ConvertJson()
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(TaskGroups);

            return JArray.Parse(jsonString).ToString();
        }
    }
}
