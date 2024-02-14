using System;
using A24_Ex02;


namespace A24_Ex02
{
    public class Connect4Map
    {
        public enum eSlots
        {
            Empty,
            Player1Token,
            Player2Token,
        }
        private eSlots[,] m_board;
        
        public eSlots[,] Boardx 
        {
            get 
            {
                readonly eSlots[,] o_board = m_board;
                return m_board; 
            }
            set { m_board = value; }
        }
    }
}
