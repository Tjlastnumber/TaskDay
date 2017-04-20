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
using TaskDay.Core.Common;
using MetroFramework;
using MetroFramework.Components;
using TaskDay.Core.ViewModel;
using MetroFramework.Controls;

namespace TaskDay.Winform
{
    public partial class TaskEditForm : MetroFramework.Forms.MetroForm
    {
        public MetroStyleManager GlobalStyleManager
        {
            get { return this.metroStyleManager; }
            set
            {
                this.metroStyleManager = (MetroStyleManager)value.Clone(this);
            }
        }

        private DailyTask _dailyTask;
        private TextBox _txt_binding;
        private List<TaskItemTextBox> _contentList = new List<TaskItemTextBox>();

        public TaskEditForm(DailyTask dt)
        {
            this._txt_binding = new TextBox();
            this._txt_binding.Name = "_txt_binding";
            this._txt_binding.Width = 0;
            this._txt_binding.Height = 0;
            this.Controls.Add(this._txt_binding);

            _dailyTask = dt;

            InitializeComponent();

            this.StyleManager = this.metroStyleManager;

            this.contentPanel.PagePanelDock<TaskItemTextBox>(list =>
            {
                _contentList = list.ToList();
            });
            this.contentPanel.ControlAdded += (s, e) => this.metroStyleManager.Update();

            this._txt_binding.DataBindings.Add("Text", _dailyTask, "Content", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txt_Title.DataBindings.Add("Text", _dailyTask, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            BindingInterval().DataBindings.Add("SelectedValue", _dailyTask, "TaskNotifyInterval", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Text = _dailyTask.Title;

            if (this._dailyTask.Content != null)
            {
                foreach (String item in this._dailyTask.Content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var titb = new TaskItemTextBox();
                    titb.DeleteEvent += titb_DeleteEvent;
                    titb.ContentDataBindings("Text", item, "");
                    this.contentPanel.Controls.Add(titb);
                    _contentList.Add(titb);
                }

                this.metroStyleManager.Update();
            }

            base.OnLoad(e);
        }

        private MetroComboBox BindingInterval()
        {
            this.metroComboBox1.DataSource = new NotifyIntervalViewModel().NotifyIntervals;
            this.metroComboBox1.DisplayMember = "IntervalText";
            this.metroComboBox1.ValueMember = "ItervalTimeSpan";
            this.metroComboBox1.SelectedItem = null;
            return this.metroComboBox1;
        }

        void titb_DeleteEvent(object sender, EventArgs e)
        {
            var titb = sender as TaskItemTextBox;
            this.contentPanel.Controls.Remove(titb);
            this._contentList.Remove(titb);
            titb = null;
        }

        private void link_Add_Click(object sender, EventArgs e)
        {
            var titb = new TaskItemTextBox();
            titb.DeleteEvent += titb_DeleteEvent;
            this.contentPanel.Controls.Add(titb);
            this._contentList.Add(titb);
            this.Focus();

            this.metroStyleManager.Update();
        }

        private void link_Ok_Click(object sender, EventArgs e)
        {
            string content = string.Empty;
            foreach (TaskItemTextBox item in _contentList)
            {
                if (!item.ContentText.IsNullOrWhiteSpace())
                {
                    content += item.ContentText + "\r\n";
                }
            }
            this._txt_binding.Text = content;

            if (this.metroComboBox1.SelectedItem != null)
            {
                this._dailyTask.TaskNotifyInterval = (TimeSpan)this.metroComboBox1.SelectedValue;
            }
        }
    }
}
