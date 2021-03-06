﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskDay.Core
{
    /// <summary>
    /// 通知任务时间调入类
    /// </summary>
    public class NotifySchedule
    {
        public bool PendingRunOnce { get; set; }

        public DateTime NextRun { get; internal set; }

        public TimeSpan DelayRunFor { get; set; }

        public Func<DateTime, DateTime> CalculateNextRun { get; set; }

        public List<Action> Notifies { get; private set; }

        public string Name { get; internal set; }

        internal object Reentrant { get; set; }

        internal ICollection<NotifySchedule> AdditionalSchedules { get; set; }

        public NotifySchedule() { }

        public NotifySchedule(Action action) : this(string.Empty, new[] { action }) { }

        public NotifySchedule(string name, Action action) : this(name, new[] { action }) { }

        public NotifySchedule(string name, IEnumerable<Action> actions)
        {
            this.Name = name;
            this.Notifies = actions.ToList();
            AdditionalSchedules = new List<NotifySchedule>();
            PendingRunOnce = false;
            Reentrant = null;
        }

        public void ToRunOnceAt(DateTime time)
        {
            CalculateNextRun = x => (DelayRunFor > TimeSpan.Zero ? time.Add(DelayRunFor) : time);
            PendingRunOnce = true;
            Reentrant = this;
        }

        public void ToRunEvery(TimeSpan interval)
        {
            DelayRunFor = interval;
            CalculateNextRun = x => x.Add(DelayRunFor);
        }

        /// <summary>
        /// Assigns a name to this job schedule.
        /// </summary>
        /// <param name="name">Name to assign</param>
        public NotifySchedule WithName(string name)
        {
            Name = name;
            return this;
        }


        public void Execute()
        {
            JobManager.SendNotify(this);
        }

        /// <summary>
        /// Sets this job schedule as non reentrant.
        /// </summary>
        public NotifySchedule NonReentrant()
        {
            Reentrant = Reentrant ?? new object();
            return this;
        }
    }

    public class NotifyMessage : INotifyMessage
    {
        public string Message { get; set; }

        public Uri ImageUri { get; set; }

        public string Title { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan NotifyInterval { get; set; }

        public NotifyMessage() { }

        public NotifyMessage(int seconds) : this(new TimeSpan(0, 0, seconds)) { }

        public NotifyMessage(int hours, int minutes) : this(new TimeSpan(hours, minutes, 0)) { }

        public NotifyMessage(TimeSpan notifyInterval)
        {
            this.NotifyInterval = notifyInterval;
            this.StartTime = DateTime.Now.Add(NotifyInterval);
        }
    }

    public interface INotifyMessage
    {
        /// <summary>
        /// 通知消息
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// 通知图片地址
        /// </summary>
        Uri ImageUri { get; set; }
        /// <summary>
        /// 通知标题
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        DateTime StartTime { get; set; }
        /// <summary>
        /// 通知时间间隔
        /// </summary>
        TimeSpan NotifyInterval { get; set; }
    }
}
