using System;
using A24_Ex02;
using System.Text;
using static A24_Ex02.ComputerLogic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;
using System.Security.Policy;


namespace A24_Ex02_ConsoleUi
{
    
    public class UI
    {
        private enum eUserChoice
        {
            PvP = 1,
            EasyPvC = 2,
            NormalPvC = 3,
            HardPvC = 4
        }

        private enum eReturnedValueAfterEnd
        {
            NoReset,
            Reset
        }

        private class Messages
        {
            internal const string       k_OpeningMSG =
@"Hello, welcome to connect4 game!";
            internal const string       k_GameTypeMSG = 
@"Please chose a game type from the options:
(1) Player vs Player
(2) Player vs Computer - Easy
(3) Player vs Computer - Noraml
(4) Player vs Computer - Hard";
            internal const byte         k_GameTypeNumOfOptions = 4;
            internal const string       k_InputWrongFormatMSG =
@"Input does not match requsted format. Please try again:";
            internal const string       k_InputOutOfRangeMSG =
@"Inserted input out of range. Please try again:";
            internal const string k_ResetInput = "Q";
            internal const string k_ColumnAlreadyFull = "Chosen Column is already full. Please try again:";
            internal static string      k_InputBoardSizeMSG =
                string.Format(
@"Please enter board size
Rows range is       {0}-{1}
Columns range is    {2}-{3}
Please enter the size of the board in the format (RowNum)x(ColumnRow)", 
                Connect4BoardLogic.k_MinRowSize, Connect4BoardLogic.k_MaxRowSize, Connect4BoardLogic.k_MinColumnSize, Connect4BoardLogic.k_MaxRowSize);
            internal static string k_ChoseColumnOptions =
                string.Format(
@"Please enter:
A number representing a column, Or enter {0} to give up:", 
k_ResetInput);
            internal const string k_AfterGameMenuMSG = "Would you like to play another round? Please enter 1 for yes, and 0 for no";
            internal const string k_GameEndMSG =
@"Game ended! ending scores are:
Player 1 score - {0}
Player 2 score - {1}";
        }

        private const char k_EmptySlot = ' ';
        private const char k_Player1Token = 'X';
        private const char k_Player2Token = 'O';

        public static void StartOfProgram
            (out Player.ePlayerType o_Player1, out Player.ePlayerType o_Player2, out ComputerLogic.eAiType o_AiType, out byte o_NumOfRows, out byte o_NumOfColumns)
        {

            Console.WriteLine("{0}", Messages.k_OpeningMSG);
            SetPlayerAndComputerType(out o_Player1, out o_Player2, out o_AiType);
            GetBoardSize(out o_NumOfRows, out o_NumOfColumns);
        }


        public static void ShowBoard(Connect4BoardLogic.Connect4Board i_Board)
        {
            byte numOfColumns = i_Board.NumOfColumns;
            byte numOfRows = i_Board.NumOfRows;
            int lineSize = ((int)numOfColumns * 4) + 1;
            StringBuilder lineToPrint = new StringBuilder();
            lineToPrint.Capacity = lineSize;

            Ex02.ConsoleUtils.Screen.Clear();
            lineToPrint.Append(' ');
            for (int columnToPrint = 1; columnToPrint <= numOfColumns; columnToPrint++)
            {
                lineToPrint.Append(' ');
                lineToPrint.Append(columnToPrint);
                lineToPrint.Append(' ');
                lineToPrint.Append(' ');

            }

            Console.WriteLine(lineToPrint);
            lineToPrint.Clear();
            lineToPrint.Capacity = lineSize;

            for (byte rowToPrint = 1; rowToPrint <= numOfRows; rowToPrint++)
            {
                lineToPrint.Append('|');
                for (byte columnToPrint = 1; columnToPrint <= numOfColumns; columnToPrint++)
                {
                    char currToken = ConverteSlotToChar(i_Board.GetSlot((byte)rowToPrint, columnToPrint));

                    lineToPrint.Append(' ');
                    lineToPrint.Append(currToken);
                    lineToPrint.Append(' ');
                    lineToPrint.Append('|');
                }

                Console.WriteLine(lineToPrint);
                lineToPrint.Clear();
                lineToPrint.Capacity = lineSize;

                for (int i = 0; i < lineSize; i++)
                {
                    lineToPrint.Append('=');
                }

                Console.WriteLine(lineToPrint);
                lineToPrint.Clear();
                lineToPrint.Capacity = lineSize;
            }
        }

        public static void ChoseColumnForToken(bool i_FirstToken, bool i_IsFull, out byte o_ColumnChosen)
        {
            string userInput;
            string msg;
            bool checkForRightInput = false;

            if(i_FirstToken == true)
            {
                msg = Messages.k_ChoseColumnOptions;
            }
            else if(i_IsFull == true)
            {
                msg = Messages.k_ColumnAlreadyFull;
            }
            else
            {
                msg = Messages.k_InputOutOfRangeMSG;
            }

            Console.WriteLine(msg);
            userInput = Console.ReadLine();

            do
            {
                if (string.Equals(userInput, Messages.k_ResetInput) == true)
                {
                    o_ColumnChosen = GameInterface.k_NoColumnChosen;
                    checkForRightInput = true;
                }
                else if (byte.TryParse(userInput, out o_ColumnChosen) == true)
                {
                    checkForRightInput = true;
                }
                else
                {
                    Console.WriteLine(Messages.k_InputWrongFormatMSG);
                    userInput = Console.ReadLine();
                }
            }
            while (checkForRightInput == false);

        }

