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

        public static void ASCII(string fileName)
        {
            if (File.Exists(fileName))
            {
                string artwork = File.ReadAllText(fileName);
                Console.WriteLine(artwork);
            }
            else
            {
                Display.ErrorMessage($"Could not find file \"${fileName}\"!");
                Environment.Exit(1);
            }
        }

    }
}

