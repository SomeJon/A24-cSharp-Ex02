using System;
using System.Runtime.InteropServices;
using A24_Ex02;


namespace A24_Ex02
{
    internal class GameInterface
    {
        Connect4BoardLogic test;

        internal void testRun()
        {
            test = new Connect4BoardLogic();
            byte n = 5;
            byte o_k = new byte();
            bool nothing = new bool();

            test.SetBoard(n, n, ref nothing);
            if (test.Board.Value.GetSlot(1,1) == Connect4BoardLogic.eSlots.EmptySlot)
                Console.WriteLine("true");
            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, ref o_k, ref nothing);
            UI.ShowBoard(test.Board.Value);

            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, ref o_k, ref nothing);
            Console.WriteLine(o_k);

            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, ref o_k, ref nothing);
            UI.ShowBoard(test.Board.Value);

            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, ref o_k, ref nothing);

            Console.WriteLine(o_k);
            UI.ShowBoard(test.Board.Value);
        }
    }
}
