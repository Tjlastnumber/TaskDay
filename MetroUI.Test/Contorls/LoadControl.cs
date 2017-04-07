using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MetroUI.Test.Contorls
{
    public partial class LoadControl : UserControl
    {
        Action _worker;
        Action _endCallBack;
        public LoadControl()
        {
            InitializeComponent();
        }

        public LoadControl(Action worker, Action endCallBack)
        {
            InitializeComponent();

            this.Paint += LoadControl_Paint;

            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            _worker = worker;
            _endCallBack = endCallBack;
        }

        void LoadControl_Paint(object sender, PaintEventArgs e)
        {
            if (this.Parent != null)
            {
                var x = (this.metroPanel1.Width - this.metroProgressSpinner1.Width) / 2;
                var y = (this.metroPanel1.Height - this.metroProgressSpinner1.Height) / 2;
                this.metroProgressSpinner1.Location = new Point(x, y);
            }
        }

        async protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            await Task.Factory.StartNew(() => { _worker(); Thread.Sleep(2000); }).ContinueWith(
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
