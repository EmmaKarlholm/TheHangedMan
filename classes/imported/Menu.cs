namespace Bytebasket
{
    internal class Menu
    {
        /// <summary>
        /// The method which renders the menu on screen.
        /// </summary>
        /// <param name="menuHeader">A string array containing lines displayed at the top of the screen.</param>
        /// <param name="menuOptions">A string array containing all the options in the menu.</param>
        /// <returns>Integer corresponding to menuOptions string array.</returns>
        public static int Render(string[] menuHeader, string[] menuOptions)
        {
            Console.CursorVisible = false;
            int menuSelection;
            int currentSelection = 0;

            while (true)
            {
                Console.Clear();
                string arrowMarker = "\t -> ";
                string emptyMarker = "\t    ";


                // Draw menu header.
                foreach (string headerLine in menuHeader)
                {
                    Console.WriteLine(headerLine);
                }

                // Draw the actual menu.
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == currentSelection)
                    {
                        Console.WriteLine($"{arrowMarker}{menuOptions[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"{emptyMarker}{menuOptions[i]}");
                    }
                }

                // Receive user input and update cursor on screen. 
                ConsoleKeyInfo pressed = Console.ReadKey(true);
                switch (pressed.Key)
                {
                    // "UP" keys
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.NumPad8:
                        if (currentSelection > 0) { currentSelection--; }
                        break;

                    // "DOWN" keys
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.NumPad5:
                        if (currentSelection < menuOptions.Length-1) { currentSelection++; }
                        break;

                    // "CONFIRM" keys
                    case ConsoleKey.Enter:
                    case ConsoleKey.E:
                    case ConsoleKey.F:
                        menuSelection = currentSelection;
                        return menuSelection;

                    // "QUIT" keys. Consider deprecating these in the future
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
