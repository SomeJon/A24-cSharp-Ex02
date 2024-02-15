using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex02
{
    internal class ComputerLogic
    {
        internal enum eAiType
        {
            RandomAi,
            AiLevel1,
            AiLevel2,
        }

        eAiType m_AiType = eAiType.RandomAi;

        internal eAiType m_AiType
        {
            get { }
        }

        internal byte GetTokenPlacemeant(Connect4BoardLogic.Connect4Board i_Board)
        {
            byte o_ChosenColumn;
            switch(m_AiType)
            {
                case eAiType.RandomAi:
                    o_ChosenColumn = GetRandomColumn(ref i_Board);
                    break;

                default:
                    break;
                        
            }

            return o_ChosenColumn;
        }

        private byte GetRandomColumn(ref Connect4BoardLogic.Connect4Board i_Board)
        {
            byte o_ChosenColumn;

            return o_ChosenColumn;
        }
    }
}
