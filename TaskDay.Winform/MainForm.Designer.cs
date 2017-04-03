namespace TaskDay.Winform
{
    partial class MainForm
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
            this.addTab = new MetroFramework.Controls.MetroLink();
            this.btn_Menu = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // addTab
            // 
            this.addTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addTab.Location = new System.Drawing.Point(384, 31);
            this.addTab.Name = "addTab";
            this.addTab.Size = new System.Drawing.Size(108, 23);
            this.addTab.TabIndex = 1;
            this.addTab.Text = "添加标签";
            this.addTab.UseSelectable = true;
            // 
            // btn_Menu
            // 
            this.btn_Menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Menu.Image = global::TaskDay.Winform.Properties.Resources.Hamburg;
            this.btn_Menu.ImageSize = 32;
            this.btn_Menu.Location = new System.Drawing.Point(8, 18);
            this.btn_Menu.Name = "btn_Menu";
            this.btn_Menu.Size = new System.Drawing.Size(44, 36);
            this.btn_Menu.TabIndex = 2;
            this.btn_Menu.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(500, 571);
            this.Controls.Add(this.btn_Menu);
            this.Controls.Add(this.addTab);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 10000);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(8, 60, 8, 8);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "    每日任务";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLink addTab;
        private MetroFramework.Controls.MetroLink btn_Menu;





    }
}

