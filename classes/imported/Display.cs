using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangedMan.classes.imported
{
    /// <summary>
    /// Displays various screens.
    /// </summary>
    internal class Display
    {
        /// <summary>
        /// Shows error message to the user on screen without crashing the application.
        /// </summary>
        /// <param name="message">The error message to be displayed</param>
        public static void ErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("ERROR:");
            Console.ResetColor();
            Console.Write($"  {message}\n");
            Pause();
        }

        /// <summary>
        /// Prompts user for keyboard input before code execution continues.
        /// </summary>
        public static void Pause()
        {
            Console.WriteLine("\n\tPress any key . . .");
            Console.ReadKey();
        }

    }
}
