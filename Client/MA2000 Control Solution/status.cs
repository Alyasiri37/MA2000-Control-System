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
    public partial class status : Form
    {
        public status()
        {
            InitializeComponent();
        }

        private void btnStatusApply_Click(object sender, EventArgs e)
        {
            Form1.Instance.appConfig.isRunning = radStatusOn.Checked;
            Form1.Instance.appConfig.refreshRate = int.Parse(txtRefreshRate.Text);
            Form1.Instance.status_timer();
        }

        private void status_Activated(object sender, EventArgs e)
        {
            txtRefreshRate.Text = Form1.Instance.appConfig.refreshRate.ToString();
        }

        private void btnStatusOk_Click(object sender, EventArgs e)
        {
            btnStatusApply_Click( sender,  e);
            this.Hide();
        }

        private void btnStatusCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void radStatusOn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
