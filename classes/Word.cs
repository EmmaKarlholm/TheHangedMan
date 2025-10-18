using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangedMan.classes
{
    internal class Word
    {
        public string DisplayableWord { get; private set; }
        public int WordLength { get; private set; }
        public char[] Letters { get; private set; }
        public char[] LetterSpaces { get; set; }
        public char[] GuessedLetters { get; set; }
        //public Dictionary<int, char> GuessedLetters { get; private set; }

        /// <summary>
        /// Creates a new Word object.
        /// </summary>
        /// <param name="incomingWord">string</param>
        public Word(string incomingWord)
        {
            DisplayableWord = incomingWord;
            WordLength = incomingWord.Length;
            Letters = ParseLetters(incomingWord);
            LetterSpaces = new char[WordLength];
            GuessedLetters = new char[WordLength];
            //GuessedLetters = new Dictionary<int, char>();
        }

        public char[] ParseLetters(string incomingWord)
        {
            char[] value = incomingWord.ToCharArray();
            return value;
        }
    }
}
