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
    /// Sets up what is needed for a multiplayer guessing game.
    /// </summary>
    internal class PlayMulti
    {
        /// <summary>
        /// Asks a player to choose a word.
        /// </summary>
        public static void AskForInput()
        {
            Console.Clear();
            Console.WriteLine("\n\tThis is a game played between two parties taking turns.");
            Console.WriteLine("\tThe first player will decide upon a word. The second player should not be");
            Console.WriteLine("\twatching this screen as that is being done.\n");
            Console.WriteLine("The first player will be instructed when it is time to swap over.\n");
            Thread.Sleep(500);
            Console.CursorVisible = true;
            Console.Write("\tWhat word do you want the second player to guess? ");
            string word = UserInput.TrimmedString();
            Word secretWord = new Word(word);
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("\tAll right! The game is ready and set.");
            Console.WriteLine("\tHand the device over to your friend.");
            Display.Pause();
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("\tWelcome to the Hanged Man.\n\t" +
                "You will be guessing the word chosen by the other player.");
            Thread.Sleep(500);
            Display.Pause();
            GameManager.Start(secretWord);
        }
    }
}
