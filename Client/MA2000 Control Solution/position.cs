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
    
    public partial class position : Form
    {
        public position()
        {
            InitializeComponent();
        }

        private void btn_position_cancel_Click(object sender, EventArgs e)
        {
            this.Hide() ;
        }

        private void btn_posApply_deg_Click(object sender, EventArgs e)
        {

           Form1.Instance.appConfig.roll_deg        = float.Parse(txt_roll_deg.Text);
           Form1.Instance.appConfig.yaw_deg         = float.Parse(txt_yaw_deg.Text);
           Form1.Instance.appConfig.pitch_deg       = float.Parse(txt_pitch_deg.Text);
           Form1.Instance.appConfig.elbow_deg       = float.Parse(txt_elbow_deg.Text);
           Form1.Instance.appConfig.shoulder_deg    = float.Parse(txt_shoulder_deg.Text);
           Form1.Instance.appConfig.waist_deg       = float.Parse(txt_waist_deg.Text);
           Form1.Instance.deg2volt();
            //** DONE ** --->>>  We need to write a conversion function to set only one set of values
            // to the PID class...


        }

        private void btn_position_ok_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_posApply_volt_Click(object sender, EventArgs e)
        {
            Form1.Instance.appConfig.roll_volt      = float.Parse(txt_roll_volt.Text);
            Form1.Instance.appConfig.yaw_volt       = float.Parse(txt_yaw_volt.Text);
            Form1.Instance.appConfig.pitch_volt     = float.Parse(txt_pitch_volt.Text);
            Form1.Instance.appConfig.elbow_volt     = float.Parse(txt_elbow_volt.Text);
            Form1.Instance.appConfig.shoulder_volt  = float.Parse(txt_shoulder_volt.Text);
            Form1.Instance.appConfig.waist_volt     = float.Parse(txt_waist_volt.Text);
            
        }

        private void position_Activated(object sender, EventArgs e)
        {
            txt_roll_volt.Text      = Form1.Instance.appConfig.roll_volt.ToString();
            txt_yaw_volt.Text       = Form1.Instance.appConfig.yaw_volt.ToString();
            txt_pitch_volt.Text     = Form1.Instance.appConfig.pitch_volt.ToString();
            txt_elbow_volt.Text     = Form1.Instance.appConfig.elbow_volt.ToString();
            txt_shoulder_volt.Text  = Form1.Instance.appConfig.shoulder_volt.ToString();
            txt_waist_volt.Text     = Form1.Instance.appConfig.waist_volt.ToString();

            txt_roll_deg.Text       = Form1.Instance.appConfig.roll_deg.ToString();
            txt_yaw_deg.Text        = Form1.Instance.appConfig.yaw_deg.ToString();
            txt_pitch_deg.Text      = Form1.Instance.appConfig.pitch_deg.ToString();
            txt_elbow_deg.Text      = Form1.Instance.appConfig.elbow_deg.ToString();
            txt_shoulder_deg.Text   = Form1.Instance.appConfig.shoulder_deg.ToString();
            txt_waist_deg.Text      = Form1.Instance.appConfig.waist_deg.ToString();

        }

        private void position_Load(object sender, EventArgs e)
        {

        }
    }
}
