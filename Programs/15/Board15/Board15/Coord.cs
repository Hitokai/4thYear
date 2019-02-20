using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board15
{
    /// <summary>
    /// Структура для работы с координатами
    /// </summary>
    struct Coord
    {
        public int x;
        public int y;

        /// <summary>
        /// Присваивание переменным структуры значения из вне
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Координаты последней ячейки
        /// </summary>
        /// <param name="size">Размер поля</param>
        public Coord(int size)
        {
            x = size - 1;
            y = size - 1;
        }

        /// <summary>
        /// Проверка нахождения на доске
        /// </summary>
        /// <param name="size">размер поля</param>
        /// <returns>Нахождение ячейки на поле</returns>
        public bool OnBoard(int size)
        {
            if (x < 0 || x > size - 1) return false;
            if (y < 0 || y > size - 1) return false;
            return true;
        }

        /// <summary>
        /// Возвращение новой координаты увеличенной на указанную
        /// </summary>
        /// <param name="sx">Текущая координата х</param>
        /// <param name="sy">Текущая координата у</param>
        /// <returns>Координаты</returns>
        public Coord Add(int sx, int sy)
        {
            return new Coord(x + sx, y + sy);
        }
    } 

}
