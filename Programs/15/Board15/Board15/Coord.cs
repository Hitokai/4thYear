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

        // Присваивание переменным структуры значения из вне
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Координаты последней ячейки
        public Coord(int size)
        {
            x = size - 1;
            y = size - 1;
        }
        
        // Проверка нахождения на доске
        public bool OnBoard(int size)
        {
            if (x < 0 || x > size - 1) return false;
            if (y < 0 || y > size - 1) return false;
            return true;
        }

        // Возвращение новой координаты увеличенной на указанную
        public Coord Add(int sx, int sy)
        {
            return new Coord(x + sx, y + sy);
        }
    } 

}
