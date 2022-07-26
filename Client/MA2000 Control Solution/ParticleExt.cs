using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MA2000_Control_Solution
{
    public partial class ParticleExt : Form
    {
        public ParticleExt()
        {
            InitializeComponent();
        }
        int swarmSize, iterations;
        int index = 0;
        int loopLimit;

        string jointName = "";
        string partName = "";
        string wholeSale = "";
        string particle = "Particle";
        string iteration = "Iteration";
        string filename = "";

        private void btnOk_Click(object sender, EventArgs e)
        {


            swarmSize = int.Parse(txtSwarm.Text);
            iterations = int.Parse(txtIter.Text);
            loopLimit = int.Parse(txtLoopLimit.Text);

            jointName = cmbJoint.SelectedItem.ToString();

            switch(jointName)
            {
                case "Roll":
                    partName= "RPID";
                    break;

                case "Yaw":
                    partName= "YPID";
                    break;

                case "Pitch":
                    partName = "PPID";
                    break;

                case "Elbow":
                    partName = "EPID";
                    break;

                case "Shoulder":
                    partName = "SPID";
                    break;

                case "Waist":
                    partName = "WPID";
                    break;


            }

            //
            // now lets write a punch of handful stuff,
            //


            StreamWriter configWriter = File.CreateText(filename);

            for (int i = 0; i < swarmSize; i++)
            {

                // variable shit making, matlab is for dummies you know
                wholeSale += particle + i.ToString() + " = [";

                for (int j = i; j < loopLimit; j+=swarmSize)
                {
                    wholeSale += partName + j.ToString() + ";" ;
                

                }
                int shit = wholeSale.Length-1;
                wholeSale=wholeSale.Remove(shit,1);
                wholeSale += " ];" + "\r";
                
                //configWriter.Write(wholeSale);
                //configWriter.Close();
            }


            //
            // Iteration Scattering
            //

            for (int i = 0; i < loopLimit; i+=swarmSize)
            {

                // variable shit making, matlab is for dummies you know

                wholeSale += iteration + index.ToString() + " = [";

                for (int j = i; (j < i+swarmSize && j<loopLimit); j++ )
                {

                    wholeSale += partName + j.ToString() + ";";


                }
                int shit = wholeSale.Length - 1;
                wholeSale = wholeSale.Remove(shit, 1);
                wholeSale += " ];" + "\r";
                //StreamWriter configWriter = File.CreateText(filename);
                index++;
            }
                
                configWriter.Write(wholeSale);
                configWriter.Close();

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveDialog = new FolderBrowserDialog();

            if (saveDialog.ShowDialog() != DialogResult.Cancel)
            {

                txtPath.Text = saveDialog.SelectedPath;

            }

           filename = txtPath.Text + "\\Extractor" + ".m";
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ParticleExt_Load(object sender, EventArgs e)
        {
            txtPath.Text = Form1.Instance.appConfig.logDir;
            txtIter.Text = Form1.Instance.appConfig.noCycles.ToString();
            txtSwarm.Text = Form1.Instance.appConfig.swarmSize.ToString();
        }
    }
}
