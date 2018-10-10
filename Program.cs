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
        static string OldDirection = "right";
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
                                if(OldDirection != "down")
                                {
                                    direction = "up";
                                    OldDirection = "up";
                                }
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (OldDirection != "up")
                                {
                                    direction = "down";
                                    OldDirection = "down";
                                }
                                    
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                if (OldDirection != "right")
                                {
                                    direction = "left";
                                    OldDirection = "left";
                                }    
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (OldDirection != "left")
                                {
                                    direction = "right";
                                    OldDirection = "right";
                                }
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

            //control
            ListenKey();

            //make the snake
            Code.Snake WhiteSnake = new Code.Snake(7, speed, ConsoleColor.Green, new Position() { lat = 40, log = 15 });
            while (true)
            {
               Code.Snake.Run(200, direction, start);
            }

        }
    }
}
