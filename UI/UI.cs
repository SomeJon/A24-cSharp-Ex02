using System;
using A24_Ex02;
using System.Text;


namespace A24_Ex02
{
    public class UI
    {

        public enum eKindOfPlayers
        {
            TwoPlayers,
            PlayerAndComputer,
        }

        private eKindOfPlayers m_KindOfPlayers;
        private byte m_NumOfRows, m_NumOfColumns;
        private byte m_CurrentColumnToInsertTo;

   

        private const char k_EmptySlot = ' ';
        private const char k_Player1Token = 'X';
        private const char k_Player2Token = 'O';
        private const int k_MinNumOfColumnsOrRows = 4;
        private const int k_MaxNumOfColumnsOrRows = 8;
        public eKindOfPlayers KindOfPlayers
        {
            set
            {
                int userNumInput;

                Console.WriteLine($"Please choose which kind of player will play against you." +
                    $"press '0' so another player'll play, or '1' so the computer'll play:  ");
                while (true)
                {
                    string userStrInput = Console.ReadLine();

                    if (int.TryParse(userStrInput, out userNumInput))
                    {
                        if (userNumInput != 0 && userNumInput == 1)
                        {
                            Console.WriteLine("Invalid input. Please enter either 0 or 1.");
                        }
                        else
                        {
                            break;
                        } 
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter either 0 or 1.");
                    }
                }

                m_KindOfPlayers = (eKindOfPlayers)userNumInput;
            }

            get
            {
                return m_KindOfPlayers;
            }
        }
        public byte NumOfRows
        {
            set
            {
                m_NumOfRows = value;
            }

            get
            {
                return m_NumOfRows;
            }
        }
        public byte NumOfColumns
        {
            set
            {
                m_NumOfColumns = value;
            }

            get
            {
                return m_NumOfColumns;
            }
        }

        public byte CurrentColumnToInsertTo
        {
            set
            {
                Console.WriteLine("please choose a column to enter to: ");
                m_CurrentColumnToInsertTo = getNumberBetween4And8ForRowsOrColumns();
            }

            get
            {
                return m_CurrentColumnToInsertTo;
            }
        }
        public static void InvalidColumnChoiceMsg()
        {
            Console.WriteLine("the column you chose is out of range. please choose a legit number of column: ");
        }
        public static void ChooseANumberBetween4And8ForRowsMsg()
        {
            Console.WriteLine($"Please enter a number between {k_MinNumOfColumnsOrRows} and {k_MaxNumOfColumnsOrRows} to be the number of rows: ");
        }

        public static void ChooseANumberBetween4And8ForColumnsMsg()////יש כאן ובפונקציה השניה כפילות, כן. לא יודע איך מסדרים את זה
        {
            Console.WriteLine($"Please enter a number between {k_MinNumOfColumnsOrRows} and {k_MaxNumOfColumnsOrRows} to be the number of columns: ");
        }
        public static byte GetNumberBetween4And8ForRowsOrColumns()
        {
            byte number;

            string input = Console.ReadLine();
            while (!byte.TryParse(input, out number))
            {
                Console.WriteLine("you entered an invalid input. please enter a valid number: ");
            }

            return number;
        }
        public static void ShowBoard(Connect4BoardLogic.Connect4Board i_Board)
        {
            byte numOfColumns = i_Board.NumOfColumns;
            byte numOfRows = i_Board.NumOfRows;
            int lineSize = ((int)numOfColumns * 4) + 1;
            StringBuilder lineToPrint = new StringBuilder();
            lineToPrint.Capacity = lineSize;

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
            
            for(byte rowToPrint = 1; rowToPrint <= numOfRows; rowToPrint++)
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

                for(int i = 0; i < lineSize; i++)
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

            switch(i_Token) 
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
