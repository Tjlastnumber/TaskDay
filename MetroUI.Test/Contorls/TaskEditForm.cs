using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskDay.Winform.Common;
using TaskDay.Winform.Controls;
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
            this.txt_Title.DataBindings.Add("Text", _dailyTask, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txt_Content.DataBindings.Add("Text", _dailyTask, "Content", true, DataSourceUpdateMode.OnPropertyChanged);
            this.metroPanel1.TabPagePanelDock<TaskItemTextBox>(() => { });

            base.OnLoad(e);
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            this.metroPanel1.Controls.Add(new TaskItemTextBox());
        }
    }
}
