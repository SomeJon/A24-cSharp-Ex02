using System;
using System.Runtime.InteropServices;
using A24_Ex02;
using A24_Ex02_ConsoleUi;


namespace A24_Ex02
{
    public class GameInterface
    {
        public const byte k_NoColumnChosen = 0;
        private Connect4BoardLogic m_Board;
        private Player m_Player1 = null;
        private Player m_player2 = null;
        private readonly ComputerLogic.eAiType m_ComputerType = ComputerLogic.eAiType.RandomAi;

        public GameInterface()
        {
            byte numOfRows, numOfColumns;

            UI.StartOfProgram(out m_Player1, out m_player2, out m_ComputerType, out numOfRows, out numOfColumns);
            m_Board = new Connect4BoardLogic(numOfRows, numOfColumns);
        }



        internal void testRun()
        {
            byte n = 5;
            byte o_k = new byte();
            bool nothing = new bool();

            if (m_Board.Board.GetSlot(1, 1) == Connect4BoardLogic.eSlots.EmptySlot)
                Console.WriteLine("true");
            m_Board.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            UI.ShowBoard(m_Board.Board);

            m_Board.EnterToken(3, Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            Console.WriteLine(o_k);
            UI.ShowBoard(m_Board.Board);

            m_Board.EnterToken(ComputerLogic.GetTokenPlacement(ref m_Board, Connect4BoardLogic.eSlots.Player2Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            m_Board.EnterToken(ComputerLogic.GetTokenPlacement(ref m_Board, Connect4BoardLogic.eSlots.Player2Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            m_Board.EnterToken(ComputerLogic.GetTokenPlacement(ref m_Board, Connect4BoardLogic.eSlots.Player2Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            m_Board.EnterToken(ComputerLogic.GetTokenPlacement(ref m_Board, Connect4BoardLogic.eSlots.Player2Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            UI.ShowBoard(m_Board.Board);
            Console.WriteLine(o_k);

            m_Board.EnterToken(ComputerLogic.GetTokenPlacement(ref m_Board, Connect4BoardLogic.eSlots.Player1Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            m_Board.EnterToken(ComputerLogic.GetTokenPlacement(ref m_Board, Connect4BoardLogic.eSlots.Player1Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            m_Board.EnterToken(ComputerLogic.GetTokenPlacement(ref m_Board, Connect4BoardLogic.eSlots.Player1Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            m_Board.EnterToken(ComputerLogic.GetTokenPlacement(ref m_Board, Connect4BoardLogic.eSlots.Player1Token, m_ComputerType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            UI.ShowBoard(m_Board.Board);
            byte a;
            UI.ChoseColumnForToken(true,false,out a);
            m_Board.EnterToken(a, Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            UI.ShowBoard(m_Board.Board);
            UI.ChoseColumnForToken(true, false, out a);
            m_Board.EnterToken(a, Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            UI.ShowBoard(m_Board.Board);
            UI.ChoseColumnForToken(true, false, out a);
            m_Board.EnterToken(a, Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            UI.ShowBoard(m_Board.Board);
            UI.ChoseColumnForToken(true, false, out a);
            m_Board.EnterToken(a, Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            UI.ShowBoard(m_Board.Board);

            Console.WriteLine(o_k);
        }
    }
}
