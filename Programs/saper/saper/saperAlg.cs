using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace saper
{
    class SaperAlg
    {
        public static int[][] MinesCoord(int size)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int bombRand = 0;
            if (size == 10)
                bombRand = rand.Next(12, 18);
            else if (size == 14)
                bombRand = rand.Next(18, 24);
            else if (size == 18)
                bombRand = rand.Next(24, 30);
            int[][] bombCoordList = new int[bombRand][];
            for (int i = 0; i < bombRand; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Random rand1 = new Random(Guid.NewGuid().GetHashCode());
                    Random rand2 = new Random(Guid.NewGuid().GetHashCode());
                    int[] subList = new int[2];
                    subList[0] = rand1.Next(0, size);
                    subList[1] = rand2.Next(0, size);
                    bombCoordList[i] = subList;
                }
                
            }
            return bombCoordList;
        }

    }
}
