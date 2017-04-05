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
using TaskDay.Model;

namespace MetroUI.Test.Contorls
{
    public partial class TaskForm : MetroFramework.Forms.MetroForm
    {
        private DailyTask _dailyTask;

        public TaskForm(Form mdiParent, DailyTask dt)
        {
            InitializeComponent();

            this.ControlBox = false;
            this.MdiParent = mdiParent;

            this.LocationChanged += TaskForm_LocationChanged;
            this.Click += TaskForm_Click;

            this.Text = dt.Title;
            this.metroLabel1.Text = dt.Content;
            this._dailyTask = dt;
        }

        void TaskForm_Click(object sender, EventArgs e)
        {
            TaskEditForm form = new TaskEditForm(_dailyTask);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
        }

        void TaskForm_LocationChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(this.Location.ToString());
            Debug.WriteLine(this.metroLabel1.Text);
        }
    }
}
