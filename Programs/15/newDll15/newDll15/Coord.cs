using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace newDll15
{
    struct Coord
    {
        public int x;
        public int y;

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coord(int size)
        {
            // Координаты последней ячейки
            x = size - 1;
            y = size - 1;
        }

        public bool OnBoard(int size)
        {
            // Проверка нахождения на доске
            if (x < 0 || x > size - 1) return false;
            if (y < 0 || y > size - 1) return false;
            return true;
        }

        public Coord Add(int sx, int sy)
        {
            // Возвращение новой координаты увеличенной на указанную
            return new Coord(x + sx, y + sy);
        }
    }
}
