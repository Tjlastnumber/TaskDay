﻿namespace TaskDay.Winform
{
    partial class TaskEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_Title = new MetroFramework.Controls.MetroTextBox();
            this.link_Ok = new MetroFramework.Controls.MetroLink();
            this.contentPanel = new MetroFramework.Controls.MetroPanel();
            this.link_Add = new MetroFramework.Controls.MetroLink();
            this.cb_TaskColor = new MetroFramework.Controls.MetroComboBox();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Title
            // 
            // 
            // 
            // 
            this.txt_Title.CustomButton.Image = null;
            this.txt_Title.CustomButton.Location = new System.Drawing.Point(154, 1);
            this.txt_Title.CustomButton.Name = "";
            this.txt_Title.CustomButton.Size = new System.Drawing.Size(37, 37);
            this.txt_Title.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_Title.CustomButton.TabIndex = 1;
            this.txt_Title.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_Title.CustomButton.UseSelectable = true;
            this.txt_Title.CustomButton.Visible = false;
            this.txt_Title.DisplayIcon = true;
            this.txt_Title.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txt_Title.Lines = new string[0];
            this.txt_Title.Location = new System.Drawing.Point(23, 96);
            this.txt_Title.MaxLength = 32767;
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.PasswordChar = '\0';
            this.txt_Title.PromptText = "标题...";
            this.txt_Title.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Title.SelectedText = "";
            this.txt_Title.SelectionLength = 0;
            this.txt_Title.SelectionStart = 0;
            this.txt_Title.ShortcutsEnabled = true;
            this.txt_Title.ShowClearButton = true;
            this.txt_Title.Size = new System.Drawing.Size(192, 39);
            this.txt_Title.TabIndex = 0;
            this.txt_Title.UseSelectable = true;
            this.txt_Title.UseStyleColors = true;
            this.txt_Title.WaterMark = "标题...";
            this.txt_Title.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Title.WaterMarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // link_Ok
            // 
            this.link_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.link_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.link_Ok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.link_Ok.Location = new System.Drawing.Point(562, 384);
            this.link_Ok.Name = "link_Ok";
            this.link_Ok.Size = new System.Drawing.Size(75, 37);
            this.link_Ok.TabIndex = 2;
            this.link_Ok.Text = "完成";
            this.link_Ok.UseSelectable = true;
            this.link_Ok.UseStyleColors = true;
            this.link_Ok.Click += new System.EventHandler(this.link_Ok_Click);
            // 
            // metroPanel1
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.AutoScroll = true;
            this.contentPanel.HorizontalScrollbar = true;
            this.contentPanel.HorizontalScrollbarBarColor = false;
            this.contentPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.contentPanel.HorizontalScrollbarSize = 8;
            this.contentPanel.Location = new System.Drawing.Point(23, 141);
            this.contentPanel.Name = "metroPanel1";
            this.contentPanel.Size = new System.Drawing.Size(614, 237);
            this.contentPanel.TabIndex = 3;
            this.contentPanel.UseStyleColors = true;
            this.contentPanel.VerticalScrollbar = true;
            this.contentPanel.VerticalScrollbarBarColor = true;
            this.contentPanel.VerticalScrollbarHighlightOnWheel = false;
            this.contentPanel.VerticalScrollbarSize = 8;
            // 
            // link_Add
            // 
            this.link_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.link_Add.Location = new System.Drawing.Point(562, 112);
            this.link_Add.Name = "link_Add";
            this.link_Add.Size = new System.Drawing.Size(75, 23);
            this.link_Add.TabIndex = 4;
            this.link_Add.Text = "添加";
            this.link_Add.UseSelectable = true;
            this.link_Add.UseStyleColors = true;
            this.link_Add.Click += new System.EventHandler(this.link_Add_Click);
            // 
            // metroComboBox1
            // 
            this.cb_TaskColor.FormattingEnabled = true;
            this.cb_TaskColor.ItemHeight = 23;
            this.cb_TaskColor.Location = new System.Drawing.Point(23, 33);
            this.cb_TaskColor.Name = "metroComboBox1";
            this.cb_TaskColor.PromptText = "设置颜色";
            this.cb_TaskColor.Size = new System.Drawing.Size(192, 29);
            this.cb_TaskColor.TabIndex = 5;
            this.cb_TaskColor.UseSelectable = true;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager.Owner = this;
            // 
            // TaskEditForm
            // 
            this.AcceptButton = this.link_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 430);
            this.Controls.Add(this.cb_TaskColor);
            this.Controls.Add(this.link_Add);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.link_Ok);
            this.Controls.Add(this.txt_Title);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskEditForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "TaskEditForm";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txt_Title;
        private MetroFramework.Controls.MetroLink link_Ok;
        private MetroFramework.Controls.MetroPanel contentPanel;
        private MetroFramework.Controls.MetroLink link_Add;
        private MetroFramework.Controls.MetroComboBox cb_TaskColor;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;

    }
}