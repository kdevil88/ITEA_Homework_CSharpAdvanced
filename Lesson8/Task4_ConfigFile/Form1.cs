using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
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
            NameValueCollection settings = ConfigurationManager.AppSettings;
            if (settings["BackColor"] != null)
                this.BackColor = ColorTranslator.FromHtml(settings["BackColor"]);
            if (settings["FontColor"] != null)
                label.ForeColor = ColorTranslator.FromHtml(settings["FontColor"]);
            if (settings["Font"] != null)
            {
                var fc = new FontConverter();
                label.Font = (Font)fc.ConvertFromString(settings["Font"]);
            }
        }

        public void WriteSettings(string key, string value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
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
