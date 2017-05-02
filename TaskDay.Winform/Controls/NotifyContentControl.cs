using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace TaskDay.Winform.Controls
{
    public partial class NotifyContentControl : MetroFramework.Controls.MetroUserControl
    {
        public NotifyContentControl()
        {
            InitializeComponent();

            //var color = typeof(MetroColors).GetProperties().SingleOrDefault(p => p.Name == this.StyleManager.Theme.ToString());
            //if (color != null)
            //{
            //    var color_value = color.GetValue(typeof(MetroColors));

            //    this.richTextBox1.BackColor = (Color)color_value;
            //}
        }


        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var color = typeof(MetroColors).GetProperties().SingleOrDefault(p => p.Name == this.StyleManager.Theme.ToString());
            if (color != null)
            {
                var color_value = color.GetValue(typeof(MetroColors));

                this.richTextBox1.BackColor = (Color)color_value;
            }
        }
    }
}
