namespace MetroUI.Test.Contorls
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
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLink2 = new MetroFramework.Controls.MetroLink();
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
            this.txt_Title.Location = new System.Drawing.Point(23, 33);
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
            this.txt_Title.WaterMark = "标题...";
            this.txt_Title.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Title.WaterMarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLink1
            // 
            this.metroLink1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLink1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.metroLink1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.metroLink1.Location = new System.Drawing.Point(332, 286);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(75, 37);
            this.metroLink1.TabIndex = 2;
            this.metroLink1.Text = "完成";
            this.metroLink1.UseSelectable = true;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.HorizontalScrollbarBarColor = false;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 8;
            this.metroPanel1.Location = new System.Drawing.Point(23, 78);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(384, 202);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 8;
            // 
            // metroLink2
            // 
            this.metroLink2.Location = new System.Drawing.Point(332, 49);
            this.metroLink2.Name = "metroLink2";
            this.metroLink2.Size = new System.Drawing.Size(75, 23);
            this.metroLink2.TabIndex = 4;
            this.metroLink2.Text = "添加";
            this.metroLink2.UseSelectable = true;
            this.metroLink2.Click += new System.EventHandler(this.metroLink2_Click);
            // 
            // TaskEditForm
            // 
            this.AcceptButton = this.metroLink1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 332);
            this.Controls.Add(this.metroLink2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroLink1);
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
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLink metroLink2;

    }
}