using System.Linq.Expressions;
using TheHangedMan.classes;


namespace TheHangedMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool stillRunning = true;
            while (stillRunning)
            {
                stillRunning = MenuHandler.Start();
            }
        }
    }
}
