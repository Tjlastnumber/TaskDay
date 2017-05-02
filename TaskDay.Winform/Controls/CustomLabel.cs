using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaskDay.Winform.Controls
{
    public partial class CustomLabel : MetroFramework.Controls.MetroLabel
    {
        private bool _strikout;
        [Description("划掉内容")]
        [DefaultValue(false)]
        public bool Strikeout
        {
            get
            {
                return _strikout;
            }
            set
            {
                _strikout = value;
            }
        }

        public CustomLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Strikeout)
            {
                Point p1 = new Point(0, this.ClientSize.Height / 2);
                Point p2 = new Point(this.ClientSize.Width, this.ClientSize.Height / 2);
                e.Graphics.DrawLine(new Pen(Color.Black), p1, p2);
            }
        }
    }
}
