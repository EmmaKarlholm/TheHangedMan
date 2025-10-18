using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TheHangedMan.classes.imported;


namespace TheHangedMan.classes
{
    internal class GameManager
    {
        /// <summary>
        /// The actual game starts here, choosing a word of the supplied wordLength.
        /// </summary>
        /// <param name="wordLength"></param>
        //public static void Start(int wordLength, bool isMultiplayer, string multiplayerWord)
        public static void Start(Word secretWord)
        {
            if (secretWord != null)
            {
                int failures = 0;

                // Fill the LetterSpaces array with spaces.
                for (int i = 0; i < secretWord.Letters.Length; i++)
                {
                    secretWord.LetterSpaces[i] = '_';
                }

                List<char> guessedLetters = new List<char>();

                bool stillPlaying = true;
                while (stillPlaying)
                {
                    // ChatGPT helped me find the syntax for how to draw on arbitrary places of the 
                    // terminal window without needing to clear the terminal window every update.
                    // This leads to a better user experience since there is less flicker on the
                    // eyes. I will be using this a lot more in the future.
                    DrawHangedMan.Picture(failures);

                    // Draw the list of letters.
                    Console.Write("    Letters: ");
                    for (int i = 0; i < secretWord.Letters.Length; i++)
                    {
                        Console.Write(secretWord.LetterSpaces[i].ToString().ToUpper());
                        Console.Write(" ");
                    }

                    Console.Write($"\n\n Previously guessed letters: ");
                    foreach (char guessed in guessedLetters)
                    {
                        Console.Write(guessed.ToString().ToUpper());
                    }

                    // Before user input.
                    // Check if the user has won. This must be done after drawing graphics to
                    // ensure the final result is actually displayed to the user.

                    bool theTwoMatch = true; // Assume they match...
                    for (int i = 0; i < secretWord.Letters.Length; i++)
                    {
                        if (secretWord.Letters[i] != secretWord.LetterSpaces[i]) // ... then check every char...
                        {
                            theTwoMatch = false; // ... and set this at every possible mismatch.
                        }
                    }

                    if (theTwoMatch) // If this remains true, then a match has been found.
                    {
                        stillPlaying = false; // Thus the game has been solved!
                        Thread.Sleep(1500);
                        WonGame(true);
                        break;
                    }

                    // Check if the player has lost the game next.
                    if (failures > 5)
                    {
                        Thread.Sleep(1500);
                        WonGame(false);
                        break;
                    }

                    // Then return the game to continue.
                    Console.Write("\n  Please, make a guess: ");

                    ConsoleKeyInfo pressed = Console.ReadKey(true);
                    if (char.IsLetter(pressed.KeyChar))
                    {
                        char guessedLetter = char.ToLower(pressed.KeyChar);

                        // Check if user already made this guess before.
                        bool uniqueGuess = true;
                        foreach (char letter in guessedLetters)
                        {
                            if (letter == guessedLetter)
                            {
                                uniqueGuess = false;
                            }
                        }

                        // Only unique guesses continue the game and risk adding failures.
                        if (uniqueGuess)
                        {
                            guessedLetters.Add(guessedLetter);

                            // Go through the word letter by letter and update the LetterSpaces along the way.
                            bool wasGoodGuess = false;
                            for (int i = 0; i < secretWord.Letters.Length; i++)
                            {
                                if (guessedLetter == secretWord.Letters[i])
                                {
                                    secretWord.LetterSpaces[i] = guessedLetter;
                                    wasGoodGuess = true;
                                }
                            }
                            if (wasGoodGuess == false)
                            {
                                failures++;
                            }
                        }
                    }
                }
            }

            // No relevant words were found.
            else
            {
                Console.Clear();
                Console.WriteLine("\tThe man behind the bar darts his gaze elsewhere and returns with an embarrassed look.\n");
                Thread.Sleep(400);
                Console.Write("\t\"I, eh, ");
                Thread.Sleep(400);
                Console.Write("I can't think of a lot of words in that range. Please try another one?\"\n\n");
                Thread.Sleep(600);
                Display.Pause();
                return;
            }
        }

        /// <summary>
        /// Handle the results of the game.
        /// </summary>
        /// <param name="won"></param>
        public static void WonGame(bool won)
        {
            if (won)
            {
                Console.Clear();
                Console.Write("\n");
                Draw.ASCII("art\\Win");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("\n\n\t\"Ey, congrulations are in order!\"\n");
                Thread.Sleep(500);
                Console.WriteLine("\tThe man adjusts his pose, seemingly embarrassed by his sudden burst of joy.\n");
                Thread.Sleep(500);
                Console.WriteLine("\t\"If you ever feel like enjoying another game, just tell me," +
                    "\n\tyou hear?\" he says, diverting his smiling gaze.\n");
                Thread.Sleep(500);
                Display.Pause();
                return;
            }
            else
            {
                Console.Clear();
                Console.Write("\n");
                Draw.ASCII("art\\GameOver");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("\n\n\t\"... and here I was rooting for you, too.\"\n");
                Thread.Sleep(500);
                Console.WriteLine("\tThe bartender looks away and starts pouring a drink.\n");
                Thread.Sleep(500);
                Console.WriteLine("\t\"If you ever feel like taking on the Hanged Man");
                Console.WriteLine("\tagain though,\" he says as a smile breaks across his face,");
                Console.WriteLine("\t\"then don't be a stranger, you hear?\"\n");
                Thread.Sleep(500);
                Display.Pause();
                return;
            }
        }

    }
}
