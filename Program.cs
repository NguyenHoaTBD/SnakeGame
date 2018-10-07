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
    /// Enjoy it! I learned a lot through this project
    /// </summary>
    class Program
    {
        static int interval = 1;
        static string direction = "right";
        static bool start = false;
        static void ListenKey()
        {
            Thread controlThread = new Thread(() => {
                while (true)
                {
                    var keyPress = Console.ReadKey();
                   switch (keyPress.Key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                direction = "up";
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                direction = "down";
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                direction = "left";
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                direction = "right";
                                break;
                            }
                        case ConsoleKey.Enter:
                            {
                                start = !start;
                                break;
                            }

                    }
                }
            });
            controlThread.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //setting
            int height = 28;
            int speed = 9;
           
            BackGround.BgrkFirst(height); //create background
            ListenKey();
            //control


            //make the snake
            Position pos = new Position() { lat = 40, log = 15 };
            Code.Snake WhiteSnake = new Code.Snake(7, speed, ConsoleColor.Green, pos);
            while (true)
            {
                Code.Snake.run(200, direction, start);
            }

        }
    }
}
