using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MA2000_Control_Solution
{
    public partial class Logger : Form
    {
        public Logger()
        {
            InitializeComponent();
        }

        private void btnLogBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog logDialog = new FolderBrowserDialog();
            
             if (logDialog.ShowDialog() != DialogResult.Cancel)
            {
                
                txtLogDir.Text = logDialog.SelectedPath; 
                 
            }
        }

        private void btnLogOk_Click(object sender, EventArgs e)
        {
            Form1.Instance.appConfig.logDir = txtLogDir.Text;
            this.Hide();
        }

        private void btnLogCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Logger_Activated(object sender, EventArgs e)
        {
            txtLogDir.Text = Form1.Instance.appConfig.logDir;
        }
    }
}
