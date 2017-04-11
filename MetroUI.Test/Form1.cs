using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MetroUI.Test.Contorls;
using TaskDay.Core;
using TaskDay.Model;
using TaskDay.GeneralLibrary;
using TaskDay.Winform.Common;

namespace MetroUI.Test
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.FormClosing += Form1_FormClosing;
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
            LoadControl lc = new LoadControl(
                () =>
                {
                    TaskManager.ClearGroups();
                    var rj = FileHelper.ReadJosn<List<CustomTasks>>();
                    if (rj != null)
                    {
                        TaskManager.Load(rj.ToList<ITaskGroup>());
                    }
                },
                () =>
                {
                    foreach (var taskgroup in TaskManager.GetTaskGroups())
                    {
                        MetroFramework.Controls.MetroTabPage tabPage = new MetroFramework.Controls.MetroTabPage();
                        tabPage.Name = taskgroup.GroupId;
                        tabPage.Tag = taskgroup;
                        tabPage.Text = taskgroup.GroupName;
                        tabPage.VerticalScrollbarSize = 4;
                        tabPage.HorizontalScrollbar = false;
                        tabPage.HorizontalScroll.Enabled = false;
                        tabPage.HorizontalScrollbarHighlightOnWheel = false;
                        tabPage.VerticalScrollbar = true;
                        tabPage.AutoScroll = true;
                        tabPage.Theme = this.metroStyleManager1.Theme;

                        tabPage.PagePanelDock<TaskForm>(list =>
                        {
                            List<DailyTask> dtl = new List<DailyTask>();
                            foreach (var ctl in list)
                            {
                                dtl.Add(ctl.DailyTask);
                            }
                            TaskManager.GetTaskGroup(tabPage.Name).DailyTasks = dtl;
                        });

                        metroTabControl1.TabPages.Add(tabPage);

                        foreach (var task in taskgroup.DailyTasks)
                        {
                            TaskForm form = new TaskForm(this, task);
                            form.Theme = this.metroStyleManager1.Theme;
                            form.Show();
                            tabPage.Controls.Add(form);
                            form.FormClosed += form_FormClosed;
                        }
                    }
                });
            lc.Parent = this;
            lc.Dock = DockStyle.Fill;
            this.Controls.Add(lc);
            this.Controls.SetChildIndex(lc, 0);
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = sender as TaskForm;
            if (TaskManager.MoveToDeletedGroup(form.DailyTask))
            {
                TaskForm taskform = new TaskForm(this, form.DailyTask);
                taskform.Show();
                this.metroTabControl1.TabPages[form.DailyTask.GroupId].Controls.Add(taskform);
                taskform.FormClosed += form_FormClosed;
                FileHelper.SaveJosn(TaskManager.ConvertJson());
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DailyTask dt = new DailyTask();
            using (TaskEditForm editForm = new TaskEditForm(dt))
            {
                if (editForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var group = this.metroTabControl1.SelectedTab.Tag as ITaskGroup;
                    if (TaskManager.AddTask(group, dt))
                    {
                        TaskForm form = new TaskForm(this, dt);
                        form.Show();
                        this.metroTabControl1.SelectedTab.Controls.Add(form);
                        this.metroTabControl1.SelectedTab.ScrollControlIntoView(form);
                        form.FormClosed += form_FormClosed;
                        FileHelper.SaveJosn(TaskManager.ConvertJson());
                    }
                }
            }
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            this.metroTabControl1.TabPages.Clear();
            LoadTasks();
        }
    }
}
