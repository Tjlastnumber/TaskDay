namespace MetroUI.Test
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroLink2 = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Size = new System.Drawing.Size(374, 511);
            this.metroTabControl1.TabIndex = 3;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroLink1
            // 
            this.metroLink1.Image = global::MetroUI.Test.Properties.Resources.Command_Reset;
            this.metroLink1.ImageSize = 32;
            this.metroLink1.Location = new System.Drawing.Point(268, 17);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(48, 48);
            this.metroLink1.TabIndex = 4;
            this.metroLink1.UseSelectable = true;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // metroLink2
            // 
            this.metroLink2.Location = new System.Drawing.Point(322, 31);
            this.metroLink2.Name = "metroLink2";
            this.metroLink2.Size = new System.Drawing.Size(75, 23);
            this.metroLink2.TabIndex = 5;
            this.metroLink2.Text = "添加任务";
            this.metroLink2.UseSelectable = true;
            this.metroLink2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 591);
            this.Controls.Add(this.metroLink2);
            this.Controls.Add(this.metroLink1);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "Form1";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "TaskDay";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroLink metroLink2;
    }
}

