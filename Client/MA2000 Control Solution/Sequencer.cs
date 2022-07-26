using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace MA2000_Control_Solution
{
    public partial class Sequencer : Form
    {

        //
        // Some variables that we need
        //

         float [,] positionArray = new float [100,6]; //  << position matrix that holds thetas
         int index = 0;                             //  << index for matrix depth
         bool ascend = true;                        //  << path direction indicator
         int idx = 0;                               // Current point to be saved
         int pathIdx = 0;                           // Gets the selected path depth

         public static pathConfig pathData = new pathConfig();    // A new instance of the path class
        
        public Sequencer()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            // Here we go

            // First we need to determine which path is selected

            switch (cmbPath.Text)
            {
                case "Square":

                    positionArray = pathData.path1;
                    pathIdx = pathData.p1Idx;
                    break;
                case "Circle":
                    positionArray = pathData.path2;
                    pathIdx = pathData.p2Idx;
                    break;
                case "Sine":
                    positionArray = pathData.path3;
                    pathIdx = pathData.p3Idx;
                    break;
                case "Path 3":
                    positionArray = pathData.path4;
                    pathIdx = pathData.p4Idx;
                    break;
            }

            tmrPosition.Interval = int.Parse(txtInterval.Text);

            // Start PID
            Form1.Instance.sequenceStart();

            // Start position changer
            tmrPosition.Enabled = true;

        }

        private void tmrPosition_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "Current position pair : " + index.ToString() ;
            if (ascend)
            {
                grbConfig.Enabled = false;
                Form1.Instance.appConfig.roll_volt = positionArray[index, 0];
                Form1.Instance.appConfig.yaw_volt = positionArray[index, 1];
                Form1.Instance.appConfig.pitch_volt = positionArray[index, 2];
                Form1.Instance.appConfig.elbow_volt = positionArray[index, 3];
                Form1.Instance.appConfig.shoulder_volt = positionArray[index, 4];
                Form1.Instance.appConfig.waist_volt = positionArray[index, 5];
                    index++;
                if (index == pathIdx)
                {
                    ascend = false;
                    tmrPosition.Interval = 4500;
                }

                
            }


            else
            {
                tmrPosition.Interval = int.Parse(txtInterval.Text) ;
                index--;

                Form1.Instance.appConfig.roll_volt = positionArray[index, 0];
                Form1.Instance.appConfig.yaw_volt = positionArray[index, 1];
                Form1.Instance.appConfig.pitch_volt = positionArray[index, 2];
                Form1.Instance.appConfig.elbow_volt = positionArray[index, 3];
                Form1.Instance.appConfig.shoulder_volt = positionArray[index, 4];
                Form1.Instance.appConfig.waist_volt = positionArray[index, 5];


                if (index == 0)
                {
                    
                    tmrPosition.Enabled = false;
                    grbConfig.Enabled = true;
                }

            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       

        private void trkWst_Scroll(object sender, EventArgs e)
        {
            lblWst.Text = trkWst.Value.ToString();
        }

        private void Sequencer_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void Sequencer_Load(object sender, EventArgs e)
        {
            idx = 0 ;
            pathData.init();
        }

        private void trkWst_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (trkWst.Value > 50)
                        trkWst.Value--;
                    break;

                case Keys.Q:
                    if (trkWst.Value < 450)
                        trkWst.Value++;
                    break;
            }
        }

        private void trkWst_ValueChanged(object sender, EventArgs e)
        {
            lblWst.Text = ((float)trkWst.Value/100).ToString();
            Form1.Instance.appConfig.waist_volt = ((float)trkWst.Value/100);
            
        }

        private void trkShld_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    if (trkShld.Value > 50)
                        trkShld.Value--;
                    break;

                case Keys.W:
                    if (trkShld.Value < 450)
                        trkShld.Value++;
                    break;

            }
        }

        private void trkElb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    if (trkElb.Value > 50)
                        trkElb.Value--;
                    break;

                case Keys.E:
                    if (trkElb.Value < 450)
                        trkElb.Value++;
                    break;

                
            }
        }

        private void trkPtch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F:
                    if (trkPtch.Value > 50)
                        trkPtch.Value--;
                    break;

                case Keys.R:
                    if (trkPtch.Value < 450)
                        trkPtch.Value++;
                    break;

                
            }
        }

        private void trkYaw_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.G:
                    if (trkYaw.Value > 50)
                        trkYaw.Value--;
                    break;

                case Keys.T:
                    if (trkYaw.Value < 450)
                        trkYaw.Value++;
                    break;

                 
            }
        }

        private void trkRol_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.H:
                    if (trkRol.Value > 50)
                        trkRol.Value--;
                    break;

                case Keys.Y:
                    if (trkRol.Value < 450)
                        trkRol.Value++;
                    break;  
            }
        }

        private void trkShld_ValueChanged(object sender, EventArgs e)
        {
            lblShld.Text = ((float)trkShld.Value / 100).ToString();
            Form1.Instance.appConfig.shoulder_volt = ((float)trkShld.Value / 100);
            
            
        }

        private void trkElb_ValueChanged(object sender, EventArgs e)
        {
            lblElb.Text = ((float)trkElb.Value / 100).ToString();
            Form1.Instance.appConfig.elbow_volt = ((float)trkElb.Value / 100);
            
        }

        private void trkPtch_ValueChanged(object sender, EventArgs e)
        {
            lblPtch.Text = ((float)trkPtch.Value / 100).ToString();
            Form1.Instance.appConfig.pitch_volt = ((float)trkPtch.Value / 100);
           
        }

        private void trkYaw_ValueChanged(object sender, EventArgs e)
        {
            lblYaw.Text = ((float)trkYaw.Value / 100).ToString();
            Form1.Instance.appConfig.yaw_volt = ((float)trkYaw.Value / 100);
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            switch (cmbSavePath.Text)
            {
                case "Square":

                    pathData.path1[idx, 0] = network.roll_p;
                    pathData.path1[idx, 1] = network.yaw_p;
                    pathData.path1[idx, 2] = network.pitch_p;
                    pathData.path1[idx, 3] = network.elbow_p;
                    pathData.path1[idx, 4] = network.shoulder_p;
                    pathData.path1[idx, 5] = network.waist_p;

                    pathData.p1Idx = idx+1;
                    break;


                case "Circle":
                    
                    pathData.path2[idx, 0] = network.roll_p;
                    pathData.path2[idx, 1] = network.yaw_p;
                    pathData.path2[idx, 2] = network.pitch_p;
                    pathData.path2[idx, 3] = network.elbow_p;
                    pathData.path2[idx, 4] = network.shoulder_p;
                    pathData.path2[idx, 5] = network.waist_p;

                    pathData.p2Idx = idx+1;
                    break;

                case "Sine":
                    pathData.path3[idx, 0] = network.roll_p;
                    pathData.path3[idx, 1] = network.yaw_p;
                    pathData.path3[idx, 2] = network.pitch_p;
                    pathData.path3[idx, 3] = network.elbow_p;
                    pathData.path3[idx, 4] = network.shoulder_p;
                    pathData.path3[idx, 5] = network.waist_p;

                    pathData.p3Idx = idx + 1;
                    break;

                case "Path 3":
                    pathData.path4[idx, 0] = network.roll_p;
                    pathData.path4[idx, 1] = network.yaw_p;
                    pathData.path4[idx, 2] = network.pitch_p;
                    pathData.path4[idx, 3] = network.elbow_p;
                    pathData.path4[idx, 4] = network.shoulder_p;
                    pathData.path4[idx, 5] = network.waist_p;

                    pathData.p4Idx = idx + 1;
                    break;
            }
            idx++;

            lblCurrentPoint.Text = idx.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (idx > 0)
            {
                idx--;
                lblCurrentPoint.Text = idx.ToString();
            }
        }

        private void trkRol_ValueChanged(object sender, EventArgs e)
        {
            lblRol.Text = ((float)trkRol.Value / 100).ToString();
            Form1.Instance.appConfig.roll_volt = ((float)trkRol.Value / 100);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.FileName = "Path";
            saveDlg.DefaultExt = ".bin";
            saveDlg.Filter = "Binary Data (.bin)|*.bin";

            if (saveDlg.ShowDialog() != DialogResult.Cancel)
            {

                string filename = saveDlg.FileName;
                saveBin(pathData, filename);

                Form1.Instance.log("Path Data Saved ..");
                
            }
        }



        static void saveBin(object objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);

            }
        }

        static void loadBin(string fileName)
        {

            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = File.OpenRead(fileName))
            {

                 pathData = (pathConfig)binFormat.Deserialize(fStream);
            }
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.DefaultExt = ".bin";
            openDlg.Filter = "Binary Data (.bin)|*.bin";

            if (openDlg.ShowDialog() != DialogResult.Cancel)
            {

                string filename = openDlg.FileName;
                loadBin(filename);

            }

            txtInterval.Enabled = true;
            cmbPath.Enabled = true;
            btnOk.Enabled = true;
            Form1.Instance.log("Path Data Loaded ..");
        }

        private void cmbSavePath_SelectedValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnDone.Enabled = true;
            btnPrev.Enabled = true;
        }

        private void Sequencer_Activated(object sender, EventArgs e)
        {
            trkWst.Value = (int)Form1.Instance.appConfig.waist_volt * 100;
            trkShld.Value = (int)Form1.Instance.appConfig.shoulder_volt * 100;
            trkElb.Value = (int)Form1.Instance.appConfig.elbow_volt * 100;


            //trkPtch.Value = (int)Form1.Instance.appConfig.pitch_volt * 100;
            //trkYaw.Value = (int)Form1.Instance.appConfig.yaw_volt * 100;
            //trkRol.Value = (int)Form1.Instance.appConfig.roll_volt * 100;
        }
    }
}
