using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroUI.Test.Contorls
{
    public partial class LoadControl : UserControl
    {
        public LoadControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (this.Parent != null)
            {
                var x = (int)((this.Parent.Width - this.Width) / 2);
                var y = (int)((this.Parent.Height - this.Height) / 2);
                this.Location = new Point(x, y);
            }
            base.OnLoad(e);
        }
    }
}
