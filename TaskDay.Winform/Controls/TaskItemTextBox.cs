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
        public string ContentText { set { this.txt_Content.Text = value; } get { return this.txt_Content.Text; } }

        public TaskItemTextBox()
        {
            InitializeComponent();

            this.metroLink1.MouseDown += metroTextBox1_MouseClick;
            this.metroLink1.MouseMove += metroLabel1_MouseMove;
            this.metroLink1.MouseUp += metroLabel1_MouseUp;
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
