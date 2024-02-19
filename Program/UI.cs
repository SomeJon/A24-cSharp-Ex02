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

        public static void OpeningMsg()
        {
            Console.WriteLine("Hello! welcome to connect4 game! if you are a human being living on this" +
            "miserable of a planet you really should already know the rules of this game. so let's skip straight ahead and start: \n");
        }
        //הפונקציה למטה כאן בודקת רק אם האינפוט הוא מספר או לא. תכלס לא הבנתי למה לא כבר לבדוק האם המספר הוא גם בין 4 ל8.
        //כאילו אם כבר ה"יו איי" מספקת פונקציה לקלוט מהמשתמש, למה שהיא כבר לא תבדוק את הקלט? היא גם ככה
        //עושה איזו שהיא בדיקת קלט. אז עד הסוף, לא?
        public static void GetNumOfRowsAndColumnsFromUser(out byte o_NumOfRows, out byte o_NumOfColumns)
        {
            byte numOfRows, numOfColumns;

            Console.WriteLine("please choose a number between {0} and {1} to be the number of rows: ",
                Connect4BoardLogic.MinRowSize, Connect4BoardLogic.MaxRowSize);//הוספתי לצורך זה פרופרטיז סטטיים לקבועים שבמחלקה
                                                                              //"קונקט4בוארד-לוג'יק". אולי זה באד פרקטיס?                                                  
            string userInput = Console.ReadLine();
            while(!byte.TryParse(userInput, out numOfRows))
            {
                Console.WriteLine("inserted input wasn't a number. please try again: ");
                userInput = Console.ReadLine();
            }
            
            Console.WriteLine("please choose a number between 4 and 8 to be the number of columns: ");
            userInput = Console.ReadLine();
            while (!byte.TryParse(userInput, out numOfColumns))
            {
                Console.WriteLine("inserted input wasn't a number. please try again: ");
                userInput = Console.ReadLine();
            }

            o_NumOfRows = numOfRows;
            o_NumOfColumns = numOfColumns;
        }
        public static void GetTypeOfOtherPlayerFromUser(out GameInterface.ePlayerType o_Player2)
        {
            Console.WriteLine("Please choose which type of opponent you are playing agains ('0' for another player, '1' for a computer):");
            string input = Console.ReadLine();
            while (input != "0" && input != "1")
            {
                Console.WriteLine("Invalid input. Please enter 0 for a player, 1 for a computer:");
                input = Console.ReadLine();
            }

            o_Player2 = (GameInterface.ePlayerType)Enum.Parse(typeof(GameInterface.ePlayerType), input);
        }
        public static void InvalidRowAndColumnSizeMsg()
        {
            Console.WriteLine("chosen row or column size is out of range." +
                "please choose a number between {0} and {1} for either of them:", Connect4BoardLogic.MinRowSize, Connect4BoardLogic.MaxRowSize);
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
