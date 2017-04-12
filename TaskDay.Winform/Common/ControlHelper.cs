using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskDay.Winform.Common
{
    public static class ControlHelper
    {
        static int margin = 8;
        /// <summary>
        /// 容器控件布局扩展方法
        /// </summary>
        /// <typeparam name="T">容器内需要排列的控件类型</typeparam>
        /// <param name="tabPage">当前容器</param>
        /// <param name="orderChangedCallBack">容器内控件顺序改变回调函数</param>
        /// <param name="isInsert">容器添加控件是否启用插入模式</param>
        public static void PagePanelDock<T>(this Panel tabPage, Action<IEnumerable<T>> orderChangedCallBack, bool isInsert = false) where T : Control
        {
            List<Control> ctlList = new List<Control>();
            tabPage.ControlAdded += (s, e) =>
            {
                Control ctl = e.Control;
                if (isInsert)
                {
                    ctlList.Insert(0, ctl);
                }
                else
                {
                    ctlList.Add(ctl);
                }

                OrderControls(tabPage, ctlList, ctlList.FirstOrDefault());
                tabPage.Invalidate();

                Point ml = new Point();
                int ctl_top = 0;
                int ctl_left = 0;
                bool isTransposition = false;

                ctl.MouseDown += (cs, ce) =>
                {
                    tabPage.Controls.SetChildIndex(ctl, 0);
                    ml = ce.Location;
                    ctl_top = ctl.Top;
                    ctl_left = ctl.Left;
                    Debug.WriteLine(ctl_top);
                };

                ctl.MouseUp += (cs, ce) =>
                {
                    if (isTransposition)
                    {
                        OrderControls(tabPage, ctlList, ctl);
                        isTransposition = false;
                    }
                    else
                    {
                        ctl.Top = ctl_top;
                        ctl.Left = ctl_left;
                    }
                };

                ctl.MouseMove += (cs, ce) =>
                {
                    if (ctl.Capture)
                    {
                        int offsetY = ce.Location.Y - ml.Y;
                        ctl.Top += offsetY;

                        BorderScroll(tabPage, ctl);

                        if (ControlsTransposition(ref ctlList, tabPage, ctl, ce, offsetY))
                        {
                            isTransposition = true;
                            orderChangedCallBack(ctlList.Cast<T>().ToList() ?? new List<T>());
                        }
                    }
                };

                ctl.SizeChanged += (cs, ce) =>
                {
                };

            };

            tabPage.ControlRemoved += (s, e) =>
            {
                Control ctl = e.Control;
                ctlList.Remove(ctl);
                OrderControls(tabPage, ctlList, ctl);
            };

            tabPage.SizeChanged += (s, e) =>
            {
                foreach (var t in tabPage.Controls.OfType<T>())
                {
                    t.Width = tabPage.ClientSize.Width - margin * 2;
                }
            };
        }

        /// <summary>
        /// 控件拖动
        /// </summary>
        /// <param name="ctlList">控件列表集合</param>
        /// <param name="tabPage">控件父级</param>
        /// <param name="ctl">当前控件</param>
        /// <param name="ce">事件提供数据</param>
        /// <param name="offsetY">鼠标Y轴偏移量</param>
        /// <param name="callback">位置改变回调函数</param>
        private static bool ControlsTransposition(ref List<Control> ctlList, Panel tabPage, Control ctl, MouseEventArgs ce, int offsetY)
        {
            bool result = false;
            var target_ctl = ctlList.Where(p => p.Bottom > (ce.Location.Y + ctl.Top) && p.Top < (ce.Location.Y + ctl.Top) && p != ctl).FirstOrDefault();
            if (target_ctl != null)
            {
                if (offsetY < 0)
                {
                    int target_index = ctlList.IndexOf(target_ctl);
                    if (target_index - 1 >= 0)
                    {
                        tabPage.ScrollControlIntoView(ctl);

                        target_ctl.Top = ctlList[target_index - 1].Bottom + ctl.Height + margin * 2;

                        result = true;
                    }
                    else
                    {
                        target_ctl.Top = ctl.Height + margin * 2;

                        result = true;
                    }
                }
                else if (offsetY > 0)
                {
                    int ctl_index = ctlList.IndexOf(ctl);
                    if (ctl_index - 1 >= 0)
                    {
                        target_ctl.Top = ctlList[ctl_index - 1].Bottom + margin;

                        result = true;
                    }
                    else
                    {
                        target_ctl.Top = margin;

                        result = true;
                    }
                }
                ctlList = ctlList.OrderBy(p => p.Top).ToList();
            }
            return result;
        }

        /// <summary>
        /// 控件贴近容器边缘时自动滚动
        /// </summary>
        /// <param name="tabPage">容器</param>
        /// <param name="ctl">当前控件</param>
        private static void BorderScroll(Panel tabPage, Control ctl)
        {
            if (ctl.Top <= 0)
            {
                if ((tabPage.VerticalScroll.Value - tabPage.VerticalScroll.SmallChange) > tabPage.VerticalScroll.Minimum)
                {
                    tabPage.VerticalScroll.Value -= tabPage.VerticalScroll.SmallChange;
                    tabPage.Update();
                }
            }
            else if (ctl.Bottom >= tabPage.Height)
            {
                if ((tabPage.VerticalScroll.Value + tabPage.VerticalScroll.SmallChange) < tabPage.VerticalScroll.Maximum)
                {
                    tabPage.VerticalScroll.Value += tabPage.VerticalScroll.SmallChange;
                    tabPage.Update();
                }
            }
        }
        /// <summary>
        /// 按照控件的顺序重新布局所有控件
        /// </summary>
        /// <param name="tabPage">容器</param>
        /// <param name="ctlList">控件列表</param>
        /// <param name="ctl">当前控件</param>
        private static void OrderControls(Panel tabPage, List<Control> ctlList, Control ctl)
        {
            int vsValue = tabPage.VerticalScroll.Value;
            tabPage.VerticalScroll.Value = 0;
            for (int i = 0; i < ctlList.Count; i++)
            {
                var previous = ctlList.ElementAtOrDefault(i - 1);
                var current = ctlList.ElementAtOrDefault(i);
                current.Location = new Point(margin, (previous ?? new Control()).Bottom + margin);
                current.Width = tabPage.ClientSize.Width - margin * 2;
            }
            if (ctl == ctlList.LastOrDefault())
            {
                tabPage.ScrollControlIntoView(ctl);
            }
            else
            {
                tabPage.VerticalScroll.Value = vsValue;
            }
            tabPage.Invalidate();
        }
    }

    public static class Extension
    {
        public static List<T> ExchangIndex<T>(this List<T> list, T o1, T o2)
        {
            var i1 = list.IndexOf(o1);
            var i2 = list.IndexOf(o2);

            var temp = list[i1];
            list[i1] = list[i2];
            list[i2] = temp;
            return list;
        }
    }
}
