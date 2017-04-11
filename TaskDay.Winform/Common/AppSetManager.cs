using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay.Winform.Common
{
    public static class AppSetManager
    {
        internal static AppSetting AppSetting
        {
            get { return global::TaskDay.Winform.AppSetting.Default; }
        }

        public static void SetTheme(string theme)
        {
            AppSetting.AppTheme = theme;
            AppSetting.Save();
        }

        public static void SetStyle(string style)
        {
            AppSetting.AppStyle = style;
            AppSetting.Save();
        }
    }
}
