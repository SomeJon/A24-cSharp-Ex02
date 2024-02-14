using System;
using A24_Ex02;
using System.Text;


namespace A24_Ex02
{
    public class UI
    {
        private const char k_EmptySlot = ' ';
        private const char k_Player1Token = 'X';
        private const char k_Player2Token = 'O';

        public static  void ShowBoard(Connect4BoardLogic.Connect4Board i_Board)
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
