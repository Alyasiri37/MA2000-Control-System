using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MA2000_Control_Solution
{
    class hc
    {
        public static  int [] metrics = new int[6];
        public static  int [] currentMetrics = new int[3];
        public static string name;

         public static int[] transferMetrics()
        {
            Form1.Instance.tuneMetrics();
            return metrics;
        }

       public static  int[] transferCurrentMetrics()
        {
            Form1.Instance.log("shit");
            Form1.Instance.currentTuneMetrics();
            return currentMetrics;
        }

         static public string getName()
        {
            Form1.Instance.currentJointName();
            return name;
        }

        //
        // a function that converts degrees to volts (for output)
        //
         
    }
}
