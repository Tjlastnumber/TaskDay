﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskDay.GeneralLibrary;
using TaskDay.Model;

namespace MetroUI.Test.Contorls
{
    public partial class TaskForm : MetroFramework.Forms.MetroForm
    {

        private bool _isClick = false;

        public DailyTask DailyTask { get; private set; }

        public TaskForm(Form mdiParent, DailyTask dt)
        {
            InitializeComponent();

            this.ControlBox = false;
            this.MdiParent = mdiParent;

            this.MouseDown += TaskForm_MouseDown;
            this.MouseMove += TaskForm_MouseMove;
            this.MouseUp += TaskForm_MouseUp;
            this.DailyTask = dt;
            try
            {
                this.lb_Title.DataBindings.Add("Text", DailyTask, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
                this.lb_Date.DataBindings.Add("Text", DailyTask, "Date", true, DataSourceUpdateMode.OnPropertyChanged);
                this.metroLabel1.DataBindings.Add("Text", DailyTask.TaskItems, "Content", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex)
            {
            }
        }

        void TaskForm_MouseDown(object sender, MouseEventArgs e)
        {
            _isClick = true;
        }

        void TaskForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isClick)
            {
                TaskEditForm form = new TaskEditForm(DailyTask);
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                }
            }
        }

        void TaskForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Capture)
            {
                _isClick = false;
            }
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            this.metroLink1.ContextMenuStrip.Show(this.metroLink1, new Point(0, 0));
        }

        private void metroLink1_MouseClick(object sender, MouseEventArgs e)
        {
            this.metroLink1.ContextMenuStrip.Show(this.metroLink1, e.Location);
        }

        private void cm_Delete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
