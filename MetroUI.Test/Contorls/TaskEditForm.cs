using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskDay.Model;

namespace MetroUI.Test.Contorls
{
    public partial class TaskEditForm : MetroFramework.Forms.MetroForm
    {
        private DailyTask _dailyTask;

        public TaskEditForm(DailyTask dt)
        {
            InitializeComponent();

            _dailyTask = dt;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Text = _dailyTask.Title;
            this.txt_Title.Text = _dailyTask.Title;
            //this.txt_Content.Lines = _dailyTask.Content.Split(new string[] { @"\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            this.txt_Content.Text = _dailyTask.Content;
            base.OnLoad(e);
        }
    }
}
