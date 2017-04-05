using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using TaskDay.Model;

namespace TaskDay.WinCore
{
    public class TaskManager
    {
        static object _manager_lock = new object();
        internal static List<ITaskGroup> TaskGroups = new List<ITaskGroup>();

        public static void ClearGroups()
        {
            TaskGroups.Clear();
        }

        public static void AddGroup(ITaskGroup group)
        {
            lock (_manager_lock)
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
            lock (_manager_lock)
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

        public static void RemoveTask(DailyTask task)
        {
            lock (_manager_lock)
            {
                var group = TaskGroups.SingleOrDefault(p => p.GroupId == task.GroupId);
                if (group != null)
                {
                    group.DailyTasks.Remove(task);

                    Debug.WriteLine(task.Title, "Remove Task");
                }
            }
        }

        public static void MoveTask(string fromGroupId, string toGroupId, DailyTask dailyTask)
        {
            lock (_manager_lock)
            {
                var fromGroup = TaskGroups.SingleOrDefault(p => p.GroupId.Equals(fromGroupId));
                var toGroup = TaskGroups.SingleOrDefault(p => p.GroupId.Equals(toGroupId));
                if (fromGroup != null && toGroup != null)
                {
                    fromGroup.DailyTasks.Remove(dailyTask);
                    toGroup.DailyTasks.Add(dailyTask);
                    dailyTask.GroupId = toGroup.GroupId;
                }
            }
        }

        public static void MoveTask(ITaskGroup fromGroup, ITaskGroup toGroup, DailyTask dailyTask)
        {
            lock (_manager_lock)
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
            lock (_manager_lock)
            {
                return TaskGroups;
            }
        }

        public static ITaskGroup GetTaskGroup(string groupId)
        {
            lock (_manager_lock)
            {
                return TaskGroups.SingleOrDefault(p => p.GroupId.Equals(groupId));
            }
        }

        public static string ConvertJson()
        {
            lock (_manager_lock)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(TaskGroups);
            }
        }

        public static string ConvertFormatJson()
        {
            lock (_manager_lock)
            {
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(TaskGroups);

                return JArray.Parse(jsonString).ToString();
            }
        }

    }
}
