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

        // Функция генерации координат для мин
        public static int[][] MinesCoord(int size)
        {
            gridNums = new int[size + 2, size + 2];
            for (int i = 0; i < size + 2; i++)
            {
                for (int j = 0; j < size + 2; j++)
                {
                    gridNums[i, j] = -1;
                }
            }
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int bombRand = 0;
            // Рандомное кол-во мин
            bombRand = rand.Next(Convert.ToInt32(Math.Floor(size * size * 0.12)), Convert.ToInt32(Math.Floor(size * size * 0.17)));
            int[][] bombCoordList = new int[bombRand][];

            int[] sl = new int[2] { -1, -1 };
            for (int i = 0; i < bombRand; i++)
            {
                bombCoordList[i] = sl;
            }

            for (int i = 0; i < bombRand; i++)
            {
                Random rand1 = new Random(Guid.NewGuid().GetHashCode());
                Random rand2 = new Random(Guid.NewGuid().GetHashCode());
                int[] subList = new int[2];
                subList[0] = rand1.Next(1, size + 1);
                subList[1] = rand2.Next(1, size + 1);
                if (CheckBombsCoord(bombCoordList, subList, bombRand))
                    bombCoordList[i] = subList;
                else
                    i--;
            }
            // Вставка мин по координатам на поле игры
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
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

        public static bool CheckBombsCoord(int[][] coords,int[] newCoords, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (newCoords[0] == coords[i][0] && newCoords[1] == coords[i][1])
                    return false;
            }
            return true;
        }

        // Генерация цифр вокруг мин
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
        }

    }
}
