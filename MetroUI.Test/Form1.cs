using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroUI.Test.Contorls;
using TaskDay.Core;

namespace MetroUI.Test
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.panel1.ControlAdded += metroPanel1_ControlAdded;

            TestModel tm = new TestModel();
            foreach (var group in TaskManager.GetTaskGroups())
            {
                foreach (var task in group.DailyTasks)
                {
                    TaskForm form = new TaskForm(this, task.Title);
                    form.Show();
                    this.panel1.Controls.Add(form);
                    form.Dock = DockStyle.Top;
                }
            }
        }

        void metroPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
        }
    }
}
