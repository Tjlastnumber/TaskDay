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
        private TextBox _txt_binding;

        public TaskEditForm(DailyTask dt)
        {
            this._txt_binding = new TextBox();
            this._txt_binding.Name = "_txt_binding";
            this._txt_binding.Width = 0;
            this._txt_binding.Height = 0;
            this.Controls.Add(this._txt_binding);

            _dailyTask = dt;

            InitializeComponent();


            this._txt_binding.DataBindings.Add("Text", _dailyTask, "Content", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txt_Title.DataBindings.Add("Text", _dailyTask, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            this.metroPanel1.PagePanelDock<TaskItemTextBox>(list =>
            {
                string content = string.Empty;
                foreach (TaskItemTextBox item in list)
                {
                    if (!string.IsNullOrWhiteSpace(item.ContentText))
                    {
                        content += item.ContentText + "\r\n";
                    }
                }
                this._txt_binding.Text = content;
            });
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Text = _dailyTask.Title;

            if (this._dailyTask.Content != null)
            {
                foreach (String item in this._dailyTask.Content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var titb = new TaskItemTextBox();
                    titb.DeleteEvent += (s, eve) => this.metroPanel1.Controls.Remove(titb);
                    titb.ContentDataBindings("Text", item, "");
                    this.metroPanel1.Controls.Add(titb);
                }
            }

            base.OnLoad(e);
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            this.metroPanel1.Controls.Add(new TaskItemTextBox());
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
        }
    }
}
