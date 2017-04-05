﻿namespace MetroUI.Test.Contorls
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
            this.txt_Title = new MetroFramework.Controls.MetroTextBox();
            this.txt_Content = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // txt_Title
            // 
            // 
            // 
            // 
            this.txt_Title.CustomButton.Image = null;
            this.txt_Title.CustomButton.Location = new System.Drawing.Point(131, 1);
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
            this.txt_Title.Location = new System.Drawing.Point(23, 33);
            this.txt_Title.MaxLength = 32767;
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.PasswordChar = '\0';
            this.txt_Title.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Title.SelectedText = "";
            this.txt_Title.SelectionLength = 0;
            this.txt_Title.SelectionStart = 0;
            this.txt_Title.ShortcutsEnabled = true;
            this.txt_Title.ShowClearButton = true;
            this.txt_Title.Size = new System.Drawing.Size(169, 39);
            this.txt_Title.TabIndex = 0;
            this.txt_Title.UseSelectable = true;
            this.txt_Title.WaterMark = "标题...";
            this.txt_Title.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Title.WaterMarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txt_Content
            // 
            this.txt_Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txt_Content.CustomButton.Image = null;
            this.txt_Content.CustomButton.Location = new System.Drawing.Point(139, 2);
            this.txt_Content.CustomButton.Name = "";
            this.txt_Content.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txt_Content.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_Content.CustomButton.TabIndex = 1;
            this.txt_Content.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_Content.CustomButton.UseSelectable = true;
            this.txt_Content.CustomButton.Visible = false;
            this.txt_Content.DisplayIcon = true;
            this.txt_Content.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txt_Content.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.txt_Content.Lines = new string[0];
            this.txt_Content.Location = new System.Drawing.Point(23, 78);
            this.txt_Content.MaxLength = 32767;
            this.txt_Content.Multiline = true;
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.PasswordChar = '\0';
            this.txt_Content.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Content.SelectedText = "";
            this.txt_Content.SelectionLength = 0;
            this.txt_Content.SelectionStart = 0;
            this.txt_Content.ShortcutsEnabled = true;
            this.txt_Content.ShowClearButton = true;
            this.txt_Content.Size = new System.Drawing.Size(358, 131);
            this.txt_Content.TabIndex = 1;
            this.txt_Content.UseSelectable = true;
            this.txt_Content.WaterMark = "内容...";
            this.txt_Content.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Content.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TaskEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 232);
            this.Controls.Add(this.txt_Content);
            this.Controls.Add(this.txt_Title);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskEditForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.Text = "TaskEditForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txt_Title;
        private MetroFramework.Controls.MetroTextBox txt_Content;

    }
}