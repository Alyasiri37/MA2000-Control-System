using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;
using System.Diagnostics;
using TribesPSO;

// Used for MAT extension logging

using csmatio.types;
using csmatio.io;



namespace MA2000_Control_Solution
{

    public partial class Form1 : Form
    {

        //******************************************************
        //       Some magic to access form1 from outside       *
        //******************************************************
        static Form1 instance;
        public static Form1 Instance { get { return instance; } }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            instance = this;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            instance = null;
        }

        //******************************************************

        //******************************************************
        //                Class Initialization                 *
        //******************************************************

        //
        // Control class instances
        //

        PID rollPID     = new PID(0.5f);
        PID yawPID      = new PID(0.5f);
        PID pitchPID    = new PID(0.5f);
        PID elbowPID    = new PID(0.2f);
        PID shoulderPID = new PID(0.2f);
        PID waistPID    = new PID(0.8f);
        
        //
        // Tune class instances
        //

       // Swarm rollTuner      = new Swarm("Roll Joint");
        //static Swarm yawTuner       = new Swarm("Yaw Joint");
        //static Swarm pitchTuner     = new Swarm("Pitch Joint");
       // static Swarm elbowTuner     = new Swarm("Elbow Joint");
      //  static Swarm shoulderTuner  = new Swarm("Shoulder Joint");
       // static Swarm waistTuner     = new Swarm("Waist Joint");

        //
        // Tuner List
        // Contains a list of the selected joint tuners.
        List<Swarm> tunerList = new List<Swarm>();

        // Counter for the tuners list
         int tunerIndex = 0;


        //
        // Configuration class instance
        //

        public config appConfig = new config();

        //******************************************************

        // forms declarations
        //********************************
        connect con_form            = new connect();
        position pos_form           = new position();
        zeroPosition zeroPos_form   = new zeroPosition();
        convert convert_form        = new convert();
        controller controller_form  = new controller();
        response response_form      = new response();
        tunePosition tunePos_form   = new tunePosition();
        tunerSetting tune_form      = new tunerSetting();
        status status_form          = new status();
        tuneProgress prg_window     = new tuneProgress();
        Logger log_window           = new Logger();
        ParticleExt extractor_form  = new ParticleExt();
        Sequencer sequencer_form    = new Sequencer();

        //********************************
        
        // Misc. Declarations
        //********************************
        DateTime dt,zeroRun,runTime = new DateTime(); //timers 
        Stopwatch cycleWatch = new Stopwatch();

        // used for tuner progress monitoring
        TimeSpan ts = TimeSpan.Zero;
        DateTime startTime = new DateTime();
        TimeSpan required = TimeSpan.Zero;
        TimeSpan estimated = TimeSpan.Zero;
        int seconds = 0; // used to store the required tune time in seconds

        //******************************************
        // Flie log parameters
        //******************************************
        
        
        // Lists used to store log data
        List<MLArray> rollLogList       = new List<MLArray>();
        List<MLArray> yawLogList        = new List<MLArray>();
        List<MLArray> pitchLogList      = new List<MLArray>();
        List<MLArray> elbowLogList      = new List<MLArray>();
        List<MLArray> shoulderLogList   = new List<MLArray>();
        List<MLArray> waistLogList      = new List<MLArray>();


        // Lists used to hold pid response
        List<MLArray> rollresList       = new List<MLArray>();
        List<MLArray> yawresList        = new List<MLArray>();
        List<MLArray> pitchresList      = new List<MLArray>();
        List<MLArray> elbowresList      = new List<MLArray>();
        List<MLArray> shoulderresList   = new List<MLArray>();
        List<MLArray> waistresList      = new List<MLArray>();
        
        //
        // Data log vectors, later will be converted to arrays.
        //
        // First, for plant output

        List<float> rollP       = new List<float>();
        List<float> yawP        = new List<float>();
        List<float> pitchP      = new List<float>();
        List<float> elbowP      = new List<float>();
        List<float> shoulderP   = new List<float>();
        List<float> waistP      = new List<float>();

        // Now for controller output
        
        List<float> rollC       = new List<float>();
        List<float> yawC        = new List<float>();
        List<float> pitchC      = new List<float>();
        List<float> elbowC      = new List<float>();
        List<float> shoulderC   = new List<float>();
        List<float> waistC      = new List<float>();

        // Last, for the desired value

        List<float> rollD       = new List<float>();
        List<float> yawD        = new List<float>();
        List<float> pitchD      = new List<float>();
        List<float> elbowD      = new List<float>();
        List<float> shoulderD   = new List<float>();
        List<float> waistD      = new List<float>();



        // Used to set the log index (for matrix naming)
        int logIndexer = 0;
        string idx      = ""; // << used as name indexer for matrices
        
        // Filenames for log files, each joint has its own log file
        string filename1 = "",filename2="",filename3=""
            ,filename4="",filename5="",filename6="",filename7="";

        // Free run files
        string filename11 = "", filename22 = "", filename33 = ""
            , filename44 = "", filename55 = "", filename66 = "", filename77 = "";


        //******************************************
        // Logging parameters
        //******************************************
        int sampleRate;                             //  << Used to set the number of samples.
        int Index = 0;                              //  << Used for error & response indexing in matrices.
        float[,] errorLog      = new float[1, 1];   //  << Error log matrix
        float[,] plantLog      = new float[1, 1];   //  << Plant log matrix
        float[,] controllerLog = new float[1, 1];   //  << Controller log matrix
        bool logSaved          = false;             //  << Indicates whether log data hase been saved or not.         
        int maxIterations;                          //  << The number of total iterations for the swarm.
        //
        // Error Log
        //
        float[] rollErrLog, yawErrLog, pitchErrLog, elbowErrLog, shoulderErrLog, waistErrLog;
        

        //
        // Plant Log
        //

        float[] rollPlantLog,yawPlantLog,pitchPlantLog,elbowPlantLog,shoulderPlantLog,waistPlantLog ;
        

        //
        //Controller Log
        //

        float[] rollControllerLog,yawControllerLog,pitchControllerLog,elbowControllerLog,shoulderControllerLog,waistControllerLog;


        //
        // Evaluation Log
        //
        
        float[] rollEval,yawEval,pitchEval,elbowEval,shoulderEval,waistEval;
        
        // The following logs are for Gbest particle only

        float[] rollEvalBest,yawEvalBest,pitchEvalBest,elbowEvalBest,shoulderEvalBest,waistEvalBest;
        //
        // Maximum Overshoot Logging
        //

        float[] rollOS, yawOS,pitchOS,elbowOS,shoulderOS,waistOS;
       
        //
        // Rise Time Logging
        //

        float[] rollTr ,yawTr,pitchTr,elbowTr,shoulderTr,waistTr;
        
        //******************************************************
        //                Tuner Initialization                 *
        //******************************************************
        float[] position0, position1, position2, position3, position4, position5;
       
       
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            con_form.ShowDialog();
            
            disconnectToolStripMenuItem.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        //
        // Status timer update function
        //
        public void status_timer()
        {
            statusTimer.Interval = appConfig.refreshRate;
            statusTimer.Enabled = appConfig.isRunning;

            // edited recently for debugging
            statusTimer.Enabled = true;
            
        }

        //
        // log function
        //****************************
        public void log(string logData)
        { 
            dt=DateTime.Now;
            txt_log.AppendText(dt.ToString("dd.MM.yyyy  HH:mm:ss"));
            txt_log.AppendText("     \t" + logData + " \n");

           
        }
        //****************************


        private void button1_Click(object sender, EventArgs e)
        {
            classStatus.tunerOn = false;
            if (!classStatus.controlOn)
            {
                network.control = 1;
                network.send();
                classStatus.controlOn = true;
            }

            PIDINIT();
            pidTimer.Interval =(int) appConfig.sampleTime;
            pidTimer.Enabled = true;
            zeroRun = DateTime.Now;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            appConfig.systemInit();
            
            
            
            
        
            DialogResult msgRes = MessageBox.Show(" Would you like to load a configuration file ? "
                , "Load Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgRes == DialogResult.Yes)
            {
                importConfigToolStripMenuItem_Click(sender,e);
            }
            else
            {
               
            }
            logInit();
            log("Application Ready");
            //tunerList.Add(new Swarm("") );
            status_timer();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            network.disconnect();
            disconnectToolStripMenuItem.Enabled = false;
            //
            // Add stop procedure here, for control, tuner, etc
            // Everything should be stopped before disconnecting 
            // from server.
        }

        private void positionConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pos_form.Show();
        }

