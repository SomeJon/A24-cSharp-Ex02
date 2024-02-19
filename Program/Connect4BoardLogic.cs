using System;
using A24_Ex02;


namespace A24_Ex02
{
    public struct Connect4BoardLogic
    {
        public enum eSlots
        {
            EmptySlot,
            Player1Token,
            Player2Token,
        }

        public struct Connect4Board
        {
            private eSlots[,] m_Board;
            private readonly byte m_NumOfColumns;
            private readonly byte m_NumOfRows;

            public Connect4Board(byte i_NumOfRows, byte i_NumOfColumns)
            {
                m_NumOfColumns = i_NumOfColumns;
                m_NumOfRows = i_NumOfRows;
                m_Board = new eSlots[i_NumOfRows, i_NumOfRows];
            }

            public byte NumOfColumns 
            {
                get { return m_NumOfColumns; }
            }

            public byte NumOfRows 
            {
                get { return m_NumOfRows; } 
            }

            public eSlots GetSlot(byte i_Row, byte i_Column)
            {
                return m_Board[i_Row - 1, i_Column - 1];
            }

            internal byte EnterTokenToSlot(eSlots i_EnteredToken, byte i_Column)
            {
                byte rowToCheck = m_NumOfRows;

                while (GetSlot(rowToCheck, i_Column) != eSlots.EmptySlot)
                {
                    rowToCheck--;
                }

                m_Board[rowToCheck - 1, i_Column - 1] = i_EnteredToken;

                return rowToCheck;
            }

        }

        private const byte k_MaxRowSize = 8;
        private const byte k_MinRowSize = 4;
        private const byte k_MaxColumnSize = 8;
        private const byte k_MinColumnSize = 4;
        public const byte k_FirstRow = 1;
        private Connect4Board? m_Board;

        public static byte MaxRowSize { get; }
        public static byte MinRowSize { get; }
        public static byte MaxColumnSize { get; }
        public static byte MinColumnSize { get; }

        public Connect4Board? Board
        {
            get
            {
                return m_Board;
            }
        }

        public void SetBoard(byte i_NumOfRows, byte i_NumOfColumns, 
            out bool o_IsValidBoardInput)
        {
            if (CheckIfValidBoardInput(i_NumOfRows, i_NumOfColumns) == true)
            {
                o_IsValidBoardInput = true;
                m_Board = new Connect4Board(i_NumOfRows, i_NumOfColumns);
            }
            else
            {
                o_IsValidBoardInput = false;
            }
        }

        public void EnterToken(byte i_Column, eSlots i_EnteredToken, 
            out byte o_ClosenessToVictory, out bool o_SuccessfulTokenEntry)
        {
            if (IsColumnNotAlreadyFull(i_Column))
            {
                byte rowToEnter = Board.Value.EnterTokenToSlot(i_EnteredToken, i_Column);

                o_SuccessfulTokenEntry = true;
                o_ClosenessToVictory = CheckVictoryCloseness(i_EnteredToken, rowToEnter, i_Column);
            }
            else
            {
                o_SuccessfulTokenEntry = false;
                o_ClosenessToVictory = 0;
            }
        }

        public bool IsValidColumn(byte i_ColumnNum)
        {
            return (i_ColumnNum >= k_FirstRow && i_ColumnNum <= m_Board.Value.NumOfColumns);
        }

        public bool IsColumnNotAlreadyFull(byte i_ColumnToCheck)
        {
            return (m_Board.Value.GetSlot(k_FirstRow, i_ColumnToCheck) == eSlots.EmptySlot);
        }

        public static bool CheckIfValidBoardInput(byte i_NumOfRows, byte i_NumOfColumns)
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

            return ++victoryCloseness;
        }

        private byte CheckDirectionMatches(eSlots i_WantedToken, byte i_RowPlacement, byte i_ColumnPlacement, 
            int i_RowDirection, int i_ColumnDirection)
        {
            byte o_CurrCount = 0;
            byte rowCoordToCheck = (byte)((int)i_RowPlacement + i_RowDirection);
            byte columnCoordToCheck = (byte)((int)i_ColumnPlacement + i_ColumnDirection);
            bool coordsInBoard = rowCoordToCheck >= k_FirstRow && rowCoordToCheck <= m_Board.Value.NumOfRows 
                && columnCoordToCheck >= 1 && columnCoordToCheck <= m_Board.Value.NumOfColumns;


            if (coordsInBoard == true && m_Board.Value.GetSlot(rowCoordToCheck, columnCoordToCheck) == i_WantedToken)
            {
                o_CurrCount++;
                o_CurrCount = (byte)((int)o_CurrCount + (int)CheckDirectionMatches
                    (i_WantedToken, rowCoordToCheck, columnCoordToCheck, i_RowDirection, i_ColumnDirection));
            }

            return o_CurrCount;
        }
    }
}
