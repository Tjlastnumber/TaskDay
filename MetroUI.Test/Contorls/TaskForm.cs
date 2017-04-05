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
        public DailyTask DailyTask { get; private set; }

        public TaskForm(Form mdiParent, DailyTask dt)
        {
            InitializeComponent();

            this.ControlBox = false;
            this.MdiParent = mdiParent;

            //this.LocationChanged += TaskForm_LocationChanged;
            this.Click += TaskForm_Click;

            this.DailyTask = dt;
            this.lb_Title.DataBindings.Add("Text", DailyTask, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            this.metroLabel1.DataBindings.Add("Text", DailyTask, "Content", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        void TaskForm_Click(object sender, EventArgs e)
        {
            TaskEditForm form = new TaskEditForm(DailyTask);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
        }

        void TaskForm_LocationChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(this.Location.ToString());
            Debug.WriteLine(this.metroLabel1.Text);
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
    }
}
