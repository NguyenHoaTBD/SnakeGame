using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Code
{
    static class BackGround
    {
        /// <summary>
        /// make background
        /// </summary>
        /// <param name="pix"></param>
        public static void BgrkFirst(int pix)
        {
            Console.SetCursorPosition(0,pix);
            Console.Write("------------------------------------------------------------------------------------------------------------------------");

        }
    }
}
