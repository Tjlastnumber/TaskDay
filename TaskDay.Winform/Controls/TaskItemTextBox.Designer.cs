namespace TaskDay.Winform.Controls
{
    partial class TaskItemTextBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.txt_Content = new MetroFramework.Controls.MetroTextBox();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.txt_Content);
            this.metroPanel1.Controls.Add(this.metroLink1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 6;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(232, 27);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 8;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.txt_Content.CustomButton.Image = null;
            this.txt_Content.CustomButton.Location = new System.Drawing.Point(209, 1);
            this.txt_Content.CustomButton.Name = "";
            this.txt_Content.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txt_Content.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_Content.CustomButton.TabIndex = 1;
            this.txt_Content.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_Content.CustomButton.UseSelectable = true;
            this.txt_Content.CustomButton.Visible = false;
            this.txt_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Content.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txt_Content.Lines = new string[0];
            this.txt_Content.Location = new System.Drawing.Point(30, 0);
            this.txt_Content.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Content.MaxLength = 32767;
            this.txt_Content.Name = "metroTextBox1";
            this.txt_Content.PasswordChar = '\0';
            this.txt_Content.PromptText = "内容";
            this.txt_Content.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Content.SelectedText = "";
            this.txt_Content.SelectionLength = 0;
            this.txt_Content.SelectionStart = 0;
            this.txt_Content.ShortcutsEnabled = true;
            this.txt_Content.Size = new System.Drawing.Size(202, 27);
            this.txt_Content.TabIndex = 2;
            this.txt_Content.UseSelectable = true;
            this.txt_Content.WaterMark = "内容";
            this.txt_Content.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Content.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLink1
            // 
            this.metroLink1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.metroLink1.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroLink1.Image = global::TaskDay.Winform.Properties.Resources.Bullets;
            this.metroLink1.ImageSize = 32;
            this.metroLink1.Location = new System.Drawing.Point(0, 0);
            this.metroLink1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(30, 27);
            this.metroLink1.TabIndex = 3;
            this.metroLink1.UseSelectable = true;
            // 
            // TaskItemTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 9F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TaskItemTextBox";
            this.Size = new System.Drawing.Size(232, 27);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox txt_Content;
        private MetroFramework.Controls.MetroLink metroLink1;
    }
}
