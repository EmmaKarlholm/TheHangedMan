using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangedMan.classes.imported;

namespace TheHangedMan.classes
{
    internal class MenuHandler
    {
        public static bool Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Random random = new Random();
                int randomIntro = random.Next(4);
                string[] menuHeader = RandomIntro(randomIntro);

                string[] menuOptions = [
                    "Play the Hanged Man with the bartender",
                    "Play the Hanged Man with a friend",
                    "Have an ale",
                    "Leave the tavern"
                ];

                int menuSelection = Menu.Render(menuHeader, menuOptions);

                switch (menuSelection)
                {
                    case 0: // Single player
                        SinglePlayerMenu();
                        break;
                    case 1: // Multi player
                        //MultiPlayerMenu();
                        break;
                    case 2: // Ale
                        Console.Clear();
                        Console.Write("\tYou take a moment with a drink of your choice.");
                        for (int i = 0; i < 2; i++)
                        { 
                            Thread.Sleep(300);
                            Console.Write(" .");
                        }
                        Thread.Sleep(800);
                        Console.Write("\n\n\t\tPerhaps it is time for a game.\n\n");
                        Thread.Sleep(500);
                        Display.Pause();
                        break;

                    case 3: // Quit
                        Console.Clear();
                        Console.WriteLine("\n\t\t\"Please come again!\" you hear bellowed as you leave.");
                        Thread.Sleep(1000);
                        return false;
                }
            }
            return true;
        }



        public static string[] RandomIntro(int introNumber)
        {
            string[][] introTexts =
            {
                new[] { "\t\tThe Hanged Man\n", "\t\"Greetings, friend! This is the Hanged Man.\" the blonde man starts.",
                        "\t\"Would you like some ale, or are we going straight into the games today?\"\n" },
                new[] { "\t\tThe Hanged Man\n", "\t\"This here tavern is the Hanged Man, and I'll be your 'tender!\"",
                        "\tThe man's hand gestures towards the fire place before continuing.",
                        "\t\"Nevermind the beardless dwarf in the corner. Enjoy the games!\"\n" },
                new[] { "\t\tThe Hanged Man\n", "\t\"The Hanged Man's open, but the beer ain't free.\"",
                        "\tSo the songs of this place are sung.",
                        "\n\t\"So... Play a game of... Hanged Man?\"\n" },
                new[] { "\t\tThe Hanged Man\n", "\t\"Welcome to the Hanged Man!\" the bartender says as he polishes a glass.",
                        "\t\"Entertain a game, or hazard a drink? Either way is fine by me, after all.\"\n" }
            };
            if (introNumber >= 0 && introNumber < introTexts.Length)
            {
                return introTexts[introNumber];
            }
            else
            {
                return new[] {  "\t\tWelcome to the Hanged Man!",
                                "\tThis is kind of embarrassing. This should never run.\n" };
            }

        }

        public static void SinglePlayerMenu()
        {

            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Thread.Sleep(200);
                Console.WriteLine();

                string[] menuHeader = [
                    "\n\tThe bartender grins. \"Let's play a game of Hanged Man.\"\n",
                    "\t\"Now, how hard would you like to play?\"\n"
                ];

                string[] menuOptions = [
                    "Give me something easy. (6-11 characters)",
                    "I'd like a challenge. (3-5 characters)",
                    "I want a word that is a specific length.",
                    "Actually, let's not play."
                ];

                int menuSelection = Menu.Render(menuHeader, menuOptions);

                switch (menuSelection)
                {
                    case 0:
                        PlaySingle.ParseOptions("easy");
                        break;
                    case 1:
                        PlaySingle.ParseOptions("hard");
                        break;
                    case 2:
                        Console.CursorVisible = true;
                        Console.Clear();
                        Console.WriteLine("\t\"Oho.\" he chuffs. \"And what is that length then?\"\n");
                        Console.Write("\tLength: ");
                        string numberString = UserInput.TrimmedString();
                        Console.CursorVisible = false;
                        PlaySingle.ParseOptions(numberString);
                        break;
                    case 3:
                        return;
                }
            }
        }
    }

}