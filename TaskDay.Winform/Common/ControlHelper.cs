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
        public static void TabPagePanelDock<T>(this Panel tabPage, Action orderChangedCallBack, bool isInsert = false) where T : Control
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

                OrderControls(tabPage, ctlList, ctl);
                tabPage.VerticalScroll.Value = 0;

                Point ml = new Point();
                ctl.MouseDown += (cs, ce) =>
                {
                    tabPage.Controls.SetChildIndex(ctl, 0);
                    ml = ce.Location;
                };

                ctl.MouseUp += (cs, ce) =>
                {
                    OrderControls(tabPage, ctlList, ctl);
                };

                ctl.MouseMove += (cs, ce) =>
                {
                    if (ctl.Capture)
                    {
                        int offsetY = ce.Location.Y - ml.Y;
                        ctl.Top += offsetY;

                        BorderScroll(tabPage, ctl);

                        tabPage.Refresh();

                        ControlsTransposition(ref ctlList, tabPage, ctl, ce, offsetY, orderChangedCallBack);
                    }
                };

                ctl.SizeChanged += (cs, ce) =>
                {
                    OrderControls(tabPage, ctlList, ctl);
                };

                tabPage.Invalidate();
            };

            tabPage.ControlRemoved += (s, e) =>
            {
                Control ctl = e.Control;
                ctlList.Remove(ctl);
                OrderControls(tabPage, ctlList, ctl);
            };
        }

        private static void ControlsTransposition(ref List<Control> ctlList, Panel tabPage, Control ctl, MouseEventArgs ce, int offsetY, Action callback)
        {
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
                    }
                    else
                    {
                        target_ctl.Top = ctl.Height + margin * 2;
                    }
                }
                else if (offsetY > 0)
                {
                    int ctl_index = ctlList.IndexOf(ctl);
                    if (ctl_index - 1 >= 0)
                    {
                        target_ctl.Top = ctlList[ctl_index - 1].Bottom + margin;
                    }
                    else
                    {
                        target_ctl.Top = margin;
                    }
                }
                ctlList = ctlList.OrderBy(p => p.Top).ToList();
                callback();
            }
        }

        private static void BorderScroll(Panel tabPage, Control ctl)
        {
            if (ctl.Top <= 0)
            {
                if ((tabPage.VerticalScroll.Value - tabPage.VerticalScroll.SmallChange) > tabPage.VerticalScroll.Minimum)
                {
                    tabPage.VerticalScroll.Value -= tabPage.VerticalScroll.SmallChange;
                }
            }
            else if (ctl.Bottom >= tabPage.Height)
            {
                if (tabPage.VerticalScroll.Value + tabPage.VerticalScroll.SmallChange < tabPage.VerticalScroll.Maximum)
                {
                    tabPage.VerticalScroll.Value += tabPage.VerticalScroll.SmallChange;
                }
            }
        }

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
            //tabPage.VerticalScroll.Value = vsValue;
            tabPage.ScrollControlIntoView(ctl);
            tabPage.Invalidate();
        }
    }

    public static class ListExtension
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
