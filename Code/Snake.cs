using SnakeGame.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame.Code
{
    class Snake
    {
        private int height;
        private static List<Position> snakePosition = new List<Position>();
        private static Position firstPs;
        public Snake(int height, int speed, ConsoleColor color, Position StartPosition)
        {
            this.height = height;
            Console.ForegroundColor = color;
            if (height < 10 && height > 0)
            for(int i = 0; i < height; i++)
            {
                snakePosition.Add(new Position() { lat = StartPosition.lat - i, log = StartPosition.log });
            }
            foreach (var unit in snakePosition)
            {
                Console.SetCursorPosition(unit.lat, unit.log);
                Console.Write(0);
            }
        }
        /// <summary>
        /// run the snake
        /// </summary>
        /// <param name="speed"></param>
        /// /// <param name="direction"></param>
        public static void run(int speed, string direction)
        {
            int lat;
            int log;
            switch (direction)
            {
                case "right":
                    {
                        lat = 1;
                        log = 0;
                        break;
                    }
                case "left":
                    {
                        lat = -1;
                        log = 0;
                        break;
                    }
                case "up":
                    {
                        lat = 0;
                        log = 1;
                        break;
                    }
                case "down":
                    {
                        lat = 0;
                        log = -1;
                        break;
                    }
                default :
                    {
                        lat = 1;
                        log = 0;
                        break;
                    }
            }
            firstPs = new Position();
            firstPs.lat = snakePosition.First().lat >= 119 ? 1 : snakePosition.First().lat <= 0 ? 118 : snakePosition.First().lat + lat;
            firstPs.log = snakePosition.First().log >= 27 ? 1 : snakePosition.First().log <= 0 ? 26 : snakePosition.First().log + log;
            snakePosition.Insert(0, firstPs);
            Console.SetCursorPosition(firstPs.lat, firstPs.log);
            Console.Write(0);
            Console.SetCursorPosition(snakePosition.Last().lat , snakePosition.Last().log);
            Console.Write(" ");
            snakePosition.RemoveAt(snakePosition.Count - 1);
            Thread.Sleep(speed);
        }
    }
}
