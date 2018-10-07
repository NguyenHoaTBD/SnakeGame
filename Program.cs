using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SnakeGame.Code;
using SnakeGame.model;

namespace SnakeGame
{
    /// <summary>
    /// Enjoy it! You will learn alot through this project
    /// </summary>
    class Program
    {
        static int interval = 1;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //setting
            int height = 28;
            int speed = 9;
            string direction = "right";
            bool start = true;
            BackGround.BgrkFirst(height); //create background
            //control
            Thread controlThread = new Thread ( () => {
                Thread.Sleep(1500);
                direction = "up";
                Thread.Sleep(1500);
                direction = "left";
                Thread.Sleep(1500);
                direction = "down";
            }) ;
            controlThread.Start();
            //make the snake
            Position pos = new Position() { lat = 40, log = 15 };
            Code.Snake WhiteSnake = new Code.Snake(7, speed, ConsoleColor.Green, pos);
            while(start)
            {
                Code.Snake.run(200, direction);
            }

        }
    }
}
