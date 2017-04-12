namespace TaskDay.Winform
{
    partial class TaskForm
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
            this.lb_Title = new MetroFramework.Controls.MetroLabel();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.cm_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_Date = new MetroFramework.Controls.MetroLabel();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroContextMenu1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Title
            // 
            this.lb_Title.AutoSize = true;
            this.lb_Title.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lb_Title.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lb_Title.LabelMode = MetroFramework.Controls.MetroLabelMode.Selectable;
            this.lb_Title.Location = new System.Drawing.Point(23, 20);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(81, 25);
            this.lb_Title.TabIndex = 1;
            this.lb_Title.Text = "TaskTitile";
            this.lb_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Title.UseStyleColors = true;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroContextMenu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cm_Delete});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(101, 26);
            // 
            // cm_Delete
            // 
            this.cm_Delete.Name = "cm_Delete";
            this.cm_Delete.Size = new System.Drawing.Size(100, 22);
            this.cm_Delete.Text = "删除";
            this.cm_Delete.Click += new System.EventHandler(this.cm_Delete_Click);
            // 
            // lb_Date
            // 
            this.lb_Date.AutoSize = true;
            this.lb_Date.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_Date.LabelMode = MetroFramework.Controls.MetroLabelMode.Selectable;
            this.lb_Date.Location = new System.Drawing.Point(107, 8);
            this.lb_Date.Name = "lb_Date";
            this.lb_Date.Size = new System.Drawing.Size(36, 19);
            this.lb_Date.TabIndex = 3;
            this.lb_Date.Text = "Date";
            this.lb_Date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLink1
            // 
            this.metroLink1.ContextMenuStrip = this.metroContextMenu1;
            this.metroLink1.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroLink1.Image = global::TaskDay.Winform.Properties.Resources.Hamburg;
            this.metroLink1.ImageSize = 32;
            this.metroLink1.Location = new System.Drawing.Point(151, 0);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(50, 39);
            this.metroLink1.TabIndex = 2;
            this.metroLink1.UseSelectable = true;
            this.metroLink1.UseStyleColors = true;
            this.metroLink1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.metroLink1_MouseClick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 62);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(28, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "123";
            this.metroLabel1.WrapToLine = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Controls.Add(this.metroLink1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(176, 15);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(201, 39);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.lb_Date);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Padding = new System.Windows.Forms.Padding(8);
            this.metroPanel2.Size = new System.Drawing.Size(151, 39);
            this.metroPanel2.TabIndex = 4;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(388, 165);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lb_Title);
            this.Controls.Add(this.metroPanel1);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "TaskForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "TaskForm";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.metroContextMenu1.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lb_Title;
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem cm_Delete;
        private MetroFramework.Controls.MetroLabel lb_Date;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}