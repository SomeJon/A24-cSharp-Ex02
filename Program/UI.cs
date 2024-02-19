using System;
using A24_Ex02;
using System.Text;
using static A24_Ex02.ComputerLogic;


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

        private const char  k_EmptySlot = ' ';
        private const char  k_Player1Token = 'X';
        private const char  k_Player2Token = 'O';

        private class Messages
        {
            internal const string   k_OpeningMSG =
@"Hello! welcome to connect4 game!";
            internal const string   k_GameTypeMSG = 
@"Please chose a game type from the options:
(1) Player vs Player
(2) Player vs Computer - Easy
(3) Player vs Computer - Noraml
(4) Player vs Computer - Hard";
            internal const byte     k_GameTypeNumOfOptions = 4;
            internal const string   k_InputWrongFormatMSG =
@"Input does not match requsted format, please try again:";
            internal const string   k_InputInvalidMSG =
@"Inserted input is invalid, please try again:";
            internal static string   k_InputBoardSizeMSG =
                string.Format(
@"Please enter board size
Rows range is       {0}-{1}
Columns range is    {2}-{3}
Please enter the size of the board in the format (RowNum)x(ColumnRow)", 
                Connect4BoardLogic.MinRowSize, Connect4BoardLogic.MaxRowSize, Connect4BoardLogic.MinColumnSize, Connect4BoardLogic.MaxRowSize);


        }

        public static void StartOfProgram
            (out Player o_Player1, out Player o_Player2, out ComputerLogic.eAiType o_AiType, out byte o_NumOfRows, out byte o_NumOfColumns)
        {

            Console.WriteLine(@"{0}", Messages.k_OpeningMSG);
            SetPlayerAndComputerType(out o_Player1, out o_Player2, out o_AiType);
            GetBoardSize(out o_NumOfRows, out o_NumOfColumns);
        }

        private static void SetPlayerAndComputerType(out Player o_Player1, out Player o_Player2, out ComputerLogic.eAiType o_AiType)
        {
            eUserChoice userChoice;
            string recivedUserInput = Console.ReadLine();

            Console.WriteLine("{1}", Messages.k_GameTypeMSG);
            while (Enum.TryParse(recivedUserInput, out userChoice) == false)
            {
                {
                    Console.WriteLine(Messages.k_InputWrongFormatMSG);
                    recivedUserInput = Console.ReadLine();
                }
            }

            o_Player1 = new Player(Player.ePlayerType.Player);
            switch (userChoice)
            {
                case eUserChoice.PvP:
                    o_Player2 = new Player(Player.ePlayerType.Player);
                    o_AiType = new ComputerLogic.eAiType();
                    break;
                case eUserChoice.EasyPvC:
                    o_Player2 = new Player(Player.ePlayerType.Computer);
                    o_AiType = ComputerLogic.eAiType.RandomAi;
                    break;
                case eUserChoice.NormalPvC:
                    o_Player2 = new Player(Player.ePlayerType.Computer);
                    o_AiType = ComputerLogic.eAiType.AiLevel1;
                    break;
                case eUserChoice.HardPvC:
                    o_Player2 = new Player(Player.ePlayerType.Computer);
                    o_AiType = ComputerLogic.eAiType.AiLevel2;
                    break;
                default:
                    o_Player2 = new Player(Player.ePlayerType.Player);
                    o_AiType = new ComputerLogic.eAiType();
                    break;
            }
        }

        private static void GetIntNumFromUser(out int o_Num)
        {
            int num;
            string userInput = Console.ReadLine();

            while (int.TryParse(userInput, out num) == false)
            {
                Console.WriteLine(@"{0}", Messages.k_InputWrongFormatMSG);
                userInput = Console.ReadLine();
            }

            o_Num = num;
        }

        private static void GetBoardSize(out byte o_NumOfRows, out byte o_NumOfColumns)
        {
            string userInput;
            string[] numsOfUserInput;
            bool checkInput;
            byte numOfRows = new byte();
            byte numOfColumns = new byte();
            
            Console.WriteLine(@"{0}", Messages.k_InputBoardSizeMSG);
            userInput = Console.ReadLine();
            numsOfUserInput = userInput.Split('(', ')', 'x', 'X');
            checkInput = numsOfUserInput.Length == 2 && byte.TryParse(numsOfUserInput[0], out numOfRows) && byte.TryParse(numsOfUserInput[1], out numOfColumns);
            if(checkInput == true)
            {
                checkInput = Connect4BoardLogic.CheckIfValidBoardInput(numOfRows, numOfColumns);
            }

            while(checkInput == false)
            {
                Console.WriteLine(@"{0}", Messages.k_InputWrongFormatMSG);
                userInput = Console.ReadLine();
                numsOfUserInput = userInput.Split('(', ')', 'x', 'X');
                checkInput = numsOfUserInput.Length == 2 && byte.TryParse(numsOfUserInput[0], out numOfRows) && byte.TryParse(numsOfUserInput[1], out numOfColumns);
                if (checkInput == true)
                {
                    checkInput = Connect4BoardLogic.CheckIfValidBoardInput(numOfRows, numOfColumns);
                }
            }

            o_NumOfRows = numOfRows;
            o_NumOfColumns = numOfColumns;
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
