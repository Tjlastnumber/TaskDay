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

    public class FinishTasks : CustomTasks
    {
        private static FinishTasks instance;
        public static readonly string GUID = "A48D4811-952D-4142-A1B8-E5EEA8B639CE";
        private FinishTasks()
            : base()
        {
            this.GroupName = "已完成";
            this.GroupId = GUID; 
        }

        public static FinishTasks Instance
        {
            get
            {
                return instance ?? (instance = new FinishTasks());
            }
        }
    }

    public class DoingTasks : CustomTasks
    {
        private static DoingTasks instance;
        public static readonly string GUID = "B54CCF78-51DF-4B06-A480-D35F31DDF09A";

        private DoingTasks()
            : base()
        {
            this.GroupName = "今日任务";
            this.GroupId = GUID; 
        }

        public static DoingTasks Instance
        {
            get
            {
                return instance ?? (instance = new DoingTasks());
            }
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
        }

        public string GroupId { get; set; }
    }
}
