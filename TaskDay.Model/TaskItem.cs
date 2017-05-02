using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay.Model
{
    public class TaskItem
    {
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsFinish { get; set; }
        /// <summary>
        /// 任务项内容
        /// </summary>
        public string Content { get; set; }
    }
}
