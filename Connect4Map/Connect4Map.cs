using System;
using A24_Ex02;


namespace A24_Ex02
{
    public class Connect4Map
    {
        public enum eSlots
        {
            EmptySlot,
            Player1Token,
            Player2Token,
        }

        public struct Connect4Matrix
        {
            private eSlots[,] m_Matrix;

            public Connect4Matrix(byte i_NumOfRows, byte i_NumOfColumns)
            {
                m_Matrix = new eSlots[i_NumOfRows, i_NumOfRows];
            }

            public eSlots[,] Matrix
            {
                get
                {
                    return m_Matrix;
                }
            }

            public eSlots GetSlot(byte i_Row, byte i_Column)
            {
                return m_Matrix[i_Row - 1, i_Column - 1];
            }
            internal byte EnterTokenToSlot(eSlots i_EnteredToken, byte i_Column)
            {
                byte rowToCheck = 1;

                while (GetSlot(rowToCheck, i_Column) != eSlots.EmptySlot)
                {
                    rowToCheck++;
                }

                m_Matrix[rowToCheck, i_Column] = i_EnteredToken;
                return rowToCheck;
            }
        }

        private const byte k_MaxRowSize = 8;
        private const byte k_MinRowSize = 4;
        private const byte k_MaxColumnSize = 8;
        private const byte k_MinColumnSize = 4;
        private Connect4Matrix? m_Board;
        private byte m_NumOfColumns = k_MinColumnSize;
        private byte m_NumOfRows = k_MinRowSize;

        public Connect4Matrix? Board
        {
            get
            {
                return m_Board;
            }
        }

        public bool SetBoard(byte i_NumOfRows, byte i_NumOfColumns)
        {
            bool validBoardInput = false;

            if (CheckBoardSize(i_NumOfRows, i_NumOfColumns) == true)
            {
                validBoardInput = true;
                m_Board = new Connect4Matrix(i_NumOfRows, i_NumOfColumns);
                m_NumOfColumns = i_NumOfColumns;
                m_NumOfRows = i_NumOfRows;
            }

            return validBoardInput;
        }

        public bool EnterToken(byte i_Column, eSlots i_EnteredToken, ref byte o_ClosenessToVictory)
        {
            bool successfulTokenEntry;
            byte rowToEnter = m_NumOfRows;

            if(m_Board.Value.GetSlot(rowToEnter, i_Column) == eSlots.EmptySlot)
            {
                successfulTokenEntry = true;
                rowToEnter = Board.Value.EnterTokenToSlot(i_EnteredToken, i_Column);
                o_ClosenessToVictory = CheckVictoryCloseness(i_EnteredToken, rowToEnter, i_Column);
            }
            else
            {
                successfulTokenEntry = false;
                o_ClosenessToVictory = 0;
            }
            
            return successfulTokenEntry;
        }


        private bool CheckBoardSize(byte i_NumOfRows, byte i_NumOfColumns)
        {
            bool rowSizeCheck = (i_NumOfRows >= k_MinColumnSize && i_NumOfRows <= k_MaxRowSize);
            bool columnSizeCheck = (i_NumOfColumns >= k_MinColumnSize && i_NumOfColumns <= k_MaxColumnSize);
            
            return rowSizeCheck && columnSizeCheck;
        }

        private byte CheckVictoryCloseness(eSlots i_TokenToCheck, byte i_Row, byte i_Column)
        {
            const int k_UpOrRight = 1;
            const int k_Reverse = -1;
            const int k_Stay = 0;
            byte vertical;
            byte horizontal;
            byte diagonalUp;
            byte diagonalDown;
            byte victoryCloseness;

            vertical = (byte)
                ((int)CheckDirectionMatches(i_TokenToCheck, i_Row, i_Column, k_Stay, k_UpOrRight) +
                (int)CheckDirectionMatches(i_TokenToCheck, i_Row, i_Column, k_Stay, (k_Reverse * k_UpOrRight)));
            horizontal = (byte)
                ((int)CheckDirectionMatches(i_TokenToCheck, i_Row, i_Column, k_UpOrRight, k_Stay) +
                (int)CheckDirectionMatches(i_TokenToCheck, i_Row, i_Column, (k_Reverse * k_UpOrRight), k_Stay));
            diagonalUp = (byte)
                ((int)CheckDirectionMatches(i_TokenToCheck, i_Row, i_Column, k_UpOrRight, k_UpOrRight) +
                (int)CheckDirectionMatches(i_TokenToCheck, i_Row, i_Column, (k_Reverse * k_UpOrRight), (k_Reverse * k_UpOrRight)));
            diagonalDown = (byte)
                ((int)CheckDirectionMatches(i_TokenToCheck, i_Row, i_Column, k_UpOrRight, (k_Reverse * k_UpOrRight)) +
                (int)CheckDirectionMatches(i_TokenToCheck, i_Row, i_Column, (k_Reverse * k_UpOrRight), k_UpOrRight));
            victoryCloseness = Math.Max(Math.Max(diagonalUp, diagonalDown), Math.Max(vertical, horizontal));

            return victoryCloseness;
        }

        private byte CheckDirectionMatches(eSlots i_WantedToken, byte i_RowPlacement, byte i_ColumnPlacement, 
            int i_RowDirection, int i_ColumnDirection)
        {
            byte o_CurrCount = 0;
            byte rowCoordToCheck = (byte)((int)i_RowPlacement + i_RowDirection);
            byte columnCoordToCheck = (byte)((int)i_ColumnPlacement + i_ColumnDirection);
            bool coordsInBoard = rowCoordToCheck >= 1 && rowCoordToCheck <= m_NumOfRows 
                && columnCoordToCheck >= 1 && columnCoordToCheck <= m_NumOfColumns;


            if (coordsInBoard == true && m_Board.Value.GetSlot(rowCoordToCheck, columnCoordToCheck) == i_WantedToken)
            {
                o_CurrCount = (byte)((int)o_CurrCount + (int)CheckDirectionMatches
                    (i_WantedToken, rowCoordToCheck, columnCoordToCheck, i_RowDirection, i_ColumnDirection));
            }

            return o_CurrCount;
        }

    }
}
