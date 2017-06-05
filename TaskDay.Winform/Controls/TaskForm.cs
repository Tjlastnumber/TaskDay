using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using TaskDay.Core;
using TaskDay.GeneralLibrary;
using TaskDay.Model;
using TaskDay.Winform.Controls;
using TaskDay.Winform.Common;

namespace TaskDay.Winform
{
    public partial class TaskForm : MetroFramework.Forms.MetroForm
    {
        private bool _isClick = false;

        public DailyTask DailyTask { get; private set; }
        public MetroStyleManager GlobalStyleManager
        {
            get
            {
                return this.StyleManager;
            }
            set
            {
                this.StyleManager = value;
            }
        }

        public TaskForm(Form mdiParent, DailyTask dt)
        {
            InitializeComponent();

            this.DailyTask = dt;

            this.ControlBox = false;
            this.MdiParent = mdiParent;

            this.MouseDown += TaskForm_MouseDown;
            this.MouseMove += TaskForm_MouseMove;
            this.MouseUp += TaskForm_MouseUp;

            this.lb_Title.DataBindings.Add("Text", DailyTask, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            this.lb_Date.DataBindings.Add("Text", DailyTask, "Date", true, DataSourceUpdateMode.OnPropertyChanged);

            this.contentPanel.PagePanelDock<CustomLabel>(callBack => { }, false);
            ShowTaskContentItem(dt);
            PointMenuItem();
        }


        private void PointMenuItem()
        {
            foreach (var group in TaskManager.GetTaskGroups())
            {
                var menuItem = new ToolStripMenuItem(group.GroupName);
                menuItem.Click += (s, e) =>
                {
                    TaskManager.MoveTask(group.GroupId, this.DailyTask);
                };
                this.groupMenu.Items.Insert(0, menuItem);
            }
        }


        void TaskForm_MouseDown(object sender, MouseEventArgs e)
        {
            _isClick = true;
        }

        void TaskForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isClick)
            {
                TaskEditForm form = new TaskEditForm(DailyTask);
                form.GlobalStyleManager = this.StyleManager;
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ShowTaskContentItem(DailyTask);
                    if (SaveEvent != null)
                    {
                        this.SaveEvent(this, null);
                    }
                }
            }
        }

        private void ShowTaskContentItem(DailyTask dailyTask)
        {
            this.contentPanel.Controls.Clear();
            foreach (var taskItem in dailyTask.TaskItems)
            {
                CustomLabel cl = new CustomLabel();
                this.contentPanel.Controls.Add(cl);
                cl.Text = taskItem.Content;
                cl.Strikeout = taskItem.IsFinish;
            }
        }

        void TaskForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Capture)
            {
                _isClick = false;
            }
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            this.metroLink1.ContextMenuStrip.Show(this.metroLink1, new Point(0, 0));
        }

        private void metroLink1_MouseClick(object sender, MouseEventArgs e)
        {
            this.metroLink1.ContextMenuStrip.Show(this.metroLink1, e.Location);
        }

        private void cm_Delete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public event EventHandler SaveEvent;
    }
}
