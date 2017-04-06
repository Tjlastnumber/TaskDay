using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroUI.Test.Contorls;
using System.IO;
using TaskDay.Core;
using TaskDay.Model;
using TaskDay.GeneralLibrary;

namespace MetroUI.Test
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var rj = FileHelper.ReadJosn<List<CustomTasks>>();
            if (rj != null)
            {
                List<ITaskGroup> group = rj.ToList<ITaskGroup>();
                TaskManager.Load(group);
            }
            foreach (var taskgroup in TaskManager.GetTaskGroups())
            {
                MetroFramework.Controls.MetroTabPage tabPage = new MetroFramework.Controls.MetroTabPage();
                tabPage.Name = taskgroup.GroupId;
                tabPage.Tag = taskgroup;
                tabPage.Text = taskgroup.GroupName;
                tabPage.HorizontalScrollbar = false;
                tabPage.HorizontalScroll.Enabled = false;
                tabPage.HorizontalScrollbarHighlightOnWheel = false;
                tabPage.VerticalScrollbar = true;
                tabPage.AutoScroll = true;
                metroTabControl1.TabPages.Add(tabPage);

                foreach (var task in taskgroup.DailyTasks)
                {
                    TaskForm form = new TaskForm(this, task);
                    form.Show();
                    tabPage.Controls.Add(form);
                    form.Dock = DockStyle.Top;
                    var location = new Point(form.Location.X, tabPage.Controls.OfType<TaskForm>().Sum(p => p.Height) - form.Height);
                    form.Dock = DockStyle.None;
                    form.Location = location;
                    form.FormClosed += form_FormClosed;
                }
            }
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = sender as TaskForm;
            if (TaskManager.MoveToDeletedGroup(form.DailyTask))
            {
                TaskForm taskform = new TaskForm(this, form.DailyTask);
                this.metroTabControl1.TabPages[DeletedTasks.GUID].Controls.Add(taskform);
                taskform.Show();
                taskform.Dock = DockStyle.Top;
                var location = new Point(taskform.Location.X, this.metroTabControl1.SelectedTab.Controls.OfType<TaskForm>().Sum(p => p.Height) - taskform.Height);
                taskform.Dock = DockStyle.None;
                taskform.Location = location;
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
                        this.metroTabControl1.SelectedTab.Controls.Add(form);
                        form.Show();
                        form.Dock = DockStyle.Top;
                        var location = new Point(form.Location.X, this.metroTabControl1.SelectedTab.Controls.OfType<TaskForm>().Sum(p => p.Height) - form.Height);
                        form.Dock = DockStyle.None;
                        form.Location = location;
                        form.FormClosed += form_FormClosed;
                        FileHelper.SaveJosn(TaskManager.ConvertJson());
                    }
                }
            }
        }
    }
}
