using System;
using System.Runtime.InteropServices;
using A24_Ex02;


namespace A24_Ex02
{
    public class GameInterface
    {
        public enum ePlayerType//stam
        {
            Player,
            Computer
        }

        private byte m_NumOfRows, m_NumOfColumns;
        private Connect4BoardLogic Board = new Connect4BoardLogic();
        private ePlayerType m_Player1, m_Player2;

        public void Run()
        {
            bool isValidNumOfRowsAndColumns = false;
            UI.OpeningMsg();
            while (!isValidNumOfRowsAndColumns)
            {
                UI.GetNumOfRowsAndColumnsFromUser(out m_NumOfRows, out m_NumOfColumns);
                Board.SetBoard(m_NumOfRows, m_NumOfColumns, out isValidNumOfRowsAndColumns);
                if(!isValidNumOfRowsAndColumns)
                {
                    UI.InvalidRowAndColumnSizeMsg();
                }
            }
        }
        
        







/*        Connect4BoardLogic test = new Connect4BoardLogic();
        ComputerLogic.eAiType compType = ComputerLogic.eAiType.RandomAi;
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

            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player2Token, compType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player2Token, compType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player2Token, compType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player2Token, compType),
                Connect4BoardLogic.eSlots.Player2Token, out o_k, out nothing);
            UI.ShowBoard(test.Board.Value);
            Console.WriteLine(o_k);

            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player1Token, compType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player1Token, compType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player1Token, compType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            test.EnterToken(ComputerLogic.GetTokenPlacement(ref test, Connect4BoardLogic.eSlots.Player1Token, compType),
                Connect4BoardLogic.eSlots.Player1Token, out o_k, out nothing);
            UI.ShowBoard(test.Board.Value);
            Console.WriteLine(o_k);
        }*/
    }
}
