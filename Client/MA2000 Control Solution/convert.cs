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
    public partial class convert : Form
    {
        public convert()
        {
            InitializeComponent();
        }

        private void btn_cancel_convert_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_ok_convert_Click(object sender, EventArgs e)
        {
            Form1.Instance.appConfig.rollConvert        = float.Parse(txt_roll_convert.Text);
            Form1.Instance.appConfig.yawConvert         = float.Parse(txt_yaw_convert.Text);
            Form1.Instance.appConfig.pitchConvert       = float.Parse(txt_pitch_convert.Text);
            Form1.Instance.appConfig.elbowConvert       = float.Parse(txt_elbow_convert.Text);
            Form1.Instance.appConfig.shoulderConvert    = float.Parse(txt_shoulder_convert.Text);
            Form1.Instance.appConfig.waistConvert       = float.Parse(txt_waist_convert.Text);

            this.Hide();
        }

        private void convert_Activated(object sender, EventArgs e)
        {
            txt_roll_convert.Text       = Form1.Instance.appConfig.rollConvert.ToString();
            txt_yaw_convert.Text        = Form1.Instance.appConfig.yawConvert.ToString();
            txt_pitch_convert.Text      = Form1.Instance.appConfig.pitchConvert.ToString();
            txt_elbow_convert.Text      = Form1.Instance.appConfig.elbowConvert.ToString();
            txt_shoulder_convert.Text   = Form1.Instance.appConfig.shoulderConvert.ToString();
            txt_waist_convert.Text      = Form1.Instance.appConfig.waistConvert.ToString();
        }
    }
}
