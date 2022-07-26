using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MA2000_Control_Solution
{

    
    public class classStatus
    {
       

        //..........................................................
        // This class contains program flags and status indicators..
        // Those flags are of boolean type.                        .
        //..........................................................
        public static bool connected  = false;       // Connection Status
        public static bool configSaved= false;           // determines whether the configuration is saved or not.
        public static bool controlOn  = false;             // determines whether the controller is running.
        public static bool tunerOn    = false;               // determines whether the tuner is running
        public static bool go2Zero    = false;          // True if the tune cycle ends


        //
        // Error and plant I/O temp matrices
        //

        //
        // Error Log
        //
        public static float[] rollErrLog;
        public static float[] yawErrLog;
        public static float[] pitchErrLog;
        public static float[] elbowErrLog;
        public static float[] shoulderErrLog;
        public static float[] waistErrLog;

        //
        // Plant Log
        //

        public static float[] rollPlantLog;
        public static float[] yawPlantLog;
        public static float[] pitchPlantLog;
        public static float[] elbowPlantLog;
        public static float[] shoulderPlantLog;
        public static float[] waistPlantLog;

        //
        //Controller Log
        //

        public static float[] rollControllerLog;
        public static float[] yawControllerLog;
        public static float[] pitchControllerLog;
        public static float[] elbowControllerLog;
        public static float[] shoulderControllerLog;
        public static float[] waistControllerLog;

        //
        // A temporary variable to save the PID paras
        //

        public static float kp, ki, kd;

        public static float evaluationResult;
    }
       

}

