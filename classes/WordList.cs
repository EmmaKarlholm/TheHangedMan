using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangedMan.classes
{
    internal class WordList
    {
        static WordList()
        {
            string[] AllWords = [
                "word1",
                "word2",
                "word3"
                
            ];

            Dictionary<string, int> WordsAndLength = new Dictionary<string, int>();
            foreach (string word in AllWords)
            {
                WordsAndLength[word] = (word.Length);
            }

        }


        //public string[] ParseWordsFile()
        //{

        //return words();
        //}
    }
}
