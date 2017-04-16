using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay.Core.Common
{
    public static class StringExpand
    {
        /// <summary>
        /// 指示指定的字符串是 null 还是 System.String.Empty 字符串。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this String s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this String s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
    }
}
