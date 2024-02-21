using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex02
{
    public class ComputerLogic
    {
        public enum eAiType
        {
            RandomAi,
            AiLevel1,
            AiLevel2,
        }

        private static Random m_Random = new Random();

        internal static void GetTokenPlacement
            (Connect4BoardLogic i_BoardState, Connect4BoardLogic.eSlots i_ComputerToken, eAiType i_AiType, out byte o_ColumnChosen)
        {
            byte chosenColumn = 0;

            if (i_AiType == eAiType.RandomAi)
            {
                bool possibleInput = new bool();
                byte randomIndex;

                randomIndex = GetRandomColumn(i_BoardState.Board.GetNumOfNonFullColumns());
                while(randomIndex !=0)
                {
                    chosenColumn++; 
                    possibleInput = i_BoardState.IsColumnNotAlreadyFull(chosenColumn);
                    if (possibleInput == true)
                    {
                        randomIndex--;
                    }
                }

            }
            else
            {
                chosenColumn = FindBestColumn(i_BoardState, i_ComputerToken, i_AiType);
            }

            o_ColumnChosen = chosenColumn;
        }

        private static byte GetRandomColumn(byte i_NumOfColumns)
        {
            byte o_randomIndex;

            o_randomIndex = (byte)m_Random.Next(Connect4BoardLogic.k_FirstRow, i_NumOfColumns);

            return o_randomIndex;
        }

        private static byte FindBestColumn(Connect4BoardLogic i_BoardInstance, Connect4BoardLogic.eSlots i_ComputerToken, eAiType i_AiType)
        {
            byte o_randomIndex = 0;

            return o_randomIndex;
        }
    }
}
