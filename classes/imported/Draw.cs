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
        /// <param name="text">Text to be written</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public static void Here(string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        /// <summary>
        /// Draws ASCII art from a separate file. 
        /// </summary>
        /// <param name="fileName">Path to file</param>
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

