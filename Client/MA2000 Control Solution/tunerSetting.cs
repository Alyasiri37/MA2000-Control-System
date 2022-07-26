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
    public partial class tunerSetting : Form
    {
        public tunerSetting()
        {
            InitializeComponent();
        }

        private void tunerSetting_Activated(object sender, EventArgs e)
        {
            txtNoCycles.Text      = Form1.Instance.appConfig.noCycles.ToString();
            txtCycleDuration.Text = Form1.Instance.appConfig.cycleDuration.ToString();
            txtC1.Text            = Form1.Instance.appConfig.c1.ToString();
            txtC2.Text            = Form1.Instance.appConfig.c2.ToString();
            txtSwarmSize.Text     = Form1.Instance.appConfig.swarmSize.ToString();
            chkRollTune.Checked     = Form1.Instance.appConfig.rollTuneOn;
            chkYawTune.Checked      = Form1.Instance.appConfig.yawTuneOn;
            chkPitchTune.Checked    = Form1.Instance.appConfig.pitchTuneOn;
            chkElbowTune.Checked    = Form1.Instance.appConfig.elbowTuneOn;
            chkShoulderTune.Checked = Form1.Instance.appConfig.shoulderTuneOn;
            chkWaistTune.Checked    = Form1.Instance.appConfig.waistTuneOn;
        }

        private void btn_tuner_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_tuner_ok_Click(object sender, EventArgs e)
        {
            Form1.Instance.appConfig.noCycles       = int.Parse(txtNoCycles.Text);
            Form1.Instance.appConfig.cycleDuration  = int.Parse(txtCycleDuration.Text);
            Form1.Instance.appConfig.c1             = float.Parse(txtC1.Text);
            Form1.Instance.appConfig.c2             = float.Parse(txtC2.Text);
            Form1.Instance.appConfig.swarmSize      = int.Parse(txtSwarmSize.Text);
            Form1.Instance.appConfig.rollTuneOn     =chkRollTune.Checked;
            Form1.Instance.appConfig.waistTuneOn    = chkYawTune.Checked;
            Form1.Instance.appConfig.pitchTuneOn    = chkPitchTune.Checked;
            Form1.Instance.appConfig.elbowTuneOn    = chkElbowTune.Checked;
            Form1.Instance.appConfig.shoulderTuneOn = chkShoulderTune.Checked;
            Form1.Instance.appConfig.waistTuneOn    = chkWaistTune.Checked;
            this.Hide();
        }
    }
}
