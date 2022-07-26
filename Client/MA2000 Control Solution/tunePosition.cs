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
    public partial class tunePosition : Form
    {
        public tunePosition()
        {
            InitializeComponent();
        }

        private void tunePosition_Load(object sender, EventArgs e)
        {

        }

        private void tunePosition_Activated(object sender, EventArgs e)
        {
            txt_roll_tune.Text      = Form1.Instance.appConfig.rollTune.ToString();
            txt_yaw_tune.Text       = Form1.Instance.appConfig.yawTune.ToString();
            txt_pitch_tune.Text     = Form1.Instance.appConfig.pitchTune.ToString();
            txt_elbow_tune.Text     = Form1.Instance.appConfig.elbowTune.ToString();
            txt_shoulder_tune.Text  = Form1.Instance.appConfig.shoulderTune.ToString();
            txt_waist_tune.Text     = Form1.Instance.appConfig.waistTune.ToString();
        }

        private void btn_tune_ok_Click(object sender, EventArgs e)
        {
            Form1.Instance.appConfig.rollDegTune        = float.Parse(txt_roll_tune.Text);
            Form1.Instance.appConfig.yawDegTune         = float.Parse(txt_yaw_tune.Text);
            Form1.Instance.appConfig.pitchDegTune       = float.Parse(txt_pitch_tune.Text);
            Form1.Instance.appConfig.elbowDegTune       = float.Parse(txt_elbow_tune.Text);
            Form1.Instance.appConfig.shoulderDegTune    = float.Parse(txt_shoulder_tune.Text);
            Form1.Instance.appConfig.waistDegTune       = float.Parse(txt_waist_tune.Text);
            Form1.Instance.deg2voltTune();
            this.Hide();
             
        }

        private void btn_tune_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
