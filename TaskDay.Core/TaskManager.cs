using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Windows;
using Newtonsoft.Json.Linq;
using TaskDay.Model;
using System.Reflection;

namespace TaskDay.Core
{
    public static class TaskManager
    {
        static object _manager_lock = new object();
        static List<ITaskGroup> _taskGroups;
        internal static List<ITaskGroup> TaskGroups
        {
            get
            {
                return _taskGroups ??
                      (_taskGroups = new List<ITaskGroup> 
                        { 
                                new DoingTasks(),
                                new DeletedTasks()
                        });
            }
            private set { _taskGroups = value; }
        }

        public static List<ITaskGroup> Init()
        {
            lock (_manager_lock)
            {
                if (TaskGroups == null)
                {
                    TaskGroups = new List<ITaskGroup>
                    {
                        new DoingTasks(),
                        new DeletedTasks()
                    };
                }
                return TaskGroups;
            }
        }

        public static void Load(List<ITaskGroup> taskGroups)
        {
            lock (_manager_lock)
            {
                TaskGroups = taskGroups;
            }
        }

        public static void ClearGroups()
        {
            TaskGroups = null;
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

        public static bool AddTask(ITaskGroup group, DailyTask task)
        {
            lock (_manager_lock)
            {
                if (!string.IsNullOrWhiteSpace(task.Title) || !string.IsNullOrWhiteSpace(task.Content))
                {
                    if (TaskGroups.SingleOrDefault(p => p.GroupId.Equals(group.GroupId)) == null)
                    {
                        AddGroup(group);
                    }
                    group.DailyTasks.Add(task);
                    task.GroupId = group.GroupId;
                    return true;
                }
                return false;
            }
        }

        public static bool InsertTask(ITaskGroup group, DailyTask task)
        {
            lock (_manager_lock)
            {
                if (!string.IsNullOrWhiteSpace(task.Title) || !string.IsNullOrWhiteSpace(task.Content))
                {
                    if (TaskGroups.SingleOrDefault(p => p.GroupId.Equals(group.GroupId)) == null)
                    {
                        AddGroup(group);
                    }
                    group.DailyTasks.Insert(0, task);
                    task.GroupId = group.GroupId;
                    return true;
                }
                return false;
            }
        }

        public static void RemoveTask(DailyTask task)
        {
            lock (_manager_lock)
            {
                foreach (var group in TaskGroups)
                {
                    group.DailyTasks.Remove(task);
                    task.GroupId = null;
                    task.OldGroupId = null;
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
                    dailyTask.GroupId = toGroupId;
                    dailyTask.OldGroupId = fromGroupId;
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
                    dailyTask.OldGroupId = fromGroup.GroupId;
                }
            }
        }

        public static bool MoveToDeletedGroup(DailyTask dailyTask)
        {
            lock (_manager_lock)
            {
                var fromGroup = TaskGroups.SingleOrDefault(p => p.GroupId.Equals(dailyTask.GroupId));
                var deletedGroup = GetTaskGroup(DeletedTasks.GUID);
                if (fromGroup != null && deletedGroup != null)
                {
                    if (fromGroup.DailyTasks.Remove(dailyTask))
                    {
                        dailyTask.OldGroupId = fromGroup.GroupId;
                        InsertTask(deletedGroup, dailyTask);
                        return true;
                    }
                }
                return false;
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

        public static event EventHandler TaskListChanged;
        public static event TaskNotifyHandler TaskNotify;
    }

    public delegate void TaskNotifyHandler(TaskNotifyEventArgs args);

    public class TaskNotifyEventArgs:EventArgs
    {
        public TaskNotifyEventArgs()
        {

        }
    }
}
