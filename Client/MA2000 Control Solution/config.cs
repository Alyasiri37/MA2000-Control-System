using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MA2000_Control_Solution
{

    [Serializable]
    public class config
    {

        //..........................................................
        // This class contains program configuration to be saved   .
        // into the configuration file.                            .
        //..........................................................


        #region Properties

        //..........................................................
        // Connection configuration Info(Server Address, port, etc).
        //..........................................................

        public string ipAddress="127.0.0.1";
        public int port = 10000;


        //..........................................................
        // Status Monitoring Configuration ( Status Window )       .
        //..........................................................
        public bool isRunning;
        public int refreshRate;

        //..........................................................
        //  Joint PID Configuration                                .
        //..........................................................
        public float roll_kp, roll_ki, roll_kd;
        public float yaw_kp, yaw_ki, yaw_kd;
        public float pitch_kp, pitch_ki, pitch_kd;
        public float elbow_kp, elbow_ki, elbow_kd;
        public float shoulder_kp, shoulder_ki, shoulder_kd;
        public float waist_kp, waist_ki, waist_kd;
        public float general_kp, general_ki, general_kd;

        // Brakes (0 = Braked or off)

        public bool rollOn;
        public bool yawOn;
        public bool pitchOn;
        public bool elbowOn;
        public bool shoulderOn;
        public bool waistOn;

        public float sampleTime; // in milliSeconds
        //..........................................................
        // Joint PSO Tuner Configuration                           .
        //..........................................................
        public bool rollTuneOn;
        public bool yawTuneOn;
        public bool pitchTuneOn;
        public bool elbowTuneOn;
        public bool shoulderTuneOn;
        public bool waistTuneOn;
        //..........................................................
        // Degrees position config
        //..........................................................

        public float roll_deg;
        public float yaw_deg;
        public float pitch_deg;
        public float elbow_deg;
        public float shoulder_deg;
        public float waist_deg;

        //----------------------------------------------------------
        // Voltages position config
        //----------------------------------------------------------

        public float roll_volt;
        public float yaw_volt;
        public float pitch_volt;
        public float elbow_volt;
        public float shoulder_volt;
        public float waist_volt;

         
        //----------------------------------------------------------
        // Cartesian position config
        //----------------------------------------------------------


        //----------------------------------------------------------
        // Zero position config
        //----------------------------------------------------------
        public float rollZero;
        public float yawZero;
        public float pitchZero;
        public float elbowZero;
        public float shoulderZero;
        public float waistZero;

        
        public float rollDegZero;
        public float yawDegZero;
        public float pitchDegZero;
        public float elbowDegZero;
        public float shoulderDegZero;
        public float waistDegZero;
        //----------------------------------------------------------
        // Tune position config
        //----------------------------------------------------------
        public float rollTune;
        public float yawTune;
        public float pitchTune;
        public float elbowTune;
        public float shoulderTune;
        public float waistTune;


        public float rollDegTune;
        public float yawDegTune;
        public float pitchDegTune;
        public float elbowDegTune;
        public float shoulderDegTune;
        public float waistDegTune;

        //----------------------------------------------------------
        // Desired PID Response
        //----------------------------------------------------------

        public float maxOvershoot;
        public float riseTime;

        //----------------------------------------------------------
        // Conversion Gains
        //----------------------------------------------------------

        public float rollConvert;
        public float yawConvert;
        public float pitchConvert;
        public float elbowConvert;
        public float shoulderConvert;
        public float waistConvert;


        //----------------------------------------------------------
        // Tuner Setting
        //----------------------------------------------------------

        public int noCycles;
        public int cycleDuration; // << in Seconds
        public int swarmSize;
        public float c1;
        public float c2;


        //----------------------------------------------------------
        // Logger Setting
        //----------------------------------------------------------

        public string logDir = "";


        #endregion

        
        
        public void systemInit()
        {
            // Here we can set the initial values for the system
            // PID Parameters

            roll_kp     = roll_ki       = roll_kd       = 0f;
            yaw_kp      = yaw_ki        = yaw_kd        = 0f;
            pitch_kp    = pitch_ki      = pitch_kd      = 0f;
            elbow_kp    = elbow_ki      = elbow_kd      = 0f;
            shoulder_kp = shoulder_ki   = shoulder_kd   = 0f;
            waist_kp    = waist_ki      = waist_kd      = 0f;
            general_kp  = general_ki    = general_kd    = 0f;

            //Brakers 

            rollOn      = false;
            yawOn       = false;
            pitchOn     = false;
            elbowOn     = false;
            shoulderOn  = false;
            waistOn     = false;
            // PID sample time
            sampleTime = 20f;

            // Position initial values:
            roll_deg        = 0f;
            yaw_deg         = 0f;
            pitch_deg       = 0f;
            elbow_deg       = 0f;
            shoulder_deg    = 0f;
            waist_deg       = 0f;

            roll_volt       = 0f;
            yaw_volt        = 0f;
            pitch_volt      = 0f;
            elbow_volt      = 0f;
            shoulder_volt   = 0f;
            waist_volt      = 0f;
            //setPosition = new float[] { roll_volt, yaw_volt, pitch_volt, elbow_volt, shoulder_volt, waist_volt };
            // Status window initial parameters
            refreshRate = 500;
            isRunning = true;

            // Desired Response
            maxOvershoot = 0.05f;
            riseTime     = 1f;

            // Conversion Parameters
            rollConvert         = 1f;
            yawConvert          = 1f;
            pitchConvert        = 1f;
            elbowConvert        = 1f;
            shoulderConvert     = 1f;
            waistConvert        = 1f;

            //
            // Tuner Config
            //
            noCycles = 5;
            cycleDuration = 8;
            swarmSize = 5;
            c1 = 2.5F;
            c2 = 2.5F;

            rollTuneOn      =false;
            yawTuneOn       =false;
            pitchTuneOn     =false;
            elbowTuneOn     =false;
            shoulderTuneOn  =false;
            waistTuneOn     =false;

        //----------------------------------------------------------
        // Zero position config
        //----------------------------------------------------------
         rollZero = 2.5f;
         yawZero = 2.5f;
         pitchZero = 2.5f;
         elbowZero = 2.5f;
         shoulderZero = 2.5f;
         waistZero = 2.5f;

         rollDegZero = 45;
         yawDegZero = 45;
         pitchDegZero = 45;
         elbowDegZero = 45;
         shoulderDegZero = 45;
         waistDegZero = 45;
        //----------------------------------------------------------
        // Tune position config
        //----------------------------------------------------------
         rollTune = 1;
         yawTune = 1;
         pitchTune = 1;
         elbowTune = 1;
         shoulderTune = 1;
         waistTune = 1;


         rollDegTune = 45;
         yawDegTune = 45;
         pitchDegTune = 45;
         elbowDegTune = 45;
         shoulderDegTune = 45;
         waistDegTune = 45;
            
            //
            // Logger Config
            //

            logDir = "";

            
 
        }

        // 
        // Set the pid parameters to proportional only
        //
        public void safeMode()
        {
            roll_kp = yaw_kp = pitch_kp = elbow_kp = shoulder_kp = waist_kp = 10f;
            roll_ki = yaw_ki = pitch_ki = elbow_ki = shoulder_ki = waist_ki = 0f;
            roll_kd = yaw_kd = pitch_kd = elbow_kd = shoulder_kd = waist_kd = 0f;

        }
    }
}
