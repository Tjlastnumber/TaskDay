using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace MetroUI.Test
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();

            this.StyleManager = this.metroStyleManager;

            ThemeSet();
            StyleSet();

            this.metroTabControl1.Controls.Add(new MetroFramework.Controls.MetroTabPage()
            {
                Text = "metroTabPage5"
            });
        }

        private void StyleSet()
        {
            var ec = new EnumConverter(typeof(MetroColorStyle));
            this.metroComboBox2.DataSource = new BindingSource(ec.GetStandardValues(), null);
        }

        private void ThemeSet()
        {
            var enumData = new EnumConverter(typeof(MetroThemeStyle));
            this.metroComboBox1.DataSource = new BindingSource(enumData.GetStandardValues(), null);
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.metroStyleManager.Theme = (MetroThemeStyle)this.metroComboBox1.SelectedItem;
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.metroStyleManager.Style = (MetroColorStyle)this.metroComboBox2.SelectedItem;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Test.Contorls.ThemeTestForm mf = new Contorls.ThemeTestForm();
            mf.StyleManager = (MetroFramework.Components.MetroStyleManager)this.metroStyleManager.Clone(mf);
            mf.ShowDialog(this);
        }
    }
}
