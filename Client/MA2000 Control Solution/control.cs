using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MA2000_Control_Solution
{
    class PID
    {

        
         //constructor used to set the anti windup level
         
         public PID( float Windup )
         {
          
         this.windup = Windup;
         
         }
       
         



        // variable declarations 
        //************************************
        float windup = 0.2f ;
         float pkp, pki, pkd, prevError = 0 , psampleRate, output;
       
        // for pid use
         float  integral=0, derivative;
        // Initialize the controller
        public void init(float kp, float ki, float kd, float sampleRate)
        {
            prevError = 0;
            pkp = kp;
            pki = ki;
            pkd = kd;
            psampleRate = (sampleRate / 1000f);
            derivative = 0;
            integral = 0;
        }


        public float calculate(float error)

        {
            float q;

            // Windup prevention limit
            if (Math.Abs(error) >= windup)
           
                q = 0f;
             
                       else
                q = 1f;

            integral += q* error * psampleRate;
            derivative = (error - prevError) / psampleRate;
            prevError = error;
            
            //
            // Integrator windup prevention should be added
            //
            output = pkp * (error + (pkd * derivative) + (pki * integral));
          
            /* if (output > 40)
                output = 40;
            if (output < -40)
                output = -40;
           */
            return output;

        }
    }
}
