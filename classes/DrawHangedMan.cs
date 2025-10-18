using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangedMan.classes.imported;

namespace TheHangedMan.classes
{
    internal class DrawHangedMan
    {

        /// <summary>
        /// Draws the Hanged Man on screen according to how many times the user has failed.
        /// </summary>
        /// <param name="failures">int</param>
        public static void Picture(int failures)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("    ___________");
            Console.WriteLine("   /      ║    ");
            Console.WriteLine("  │       ║    ");
            Console.WriteLine("  │            ");
            Console.WriteLine("  │            ");
            Console.WriteLine("  │            ");
            Console.WriteLine("  │	          ");
            Console.WriteLine("──^────────────");

            if (failures > 0) // Draw head
            {
                Draw.Here("O", 10, 3);
            }

            if (failures > 1) // Draw body
            {
                Draw.Here("│", 10, 4);
            }

            if (failures > 2) // Draw right arm in raised position
            {
                Draw.Here("\\", 9, 3);
            }

            if (failures > 3) // Draw left arm in raised position
            {
                Draw.Here("/", 11, 3);
            }

            if (failures > 4) // Draw right leg
            {
                Draw.Here("/", 9, 5);
            }

            if (failures > 5) // Draw left leg, then erase arms and draw them in fallen position
            {
                Draw.Here("\\", 11, 5);
                Thread.Sleep(500);
                Draw.Here(" ", 9, 3);
                Draw.Here(" ", 11, 3);
                Draw.Here("/", 9, 4);
                Draw.Here("\\", 11, 4);
            }

            Draw.Here(" ", 0, 9); // Reset cursor below picture

        }
    }
}