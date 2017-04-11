using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;

namespace TaskDay.Winform.Controls
{
    public partial class TaskItemTextBox : UserControl
    {
        //public MetroStyleManager StyleManager
        //{
        //    get { return this.metroStyleManager; }
        //    set
        //    {
        //        this.metroStyleManager = value; 
        //    }
        //}

        public event EventHandler DeleteEvent;

        public string ContentText
        {
            set { this.txt_Content.Text = value; }
            get { return this.txt_Content.Text; }
        }

        public void ContentDataBindings(string propertyName, object dataSource, string dataMember)
        {
            this.txt_Content.DataBindings.Add(propertyName, dataSource, dataMember);
        }

        public TaskItemTextBox()
        {
            InitializeComponent();

            this.metroLink1.MouseDown += metroTextBox1_MouseClick;
            this.metroLink1.MouseMove += metroLabel1_MouseMove;
            this.metroLink1.MouseUp += metroLabel1_MouseUp;

            this.txt_Content.ButtonClick += txt_Content_ButtonClick;
        }

        void txt_Content_ButtonClick(object sender, EventArgs e)
        {
            if (DeleteEvent != null)
            {
                DeleteEvent(this, e);
            }
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