        public static void VictoyMSG(Player i_WinningPlayer)
        {
            StringBuilder msg = new StringBuilder("Victory! ");

            msg.Append(i_WinningPlayer.PlayerName);
            msg.Append(" has won the round!");
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(msg);
        }

        public static void TieMSG()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Its a tie! no winner! everyone is a winner in a way!");
        }

        public static void AfterRound(out bool o_PlayAgain)
        {
            
            string userInput;
            eReturnedValueAfterEnd input;
            bool checkInput;

            Console.WriteLine(Messages.k_AfterGameMenuMSG);
            userInput = Console.ReadLine();

            checkInput = eReturnedValueAfterEnd.TryParse(userInput, out input);
            while(checkInput == false)
            {
                Console.WriteLine(Messages.k_InputWrongFormatMSG);
                userInput = Console.ReadLine();
                checkInput = eReturnedValueAfterEnd.TryParse(userInput, out input);
            }

            o_PlayAgain = input == eReturnedValueAfterEnd.Reset;
        }

        public static void ProgramEnd(byte i_Player1Score, byte i_Player2Score)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(Messages.k_GameEndMSG, i_Player1Score, i_Player2Score);
            Console.WriteLine("Press enter to close program");
            Console.ReadLine();
        }

        private static void SetPlayerAndComputerType(out Player.ePlayerType o_Player1, out Player.ePlayerType o_Player2, out ComputerLogic.eAiType o_AiType)
        {
            eUserChoice userChoice;
            string recivedUserInput; 

            Console.WriteLine("{0}", Messages.k_GameTypeMSG);
            recivedUserInput = Console.ReadLine();
            while (Enum.TryParse(recivedUserInput, out userChoice) == false)
            {
                {
                    Console.WriteLine(Messages.k_InputWrongFormatMSG);
                    recivedUserInput = Console.ReadLine();
                }
            }

            o_Player1 = Player.ePlayerType.Player;
            switch (userChoice)
            {
                case eUserChoice.PvP:
                    o_Player2 = Player.ePlayerType.Player;
                    o_AiType = new ComputerLogic.eAiType();
                    break;
                case eUserChoice.EasyPvC:
                    o_Player2 = Player.ePlayerType.Computer;
                    o_AiType = ComputerLogic.eAiType.RandomAi;
                    break;
                case eUserChoice.NormalPvC:
                    o_Player2 = Player.ePlayerType.Computer;
                    o_AiType = ComputerLogic.eAiType.AiLevel1;
                    break;
                case eUserChoice.HardPvC:
                    o_Player2 = Player.ePlayerType.Computer;
                    o_AiType = ComputerLogic.eAiType.AiLevel2;
                    break;
                default:
                    o_Player2 = Player.ePlayerType.Computer;
                    o_AiType = new ComputerLogic.eAiType();
                    break;
            }
        }

        private static void GetBoardSize(out byte o_NumOfRows, out byte o_NumOfColumns)
        {
            string userInput;
            char[] separators = new char[] { '(', ')', 'x', 'X', ' '};
            string[] numsOfUserInput;
            bool checkInput;
            byte numOfRows = new byte();
            byte numOfColumns = new byte();
            
            Console.WriteLine("{0}", Messages.k_InputBoardSizeMSG);
            userInput = Console.ReadLine();
            numsOfUserInput = userInput.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            checkInput = numsOfUserInput.Length == 2 && byte.TryParse(numsOfUserInput[0], out numOfRows) && byte.TryParse(numsOfUserInput[1], out numOfColumns);
            if(checkInput == true)
            {
                checkInput = Connect4BoardLogic.CheckIfValidBoardInput(numOfRows, numOfColumns);
            }

            while(checkInput == false)
            {
                Console.WriteLine("{0}", Messages.k_InputWrongFormatMSG);
                userInput = Console.ReadLine();
                numsOfUserInput = userInput.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                checkInput = numsOfUserInput.Length == 2 && byte.TryParse(numsOfUserInput[0], out numOfRows) && byte.TryParse(numsOfUserInput[1], out numOfColumns);
                if (checkInput == true)
                {
                    checkInput = Connect4BoardLogic.CheckIfValidBoardInput(numOfRows, numOfColumns);
                }
            }

            o_NumOfRows = numOfRows;
            o_NumOfColumns = numOfColumns;
        }

        private static char ConverteSlotToChar(Connect4BoardLogic.eSlots i_Token)
        {
            char o_ReturnedChar;

            switch (i_Token)
            {
                case Connect4BoardLogic.eSlots.Player1Token:
                    o_ReturnedChar = k_Player1Token;
                    break;
                case Connect4BoardLogic.eSlots.Player2Token:
                    o_ReturnedChar = k_Player2Token;
                    break;
                default:
                    o_ReturnedChar = k_EmptySlot;
                    break;
            }

            return o_ReturnedChar;
        }
    }
}
