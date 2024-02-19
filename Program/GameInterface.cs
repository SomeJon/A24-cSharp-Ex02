using System;
using A24_Ex02;
using A24_Ex02_ConsoleUi;


namespace A24_Ex02
{
    public class GameInterface
    {
        private Connect4BoardLogic m_Board;
        private Player m_Player1 = null;
        private Player m_player2 = null;
        private readonly ComputerLogic.eAiType m_ComputerType = ComputerLogic.eAiType.RandomAi;

        public GameInterface()
        {

            //UI.StartOfProgram(out m_Player1);
        }



        Connect4BoardLogic test = new Connect4BoardLogic();
        internal void testRun()
        {
            test = new Connect4BoardLogic();
            byte n = 5;
            byte o_k = new byte();
            bool nothing = new bool();

            test.SetBoard(n, n, out nothing);
            if (test.Board.Value.GetSlot(1, 1) == Connect4BoardLogic.eSlots.EmptySlot)
                Console.WriteLine("true");
            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            UI.ShowBoard(test.Board.Value);

            test.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            Console.WriteLine(o_k);
            UI.ShowBoard(test.Board.Value);

            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player2Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player2Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player2Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player2Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            UI.ShowBoard(test.Board.Value);
            Console.WriteLine(o_k);

            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player1Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player1Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player1Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player1Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            UI.ShowBoard(test.Board.Value);
            Console.WriteLine(o_k);
        }
    }
}
