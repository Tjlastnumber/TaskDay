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

namespace MetroUI.Test
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DailyTask dt = new DailyTask();
            using (TaskEditForm editForm = new TaskEditForm(dt))
            {
                if (editForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    TaskForm form = new TaskForm(this, dt);
                    form.Show();
                    this.panel1.Controls.Add(form);
                    form.Dock = DockStyle.Top;
                    var location = new Point(form.Location.X, this.panel1.Controls.OfType<TaskForm>().Sum(p => p.Height) - form.Height);
                    form.Dock = DockStyle.None;
                    form.Location = location;
                    form.FormClosed += (s, a) =>
                    {
                        TaskManager.RemoveTask(form.DailyTask);
                    };
                }
            }
        }
    }
}
