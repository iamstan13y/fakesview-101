using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using fakesview101.Properties;
using System.Threading;

namespace fakesview101
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            //Settings.Default.Reset();
            if (Settings.Default.configured != true)
            {
                lblmsg.Visible = true;
            }
            else
            {
                refreshTimer.Enabled = true;
                refreshTimer.Start();
                DoTheThing();
            }
        }

        public void DoTheThing()
        {
            try
            {
                Process vpn = Process.Start(Settings.Default.vpnpath);
                int exittime = Settings.Default.time * 1000;
                webBrowser.Navigate(Settings.Default.url);
                webBrowser.Refresh();
                lblmsg.Visible = false;
                Thread.Sleep(exittime);
                vpn.Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            configure conForm = new configure();
            conForm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoTheThing();
        }

        int ticks = 0;
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (ticks >= Settings.Default.time)
            {
                DoTheThing();
                ticks = 0;
            }
        }
    }
}
