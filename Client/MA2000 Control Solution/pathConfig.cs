using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MA2000_Control_Solution
{
    [Serializable]
    public class pathConfig
    {

        //----------------------------------------------------------
        // Manipulator Paths
        //----------------------------------------------------------
        

        public float[,] path1 = new float[100, 6];
        public float[,] path2 = new float[100, 6];
        public float[,] path3 = new float[100, 6];
        public float[,] path4 = new float[100, 6];
        public float[,] path5 = new float[100, 6];
        public int p1Idx, p2Idx, p3Idx, p4Idx, p5Idx;

        public void init()
        {
            //
            // Path Config
            //

            for (int i = 0; i < 100; i++)
                for (int j = 0; i < 6; i++)
                {
                    path1[i, j] = path2[i, j] = path3[i, j] = path4[i, j] = path5[i, j] = 1.5f;
                }
            p1Idx = p2Idx = p3Idx = p4Idx = p5Idx = 20;
        }

    }
}
