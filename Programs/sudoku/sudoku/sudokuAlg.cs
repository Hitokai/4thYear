using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace sudoku
{
    class sudokuAlg
    {
        public static int[,] grid = new int[9, 9];

        // Заполнение массива цифрами по формуле
        public static void initGrid(int[,] grid)
        // Формула постоянно сдвигает цифры на следующей строке на насколько позиций
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
                }
            }
        }

        // Изменение значений в двух клетках
        static void changeTwoCell(int[,] grid, int findValue1, int findValue2)
        {
            int xParam1, yParam1, xParam2, yParam2;
            xParam1 = yParam1 = xParam2 = yParam2 = 0;
            // Поиск в таблице переданных значений
            for (int i = 0; i < 9; i+=3)
            {
                for (int k = 0; k < 9; k+=3)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            if (grid[i + j, k + z] == findValue1)
                            {
                                xParam1 = i + j;
                                yParam1 = k + z;
                            }

                            if (grid[i + j, k + z] == findValue2)
                            {
                                xParam2 = i + j;
                                yParam2 = k + z;
                            }
                        }
                    }
                    // Меняем значения
                    grid[xParam1, yParam1] = findValue2;
                    grid[xParam2, yParam2] = findValue1;
                }
            }
        }

        // Перемешивание чисел в таблице
        public static void updateGrid(int[,] grid)
        {
            Random shuffleLevel = new Random(); // Кол-во перемешиваний
            for (int repeat = 0; repeat < shuffleLevel.Next(10, 20); repeat++)
            {
                // Без параметра Guid.NewGuid().GetHashCode() в таблице всё заполняется одинаковыми цифрами
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                Random rand2 = new Random(Guid.NewGuid().GetHashCode());
                changeTwoCell(grid, rand.Next(1, 10), rand2.Next(1, 10)); // Обмен местами двух чисел
            }
        }
    }
}
