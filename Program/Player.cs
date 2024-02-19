using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex02
{
    public class Player
    {
        public enum ePlayerType
        {
            Player,
            Computer
        }

        private byte m_Score = 0;
        private ePlayerType m_PlayerType;

        public Player(ePlayerType playerType)
        {
            this.m_PlayerType = playerType;
        }

        public ePlayerType PlayerType { get; set; }
        public byte Score { get; set; }
    }
}
