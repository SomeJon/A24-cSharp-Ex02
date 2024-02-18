using System;
using System.Runtime.InteropServices;
using A24_Ex02;


namespace A24_Ex02
{
    public class GameInterface
    {
        private Connect4BoardLogic Board = new Connect4BoardLogic();
        private UI userInterface = new UI();

        public void Run()
        {
            bool isValidInput = true;

            do
            {
                if(!isValidInput)
                {
                    UI.InvalidColumnChoiceMsg();
                }
                UI.ChooseANumberBetween4And8ForRowsMsg();
                userInterface.NumOfRows = UI.GetNumberBetween4And8ForRowsOrColumns();
                UI.ChooseANumberBetween4And8ForColumnsMsg();
                userInterface.NumOfColumns = UI.GetNumberBetween4And8ForRowsOrColumns();
                Board.SetBoard(userInterface.NumOfRows, userInterface.NumOfColumns, out isValidInput);
            } while (!isValidInput);



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
