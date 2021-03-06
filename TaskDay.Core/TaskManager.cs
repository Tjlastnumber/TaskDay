﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Windows;
using Newtonsoft.Json.Linq;
using TaskDay.Model;
using System.Reflection;
using TaskDay.Core.Common;
using TaskDay.Core.CoreCollectionExpand;
using TaskDay.Core.Enum;
using TaskDay.Core.Event;

namespace TaskDay.Core
{
    public static class TaskManager
    {
        private static object _manager_lock = new object();

        private static List<ITaskGroup> _taskGroups;

        internal static List<ITaskGroup> TaskGroups
        {
            get { return _taskGroups ?? (_taskGroups = new List<ITaskGroup>()); }
            private set { _taskGroups = value; }
        }

        #region Groups

        public static List<ITaskGroup> InitGroup()
        {
            lock (_manager_lock)
            {
                return _taskGroups ??
                      (_taskGroups = new List<ITaskGroup> 
                        { 
                           DoingTasks.Instance,
                           FinishTasks.Instance
                        });
            }
        }

        public static void LoadGroup(List<ITaskGroup> taskGroups)
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

        public static bool MoveToFinishGroup(DailyTask dailyTask)
        {
            lock (_manager_lock)
            {
                var finishGroup = GetTaskGroup(FinishTasks.GUID);
                if (finishGroup != null)
                {
                    return MoveTask(finishGroup, dailyTask);
                }
                return false;
            }
        }

        public static List<ITaskGroup> GetTaskGroups()
        {
            lock (_manager_lock)
            {
                return InitGroup();
            }
        }

        public static ITaskGroup GetTaskGroup(string groupId)
        {
            lock (_manager_lock)
            {
                return TaskGroups.SingleOrDefault(p => p.GroupId.Equals(groupId));
            }
        }

        #endregion

        #region Task
        public static void AddTasks(ITaskGroup group, ICollection<DailyTask> dailyTasks)
        {
            foreach (var dailyTask in dailyTasks)
            {
                AddTask(group, dailyTask);
            }
        }

        public static bool AddTask(ITaskGroup group, DailyTask task)
        {
            lock (_manager_lock)
            {
                if (!task.Title.IsNullOrWhiteSpace() || (task.TaskItems != null && task.TaskItems.Count > 0))
                {
                    if (GetTaskGroup(group.GroupId) == null)
                    {
                        AddGroup(group);
                    }
                    else
                    {
                        group = TaskGroups.SingleOrDefault(p => p.GroupId.Equals(group.GroupId));
                    }
                    group.DailyTasks.Add(task);

                    task.GroupId = group.GroupId;

                    OnTaskListChanged(task, TaskChangedType.Add);
                    Debug.WriteLine(group.DailyTasks.Count);
                    return true;
                }
                return false;
            }
        }

        public static bool AddTask(string taskgroupid, DailyTask task)
        {
            lock (_manager_lock)
            {
                if (!task.Title.IsNullOrWhiteSpace() || (task.TaskItems != null && task.TaskItems.Count > 0))
                {
                    var group = GetTaskGroup(taskgroupid);
                    if (group != null)
                    {
                        group.DailyTasks.Add(task);
                        task.GroupId = group.GroupId;
                        OnTaskListChanged(task, TaskChangedType.Add);
                        Debug.WriteLine(group.DailyTasks.Count);
                        return true;
                    }
                }
                return false;
            }
        }

        public static bool InsertTask(ITaskGroup group, DailyTask task)
        {
            lock (_manager_lock)
            {
                if (!task.Title.IsNullOrWhiteSpace() || (task.TaskItems != null && task.TaskItems.Count > 0))
                {
                    if (TaskGroups.SingleOrDefault(p => p.GroupId.Equals(group.GroupId)) == null)
                    {
                        AddGroup(group);
                    }
                    group.DailyTasks.Insert(0, task);
                    task.GroupId = group.GroupId;
                    OnTaskListChanged(task, TaskChangedType.Insert);
                    return true;
                }
                return false;
            }
        }

        public static bool RemoveTask(DailyTask task)
        {
            lock (_manager_lock)
            {
                try
                {
                    var result = TaskGroups.SingleOrDefault(p => p.GroupId == task.GroupId).DailyTasks.Remove(task);
                    task.OldGroupId = task.GroupId;
                    task.GroupId = null;
                    OnTaskListChanged(task, TaskChangedType.Remove);
                    return result;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool MoveTask(string toGroupId, DailyTask dailyTask)
        {
            lock (_manager_lock)
            {
                bool result = false;
                try
                {
                    var fromGroup = TaskGroups.SingleOrDefault(p => p.GroupId.Equals(dailyTask.GroupId));
                    var toGroup = TaskGroups.SingleOrDefault(p => p.GroupId.Equals(toGroupId));
                    if (fromGroup != null && toGroup != null)
                    {
                        fromGroup.DailyTasks.Remove(dailyTask);
                        toGroup.DailyTasks.Add(dailyTask);
                        dailyTask.GroupId = toGroup.GroupId;
                        dailyTask.OldGroupId = fromGroup.GroupId;

                        OnTaskListChanged(dailyTask, TaskChangedType.Move);
                        result = true;
                    }
                    return result;
                }
                catch
                {
                    return result;
                }
            }
        }

        public static bool MoveTask(ITaskGroup toGroup, DailyTask dailyTask)
        {
            lock (_manager_lock)
            {
                bool result = false;
                try
                {
                    if (TaskGroups.SingleOrDefault(p => p.GroupId.Equals(dailyTask.GroupId)) != null &&
                        TaskGroups.SingleOrDefault(p => p.GroupId.Equals(toGroup.GroupId)) != null)
                    {
                        var fromGroup = TaskGroups.SingleOrDefault(p => p.GroupId.Equals(dailyTask.GroupId));
                        fromGroup.DailyTasks.Remove(dailyTask);
                        toGroup.DailyTasks.Add(dailyTask);
                        dailyTask.GroupId = toGroup.GroupId;
                        dailyTask.OldGroupId = fromGroup.GroupId;
                        OnTaskListChanged(dailyTask, TaskChangedType.Move);
                        result = true;
                    }
                    return result;
                }
                catch
                {
                    return result;
                }
            }
        }

        #endregion

        #region Convert Josn

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

        #endregion

        #region Event
        public static event TaskNotifyHandler TaskNotified;
        private static void OnTaskNotified(DailyTask task)
        {
            if (TaskNotified!=null)
            {
                TaskNotified(new TaskItemNotifyEventArgs(task));
            }
        }

        /// <summary>
        /// 任务通知事件
        /// </summary>
        public static event TaskChangedHandler TaskListChanged;
        private static void OnTaskListChanged(DailyTask task, TaskChangedType type)
        {
            if (TaskListChanged != null)
            {
                TaskListChanged(task, new TaskItemChangedEventArgs(type));
            }
        }
        #endregion
    }

}
