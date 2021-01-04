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

namespace Task4
{
    public partial class Form1 : Form
    {
        Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowStopWatchElapsed()
        {
           teDisplay.Text = string.Format("{0}", sw.Elapsed);
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            sw.Start();
            timer.Enabled = true;
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            sw.Stop();
            timer.Enabled = false;
            ShowStopWatchElapsed();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            sw.Reset();
            timer.Enabled = false;
            ShowStopWatchElapsed();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ShowStopWatchElapsed();
        }
    }
}
