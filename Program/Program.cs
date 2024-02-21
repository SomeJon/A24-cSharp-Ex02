using System;
using A24_Ex02;

namespace A24_Ex02
{
    class Program
    {
        public static void Main()
        {
            Run();
        }

        public static void Run()
        {
            bool didGameEnd = false;

            GameInterface gameInstance = new GameInterface();
            while(didGameEnd == false) 
            {
                gameInstance.NextTurn(out didGameEnd);
            }
        }
    }
}
