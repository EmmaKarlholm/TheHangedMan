using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangedMan.classes.imported;


namespace TheHangedMan.classes
{
    internal class GameManager
    {
        /// <summary>
        /// The actual game starts here, choosing a word of the supplied wordLength.
        /// </summary>
        /// <param name="wordLength"></param>
        public static void Start(int wordLength)
        {
            Word secretWord = WordList.RandomWord(wordLength);
            int failures = 0;

            // Fill the LetterSpaces array with spaces.
            for (int i = 0; i < secretWord.Letters.Length; i++)
            {
                secretWord.LetterSpaces[i] = '_';
            }
            
            List<char> guessedLetters = new List<char>();

            bool notYetSolved = true;
            while (notYetSolved)
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
                    notYetSolved = false; // Thus the game has been solved!
                }

                Console.Write("\n  Please, make a guess: ");

                ConsoleKeyInfo pressed = Console.ReadKey(true);
                if (char.IsLetter(pressed.KeyChar))
                {
                    char guessedLetter = char.ToLower(pressed.KeyChar);
                    guessedLetters.Add(guessedLetter);
                    bool wasGoodGuess = false;

                    // Go through the word letter by letter and update the LetterSpaces along the way.
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
}
