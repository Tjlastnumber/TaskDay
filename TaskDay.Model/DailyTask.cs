﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskDay.Model
{
    public class DailyTask
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 分组ID
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 原分组ID
        /// </summary>
        public string OldGroupId { get; set; }

        /// <summary>
        /// 任务标记颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 任务通知间隔
        /// </summary>
        public TimeSpan TaskNotifySpan { get; set; }

        public DailyTask()
        {
            var dateTimeNow = DateTime.Now;
            Date = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day, dateTimeNow.Hour, dateTimeNow.Minute, dateTimeNow.Second);
            TaskNotifySpan = new TimeSpan(0, 15, 0);
        }
    }
}
