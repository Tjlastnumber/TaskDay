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
            this.components = new System.ComponentModel.Container();
            this.addTab = new MetroFramework.Controls.MetroLink();
            this.metroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cb_SelectStyle = new MetroFramework.Controls.MetroComboBox();
            this.cb_SelectTheme = new MetroFramework.Controls.MetroComboBox();
            this.link_Refresh = new MetroFramework.Controls.MetroLink();
            this.link_Set = new MetroFramework.Controls.MetroLink();
            this.metroToolTip = new MetroFramework.Components.MetroToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroPanel1.SuspendLayout();
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
            this.addTab.UseStyleColors = true;
            this.addTab.Click += new System.EventHandler(this.addTab_Click);
            // 
            // metroTabControl
            // 
            this.metroTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl.Location = new System.Drawing.Point(8, 60);
            this.metroTabControl.Name = "metroTabControl";
            this.metroTabControl.Size = new System.Drawing.Size(484, 510);
            this.metroTabControl.TabIndex = 3;
            this.metroTabControl.UseSelectable = true;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.cb_SelectStyle);
            this.metroPanel1.Controls.Add(this.cb_SelectTheme);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(8, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(0, 510);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 3);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "主题设置";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 59);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "样式设置";
            // 
            // cb_SelectStyle
            // 
            this.cb_SelectStyle.FormattingEnabled = true;
            this.cb_SelectStyle.ItemHeight = 23;
            this.cb_SelectStyle.Location = new System.Drawing.Point(3, 78);
            this.cb_SelectStyle.Name = "cb_SelectStyle";
            this.cb_SelectStyle.Size = new System.Drawing.Size(194, 29);
            this.cb_SelectStyle.TabIndex = 3;
            this.cb_SelectStyle.UseSelectable = true;
            // 
            // cb_SelectTheme
            // 
            this.cb_SelectTheme.FormattingEnabled = true;
            this.cb_SelectTheme.ItemHeight = 23;
            this.cb_SelectTheme.Location = new System.Drawing.Point(3, 23);
            this.cb_SelectTheme.Name = "cb_SelectTheme";
            this.cb_SelectTheme.Size = new System.Drawing.Size(194, 29);
            this.cb_SelectTheme.TabIndex = 2;
            this.cb_SelectTheme.UseSelectable = true;
            // 
            // link_Refresh
            // 
            this.link_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.link_Refresh.Image = global::TaskDay.Winform.Properties.Resources.Command_Reset;
            this.link_Refresh.ImageSize = 32;
            this.link_Refresh.Location = new System.Drawing.Point(348, 29);
            this.link_Refresh.Name = "link_Refresh";
            this.link_Refresh.Size = new System.Drawing.Size(48, 23);
            this.link_Refresh.TabIndex = 6;
            this.metroToolTip.SetToolTip(this.link_Refresh, "刷新");
            this.link_Refresh.UseSelectable = true;
            this.link_Refresh.UseStyleColors = true;
            this.link_Refresh.Click += new System.EventHandler(this.link_Refresh_Click);
            // 
            // link_Set
            // 
            this.link_Set.Image = global::TaskDay.Winform.Properties.Resources.Hamburg;
            this.link_Set.ImageSize = 32;
            this.link_Set.Location = new System.Drawing.Point(11, 25);
            this.link_Set.Name = "link_Set";
            this.link_Set.Size = new System.Drawing.Size(40, 23);
            this.link_Set.TabIndex = 4;
            this.link_Set.UseSelectable = true;
            this.link_Set.UseStyleColors = true;
            this.link_Set.Click += new System.EventHandler(this.link_Set_Click);
            // 
            // metroToolTip
            // 
            this.metroToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip.StyleManager = null;
            this.metroToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(500, 578);
            this.Controls.Add(this.link_Refresh);
            this.Controls.Add(this.link_Set);
            this.Controls.Add(this.metroTabControl);
            this.Controls.Add(this.addTab);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainForm";
            this.Opacity = 0.8D;
            this.Padding = new System.Windows.Forms.Padding(8, 60, 8, 8);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "    每日任务";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLink addTab;
        private MetroFramework.Controls.MetroTabControl metroTabControl;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroLink link_Set;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroComboBox cb_SelectTheme;
        private MetroFramework.Controls.MetroComboBox cb_SelectStyle;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLink link_Refresh;
        private MetroFramework.Components.MetroToolTip metroToolTip;





    }
}

