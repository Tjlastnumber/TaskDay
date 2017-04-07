using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskDay.Winform.Controls
{
    public partial class TaskItemTextBox : UserControl
    {
        public TaskItemTextBox()
        {
            InitializeComponent();

            this.metroLabel1.MouseDown += metroTextBox1_MouseClick;
            this.metroLabel1.MouseMove += metroLabel1_MouseMove;
            this.metroLabel1.MouseUp += metroLabel1_MouseUp;
        }

        void metroLabel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            this.OnMouseUp(e);
        }

        void metroLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        void metroTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Capture = true;
            this.OnMouseDown(e);
        }
    }
}
