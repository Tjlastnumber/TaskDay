using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskDay.Model
{
    public interface ITaskGroup
    {
        string GroupId { get; }

        string GroupName { get; set; }

        List<DailyTask> DailyTasks { get; set; }
    }

    public class DeletedTasks : CustomTasks
    {
        public DeletedTasks()
            : base()
        {
            this.GroupName = "已删除";
        }
    }

    public class DoingTasks : CustomTasks
    {
        public DoingTasks()
            : base()
        {
            this.GroupName = "今日任务";
        }
    }

    public class CustomTasks : ITaskGroup
    {
        private string _groupName;

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        private List<DailyTask> _dailyTasks;
        /// <summary>
        /// 每日任务队列
        /// </summary>
        public List<DailyTask> DailyTasks
        {
            get { return _dailyTasks; }
            set { _dailyTasks = value; }
        }

        public CustomTasks()
        {
            _dailyTasks = new List<DailyTask>();

            GroupId = Guid.NewGuid().ToString();
        }

        public string GroupId { get; private set; }
    }
}
