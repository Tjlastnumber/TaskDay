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
using TaskDay.Core;
using TaskDay.GeneralLibrary;
using TaskDay.Winform.Common;
using TaskDay.Model;
using MetroFramework;

namespace TaskDay.Winform
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.InitThemeAndStyle();

            this.StyleManager = this.metroStyleManager;
            this.IsMdiContainer = true;
            this.FormClosing += Form1_FormClosing;
        }


        private void InitThemeAndStyle()
        {
            var themes = new EnumConverter(typeof(MetroThemeStyle)).GetStandardValues();
            var styles = new EnumConverter(typeof(MetroColorStyle)).GetStandardValues();

            this.cb_SelectTheme.DataSource = new BindingSource(themes, null);
            this.cb_SelectStyle.DataSource = new BindingSource(styles, null);

            this.cb_SelectTheme.SelectedIndexChanged += (s, e) =>
            {
                this.metroStyleManager.Theme = (MetroThemeStyle)this.cb_SelectTheme.SelectedItem;
                AppSetManager.SetTheme(this.cb_SelectTheme.SelectedValue.ToString());
            };
            this.cb_SelectStyle.SelectedIndexChanged += (s, e) =>
            {
                this.metroStyleManager.Style = (MetroColorStyle)this.cb_SelectStyle.SelectedItem;
                AppSetManager.SetStyle(this.cb_SelectStyle.SelectedValue.ToString());
            };

            this.cb_SelectTheme.Text = AppSetManager.AppSetting.AppTheme;
            this.cb_SelectStyle.Text = AppSetManager.AppSetting.AppStyle;
        }


        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileHelper.SaveJosn(TaskManager.ConvertJson());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadTasks();
        }

        private void LoadTasks()
        {
            TaskManager.ClearGroups();
            LoadControl lc = new LoadControl(LoadSource, PointTasks);
            lc.Parent = this;
            lc.Dock = DockStyle.Fill;
            this.Controls.Add(lc);
            this.Controls.SetChildIndex(lc, 0);
        }

        private void LoadSource()
        {
            TaskManager.ClearGroups();
            var rj = FileHelper.ReadJosn<List<CustomTasks>>();
            if (rj != null)
            {
                TaskManager.LoadGroup(rj.ToList<ITaskGroup>());
            }
        }

        private void PointTasks()
        {
            foreach (var taskgroup in TaskManager.GetTaskGroups())
            {
                MetroFramework.Controls.MetroTabPage tabPage = new MetroFramework.Controls.MetroTabPage();
                tabPage.UseVisualStyleBackColor = true;
                tabPage.Name = taskgroup.GroupId;
                tabPage.Tag = taskgroup;
                tabPage.Text = taskgroup.GroupName;
                tabPage.VerticalScrollbarSize = 4;
                tabPage.HorizontalScrollbar = false;
                tabPage.HorizontalScroll.Enabled = false;
                tabPage.HorizontalScrollbarHighlightOnWheel = false;
                tabPage.VerticalScrollbar = true;
                tabPage.AutoScroll = true;
                tabPage.PagePanelDock<TaskForm>(list =>
                {
                    List<DailyTask> dtl = new List<DailyTask>();
                    foreach (var ctl in list)
                    {
                        dtl.Add(ctl.DailyTask);
                    }
                    TaskManager.GetTaskGroup(tabPage.Name).DailyTasks = dtl;
                    FileHelper.SaveJosn(TaskManager.ConvertJson());
                });

                metroTabControl.TabPages.Add(tabPage);

                foreach (var task in taskgroup.DailyTasks)
                {
                    tabPage.Controls.Add(AddTaskForm(task));
                }
            }
            this.metroStyleManager.Update();
        }

        private TaskForm AddTaskForm(DailyTask task)
        {
            TaskForm form = new TaskForm(this, task);
            form.GlobalStyleManager = this.metroStyleManager;
            form.Show();
            form.SaveEvent += form_SaveEvent;
            form.FormClosed += form_FormClosed;
            return form;
        }

        void form_SaveEvent(object sender, EventArgs e)
        {
            FileHelper.SaveJosn(TaskManager.ConvertJson());
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = sender as TaskForm;
            if (TaskManager.MoveToDeletedGroup(form.DailyTask))
            {
                this.metroTabControl.TabPages[form.DailyTask.OldGroupId].Controls.Remove(form);
                this.metroTabControl.TabPages[form.DailyTask.GroupId].Controls.Add(form);
                this.metroStyleManager.Update();
                FileHelper.SaveJosn(TaskManager.ConvertJson());
            }
        }

        static NotifySchedule _notifyManager = new NotifySchedule();
        private async void addTab_Click(object sender, EventArgs e)
        {
            DailyTask dt = new DailyTask();
            using (TaskEditForm editForm = new TaskEditForm(dt))
            {
                editForm.GlobalStyleManager = this.metroStyleManager;
                if (editForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var group = this.metroTabControl.SelectedTab.Tag as ITaskGroup;
                    if (TaskManager.AddTask(group, dt))
                    {
                        var form = AddTaskForm(dt);
                        this.metroTabControl.SelectedTab.Controls.Add(form);
                        this.metroTabControl.SelectedTab.ScrollControlIntoView(form);
                        this.metroStyleManager.Update();
                        FileHelper.SaveJosn(TaskManager.ConvertJson());
                    }

                    _notifyManager.AddNotify(new NotifyMessage(dt.TaskNotifyInterval) { Title = dt.Title, Message = dt.Content }, () =>
                    {
                        MetroFramework.Forms.MetroTaskWindow tw = new MetroFramework.Forms.MetroTaskWindow();
                        tw.Text = dt.Title;
                        tw.Show(this);
                    });
                }
            }
        }

        bool menuIsShow = false;
        private void link_Set_Click(object sender, EventArgs e)
        {
            var expand = new MetroFramework.Animation.ExpandAnimation();
            if (menuIsShow)
            {
                expand.Start(this.metroPanel1, new Size(0, this.metroPanel1.Height), MetroFramework.Animation.TransitionType.EaseInOutCubic, 6);
                menuIsShow = false;
            }
            else
            {
                expand.Start(this.metroPanel1, new Size(200, this.metroPanel1.Height), MetroFramework.Animation.TransitionType.EaseInOutCubic, 6);
                menuIsShow = true;
            }
        }

        private void link_Refresh_Click(object sender, EventArgs e)
        {
            this.metroTabControl.TabPages.Clear();
            LoadTasks();
        }
    }
}
