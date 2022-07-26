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
    public partial class response : Form
    {
        public response()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void response_Load(object sender, EventArgs e)
        {

        }

        private void response_Activate(object sender, EventArgs e)
        {
            txtMaxOvershoot.Text = Form1.Instance.appConfig.maxOvershoot.ToString();
            txtRiseTime.Text     = Form1.Instance.appConfig.riseTime.ToString();
        }

        private void btn_response_ok_Click(object sender, EventArgs e)
        {
            Form1.Instance.appConfig.maxOvershoot = float.Parse(txtMaxOvershoot.Text);
            Form1.Instance.appConfig.riseTime     = float.Parse(txtRiseTime.Text);
        }
    }
}
