using System;


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
        private string m_PlayerName;

        public Player(ePlayerType playerType, string i_PlayerName)
        {
            this.m_PlayerType = playerType;
            this.m_PlayerName = i_PlayerName;
        }

        public ePlayerType PlayerType 
        { 
            get { return m_PlayerType;  } 
            set { m_PlayerType = value; }
        }
        public byte Score 
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        public string PlayerName 
        {
            get { return m_PlayerName; }
        }
    }
}
