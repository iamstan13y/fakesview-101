using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fakesview101.Properties;

namespace fakesview101
{
    public partial class configure : Form
    {
        public configure()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string vpnpath="";
            string weburl="";

            int refreshtime = (int)numUp.Value;
            vpnpath = txtVpn.Text;
            weburl = txtUrl.Text;

            if (!(vpnpath=="" || weburl == ""))
            {
                Settings.Default.url = weburl;
                Settings.Default.vpnpath = vpnpath;
                Settings.Default.time = refreshtime;
                Settings.Default.configured = true;
                Settings.Default.Save();
                MessageBox.Show("Settings saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("All fields are required!", "Save error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtVpn.Text = openFile.FileName;
            }
        }
    }
}
