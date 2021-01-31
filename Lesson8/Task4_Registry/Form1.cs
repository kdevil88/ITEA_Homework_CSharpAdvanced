using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class fmMain : System.Windows.Forms.Form
    {
        public fmMain()
        {
            InitializeComponent();
            ReadSettings();
        }

        private void ReadSettings()
        {
            RegistryKey settings = Registry.CurrentUser.CreateSubKey(@"Software\Lesson8Task4");
            if (settings.GetValue("BackColor") != null)
                this.BackColor = ColorTranslator.FromHtml((string)settings.GetValue("BackColor"));
            if (settings.GetValue("FontColor") != null)
                label.ForeColor = ColorTranslator.FromHtml((string)settings.GetValue("FontColor"));
            if (settings.GetValue("Font") != null)
            {
                var fc = new FontConverter();
                label.Font = (Font)fc.ConvertFromString((string)settings.GetValue("Font"));
            }
            settings.Close();
        }

        public void WriteSettings(string key, string value)
        {
            RegistryKey settings = Registry.CurrentUser.CreateSubKey(@"Software\Lesson8Task4");
            settings.SetValue(key, value);
            settings.Close();
        }

        private void menuFile_CheckStateChanged(object sender, EventArgs e)
        {
            menuRegistry.Checked = !menuFile.Checked;
        }

        private void menuRegistry_CheckStateChanged(object sender, EventArgs e)
        {
            menuFile.Checked = !menuRegistry.Checked;
        }

        private void menuBackColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = this.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog.Color;
                WriteSettings("BackColor", ColorTranslator.ToHtml(this.BackColor));
            }
        }

        private void menuFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = label.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                label.Font = fontDialog.Font;
                var fc = new FontConverter();
                WriteSettings("Font", fc.ConvertToString(label.Font));
            }
        }

        private void menuFontColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = label.ForeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                label.ForeColor = colorDialog.Color;
                WriteSettings("FontColor", ColorTranslator.ToHtml(label.ForeColor));
            }
        }
    }
}
