using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangedMan.classes.imported
{
    internal class Draw
    {
        /// <summary>
        /// Draws arbitrary text on arbitrary parts of the screen.
        /// </summary>
        /// <param name="text">string</param>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        public static void Here(string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