        private void zeroPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zeroPos_form.Show();
           
        }


        
        private void exportConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.FileName = "Config";
            saveDlg.DefaultExt = ".xml";
            saveDlg.Filter = "XML documents (.xml)|*.xml";
            
            if (saveDlg.ShowDialog() != DialogResult.Cancel)
            {
               
                string filename = saveDlg.FileName;
                XmlSerializer x = new XmlSerializer(appConfig.GetType());
                StreamWriter saver = new StreamWriter(filename);
                x.Serialize(saver, appConfig);
                log("Configuration Saved");
                saver.Close();
            }

        }

        private void importConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
           
            openDlg.DefaultExt = ".xml";
            openDlg.Filter = "XML documents (.xml)|*.xml";

            if (openDlg.ShowDialog() != DialogResult.Cancel)
            {

                string filename = openDlg.FileName;
                XmlSerializer x = new XmlSerializer(appConfig.GetType());
                StreamReader opener = new StreamReader(filename);
                appConfig =(config) x.Deserialize(opener);
                log("Configuration loaded");
                opener.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void conversionParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            convert_form.Show();
        }

        private void controllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller_form.Show();
        }

        private void responseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            response_form.Show();
        }

        private void tunePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tunePos_form.Show();
        }

        private void tunerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tune_form.Show();
        }

        private void statusAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status_form.Show();
        }

        private void pidTimer_Tick(object sender, EventArgs e)
        {

        }

        // 
        // General control function
        //
        private void PID()
        {
            // Check if controller should be stopped

            if (classStatus.controlOn)
            {


                //
                // Hear server barfing..
                //
                network.receive();

                //
                // Truncation
                //

                network.roll_p = (float)(Math.Truncate(network.roll_p * 100) / 100);
                network.yaw_p = (float)(Math.Truncate(network.yaw_p * 100) / 100);
                network.pitch_p = (float)(Math.Truncate(network.pitch_p * 100) / 100);
                network.elbow_p = (float)(Math.Truncate(network.elbow_p * 100) / 100);
                network.shoulder_p = (float)(Math.Truncate(network.shoulder_p * 100) / 100);
                network.waist_p = (float)(Math.Truncate(network.waist_p * 100) / 100);
                //
                // Calculate error terms, protocol integrity should be maintained  ;)
                //

                network.e0 = appConfig.roll_volt    - network.roll_p;
                network.e1 = appConfig.yaw_volt     - network.yaw_p;
                network.e2 = appConfig.pitch_volt   - network.pitch_p;
                network.e3 = appConfig.elbow_volt   - network.elbow_p;
                network.e4 = appConfig.shoulder_volt- network.shoulder_p;
                network.e5 = appConfig.waist_volt   - network.waist_p;


                // ****************************************************************
                // Truncation  <<<<<<  Last Edit, truncation moved the plant input
                // ****************************************************************
                /*
                network.e0 = (float)(Math.Truncate(network.e0 * 100) / 100);
                network.e1 = (float)(Math.Truncate(network.e1 * 100) / 100);
                network.e2 = (float)(Math.Truncate(network.e2 * 100) / 100);
                network.e3 = (float)(Math.Truncate(network.e3 * 100) / 100);
                network.e4 = (float)(Math.Truncate(network.e4 * 100) / 100);
                network.e5 = (float)(Math.Truncate(network.e5 * 100) / 100);
                  */  
                    //
                    //now we calculate the controller response..
                    //
                    if (appConfig.rollOn)
                    {

                        network.roll_c = rollPID.calculate(network.e0);
                        network.roll_c = (float)(Math.Truncate(network.roll_c * 100) / 100);
                    }


                    if (appConfig.yawOn)
                    {

                        network.yaw_c = yawPID.calculate(network.e1);
                        network.yaw_c = (float)(Math.Truncate(network.yaw_c * 100) / 100);
                    }

                    if (appConfig.pitchOn)
                    {

                        network.pitch_c = pitchPID.calculate(network.e2);
                        network.pitch_c = (float)(Math.Truncate(network.pitch_c * 100) / 100);
                    }

                    if (appConfig.elbowOn)
                    {

                        network.elbow_c = elbowPID.calculate(network.e3);
                        network.elbow_c = (float)(Math.Truncate(network.elbow_c * 100) / 100);
                    }

                    if (appConfig.shoulderOn)
                    {

                        network.shoulder_c = shoulderPID.calculate(network.e4);
                        network.shoulder_c = (float)(Math.Truncate(network.shoulder_c * 100) / 100);
                    }


                    if (appConfig.waistOn)
                    {

                        network.waist_c = waistPID.calculate(network.e5);
                        network.waist_c = (float)(Math.Truncate(network.waist_c * 100) / 100);
                    }

                    //
                    // The brakes should be released, sometimes !!
                    //
                    network.brakeBit.Set(0, !appConfig.rollOn);
                    network.brakeBit.Set(1, !appConfig.yawOn);
                    network.brakeBit.Set(2, !appConfig.pitchOn);
                    network.brakeBit.Set(3, !appConfig.elbowOn);
                    network.brakeBit.Set(4, !appConfig.shoulderOn);
                    network.brakeBit.Set(5, !appConfig.waistOn);


                    //
                    // ?? << what is that!
                    //
                    if (!classStatus.controlOn)
                    { pidTimer.Enabled = false;
                      network.control = 0;
                      //network.send();
                    }
                    //
                    // Burst data to our beloved server..
                    //
                    network.send();

                    //
                    // Check for the elapsed time and brake if tuning period elapsed
                    //

                    
                    //
                    // Log data for other operations 
                    //
                    
                
                    // Log normal run data, this includes:
                    // 1-Desired set point
                    // 2-Plant output
                    // 3-Controller response
                    //
                    if (classStatus.controlOn && !classStatus.tunerOn)
                    {
                        //
                        // Add plant output, controller output and desired position to log vectors
                        //

                        if (appConfig.rollOn)
                        {
                            rollP.Add(network.roll_p);
                            rollC.Add(network.roll_c);
                            rollD.Add(appConfig.roll_volt);
                        }


                        if (appConfig.yawOn)
                        {
                            yawP.Add(network.yaw_p);
                            yawC.Add(network.yaw_c);
                            yawD.Add(appConfig.yaw_volt);
                        }


                        if (appConfig.pitchOn)
                        {
                            pitchP.Add(network.pitch_p);
                            pitchC.Add(network.pitch_c);
                            pitchD.Add(appConfig.pitch_volt);
                           
                        }


                        if (appConfig.elbowOn)
                        {
                            elbowP.Add(network.elbow_p);
                            elbowC.Add(network.elbow_c);
                            elbowD.Add(appConfig.elbow_volt);
                        }


                        if (appConfig.shoulderOn)
                        {
                            shoulderP.Add(network.shoulder_p);
                            shoulderC.Add(network.shoulder_c);
                            shoulderD.Add(appConfig.shoulder_volt);
                        }


                        if (appConfig.waistOn)
                        {
                            waistP.Add(network.waist_p);
                            waistC.Add(network.waist_c);
                            waistD.Add(appConfig.waist_volt);
                        }
                    }

                //
                // New Edit <<<<<    This log part is dedicated  to the tuning process
                //
                    if (classStatus.tunerOn)
                    {
                        if (Index < sampleRate)
                        {
                            //
                            // Log the error, we may need it  :D
                            //

                            rollErrLog[Index] = Math.Abs(network.e0);
                            yawErrLog[Index] = Math.Abs(network.e1);
                            pitchErrLog[Index] = Math.Abs(network.e2);
                            elbowErrLog[Index] = Math.Abs(network.e3);
                            shoulderErrLog[Index] = Math.Abs(network.e4);
                            waistErrLog[Index] = Math.Abs(network.e5);

                            /*   errorLog[0, Index] = rollErrLog[Index];
                               errorLog[1, Index] = yawErrLog[Index];
                               errorLog[2, Index] = pitchErrLog[Index];
                               errorLog[3, Index] = elbowErrLog[Index];
                               errorLog[4, Index] = shoulderErrLog[Index];
                               errorLog[5, Index] = waistErrLog[Index];
                               */
                            //
                            // Log plant output
                            //

                            rollPlantLog[Index] = network.roll_p;
                            yawPlantLog[Index] = network.yaw_p;
                            pitchPlantLog[Index] = network.pitch_p;
                            elbowPlantLog[Index] = network.elbow_p;
                            shoulderPlantLog[Index] = network.shoulder_p;
                            waistPlantLog[Index] = network.waist_p;

                            //
                            // Log controller output
                            //

                            rollControllerLog[Index] = network.roll_c;
                            yawControllerLog[Index] = network.yaw_c;
                            pitchControllerLog[Index] = network.pitch_c;
                            elbowControllerLog[Index] = network.elbow_c;
                            shoulderControllerLog[Index] = network.shoulder_c;
                            waistControllerLog[Index] = network.waist_c;

                            Index += 1;
                        }

                         else

                        {

                            //
                            // Save Error & Output vectors
                            // REMOVE THE COMMENT

                            classStatus.rollErrLog = rollErrLog;
                            classStatus.yawErrLog = yawErrLog;
                            classStatus.pitchErrLog = pitchErrLog;
                            classStatus.elbowErrLog = elbowErrLog;
                            classStatus.shoulderErrLog = shoulderErrLog;
                            classStatus.waistErrLog = waistErrLog;

                            classStatus.rollPlantLog = rollPlantLog;
                            classStatus.yawPlantLog = yawPlantLog;
                            classStatus.pitchPlantLog = pitchPlantLog;
                            classStatus.elbowPlantLog = elbowPlantLog;
                            classStatus.shoulderPlantLog = shoulderPlantLog;
                            classStatus.waistPlantLog = waistPlantLog;

                            classStatus.rollControllerLog = rollControllerLog;
                            classStatus.yawControllerLog = yawControllerLog;
                            classStatus.pitchControllerLog = pitchControllerLog;
                            classStatus.elbowControllerLog = elbowControllerLog;
                            classStatus.shoulderControllerLog = shoulderControllerLog;
                            classStatus.waistControllerLog = waistControllerLog;



                        }
                    
                    
                        //*******************************************************
                        /////////////////////// ERROR HERE ///////////////////// TimeSpan Should be used instead of DateTime Objects.
                        //*******************************************************
 
                        // no Action specified at the end of the tune run << specify what will happed when the tuner stops

                        // the joints should be updated one by one, check that also


                        if (Index >= sampleRate)
                        {
                            if ((int)(DateTime.Now - runTime).TotalSeconds >= appConfig.cycleDuration)
                            {
                                brake();
                                pidTimer.Stop();
                                matLog();
                                evalMatLog();
                                // call the zero position function
                                go2zero();
                                //Index = 0;
                                logIndexer += 1;
                                if (logIndexer >= ((tunerList[0].swarmSize) * (tunerList[0].iterations)))
                                {
                                    logIndexer = 0;

                                }
                            }
                        }
                    }
                }

            
        }
        
        private void statusTimer_Tick(object sender, EventArgs e)
        {
            //lblTuneRoll.Text = tunerList[0].iterations.ToString();
            btnController.Enabled =btnTuner.Enabled = btnEmergency.Enabled = classStatus.connected;
            label1.Text = pidTimer.Enabled.ToString();
            lblStatus.Text = zeroTimer.Enabled.ToString();
            //
            // PID parameter monitoring
            //
            lblRollKp.Text = appConfig.roll_kp.ToString();
            lblRollKi.Text = appConfig.roll_ki.ToString();
            lblRollKd.Text = appConfig.roll_kd.ToString();

            // Active when tuner is on


            lblYawKp.Text  = appConfig.yaw_kp.ToString();
            lblYawKi.Text  = appConfig.yaw_ki.ToString();
            lblYawKd.Text  = appConfig.yaw_kd.ToString();
            

            lblPitchKp.Text = appConfig.pitch_kp.ToString();
            lblPitchKi.Text = appConfig.pitch_ki.ToString();
            lblPitchKd.Text = appConfig.pitch_kd.ToString();

            lblElbowKp.Text = appConfig.elbow_kp.ToString();
            lblElbowKi.Text = appConfig.elbow_ki.ToString();
            lblElbowKd.Text = appConfig.elbow_kd.ToString();

            lblShoulderKp.Text = appConfig.shoulder_kp.ToString();
            lblShoulderKi.Text = appConfig.shoulder_ki.ToString();
            lblShoulderKd.Text = appConfig.shoulder_kd.ToString();

            lblWaistKp.Text = appConfig.waist_kp.ToString();
            lblWaistKi.Text = appConfig.waist_ki.ToString();
            lblWaistKd.Text = appConfig.waist_kd.ToString();

            //
            
            //label50.Text = network.e0.ToString();
            if (classStatus.connected)
            {
                lblConnected.BackColor = Color.Lime;
                lblConnected.Text = "CONNECTED";

               // if (classStatus.controlOn)
                
                    if (appConfig.rollOn)
                    {
                        lblControlRoll.BackColor = Color.Lime;
                        lblRollCont.Text = network.roll_c.ToString();
                    }
                    else
                    {
                        lblControlRoll.BackColor = Color.Red;
                    }
                    //
                    //
                    //
                    if (appConfig.yawOn)
                    {
                        lblControlYaw.BackColor = Color.Green;
                        lblYawCont.Text = network.yaw_c.ToString();
                    }
                    else
                    {
                        lblControlYaw.BackColor = Color.Red;
                    }
                    //
                    //
                    //
                    if (appConfig.pitchOn)
                    {
                        lblControlPitch.BackColor = Color.Green;
                        lblPitchCont.Text = network.pitch_c.ToString();
                    }
                    else
                    {
                        lblControlPitch.BackColor = Color.Red;
                    }
                    //
                    //
                    //
                    if (appConfig.elbowOn)
                    {
                        lblControlElbow.BackColor = Color.Green;
                        lblElbowCont.Text = network.elbow_c.ToString();
                    }
                    else
                    {
                        lblControlElbow.BackColor = Color.Red;
                    }
                    //
                    //
                    //

                    if (appConfig.shoulderOn)
                    {
                        lblControlShoulder.BackColor = Color.Green;
                        lblShoulderCont.Text = network.shoulder_c.ToString();
                    }
                    else
                    {
                        lblControlShoulder.BackColor = Color.Red;
                    }
                    //
                    //
                    //

                    if (appConfig.waistOn)
                    {
                        lblControlWaist.BackColor = Color.Green;
                        lblWaistCont.Text = network.waist_c.ToString();
                    }
                    else
                    {
                        lblControlWaist.BackColor = Color.Red;
                    }
                

                //
                // Data monitoring Should be Applied here
                //
                lblRollPlant.Text = network.roll_p.ToString();
                lblYawPlant.Text = network.yaw_p.ToString();
                lblPitchPlant.Text = network.pitch_p.ToString();
                lblElbowPlant.Text = network.elbow_p.ToString();
                lblShoulderPlant.Text = network.shoulder_p.ToString();
                lblWaistPlant.Text = network.waist_p.ToString();
                
            
            
            }// if (connected)

            else
            {
                lblConnected.BackColor = Color.Red;
                lblConnected.Text = "DISCONNECTED";
            }
            
            
            //
            // Tuner status monitoring
            //

            if (classStatus.tunerOn)
            {

                lblJoints.Text = tunerList.Count.ToString(); // joints to tune
                lblSwarm.Text = tunerList[tunerIndex].swarmSize.ToString();  // swarm size
                lblIterations.Text = tunerList[tunerIndex].iterations.ToString(); // number of iterations
                lblJoint.Text = tunerList[tunerIndex].name;  // Current joint "Name"
                lblParticle.Text = tunerList[tunerIndex].particleCounter.ToString();   // Current particle
                lblIteration.Text = tunerList[tunerIndex].iterationCounter.ToString(); // Current iteration


                seconds = tunerList[tunerIndex].swarmSize * tunerList.Count * tunerList[tunerIndex].iterations * appConfig.cycleDuration * 2;
                ts = DateTime.Now - startTime;
                if (ts > required)
                    ts = required;
                required = TimeSpan.FromSeconds(seconds);
                //prgTune.Value = (int)ts.TotalSeconds;
                lblEapsed.Text = TimeSpan.FromSeconds( (int)ts.TotalSeconds).ToString();
                estimated = required - ts;
                lblRequired.Text = required.ToString();
                lblRemaining.Text =TimeSpan.FromSeconds((int) estimated.TotalSeconds).ToString();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
        private void evaluate()
        {
            //pidTimer.Enabled = false;
            
            //
            // Evaluation function
            //
            preEvaluate();
            tunerList[tunerIndex].evaluate(classStatus.evaluationResult);
            Index = 0;


            //***********************************************************
            // Log the evaluation result
            //***********************************************************
            // how about switching to switch / case ???

            //int tempCounter = (tunerList[tunerIndex].iterationCounter) * (tunerList[tunerIndex].particleCounter + 1);
            if (tunerList[tunerIndex].name == "Roll")
            {
                rollEval[logIndexer] = classStatus.evaluationResult;
                rollEvalBest[logIndexer ] = tunerList[tunerIndex].gBestError;
                rollOS[logIndexer] = overShoot(rollErrLog, appConfig.roll_volt);
                rollTr[logIndexer] = riseTime(rollPlantLog, appConfig.roll_volt);
            }

            if (tunerList[tunerIndex].name == "Yaw")
            {
                yawEval[logIndexer ] = classStatus.evaluationResult;
                yawEvalBest[logIndexer ] = tunerList[tunerIndex].gBestError;
                yawOS[logIndexer] = overShoot(yawErrLog, appConfig.yaw_volt);
               yawTr[logIndexer] = riseTime(yawPlantLog, appConfig.yaw_volt);
            }

            if (tunerList[tunerIndex].name == "Pitch")
            {
                pitchEval[logIndexer ] = classStatus.evaluationResult;
                pitchEvalBest[logIndexer ] = tunerList[tunerIndex].gBestError;
                pitchOS[logIndexer] = overShoot(pitchErrLog, appConfig.pitch_volt);
                pitchTr[logIndexer] = riseTime(pitchPlantLog, appConfig.pitch_volt);
            }

            if (tunerList[tunerIndex].name == "Elbow")
            {
                elbowEval[logIndexer] = classStatus.evaluationResult;
                elbowEvalBest[logIndexer] = tunerList[tunerIndex].gBestError;
                elbowOS[logIndexer] = overShoot(elbowErrLog, appConfig.elbow_volt);
                elbowTr[logIndexer] = riseTime(elbowPlantLog, appConfig.elbow_volt);
            }

            if (tunerList[tunerIndex].name == "Shoulder")
            {
                shoulderEval[logIndexer ] = classStatus.evaluationResult;
                shoulderEvalBest[logIndexer ] = tunerList[tunerIndex].gBestError;
                shoulderOS[logIndexer] = overShoot(shoulderErrLog, appConfig.shoulder_volt);
                shoulderTr[logIndexer] = riseTime(shoulderPlantLog, appConfig.shoulder_volt);

            }

            if (tunerList[tunerIndex].name == "Waist")
            {
                waistEval[logIndexer ] = classStatus.evaluationResult;
                waistEvalBest[logIndexer ] = tunerList[tunerIndex].gBestError;
                waistOS[logIndexer] = overShoot(waistErrLog, appConfig.waist_volt);
                waistTr[logIndexer] = riseTime(waistPlantLog, appConfig.waist_volt);
            }

            tunerList[tunerIndex].move();
            
            if (tunerList[tunerIndex].stop)
           
            {
                tunerIndex += 1;

                if (tunerIndex >= tunerList.Count)
                {
                    //
                    // Evaluation log should be written to the log file from here
                    //
                    

                    tunerIndex -= 1;
                    tunerConfiglog();
                    // stop the tuning process
                    // save config
                    classStatus.controlOn = false;
                    classStatus.tunerOn = false;
                    pidTimer.Enabled = false;
                    zeroTimer.Enabled = false;
                   return;
                }
                


            }
            prgTune.Value += 1;
            tuneFunction();

           
       
            //
                // Call tune function
            //cycleCount += 1;
            //
            // Get PID set from the tuner and init the required joint controller
            //
            

            //
            // Get the PID running again
            //
            //button1_Click(null, null);
            
        }

        private void PIDINIT()
        {
            //
            // init controllers b4 the runcf
            //
            rollPID.init(appConfig.roll_kp, appConfig.roll_ki, appConfig.roll_kd, appConfig.sampleTime);
            yawPID.init(appConfig.yaw_kp, appConfig.yaw_ki, appConfig.yaw_kd, appConfig.sampleTime);
            pitchPID.init(appConfig.pitch_kp, appConfig.pitch_ki, appConfig.pitch_kd, appConfig.sampleTime);
            elbowPID.init(appConfig.elbow_kp, appConfig.elbow_ki, appConfig.elbow_kd, appConfig.sampleTime);
            shoulderPID.init(appConfig.shoulder_kp, appConfig.shoulder_ki, appConfig.shoulder_kd, appConfig.sampleTime);
            waistPID.init(appConfig.waist_kp, appConfig.waist_ki, appConfig.waist_kd, appConfig.sampleTime);
            
            Index = 0;
        }

        private void btnEmergency_Click(object sender, EventArgs e)
        {
            if (classStatus.controlOn && !classStatus.tunerOn)
            {
                classStatus.controlOn = false;
                freeTuneLog();

            }
            if (classStatus.tunerOn)
            {
                matLog();
                evalMatLog();
                tunerConfiglog();
                logSaved = true;
                classStatus.tunerOn = false;
            }
            
            
            
            
            pidTimer.Enabled = false;
            zeroTimer.Enabled = false;
        }


        //
        //
        //

        private void pidTimer_Tick_1(object sender, EventArgs e)
        {
            
            PID();

            if (!classStatus.controlOn)
            {
                
                network.control = 0;
                network.send();
                pidTimer.Enabled = false;
            }
        }

        //
        // Log initialization function, inits the log matrices 
        //
        private void logInit()
        {
            sampleRate      = appConfig.cycleDuration*(1000/(int)appConfig.sampleTime);
            maxIterations = appConfig.swarmSize * appConfig.noCycles;
            errorLog        = new float[6, sampleRate];
            plantLog        = new float[6, sampleRate];
            controllerLog   = new float[6, sampleRate];
            //
            // Error Log
            //
            rollErrLog = new float[sampleRate];
            yawErrLog = new float[sampleRate];
            pitchErrLog = new float[sampleRate];
            elbowErrLog = new float[sampleRate];
            shoulderErrLog = new float[sampleRate];
            waistErrLog = new float[sampleRate];

            //
            // Plant Log
            //

            rollPlantLog = new float[sampleRate];
            yawPlantLog = new float[sampleRate];
            pitchPlantLog = new float[sampleRate];
            elbowPlantLog = new float[sampleRate];
            shoulderPlantLog = new float[sampleRate];
            waistPlantLog = new float[sampleRate];

            //
            //Controller Log
            //

            rollControllerLog = new float[sampleRate];
            yawControllerLog = new float[sampleRate];
            pitchControllerLog = new float[sampleRate];
            elbowControllerLog = new float[sampleRate];
            shoulderControllerLog = new float[sampleRate];
            waistControllerLog = new float[sampleRate];

            //
            // Evaluation Log
            //

            float[] rollEval = new float[maxIterations];
            float[] yawEval = new float[maxIterations];
            float[] pitchEval = new float[maxIterations];
            float[] elbowEval = new float[maxIterations];
            float[] shoulderEval = new float[maxIterations];
            float[] waistEval = new float[maxIterations];

            // The following logs are for Gbest particle only

            float[] rollEvalBest = new float[maxIterations];
            float[] yawEvalBest = new float[maxIterations];
            float[] pitchEvalBest = new float[maxIterations];
            float[] elbowEvalBest = new float[maxIterations];
            float[] shoulderEvalBest = new float[maxIterations];
            float[] waistEvalBest = new float[maxIterations];

            //
            // Maximum Overshoot Logging
            //

            float[] rollOS = new float[maxIterations];
            float[] yawOS = new float[maxIterations];
            float[] pitchOS = new float[maxIterations];
            float[] elbowOS = new float[maxIterations];
            float[] shoulderOS = new float[maxIterations];
            float[] waistOS = new float[maxIterations];

            //
            // Rise Time Logging
            //

            float[] rollTr = new float[maxIterations];
            float[] yawTr = new float[maxIterations];
            float[] pitchTr = new float[maxIterations];
            float[] elbowTr = new float[maxIterations];
            float[] shoulderTr = new float[maxIterations];
            float[] waistTr = new float[maxIterations];

        }

        //
        // Integration function ( Trapezoidal rule )
        //
        private float integrator(float[] y, float timePeriod)
        {
            //
            // Edited time period, should be a fix though.
            //Fixed again, added the timeStore variable to get rid of the loob variable
            //
            timePeriod /= 1000f;
            float timeStore = timePeriod;

            for (int i = 0; i < y.Length; i++)
            {
                y[i] = y[i] * timeStore;
                timeStore += timePeriod;
            }

            float result;                    //  <<Integration result
            float t = timePeriod / 2f;       //  << Sampling interval divided by 2
            float temp = 0f;                 //  << Used for storing temporary values
            temp += y[0]+y[sampleRate-1];
            
            for (int count = 1; count < sampleRate-1; count++)
            {
                temp += 2.00f * y[count];
            }

            result = temp * t;

            return result;
        }



        //
        // Zero position function
        //

        private void setZeroPosition()
        {
            // 
            // Set the desired position to zero position
            //
            appConfig.roll_volt     = appConfig.rollZero;
            appConfig.yaw_volt      = appConfig.yawZero;
            appConfig.pitch_volt    = appConfig.pitchZero;
            appConfig.elbow_volt    = appConfig.elbowZero;
            appConfig.shoulder_volt = appConfig.shoulderZero;
            appConfig.waist_volt    = appConfig.waistZero;

           
            
        }

        //
        // Brake functionality, this will be achieved from serverSide
        // by setting the controlOn flag to zero.
        //

        private void brake()
        {
            network.brakeBit.SetAll(true);
            //classStatus.tunerOn = false;
            //classStatus.controlOn = false;

        }

        //
        // Sets the desired position to the tune position
        //
        
        private void setTunePosition()
        {
            appConfig.roll_volt     =appConfig.rollTune;
            appConfig.yaw_volt      =appConfig.yawTune;
            appConfig.pitch_volt    =appConfig.pitchTune;
            appConfig.elbow_volt    =appConfig.elbowTune;
            appConfig.shoulder_volt =appConfig.shoulderTune;
            appConfig.waist_volt=   appConfig.waistTune;
        }

        private void zeroTimer_Tick(object sender, EventArgs e)
        {
            zeroPID();
            if (!classStatus.controlOn)
            {

                network.control = 0;
                network.send();
                zeroTimer.Enabled = false;
            }
        }

        //
        // A function that is called after the end of a tune cycle..
        //
        private void tunerInit()
        {

            if (appConfig.rollTuneOn)
            { 
                tunerList.Add(new Swarm("Roll"));
               // appConfig.rollOn = true;
            }

            if (appConfig.yawTuneOn)
            {
                tunerList.Add(new Swarm("Yaw"));
                
               // appConfig.yawOn = true;
            }

            if (appConfig.pitchTuneOn)
            { 
                tunerList.Add(new Swarm("Pitch"));
               // appConfig.pitchOn = true;
            }

            if (appConfig.elbowTuneOn)
            { 
                tunerList.Add(new Swarm("Elbow"));
               // appConfig.elbowOn = true;
            }

            if (appConfig.shoulderTuneOn)
            { 
                tunerList.Add(new Swarm("Shoulder"));
               // appConfig.shoulderOn = true;
            }

            if (appConfig.waistTuneOn)
            { 
                tunerList.Add(new Swarm("Waist"));
               // appConfig.waistOn = true;
            }

            //
            // Init the swarms before scaring the poor particles
            //

            //
            // Temp fix for RND Shit
            //
                int xx = appConfig.swarmSize*appConfig.noCycles;

            for (int i = 0; i < tunerList.Count; i++)
            {
                tunerList[i].swarmInit();

                switch (tunerList[i].name)
                {
                        
                    case "Yaw":
                        tunerList[i].bypass(xx);
                        break;
                    case "Pitch":
                        tunerList[i].bypass(2*xx);
                        break;
                    case "Elbow":
                        tunerList[i].bypass(3 * xx);
                        break;
                    case "Shoulder":
                        tunerList[i].bypass(4 * xx);
                        break;
                    case "Waist":
                        tunerList[i].bypass(5 * xx);
                        break;
                    default :
                        tunerList[i].bypass(6 * xx);
                        break;

                }

                
            }

            //
            // we need to call tuner initialization
            //FIXED

           //
           // Init the evaluation logging
           //
            int totalCount  = appConfig.noCycles*appConfig.swarmSize;
            rollEval        = new float[totalCount];
            yawEval         = new float[totalCount];
            pitchEval       = new float[totalCount];
            elbowEval       = new float[totalCount];
            shoulderEval    = new float[totalCount];
            waistEval       = new float[totalCount];

            rollEvalBest        = new float[totalCount];
            yawEvalBest         = new float[totalCount];
            pitchEvalBest       = new float[totalCount];
            elbowEvalBest       = new float[totalCount];
            shoulderEvalBest    = new float[totalCount];
            waistEvalBest       = new float[totalCount];

            //
            // Maximum Overshoot logging
            //
            rollOS = new float[totalCount];
            yawOS = new float[totalCount];
            pitchOS = new float[totalCount];
            elbowOS = new float[totalCount];
            shoulderOS = new float[totalCount];
            waistOS = new float[totalCount];

            //
            // Rise Time Logging
            //

            rollTr = new float[totalCount];
            yawTr = new float[totalCount];
            pitchTr = new float[totalCount];
            elbowTr = new float[totalCount];
            shoulderTr = new float[totalCount];
            waistTr = new float[totalCount];
        }

        //
        // A function that is called after the start of a tune cycle..
        //
        private void tuneBeginPass()
        {

        }

        private void tuneRollInit()
        {
            if (appConfig.rollTuneOn)
            {
                //
                // Get PID parameters from tuner..
                // Save for logging .. 
                //
                
                // A call for the searchSpace needs to be done to get the PID set
                position0 = tunerList[tunerIndex].updatePosition();  // A method edited in the sourceCode used prior to MoveThenAdapt

                // to get the current position.
                appConfig.rollOn = true;
                appConfig.roll_kp = classStatus.kp = position0[0];
                appConfig.roll_ki = classStatus.ki = position0[1];
                appConfig.roll_kd = classStatus.kd = position0[2];
                // Init
                rollPID.init(appConfig.roll_kp, appConfig.roll_ki, appConfig.roll_kd, appConfig.sampleTime);
            }
        }

        private void tuneYawInit()
        {
            if (appConfig.yawTuneOn)
            {
                

                appConfig.yawOn = true;
                position1 = tunerList[tunerIndex].updatePosition();  // A method edited in the sourceCode used prior to MoveThenAdapt
                appConfig.yaw_kp = classStatus.kp = position1[0];
                appConfig.yaw_ki = classStatus.ki = position1[1];
                appConfig.yaw_kd = classStatus.kd = position1[2];
                yawPID.init(appConfig.yaw_kp, appConfig.yaw_ki, appConfig.yaw_kd, appConfig.sampleTime);
            }
        }

        private void tunePitchInit()
        {
            if (appConfig.pitchTuneOn)
            {
                
                appConfig.pitchOn = true;
                position2 = tunerList[tunerIndex].updatePosition();  // A method edited in the sourceCode used prior to MoveThenAdapt
                appConfig.pitch_kp = classStatus.kp = position2[0];
                appConfig.pitch_ki = classStatus.ki = position2[1];
                appConfig.pitch_kd = classStatus.kd = position2[2];
                pitchPID.init(appConfig.pitch_kp, appConfig.pitch_ki, appConfig.pitch_kd, appConfig.sampleTime);
            }
        }

        private void tuneElbowInit()
        {
            if (appConfig.elbowTuneOn)
            {
                
                appConfig.elbowOn=true;
                position3 = tunerList[tunerIndex].updatePosition();  // A method edited in the sourceCode used prior to MoveThenAdapt
                appConfig.elbow_kp = classStatus.kp = position3[0];
                appConfig.elbow_ki = classStatus.ki = position3[1];
                appConfig.elbow_kd = classStatus.kd = position3[2];
                elbowPID.init(appConfig.elbow_kp, appConfig.elbow_ki, appConfig.elbow_kd, appConfig.sampleTime);
            }
        }

        private void tuneShoulderInit()
        {
            if (appConfig.shoulderTuneOn)
            {
                
                appConfig.shoulderOn = true;
                position4 = tunerList[tunerIndex].updatePosition();  // A method edited in the sourceCode used prior to MoveThenAdapt
                appConfig.shoulder_kp = classStatus.kp = position4[0];
                appConfig.shoulder_ki = classStatus.ki = position4[1];
                appConfig.shoulder_kd = classStatus.kd = position4[2];
                shoulderPID.init(appConfig.shoulder_kp, appConfig.shoulder_ki, appConfig.shoulder_kd, appConfig.sampleTime);
            }
        }

        private void tuneWaistInit()
        {
            if (appConfig.waistTuneOn)
            {
               
                appConfig.waistOn = true;
                position5 = tunerList[tunerIndex].updatePosition(); 
                appConfig.waist_kp = classStatus.kp = position5[0];
                appConfig.waist_ki = classStatus.ki = position5[1];
                appConfig.waist_kd = classStatus.kd = position5[2];
                waistPID.init(appConfig.waist_kp, appConfig.waist_ki, appConfig.waist_kd, appConfig.sampleTime);
            }
        }


        //
        // A function used to calculate the ovrshoot
        //

        private float overShoot(float[] plantVector, float setPosition)
        {

            float max = 0,result = 0;
            result = plantVector[0];

            for (int i = 0; i < plantVector.Length; i++)
            {
                plantVector[i] = Math.Abs(plantVector[i]);
                if (plantVector[i] > setPosition)
                {
                    if (plantVector[i] > max)
                        max = plantVector[i];
                }
            }

            // Fix edit, to cover the state were no overshoot exists.
            if (max != plantVector[0])
            {
                result = ((max - setPosition) / setPosition) * 100f;
            }
            else
                result = 0;

            return result;
        }

        //
        // A function that is used to calculate the rise time(Tr)
        //

        private float riseTime(float[] plantOut, float setPoint)
        {

            //
            // Fixed, added incremental time calaculation to prevent
            // intermediate errors and isolated the loop variable, should be working now.
            //


            float Tr = 0;
            float limit = 0.9f * setPoint;
            float temp;
            float incrementFactor=0;
            float timeStrip = appConfig.sampleTime / 1000;

            for (int i = 0; i < plantOut.Length; i++)
            {
                incrementFactor += timeStrip;

                temp = Math.Abs (plantOut[i]);
                if (temp >= limit)
                {
                    Tr = incrementFactor ;
                    break;
                }
                else
                    Tr = 0;
            }

            return Tr;
        }
        //
        //A function that is executed before the evaluate function
        //
        private void preEvaluate()
        {
            

            if (tunerList[tunerIndex].name == "Roll")
            {

                classStatus.evaluationResult = integrator(rollErrLog, appConfig.sampleTime);// + overShoot(rollPlantLog, appConfig.roll_volt) + riseTime(rollPlantLog, appConfig.roll_volt);
            }


            if (tunerList[tunerIndex].name == "Yaw")
            {
                classStatus.evaluationResult = integrator(yawErrLog, appConfig.sampleTime);// + overShoot(yawPlantLog, appConfig.yaw_volt) + riseTime(yawPlantLog, appConfig.yaw_volt);
            }

            if (tunerList[tunerIndex].name == "Pitch")
            {
                classStatus.evaluationResult = integrator(pitchErrLog, appConfig.sampleTime);// + overShoot(pitchPlantLog, appConfig.pitch_volt) + riseTime(pitchPlantLog, appConfig.pitch_volt);
            }

            if (tunerList[tunerIndex].name == "Elbow")
            {
                classStatus.evaluationResult = integrator(elbowErrLog, appConfig.sampleTime);//+ overShoot(elbowPlantLog, appConfig.elbow_volt) + riseTime(elbowPlantLog, appConfig.elbow_volt);
            }

            if (tunerList[tunerIndex].name == "Shoulder")
            {
                classStatus.evaluationResult = integrator(shoulderErrLog, appConfig.sampleTime);// + overShoot(shoulderPlantLog, appConfig.shoulder_volt) + riseTime(shoulderPlantLog, appConfig.shoulder_volt);
            }

            if (tunerList[tunerIndex].name == "Waist")
            {
                classStatus.evaluationResult = integrator(waistErrLog, appConfig.sampleTime);// +overShoot(waistPlantLog, appConfig.waist_volt) + riseTime(waistPlantLog, appConfig.waist_volt);
            }

            
        }

        private void btnTuner_Click(object sender, EventArgs e)
        {
            classStatus.tunerOn = true;
            //tunerList[tunerIndex].swarmInit();
           //
           // code needed to activate the shit here

            // set the tuner start time
            startTime = DateTime.Now;
            tunerInit();
            tuneFunction();
            prgTune.Value = 1;
        }

        private void tuneFunction()
        {
            classStatus.tunerOn = true;

            if (classStatus.tunerOn)
            {
                // initialize the desired joint tuners
               // tunerInit();
                // reset pid tune position
                setTunePosition();

                // set up the tuner progress bar

                prgTune.Maximum = tunerList[0].swarmSize * tunerList.Count *
                    tunerList[0].iterations ;

                // init pid
                pidTuneInit(); // get parameters from the tuners

                PIDINIT(); // set them

                // start pid
                PIDStart();
                status_timer();
            }
        }

        private void PIDStart()
        {
            //classStatus.tunerOn = true;
            if (!classStatus.controlOn)
            {
                network.control = 1;
                network.send();
                classStatus.controlOn = true;
            }

            pidTimer.Interval = (int)appConfig.sampleTime;
            pidTimer.Enabled=true;
            
            // a runtime variable needs to be specified
            runTime = DateTime.Now;
        }//PIDStart

        private void go2zero()
        {
            //classStatus.tunerOn = true;
            //setZeroPosition();
            safeMode();
            if(!classStatus.controlOn)
            {
                network.control = 1;
                network.send();
                classStatus.controlOn = true;
            }

            zeroTimer.Interval = (int)appConfig.sampleTime;
            
            zeroTimer.Start();

            //
            // Set the watch dog
            //

            zeroRun = DateTime.Now;
        }

        private void safeMode()
        {
            appConfig.safeMode();
            PIDINIT();
        }

        private void zeroPID()
        {
            // Check if controller should be stopped

            if (classStatus.controlOn)
            {


                //
                // Hear server barfing..
                //
                network.receive();


                //
                // Calculate error terms, protocol integrity should be maintained  ;)
                //

                network.e0 = appConfig.rollZero - network.roll_p;
                network.e1 = appConfig.yawZero - network.yaw_p;
                network.e2 = appConfig.pitchZero - network.pitch_p;
                network.e3 = appConfig.elbowZero - network.elbow_p;
                network.e4 = appConfig.shoulderZero - network.shoulder_p;
                network.e5 = appConfig.waistZero - network.waist_p;


                //
                // Truncation
                //

                network.e0 = (float)(Math.Truncate(network.e0 * 100) / 100);
                network.e1 = (float)(Math.Truncate(network.e1 * 100) / 100);
                network.e2 = (float)(Math.Truncate(network.e2 * 100) / 100);
                network.e3 = (float)(Math.Truncate(network.e3 * 100) / 100);
                network.e4 = (float)(Math.Truncate(network.e4 * 100) / 100);
                network.e5 = (float)(Math.Truncate(network.e5 * 100) / 100);
                
                //
                //now we calculate the controller response..
                //
                if (appConfig.rollOn)
                {

                    network.roll_c = rollPID.calculate(network.e0);
                }


                if (appConfig.yawOn)
                {

                    network.yaw_c = yawPID.calculate(network.e1);
                }

                if (appConfig.pitchOn)
                {

                    network.pitch_c = pitchPID.calculate(network.e2);
                }

                if (appConfig.elbowOn)
                {

                    network.elbow_c = elbowPID.calculate(network.e3);
                }

                if (appConfig.shoulderOn)
                {

                    network.shoulder_c = shoulderPID.calculate(network.e4);
                }


                if (appConfig.waistOn)
                {

                    network.waist_c = waistPID.calculate(network.e5);
                }

                //
                // The brakes should be released, sometimes !!
                //
                network.brakeBit.Set(0, !appConfig.rollOn);
                network.brakeBit.Set(1, !appConfig.yawOn);
                network.brakeBit.Set(2, !appConfig.pitchOn);
                network.brakeBit.Set(3, !appConfig.elbowOn);
                network.brakeBit.Set(4, !appConfig.shoulderOn);
                network.brakeBit.Set(5, !appConfig.waistOn);


                //
                // ?? << what is that!
                //
                if (!classStatus.controlOn)
                {
                    pidTimer.Enabled = false;
                    network.control = 0;
                    //network.send();
                }
                //
                // Burst data to our beloved server..
                //
                network.send();

                //
                // Check for the elapsed time and brake if tuning period elapsed
                //

                if (((DateTime.Now - zeroRun).TotalSeconds >=(float) appConfig.cycleDuration))
                {
                    brake();
                    zeroTimer.Stop();
                    evaluate();

                    //
                    // Check for stop condition
                    //

                  

                    
                }

                
            }

        }

        //
        // Calculate total required cycles for tuning
        public void tuneMetrics()
        {
            
            int[] result = new int[6];
            
            result[0] = tunerList.Count; // joints to tune
            result[1] = tunerList[tunerIndex].iterations; // number of iterations
            result[2] = tunerList[tunerIndex].swarmSize;  // swarm size
            result[3] = sampleRate;  // number of samples for each cycle
            result[4] = (int)appConfig.sampleTime; // sampling time(milliseconds)
            result[5] = appConfig.cycleDuration; // tune cycle duration
            hc.metrics= result;
        }

        public void currentTuneMetrics()
        {
             
            int[] result = new int[3];
            result[0] = tunerIndex;
            result[1] = tunerList[tunerIndex].iterationCounter;
            result[2] = tunerList[tunerIndex].particleCounter; 

            hc.currentMetrics= result;
        }

        public void currentJointName()
        {
             
            hc.name= tunerList[tunerIndex].name;
        }

        private void calibratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sequencer_form.Show();
        }

        //
        // A function used to get the newpid parameters from the tuners
        //
        private void pidTuneInit()
        {
            //for (int i = 0; i < tunerList.Count; i++)
           // {
                switch (tunerList[tunerIndex].name)
                {
                    case "Roll":
                        tuneRollInit();

                        break;

                    case "Yaw":
                        tuneYawInit();

                        break;

                    case "Pitch":
                        tunePitchInit();

                        break;

                    case "Elbow":
                        tuneElbowInit();

                        break;

                    case "Shoulder":
                        tuneShoulderInit();


                        break;

                    case "Waist":
                        tuneWaistInit();
                        break;

                }

            //}

        }


        private void matLog()
        {
            //
            // Construct mat single arrays that hold log data
            // This is preliminary in order to save them to the log list
            //
            idx = logIndexer.ToString();
            //
            // Error Matrices
            //
            if (tunerList.Count != 0)
            {
                if (tunerList[tunerIndex].name == "Roll")
                {
                    filename1 = appConfig.logDir + "\\Roll.mat";
                    MLSingle rollErr = new MLSingle("RE" + idx, rollErrLog, 1); // Error
                    MLSingle rollPlnt = new MLSingle("RP" + idx, rollPlantLog, 1);// Plant Output
                    MLSingle rollCnt = new MLSingle("RC" + idx, rollControllerLog, 1);// Controller Output
                    MLSingle RPID = new MLSingle("RPID" + idx, position0, 1);// PID set
                    //
                    //Write data to log lists
                    //

                    rollLogList.Add(rollErr);
                    rollLogList.Add(rollPlnt);
                    rollLogList.Add(rollCnt);
                    rollLogList.Add(RPID);

                    //   MatFileWriter mfw1 = new MatFileWriter(filename1, rollLogList, true);

                }
                //---------------------------------------------------------------------------------

                if (tunerList[tunerIndex].name == "Yaw")
                {
                    filename2 = appConfig.logDir + "\\Yaw.mat";
                    MLSingle yawErr = new MLSingle("YE" + idx, yawErrLog, 1);
                    MLSingle yawPlnt = new MLSingle("YP" + idx, yawPlantLog, 1);
                    MLSingle yawCnt = new MLSingle("YC" + idx, yawControllerLog, 1);
                    MLSingle YPID = new MLSingle("YPID" + idx, position1, 1);

                    yawLogList.Add(yawErr);
                    yawLogList.Add(yawPlnt);
                    yawLogList.Add(yawCnt);
                    yawLogList.Add(YPID);

                    //   MatFileWriter mfw2 = new MatFileWriter(filename2, yawLogList, true);
                }
                //---------------------------------------------------------------------------------

                if (tunerList[tunerIndex].name == "Pitch")
                {
                    filename3 = appConfig.logDir + "\\Pitch.mat";
                    MLSingle pitchErr = new MLSingle("PE" + idx, pitchErrLog, 1);
                    MLSingle pitchPlnt = new MLSingle("PP" + idx, pitchPlantLog, 1);
                    MLSingle pitchCnt = new MLSingle("PC" + idx, pitchControllerLog, 1);
                    MLSingle PPID = new MLSingle("PPID" + idx, position2, 1);

                    pitchLogList.Add(pitchErr);
                    pitchLogList.Add(pitchPlnt);
                    pitchLogList.Add(pitchCnt);
                    pitchLogList.Add(PPID);

                    //  MatFileWriter mfw3 = new MatFileWriter(filename3, pitchLogList, true);
                }
                //---------------------------------------------------------------------------------

                if (tunerList[tunerIndex].name == "Elbow")
                {

                    filename4 = appConfig.logDir + "\\Elbow.mat";
                    MLSingle elbowErr = new MLSingle("EE" + idx, elbowErrLog, 1);
                    MLSingle elbowPlnt = new MLSingle("EP" + idx, elbowPlantLog, 1);
                    MLSingle elbowCnt = new MLSingle("EC" + idx, elbowControllerLog, 1);
                    MLSingle EPID = new MLSingle("EPID" + idx, position3, 1);

                    elbowLogList.Add(elbowErr);
                    elbowLogList.Add(elbowPlnt);
                    elbowLogList.Add(elbowCnt);
                    elbowLogList.Add(EPID);

                    //  MatFileWriter mfw4 = new MatFileWriter(filename4, elbowLogList, true);
                }
                //---------------------------------------------------------------------------------

                if (tunerList[tunerIndex].name == "Shoulder")
                {

                    filename5 = appConfig.logDir + "\\Shoulder.mat";
                    MLSingle shoulderErr = new MLSingle("SE" + idx, shoulderErrLog, 1);
                    MLSingle shoulderPlnt = new MLSingle("SP" + idx, shoulderPlantLog, 1);
                    MLSingle shoulderCnt = new MLSingle("SC" + idx, shoulderControllerLog, 1);
                    MLSingle SPID = new MLSingle("SPID" + idx, position4, 1);

                    shoulderLogList.Add(shoulderErr);
                    shoulderLogList.Add(shoulderPlnt);
                    shoulderLogList.Add(shoulderCnt);
                    shoulderLogList.Add(SPID);

                    //  MatFileWriter mfw5 = new MatFileWriter(filename5, shoulderLogList, true);
                }
                //---------------------------------------------------------------------------------

                if (tunerList[tunerIndex].name == "Waist")
                {
                    filename6 = appConfig.logDir + "\\Waist.mat";
                    MLSingle waistErr = new MLSingle("WE" + idx, waistErrLog, 1);
                    MLSingle waistPlnt = new MLSingle("WP" + idx, waistPlantLog, 1);
                    MLSingle waistCnt = new MLSingle("WC" + idx, waistControllerLog, 1);
                    MLSingle WPID = new MLSingle("WPID" + idx, position5, 1);
                    waistLogList.Add(waistErr);
                    waistLogList.Add(waistPlnt);
                    waistLogList.Add(waistCnt);
                    waistLogList.Add(WPID);

                    // MatFileWriter mfw6 = new MatFileWriter(filename6, waistLogList, true);
                }
            }
            //---------------------------------------------------------------------------------

            // logIndexer += 1;
            //Index = 0;
        }

        private void loggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_window.Show();
        }

        //
        // A function that logs the evaluation result at the end of the tuning shift
        //
        private void evalMatLog()
        {
            //
            // Construct mat single arrays that hold log data
            // This is preliminary in order to save them to the log list
            //
            idx = logIndexer.ToString();
            //
            // Error Matrices
            //

            if (tunerList[tunerIndex].name == "Roll")
            {
                filename1 = appConfig.logDir + "\\Roll" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle rollEvaluation = new MLSingle("REval" + idx, rollEval, 1); // Evaluation Result
                MLSingle rollEvaluationBest = new MLSingle("REvalBest" + idx, rollEvalBest, 1); // Evaluation Result
                MLSingle rollOverShoot = new MLSingle("ROS" + idx, rollOS, 1); // Maximum Overshoot Result
                MLSingle rollRiseTime = new MLSingle("RTr" + idx, rollTr, 1);  // Rise Time
                //
                //Write data to log lists
                //

                rollLogList.Add(rollEvaluation);
                rollLogList.Add(rollEvaluationBest);
                rollLogList.Add(rollOverShoot);
                rollLogList.Add(rollRiseTime);

               // MatFileWriter mfw1 = new MatFileWriter(filename1, rollLogList, true);

            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Yaw")
            {
                filename2 = appConfig.logDir + "\\Yaw" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle yawEvaluation = new MLSingle("YEval" + idx, yawEval, 1);
                MLSingle yawEvaluationBest = new MLSingle("YEvalBest" + idx, yawEvalBest, 1);
                MLSingle yawOverShoot = new MLSingle("YOS" + idx, yawOS, 1);
                MLSingle yawRiseTime = new MLSingle("YTr" + idx, yawTr, 1);

                yawLogList.Add(yawEvaluation);
                yawLogList.Add(yawEvaluationBest);
                yawLogList.Add(yawOverShoot);
                yawLogList.Add(yawRiseTime);

             //   MatFileWriter mfw2 = new MatFileWriter(filename2, yawLogList, true);
            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Pitch")
            {
                filename3 = appConfig.logDir + "\\Pitch" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle pitchEvaluation = new MLSingle("PEval" + idx, pitchEval, 1);
                MLSingle pitchEvaluationBest = new MLSingle("PEvalBest" + idx, pitchEvalBest, 1);
                MLSingle pitchOverShoot = new MLSingle("POS" + idx, pitchOS, 1);
                MLSingle pitchRiseTime = new MLSingle("PTr" + idx, pitchTr, 1);

                pitchLogList.Add(pitchEvaluation);
                pitchLogList.Add(pitchEvaluationBest);
                pitchLogList.Add(pitchOverShoot);
                pitchLogList.Add(pitchRiseTime);

             //   MatFileWriter mfw3 = new MatFileWriter(filename3, pitchLogList, true);
            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Elbow")
            {

                filename4 = appConfig.logDir + "\\Elbow" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle elbowEvaluation = new MLSingle("EEval" + idx, elbowEval, 1);
                MLSingle elbowEvaluationBest = new MLSingle("EEvalBest" + idx, elbowEvalBest, 1);
                MLSingle elbowOverShoot = new MLSingle("EOS" + idx, elbowOS, 1);
                MLSingle elbowRiseTime = new MLSingle("ETr" + idx, elbowTr, 1);

                elbowLogList.Add(elbowEvaluation);
                elbowLogList.Add(elbowEvaluationBest);
                elbowLogList.Add(elbowOverShoot);
                elbowLogList.Add(elbowRiseTime);

              //  MatFileWriter mfw4 = new MatFileWriter(filename4, elbowLogList, true);
            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Shoulder")
            {

                filename5 = appConfig.logDir + "\\Shoulder" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle shoulderEvaluation = new MLSingle("SEval" + idx, shoulderEval, 1);
                MLSingle shoulderEvaluationBest = new MLSingle("SEvalBest" + idx, shoulderEvalBest, 1);
                MLSingle shoulderOverShoot = new MLSingle("SOS" + idx, shoulderOS, 1);
                MLSingle shoulderRiseTime = new MLSingle("STr" + idx, shoulderTr, 1);

                shoulderLogList.Add(shoulderEvaluation);
                shoulderLogList.Add(shoulderEvaluationBest);
                shoulderLogList.Add(shoulderOverShoot);
                shoulderLogList.Add(shoulderRiseTime);

              //  MatFileWriter mfw5 = new MatFileWriter(filename5, shoulderLogList, true);
            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Waist")
            {
                filename6 = appConfig.logDir + "\\Waist" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle waistEvaluation = new MLSingle("WEval" + idx, waistEval, 1);
                MLSingle waistEvaluationBest = new MLSingle("WEvalBest" + idx, waistEvalBest, 1);
                MLSingle waistOverShoot = new MLSingle("WOS" + idx, waistOS, 1);
                MLSingle waistRiseTime = new MLSingle("WTr" + idx, waistTr, 1);

                waistLogList.Add(waistEvaluation);
                waistLogList.Add(waistEvaluationBest);
                waistLogList.Add(waistOverShoot);
                waistLogList.Add(waistRiseTime);

              //  MatFileWriter mfw6 = new MatFileWriter(filename6, waistLogList, true);


               
            }
            //---------------------------------------------------------------------------------

            // logIndexer += 1;
            //Index = 0;
        }

        private void tunerConfiglog()
        {
            //
            // It is just getting shitty, so we will delay log writing procedures
            //
            if (tunerList[tunerIndex].name == "Roll")
            {
                MatFileWriter mfw1 = new MatFileWriter(filename1, rollLogList, true);

            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Yaw")
            {
                MatFileWriter mfw2 = new MatFileWriter(filename2, yawLogList, true);
            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Pitch")
            {
                MatFileWriter mfw3 = new MatFileWriter(filename3, pitchLogList, true);
            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Elbow")
            {

                MatFileWriter mfw4 = new MatFileWriter(filename4, elbowLogList, true);
            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Shoulder")
            {
                MatFileWriter mfw5 = new MatFileWriter(filename5, shoulderLogList, true);
            }
            //---------------------------------------------------------------------------------

            if (tunerList[tunerIndex].name == "Waist")
            {
                MatFileWriter mfw6 = new MatFileWriter(filename6, waistLogList, true);
            }
            //
            // Write tuner config
            //
            filename7 = appConfig.logDir + "\\Summary-" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".txt";
            StreamWriter configWriter = File.CreateText(filename7);
            configWriter.WriteLine("*************************************************");
            configWriter.WriteLine("********************  SUMMARY  ******************");
            configWriter.WriteLine("*************************************************");
            configWriter.WriteLine("This file was written on : " + DateTime.Now.ToString("dd.MM.yyyy  HH:mm:ss"));
            configWriter.WriteLine();
            configWriter.WriteLine("Swarm Size              : " + appConfig.swarmSize.ToString());
            configWriter.WriteLine("Number of Tuning Cycles : " + appConfig.noCycles.ToString());
            configWriter.WriteLine("Cycle Duration : " + appConfig.cycleDuration.ToString());
            configWriter.WriteLine("Cognitive Acceleration Factor (C1) : " + appConfig.c1.ToString());
            configWriter.WriteLine("Social Acceleration Factor    (C2) : " + appConfig.c2.ToString());
            configWriter.WriteLine("Joints PID`s Tuned : " + tunerList.Count.ToString());

            for (int i = 0; i < tunerList.Count; i++)
            {
                configWriter.WriteLine("Joint " + i.ToString() + " : " + tunerList[i].name);

                configWriter.WriteLine("Best PID Gain Set Found : " + tunerList[i].gBest[0].ToString() +
                    " || " + tunerList[i].gBest[1].ToString() + " || " + tunerList[i].gBest[2].ToString());

                configWriter.WriteLine("Particle " + tunerList[i].particleCounter.ToString() + ", Iteration " + tunerList[i].iterationCounter.ToString());
                configWriter.WriteLine("Evaluation Function Value : "+tunerList[i].gBestError.ToString());
                configWriter.WriteLine();
            }
            configWriter.WriteLine("Time Spent : " + lblEapsed.Text);

            configWriter.WriteLine("***************************************************");
            configWriter.WriteLine("*********************** EOF ***********************");
            configWriter.WriteLine("***************************************************");
            
            configWriter.Close();
        }

        public void deg2voltTune()
        {
            float x1=appConfig.rollDegTune;
            float x2=appConfig.yawDegTune;
            float x3=appConfig.pitchDegTune;
            float x4=appConfig.elbowDegTune;
            float x5=appConfig.shoulderDegTune;
            float x6=appConfig.waistDegTune;


            // first three joints haven`t added yet
            appConfig.waistTune = 0.000000002491f * (float)Math.Pow(x6, 4) - 0.0000014687f *
                (float)Math.Pow(x6, 3) + 0.00027265f * (float)Math.Pow(x6, 2) - 0.029733f * x6 +
                4.1412f;

            appConfig.shoulderTune = 0.013944f * x5 + 1.2493f;

            appConfig.elbowTune = 0.013643f * x4 + 1.5164f;

        }

        public void deg2voltZero()
        {
            float x1 = appConfig.rollDegZero;
            float x2 = appConfig.yawDegZero;
            float x3 = appConfig.pitchDegZero;
            float x4 = appConfig.elbowDegZero;
            float x5 = appConfig.shoulderDegZero;
            float x6 = appConfig.waistDegZero;


            // first three joints haven`t added yet
            appConfig.waistZero = 0.000000002491f * (float)Math.Pow(x6, 4) - 0.0000014687f *
                (float)Math.Pow(x6, 3) + 0.00027265f * (float)Math.Pow(x6, 2) - 0.029733f * x6 +
                4.1412f;

            appConfig.shoulderZero = 0.013944f * x5 + 1.2493f;

            appConfig.elbowZero = 0.013643f * x4 + 1.5164f;

        }

        public void deg2volt()
        {
            float x1 = appConfig.roll_deg;
            float x2 = appConfig.yaw_deg;
            float x3 = appConfig.pitch_deg;
            float x4 = appConfig.elbow_deg;
            float x5 = appConfig.shoulder_deg;
            float x6 = appConfig.waist_deg;


            // first three joints haven`t added yet
            appConfig.waist_volt = 0.000000002491f * (float)Math.Pow(x6, 4) - 0.0000014687f *
                (float)Math.Pow(x6, 3) + 0.00027265f * (float)Math.Pow(x6, 2) - 0.029733f * x6 +
                4.1412f;

            appConfig.shoulder_volt = 0.013944f * x5 + 1.2493f;

            appConfig.elbow_volt = 0.013643f * x4 + 1.5164f;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            // This is the first idea
            //
            
            /*
            classStatus.controlOn = false;
            classStatus.tunerOn = false;
            pidTimer.Enabled = false;
            zeroTimer.Enabled = false;
            matLog();
            evalMatLog();
            tunerConfiglog();
             * */
            //
            //this is the seconds Idea, a dialog box
            //

            if (!logSaved&& classStatus.tunerOn)
            {
                DialogResult extRes = MessageBox.Show("Data saving is forced since 11/9, saving now..."
                    , "Saving log data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                if (extRes == DialogResult.OK)
                {
                    classStatus.controlOn = false;
                    classStatus.tunerOn = false;
                    pidTimer.Enabled = false;
                    zeroTimer.Enabled = false;
                    matLog();
                    evalMatLog();
                    tunerConfiglog();
                }
                else
                {
                    classStatus.controlOn = false;
                    classStatus.tunerOn = false;
                    pidTimer.Enabled = false;
                    zeroTimer.Enabled = false;
                    matLog();
                    evalMatLog();
                    tunerConfiglog();
                }
            }
        }

        //
        // Afunction to log the free run data
        //
        private void freeTuneLog()
        {
            //
            // Add new directory for the free run log
            //
            DirectoryInfo freeRunDir = new DirectoryInfo(@appConfig.logDir + "\\Free Run");
            freeRunDir.Create();
            
            // Construct mat single arrays that hold log data
            // This is preliminary in order to save them to the log list
            //

            //
            // Error Matrices
            //
            if (appConfig.rollOn)
            {
                filename11 = freeRunDir.FullName + "\\Roll" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle rollPP = new MLSingle("RP", rollP.ToArray(), 1); // Plant Output
                MLSingle rollCC = new MLSingle("RC", rollC.ToArray(), 1); // Controller Output
                MLSingle rollDD = new MLSingle("RD", rollD.ToArray(), 1); // Desired Value

                //
                //Write data to log lists
                //

                rollresList.Add(rollPP);
                rollresList.Add(rollCC);
                rollresList.Add(rollDD);


                   MatFileWriter mfw11 = new MatFileWriter(filename11, rollresList, true);

            }
            //---------------------------------------------------------------------------------

            if (appConfig.yawOn)
            {
                filename22 = freeRunDir.FullName + "\\Yaw" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle yawPP = new MLSingle("YP", yawP.ToArray(), 1); // Plant Output
                MLSingle yawCC = new MLSingle("YC", yawC.ToArray(), 1); // Controller Output
                MLSingle yawDD = new MLSingle("YD", yawD.ToArray(), 1); // Desired Value

                //
                //Write data to log lists
                //

                yawresList.Add(yawPP);
                yawresList.Add(yawCC);
                yawresList.Add(yawDD);


                   MatFileWriter mfw22 = new MatFileWriter(filename22, yawresList, true);

            }
            //---------------------------------------------------------------------------------

            if (appConfig.pitchOn)
            {
                filename33 = freeRunDir.FullName + "\\Pitch" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle pitchPP = new MLSingle("PP", pitchP.ToArray(), 1); // Plant Output
                MLSingle pitchCC = new MLSingle("PC", pitchC.ToArray(), 1); // Controller Output
                MLSingle pitchDD = new MLSingle("PD", pitchD.ToArray(), 1); // Desired Value

                //
                //Write data to log lists
                //

                pitchresList.Add(pitchPP);
                pitchresList.Add(pitchCC);
                pitchresList.Add(pitchDD);


                   MatFileWriter mfw33 = new MatFileWriter(filename33, pitchresList, true);

            }
            //---------------------------------------------------------------------------------

            if (appConfig.elbowOn)
            {
                filename44 = freeRunDir.FullName + "\\Elbow" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle elbowPP = new MLSingle("EP", elbowP.ToArray(), 1); // Plant Output
                MLSingle elbowCC = new MLSingle("EC", elbowC.ToArray(), 1); // Contelbower Output
                MLSingle elbowDD = new MLSingle("ED", elbowD.ToArray(), 1); // Desired Value

                //
                //Write data to log lists
                //

                elbowresList.Add(elbowPP);
                elbowresList.Add(elbowCC);
                elbowresList.Add(elbowDD);


                   MatFileWriter mfw44 = new MatFileWriter(filename44, elbowresList, true);

            }
            //---------------------------------------------------------------------------------

            if (appConfig.shoulderOn)
            {
                filename55 = freeRunDir.FullName + "\\Shoulder" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle shoulderPP = new MLSingle("SP", shoulderP.ToArray(), 1); // Plant Output
                MLSingle shoulderCC = new MLSingle("SC", shoulderC.ToArray(), 1); // Contshoulderer Output
                MLSingle shoulderDD = new MLSingle("SD", shoulderD.ToArray(), 1); // Desired Value

                //
                //Write data to log lists
                //

                shoulderresList.Add(shoulderPP);
                shoulderresList.Add(shoulderCC);
                shoulderresList.Add(shoulderDD);


                   MatFileWriter mfw55 = new MatFileWriter(filename55, shoulderresList, true);

            }
            //---------------------------------------------------------------------------------

            if (appConfig.waistOn)
            {
                filename66 = freeRunDir.FullName + "\\Waist" + dt.ToString("dd.MM.yyyy-HH.mm.ss") + ".mat";
                MLSingle waistPP = new MLSingle("WP", waistP.ToArray(), 1); // Plant Output
                MLSingle waistCC = new MLSingle("WC", waistC.ToArray(), 1); // Contwaister Output
                MLSingle waistDD = new MLSingle("WD", waistD.ToArray(), 1); // Desired Value

                //
                //Write data to log lists
                //

                waistresList.Add(waistPP);
                waistresList.Add(waistCC);
                waistresList.Add(waistDD);


                MatFileWriter mfw66 = new MatFileWriter(filename66, waistresList, true);

            }
        }
        
        
        private void grapherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extractor_form.Show();
        }

        public void sequenceStart()
        {
            button1_Click(null, null);
        }
    }
}
