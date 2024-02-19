using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex02
{
    internal class ComputerLogic
    {
        internal enum eAiType//stam
        {
            RandomAi,
            AiLevel1,
            AiLevel2,
        }

        private static Random m_Random = new Random();

        internal static byte GetTokenPlacement(ref Connect4BoardLogic i_BoardState, Connect4BoardLogic.eSlots i_ComputerToken, eAiType i_AiType)
        {
            byte o_ChosenColumn = 0;

            if (i_AiType == eAiType.RandomAi)
            {
                bool possibleInput = new bool();
                do
                {
                    o_ChosenColumn = GetRandomColumn(i_BoardState.Board.Value.NumOfColumns);
                    possibleInput = i_BoardState.IsColumnNotAlreadyFull(o_ChosenColumn);
                }
                while (possibleInput == false);
            }
            else
            {
                o_ChosenColumn = FindBestColumn(i_BoardState, i_ComputerToken, i_AiType);
            }

            return o_ChosenColumn;
        }

        private static byte GetRandomColumn(byte i_NumOfColumns)
        {
            byte o_ChosenColumn;

            o_ChosenColumn = (byte)m_Random.Next(Connect4BoardLogic.k_FirstRow, i_NumOfColumns);

            return o_ChosenColumn;
        }

        private static byte FindBestColumn(Connect4BoardLogic i_BoardInstance, Connect4BoardLogic.eSlots i_ComputerToken, eAiType i_AiType)
        {
            byte o_ChosenColumn = 0;

            return o_ChosenColumn;
        }
    }
}
