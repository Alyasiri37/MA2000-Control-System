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
    public partial class controller : Form
    {
        public controller()
        {
            InitializeComponent();
        }

        private void btn_controller_apply_Click(object sender, EventArgs e)
        {

            if (rad_controller_spec.Checked == true)
            {

                Form1.Instance.appConfig.sampleTime = int.Parse(txt_sample_time.Text);

                if (chkRoll.Checked == true)
                {
                    
                    Form1.Instance.appConfig.roll_kp = float.Parse(txt_roll_kp.Text);
                    Form1.Instance.appConfig.roll_ki = float.Parse(txt_roll_ki.Text);
                    Form1.Instance.appConfig.roll_kd = float.Parse(txt_roll_kd.Text);

                }

                 if (chkYaw.Checked == true)
                {
                    
                    Form1.Instance.appConfig.yaw_kp = float.Parse(txt_yaw_kp.Text);
                    Form1.Instance.appConfig.yaw_ki = float.Parse(txt_yaw_ki.Text);
                    Form1.Instance.appConfig.yaw_kd = float.Parse(txt_yaw_kd.Text);
                }

                 if (chkPitch.Checked == true)
                {
                    
                    Form1.Instance.appConfig.pitch_kp = float.Parse(txt_pitch_kp.Text);
                    Form1.Instance.appConfig.pitch_ki = float.Parse(txt_pitch_ki.Text);
                    Form1.Instance.appConfig.pitch_kd = float.Parse(txt_pitch_kd.Text);
                }


                 if (chkElbow.Checked == true)
                {
                    
                    Form1.Instance.appConfig.elbow_kp = float.Parse(txt_elbow_kp.Text);
                    Form1.Instance.appConfig.elbow_ki = float.Parse(txt_elbow_ki.Text);
                    Form1.Instance.appConfig.elbow_kd = float.Parse(txt_elbow_kd.Text);
                }



                 if (chkShoulder.Checked == true)
                {
                    
                    Form1.Instance.appConfig.shoulder_kp = float.Parse(txt_shoulder_kp.Text);
                    Form1.Instance.appConfig.shoulder_ki = float.Parse(txt_shoulder_ki.Text);
                    Form1.Instance.appConfig.shoulder_kd = float.Parse(txt_shoulder_kd.Text);
                }


                 if (chkWaist.Checked == true)
                {
                    
                    Form1.Instance.appConfig.waist_kp = float.Parse(txt_waist_kp.Text);
                    Form1.Instance.appConfig.waist_ki = float.Parse(txt_waist_ki.Text);
                    Form1.Instance.appConfig.waist_kd = float.Parse(txt_waist_kd.Text);
                }
                
                    Form1.Instance.appConfig.rollOn     = chkRoll.Checked;
                    Form1.Instance.appConfig.yawOn      = chkYaw.Checked;
                    Form1.Instance.appConfig.pitchOn    = chkPitch.Checked;
                    Form1.Instance.appConfig.elbowOn    = chkElbow.Checked;
                    Form1.Instance.appConfig.shoulderOn = chkShoulder.Checked;
                    Form1.Instance.appConfig.waistOn    = chkWaist.Checked;
                
                
            }
        }

        private void btn_controller_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_controller_ok_Click(object sender, EventArgs e)
        {
            btn_controller_apply_Click(sender, e);
            this.Hide();
        }

        private void controller_Load(object sender, EventArgs e)
        {
            

        }

        public void controller_Activate(object sender, EventArgs e)

        {
            systemPID();
        }

        private void systemPID()
        {
            //
            // Brakes
            //
            chkRoll.Checked     = Form1.Instance.appConfig.rollOn;
            chkYaw.Checked      = Form1.Instance.appConfig.yawOn;
            chkPitch.Checked    = Form1.Instance.appConfig.pitchOn;
            chkElbow.Checked    = Form1.Instance.appConfig.elbowOn;
            chkShoulder.Checked = Form1.Instance.appConfig.shoulderOn;
            chkWaist.Checked    = Form1.Instance.appConfig.waistOn;

            txt_gen_kp.Text = Form1.Instance.appConfig.general_kp.ToString();
            txt_gen_ki.Text = Form1.Instance.appConfig.general_ki.ToString();
            txt_gen_kd.Text = Form1.Instance.appConfig.general_kd.ToString();

            txt_roll_kp.Text = Form1.Instance.appConfig.roll_kp.ToString();
            txt_roll_ki.Text = Form1.Instance.appConfig.roll_ki.ToString();
            txt_roll_kd.Text = Form1.Instance.appConfig.roll_kd.ToString();

            txt_yaw_kp.Text = Form1.Instance.appConfig.yaw_kp.ToString();
            txt_yaw_ki.Text = Form1.Instance.appConfig.yaw_ki.ToString();
            txt_yaw_kd.Text = Form1.Instance.appConfig.yaw_kd.ToString();

            txt_pitch_kp.Text = Form1.Instance.appConfig.pitch_kp.ToString();
            txt_pitch_ki.Text = Form1.Instance.appConfig.pitch_ki.ToString();
            txt_pitch_kd.Text = Form1.Instance.appConfig.pitch_kd.ToString();

            txt_elbow_kp.Text = Form1.Instance.appConfig.elbow_kp.ToString();
            txt_elbow_ki.Text = Form1.Instance.appConfig.elbow_ki.ToString();
            txt_elbow_kd.Text = Form1.Instance.appConfig.elbow_kd.ToString();

            txt_shoulder_kp.Text = Form1.Instance.appConfig.shoulder_kp.ToString();
            txt_shoulder_ki.Text = Form1.Instance.appConfig.shoulder_ki.ToString();
            txt_shoulder_kd.Text = Form1.Instance.appConfig.shoulder_kd.ToString();

            txt_waist_kp.Text = Form1.Instance.appConfig.waist_kp.ToString();
            txt_waist_ki.Text = Form1.Instance.appConfig.waist_ki.ToString();
            txt_waist_kd.Text = Form1.Instance.appConfig.waist_kd.ToString();

            txt_sample_time.Text = Form1.Instance.appConfig.sampleTime.ToString();
        }

        private void rad_controller_spec_CheckedChanged(object sender, EventArgs e)
        {
            grpSpecific.Enabled = rad_controller_spec.Checked;
        }

        private void rad_controller_gen_CheckedChanged(object sender, EventArgs e)
        {
            grpGeneral.Enabled = rad_controller_gen.Checked;
        }

    }
}
