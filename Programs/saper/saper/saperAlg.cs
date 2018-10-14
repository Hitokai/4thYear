using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace saper
{
    class SaperAlg
    {
        public static Button[,] buttonMatrix;
        public static int[][] minesCoords = new int[0][];
        public static int[,] gridNums;

        public static int[][] MinesCoord(int size)
        {
            gridNums = new int[size, size];
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
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < bombRand; k++)
                    {
                        if (i == bombCoordList[k][0] && j == bombCoordList[k][1])
                            gridNums[i, j] = 99;
                    }
                }
            }
            return bombCoordList;
        }

        public static void GenerateGrid(int size)
        {
            int K;
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    if (gridNums[i, j] != 99)
                    {
                        K = 0;
                        if (gridNums[i + 1, j - 1] == 99) K++;
                        if (gridNums[i + 1, j] == 99) K++;
                        if (gridNums[i + 1, j + 1] == 99) K++;
                        if (gridNums[i, j - 1] == 99) K++;
                        if (gridNums[i, j + 1] == 99) K++;
                        if (gridNums[i - 1, j - 1] == 99) K++;
                        if (gridNums[i - 1, j] == 99) K++;
                        if (gridNums[i - 1, j + 1] == 99) K++;

                        gridNums[i, j] = K;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    buttonMatrix[i, j].Content = gridNums[i, j];
                }
            }
        }

    }
}
