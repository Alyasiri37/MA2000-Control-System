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
    public partial class connect : Form
    {

        
        public connect()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void connect_Load(object sender, EventArgs e)
        {
            

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            // Initialize then connect
            network.net_init(txt_ip.Text, int.Parse(txt_port.Text));
            network.connect();
            
            // Save the config
            Form1.Instance.appConfig.ipAddress = txt_ip.Text;
            Form1.Instance.appConfig.port = int.Parse(txt_port.Text);
            
            this.Hide();
            
        }

        private void connect_Activate(object sender, EventArgs e)
        {
            txt_ip.Text = Form1.Instance.appConfig.ipAddress;
            txt_port.Text = Form1.Instance.appConfig.port.ToString();
        }


       
    }
}
