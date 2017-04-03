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

namespace MetroUI.Test.Contorls
{
    public partial class TaskForm : MetroFramework.Forms.MetroForm
    {
        public TaskForm(Form mdiParent, string title, string content = "")
        {
            InitializeComponent();

            this.ControlBox = false;
            this.MdiParent = mdiParent;
            this.Text = title;
            this.metroLabel1.Text = content;
            this.LocationChanged += TaskForm_LocationChanged;
        }

        void TaskForm_LocationChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(this.Location.ToString());
        }
    }
}
