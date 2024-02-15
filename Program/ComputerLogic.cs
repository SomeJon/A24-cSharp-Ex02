using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex02
{
    internal struct ComputerLogic
    {
        internal enum eAiType
        {
            RandomAi,
            AiLevel1,
            AiLevel2,
        }

        private eAiType m_AiType;

        public ComputerLogic(eAiType i_AiType)
        {
            m_AiType = i_AiType;
        }

        internal eAiType AiType
        {
            get 
            {
                return m_AiType;
            }
            set 
            { 
                m_AiType = value;
            }
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
