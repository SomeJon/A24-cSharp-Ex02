using System;
using System.Runtime.InteropServices;
using A24_Ex02;


namespace A24_Ex02
{
    public class GameInterface
    {
        Connect4BoardLogic test;

        public void testRun()
        {
            test = new Connect4BoardLogic();
            byte n = 5;
            bool hey = test.SetBoard(n, n);
            byte o_k = new byte();

            if (test.Board.Value.GetSlot(1,1) == Connect4BoardLogic.eSlots.EmptySlot)
                Console.WriteLine("true");
            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, ref o_k);
            UI.ShowBoard(test.Board.Value);

            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, ref o_k);
            Console.WriteLine(o_k);

            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, ref o_k);
            UI.ShowBoard(test.Board.Value);

            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, ref o_k);

            Console.WriteLine(o_k);
            UI.ShowBoard(test.Board.Value);
        }
    }
}
