using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MA2000_Control_Solution
{
    class Swarm
    {
        //---------------------------------------------
        // Variable declarations
        //---------------------------------------------
        public string name = "";

        public Swarm(string name)
       {
            this.name = name;
        }
        public int swarmSize = 5;
        /// <summary>
        /// The particle counter that points to the current particle
        /// </summary>
        public int particleCounter = 0;
        public int iterationCounter = 0;
        public int iterations = 5;
        float c1 = 2.5f;
        float c2 = 1.5f;
        
        float vmax = 5f;
        public bool stop = false;
        float constrictionFactor = 0f;
        public float[] gBest = new float[] { 0, 0, 0 };
        public float gBestError = 1000000f;
        public float gBestErrLast = 1000000f;
        //---------------------------------------------
        // Class declarations
        //---------------------------------------------
        Random rndInit = new Random();
        Random rnd = new Random();
        Random rnd1 = new Random();
        Random rnd2 = new Random();
        Random rnd3 = new Random();
        List<Particle> swarm = new List<Particle>();

        //
        // Initialize the swarm
        //
        public void swarmInit()
        {
            stop = false; // Iterations end indicator

            swarmSize = Form1.Instance.appConfig.swarmSize;
            iterations = Form1.Instance.appConfig.noCycles;
            c1 = Form1.Instance.appConfig.c1;
            c2 = Form1.Instance.appConfig.c2;
            gBest = new float[] { 0, 0, 0 };
            gBestError = 1000000f;
            gBestErrLast = 1000000f;

            // Constriction factor computation
            float theta = c1+c2;
            constrictionFactor = (2f / (Math.Abs(2f - theta - (float)Math.Sqrt(theta * theta - 4 * theta))));

            for (int i = 0; i < swarmSize; i++)

            {
                swarm.Add(new Particle());

                //
                // modified code
                //

                /*
                 *
                swarm[i].currentPosition[0] = (float)((100 *rndInit.NextDouble())*rndInit.NextDouble());
                swarm[i].currentPosition[1] = (float)((100 * rndInit.NextDouble()) * rndInit.NextDouble());
                swarm[i].currentPosition[2] = (float)((100 *rndInit.NextDouble())*rndInit.NextDouble());
                swarm[i].lBest = swarm[i].currentPosition;
                
                 * 
                 */

                swarm[i].currentPosition[0] = 1f;
                swarm[i].currentPosition[1] = 10f;
                swarm[i].currentPosition[2] = 0.1f;
                swarm[i].currentVelocity = new float[] { 0, 0, 0 };
            }
        } // swarmInit

        //
        // Initialize the swarm
        //

        public float[] updatePosition()
        {
            float[] position = new float[3];
            for (int i = 0; i < 3; i++)
            {
                // Speed calculation
                swarm[particleCounter].currentVelocity[i] = constrictionFactor * ( swarm[particleCounter].currentVelocity[i]
                    + c1 * ((float)rnd1.NextDouble()) * (swarm[particleCounter].lBest[i] - swarm[particleCounter].currentPosition[i])
                    + c2 * ((float)rnd2.NextDouble()) * (gBest[i] - swarm[particleCounter].currentPosition[i]));

                // Speed limit
                if (swarm[particleCounter].currentVelocity[i] > vmax)
                    swarm[particleCounter].currentVelocity[i] = vmax;

                swarm[particleCounter].currentPosition[i] += swarm[particleCounter].currentVelocity[i];

                // Edit, added negative value truncation ( -ve will be zeroed )
                if (swarm[particleCounter].currentPosition[i] < 0)
                    swarm[particleCounter].currentPosition[i] = 0;

            }
            position = swarm[particleCounter].currentPosition;

            return position;
        } // Update position

        public void move()
        {
            // Point to the next particle
            particleCounter += 1;

            // Reset it if we reached the limit
            if (particleCounter >= swarmSize)
            {
                particleCounter = 0;

                // Go to the next iteration
                iterationCounter += 1;

                // Perform limit check
                if (iterationCounter >= iterations)
                {
                    iterationCounter = 0;

                    // stop the swarm movement
                    stop = true;
                }
            }
        }

        public void bypass(int number)
        {
            for (int i = 0; i < number; i++)
            {
                rnd1.NextDouble();
                rnd2.NextDouble();
            }
        }


        public void evaluate(float error)
        {
            swarm[particleCounter].currentError = error;

            if (swarm[particleCounter].currentError < swarm[particleCounter].lBestError)
            {
                swarm[particleCounter].lBest[0] = swarm[particleCounter].currentPosition[0];
                swarm[particleCounter].lBest[1] = swarm[particleCounter].currentPosition[1];
                swarm[particleCounter].lBest[2] = swarm[particleCounter].currentPosition[2];

                swarm[particleCounter].lBestError = swarm[particleCounter].currentError;

            }

            if (swarm[particleCounter].lBestError < gBestError)
            {
                gBest[0] = swarm[particleCounter].lBest[0];
                gBest[1] = swarm[particleCounter].lBest[1];
                gBest[2] = swarm[particleCounter].lBest[2];

                gBestErrLast = gBestError;
                gBestError = swarm[particleCounter].lBestError;
            }

        }

    }

    //
    // The particle mold
    //
    public class Particle
    {
        public float[] currentVelocity = new float[3];
        public float[] currentPosition = new float[3];
        public float[] lBest = new float[3];

        public float currentError;
        public float lBestError = 1000000f;



    }

}
