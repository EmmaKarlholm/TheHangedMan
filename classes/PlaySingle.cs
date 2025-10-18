using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangedMan.classes.imported;

namespace TheHangedMan.classes
{
    /// <summary>
    /// Handles the output of the MenuHandler to create a word to send to the GameManager.
    /// </summary>
    internal class PlaySingle
    {
        /// <summary>
        /// Takes the given difficulty value, handles it and sends the parsed value to GameManager.Start().
        /// </summary>
        /// <param name="difficulty">string</param>
        public static void ParseOptions(string difficulty)
        {
            Random random = new Random();
            switch (difficulty)
            {
                case "easy":
                    {
                        Word secretWord = WordList.RandomWord(random.Next(6, 12));
                        GameManager.Start(secretWord);
                        break;
                    }
                case "hard":
                    {
                        Word secretWord = WordList.RandomWord(random.Next(3, 7));
                        GameManager.Start(secretWord);
                        break;
                    }
                default:
                    {
                        // I asked ChatGPT whether there was a better way of using a helper method such as this.
                        // It told me that using var is generally easier to follow than writing a longer tuple with
                        // manual specification, which I will trust. It also helped me shorten the amount of code in
                        // StringToInteger as well.
                        var (difficultyInt, wasSuccessful) = DataHandling.StringToInteger(difficulty);
                        if (wasSuccessful)
                        {
                            Word secretWord = WordList.RandomWord(difficultyInt);

                            GameManager.Start(secretWord);
                        }
                        break;
                    }
            }

        }
    }
}
