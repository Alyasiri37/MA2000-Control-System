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
    public partial class zeroPosition : Form
    {
        public zeroPosition()
        {
            InitializeComponent();
        }

        private void btn_zero_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void zeroPosition_Load(object sender, EventArgs e)
        {

        }

        private void zeroPosition_Activate(object sender, EventArgs e)
        {
            txt_roll_zero.Text      = Form1.Instance.appConfig.rollZero.ToString();
            txt_yaw_zero.Text       = Form1.Instance.appConfig.yawZero.ToString();
            txt_pitch_zero.Text     = Form1.Instance.appConfig.pitchZero.ToString();
            txt_elbow_zero.Text     = Form1.Instance.appConfig.elbowZero.ToString();
            txt_shoulder_zero.Text  = Form1.Instance.appConfig.shoulderZero.ToString();
            txt_waist_zero.Text     = Form1.Instance.appConfig.waistZero.ToString();


        }

        private void btn_zero_ok_Click(object sender, EventArgs e)
        {
            Form1.Instance.appConfig.rollDegZero        = float.Parse(txt_roll_zero.Text);
            Form1.Instance.appConfig.yawDegZero         = float.Parse(txt_yaw_zero.Text);
            Form1.Instance.appConfig.pitchDegZero       = float.Parse(txt_pitch_zero.Text);
            Form1.Instance.appConfig.elbowDegZero       = float.Parse(txt_elbow_zero.Text);
            Form1.Instance.appConfig.shoulderDegZero    = float.Parse(txt_shoulder_zero.Text);
            Form1.Instance.appConfig.waistDegZero       = float.Parse(txt_waist_zero.Text);
            Form1.Instance.deg2voltZero();
            this.Hide();

        }
    }
}
