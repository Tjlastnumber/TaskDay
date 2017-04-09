namespace MetroUI.Test.Contorls
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
            this.metroContextMenu1.SuspendLayout();
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
            // 
            // metroContextMenu1
            // 
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
            this.lb_Date.LabelMode = MetroFramework.Controls.MetroLabelMode.Selectable;
            this.lb_Date.Location = new System.Drawing.Point(111, 23);
            this.lb_Date.Name = "lb_Date";
            this.lb_Date.Size = new System.Drawing.Size(36, 19);
            this.lb_Date.TabIndex = 3;
            this.lb_Date.Text = "Date";
            // 
            // metroLink1
            // 
            this.metroLink1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLink1.ContextMenuStrip = this.metroContextMenu1;
            this.metroLink1.Image = global::MetroUI.Test.Properties.Resources.Hamburg;
            this.metroLink1.ImageSize = 32;
            this.metroLink1.Location = new System.Drawing.Point(331, 10);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(50, 35);
            this.metroLink1.TabIndex = 2;
            this.metroLink1.UseSelectable = true;
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
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(388, 165);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lb_Date);
            this.Controls.Add(this.metroLink1);
            this.Controls.Add(this.lb_Title);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "TaskForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TaskForm";
            this.metroContextMenu1.ResumeLayout(false);
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
    }
}