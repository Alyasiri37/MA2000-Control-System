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
    public partial class tuneProgress : Form
    {
        public tuneProgress()
        {
            InitializeComponent();
        }
        TimeSpan ts = TimeSpan.Zero;
        private void tuneProgress_Load(object sender, EventArgs e)
        {
            
             
            int[] max = new int[6];
            max = hc.transferMetrics();

            prgTune.Maximum = max[0] * max[1] * max[2];
            lblJoints.Text = max[0].ToString();
            lblIterations.Text = max[1].ToString();
            lblSwarm.Text = max[2].ToString();

            int duration = max[0] * max[1] * max[2] * max[5];
            
            
            lblRequired.Text = ts.Add(TimeSpan.FromSeconds(duration)).ToString();
            tmrTunePrg.Enabled = true;
        }
        string currentJoint = "";
        private void tmrTunePrg_Tick(object sender, EventArgs e)
        {

            int[] metrics = new int[3];

            metrics = hc.transferCurrentMetrics();
            currentJoint = hc.name;
            lblJoint.Text = currentJoint;
            lblParticle.Text = metrics[2].ToString();
            lblIteration.Text = metrics[1].ToString();
             ts= ts.Add(TimeSpan.FromSeconds(1));
             lblEapsed.Text = ts.ToString();

            
            
              
                  
        }

        private void tuneProgress_Activated(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
