using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangedMan.classes
{
    internal static class WordList
    {
        // Originally, I didn't use a property for this dictionary. I asked ChatGPT for
        // ideas on how to shorten my code, which was quite lengthy originally. By making
        // this dictionary into a property I could access it throughout the entire class
        // and could cut down on code complexity by a lot. Functionality did not change,
        // but I strongly believe readability did. Concisiveness certainly did.
        public static Dictionary<string, int> WordsAndLength = new Dictionary<string, int>();

        static WordList()
        {
            // This Words file was created by asking ChatGPT to generate a list of suitable
            // words for a Hangman game. I would have used another resource to find a list
            // of words but could rely on the language model to make me one.
            string wordsFile = "Words";


            if (File.Exists(wordsFile))
            {
                foreach (string line in File.ReadAllLines(wordsFile))
                {
                    string word = line.Trim().ToUpper();

                    if (!string.IsNullOrEmpty(word))
                    {
                        WordsAndLength[line] = (line.Length);
                    }
                }
            }
            else
            {
                Program.ErrorMessage("Could not find Words file for WordList()!");
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Returns a random word from the WordsAndLength dictionary given the supplied word length.
        /// </summary>
        /// <param name="wordLength">integer</param>
        /// <returns>Word</returns>
        public static Word RandomWord(int wordLength)
        {
            if (WordsAndLength.Count == 0) // List is empty
            {
                Program.ErrorMessage("WordsAndLength found empty in WordList.RandomWord!");
                Environment.Exit(1);
                return null; // This will never run. It is here to ensure the compiler remains happy.
            }
            else
            {
                List<string> relevantWords = new List<string>();
                foreach (KeyValuePair<string, int> word in WordsAndLength)
                {
                    if (word.Value == wordLength)
                    {
                        relevantWords.Add(word.Value.ToString());
                    }
                }

                Random random = new Random();
                int randomIndex = random.Next(relevantWords.Count);
                string incomingWord = relevantWords[randomIndex];
                return new Word(incomingWord);
            }
        }
    }
}
