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
        Action _worker;
        Action _endCallBack;

        public LoadControl(Action worker, Action endCallBack)
        {
            InitializeComponent();

            this.SizeChanged += LoadControl_SizeChanged;

            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            _worker = worker;
            _endCallBack = endCallBack;
        }

        void LoadControl_SizeChanged(object sender, EventArgs e)
        {
            if (this.metroProgressSpinner1.Parent != null)
            {
                var x = (this.metroPanel1.Width - this.metroProgressSpinner1.Width) / 2;
                var y = (this.metroPanel1.Height - this.metroProgressSpinner1.Height) / 2;
                this.metroProgressSpinner1.Location = new Point(x, y);
            }
        }

        async protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            await Task.Factory.StartNew(_worker).ContinueWith(
                t =>
                {
                    if (_endCallBack != null)
                    {
                        _endCallBack();
                    }
                    this.Parent.Controls.Remove(this);
                },
                TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
