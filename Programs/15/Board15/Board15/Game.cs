﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Board15
{
    public class Game
    {
        int size;
        Map map;
        Coord space;

        public int moves { get; private set; }

        // Конструктор класса (инициализация игрового поля)
        public Game (int size)
        {
            this.size = size;
            map = new Map(size);
        }

        // Старт игры
        public void Start (int seed = 0)
        {
            int digit = 0;
            for (int y = 0; y < size; y++)
                for(int x = 0; x < size; x++) // Перебор всех координат
                    map.Set(new Coord(x, y), ++digit); // Установка цифры в координату
            space = new Coord(size); // Создание пустого места на доске
            if (seed > 0)
                Shuffle(seed);
            moves = 0;
        }

        // Перемешивание кнопок
        void Shuffle(int seed)
        {
            Random random = new Random(seed);
            for (int j = 0; j < seed; j++)
                Press(random.Next(size), random.Next(size));
        }

        // Обработка нажатий на кнопку
        public int Press(int x, int y)
        {
            return Press(new Coord(x, y));
        }

        int Press(Coord xy)
        {
            // Нажатия на кнопки
            if (space.Equals(xy))
                return 0;
            if (xy.x != space.x && // Диагональ
                xy.y != space.y)
                return 0;

            int steps = 0;

            while (xy.x != space.x)
            {
                // Смещение на +1 или -1 по X
                Shift(Math.Sign(xy.x - space.x), 0);
                steps++;
            }

            while (xy.y != space.y)
            {
                // Смещение на +1 или -1 по Y
                Shift(0, Math.Sign(xy.y - space.y));
                steps++;
            }

            moves += steps;

            return steps;
        }

        // Смещение кнопок
        void Shift(int sx, int sy)
        {
            Coord next = space.Add(sx, sy);
            // Меняем кнопку и пустое место местами
            map.Copy(next, space); 
            space = next;
        }

        // Получение информации о местонахождение кнопок
        public int GetDigit(int x, int y)
        {
            return GetDigit(new Coord(x, y));
        }

        int GetDigit(Coord xy)
        {
            if (space.Equals(xy))
                return 0;
            return map.Get(xy);
        }

        // Окончание игры
        public bool Solved()
        {
            if (!space.Equals(new Coord(size)))
                // Пробел должен находится на последнем месте
                return false;
            int digit = 0;
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    // Если на поле в координате нет цифры до которой мы дошли
                    if (map.Get(new Coord(x, y)) != ++digit) 
                        // Возвращаем координаты пробела
                        return space.Equals(new Coord(x, y));
            return true;

        }
    }
}
