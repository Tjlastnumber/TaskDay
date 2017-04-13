using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay.Core
{
    public class NotifyManager
    {

        // TODO:
        // 通知类
        // 根据传入的通知消息时间间隔定时触发相应回调函数
        // 执行过的消息移除通知队列
        // 通知队列

        public NotifyManager()
        {
        }

        public async void AddNewNotify(INotifyMessage message, Action worker)
        {
        }

        public void RemoveNotify(INotifyMessage message)
        {

        }
    }

    public class NotifyMessage : INotifyMessage
    {

        public string Message { get; set; }

        public Uri ImageUri { get; set; }

        public string Title { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan NotifyTimeSpan { get; set; }

        public NotifyMessage()
        {
            NotifyTimeSpan = new TimeSpan(0, 0, 3);
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
        TimeSpan NotifyTimeSpan { get; set; }
    }
}
