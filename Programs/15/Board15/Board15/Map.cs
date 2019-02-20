using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board15
{
    struct Map
    {
        int size;
        int[,] map;

        /// <summary>
        /// Создание матрицы с заданными размерами
        /// </summary>
        /// <param name="size">Размер поля</param>
        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }

        /// <summary>
        /// Встасляем значение в матрицу
        /// </summary>
        /// <param name="xy">коордиината ху</param>
        /// <param name="value">значение</param>
        public void Set(Coord xy, int value)
        {
            if (xy.OnBoard(size))
                map[xy.x, xy.y] = value;
        }

        /// <summary>
        /// Забираем значение из матрицы
        /// </summary>
        /// <param name="xy">Координата ху</param>
        /// <returns>значение из матрицы</returns>
        public int Get(Coord xy)
        {
            if (xy.OnBoard(size))
                return map[xy.x, xy.y];
            return 0;
        }

        /// <summary>
        /// Меняем блоки (пустой и нужный) местами
        /// </summary>
        /// <param name="from">откуда</param>
        /// <param name="to">куда</param>
        public void Copy(Coord from, Coord to)
        { 
            Set(to, Get(from));
        }
    }
}
