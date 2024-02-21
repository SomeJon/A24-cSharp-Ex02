using System;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using A24_Ex02;
using A24_Ex02_ConsoleUi;


namespace A24_Ex02
{
    public class GameInterface
    {
        internal const byte k_ResetInput = 0;
        public const byte k_NoColumnChosen = 0;
        public const byte k_VictoryConnectCondition = 4;
        private Connect4BoardLogic m_Board;
        private Player m_Player1 = null;
        private Player m_Player2 = null;
        private Player m_CurrPlayer = null;
        private readonly ComputerLogic.eAiType m_ComputerType = ComputerLogic.eAiType.RandomAi;

        public GameInterface()
        {
            byte numOfRows, numOfColumns;
            Player.ePlayerType p1Type, p2Type;

            UI.StartOfProgram(out p1Type, out p2Type, out m_ComputerType, out numOfRows, out numOfColumns);
            m_Player1 = new Player(p1Type, "Player 1");
            m_Player2 = new Player(p2Type, "Player 2");
            m_Board = new Connect4BoardLogic(numOfRows, numOfColumns);
            m_CurrPlayer = m_Player1;
        }

        public void NextTurn(out bool o_DidGameEnd)
        {
            byte columnToPutTokenInto;
            byte clossnessToVictory;
            bool successfulEntry;
            bool inputReset = false;
            Connect4BoardLogic.eSlots slot;

            if (m_CurrPlayer == m_Player1)
            {
                slot = Connect4BoardLogic.eSlots.Player1Token;
            }
            else
            {
                slot = Connect4BoardLogic.eSlots.Player2Token;
            }

            if (m_CurrPlayer.PlayerType == Player.ePlayerType.Player)
            {
                UI.ShowBoard(m_Board.Board, m_Player1.Score, m_Player2.Score);
                UI.ChoseColumnForToken(true, false, out columnToPutTokenInto);
                if (columnToPutTokenInto == k_ResetInput)
                {
                    if (m_CurrPlayer == m_Player1)
                    {
                        m_CurrPlayer = m_Player2;
                    }
                    else
                    {
                        m_CurrPlayer = m_Player1;
                    }
                    clossnessToVictory = k_VictoryConnectCondition;
                }
                else
                {
                    m_Board.EnterToken(columnToPutTokenInto, slot, out clossnessToVictory, out successfulEntry);
                    while (successfulEntry == false)
                    {
                        UI.ChoseColumnForToken(false, true, out columnToPutTokenInto);
                        m_Board.EnterToken(columnToPutTokenInto, slot, out clossnessToVictory, out successfulEntry);
                    }
                }
            }
            else
            {
                ComputerLogic.GetTokenPlacement(m_Board, slot, m_ComputerType, out columnToPutTokenInto);
                m_Board.EnterToken(columnToPutTokenInto, slot, out clossnessToVictory, out successfulEntry);
            }


            EndGame(clossnessToVictory, out o_DidGameEnd);
            if (o_DidGameEnd == false)
            {
                if (m_CurrPlayer == m_Player1)
                {
                    m_CurrPlayer = m_Player2;
                }
                else
                {
                    m_CurrPlayer = m_Player1;
                }
            }
            else
            {
                UI.ProgramEnd(m_Player1.Score, m_Player2.Score);
            }

        }

        public void EndGame(byte i_ClossnessToVictor, out bool o_DidGameEnd)
        {
            bool reset;

            if (i_ClossnessToVictor >= k_VictoryConnectCondition)
            {
                m_CurrPlayer.Score = (byte)((int)(m_CurrPlayer.Score) + 1);
                UI.ShowBoard(m_Board.Board, m_Player1.Score, m_Player2.Score);
                UI.VictoyMSG(m_CurrPlayer);
                UI.AfterRound(out reset);
                if (reset == true)
                {
                    m_Board.ClearBoard();
                    o_DidGameEnd = false;
                }
                else
                {
                    o_DidGameEnd = true;
                }
            }
            else if (m_Board.Board.CheckFull() == true)
            {
                UI.ShowBoard(m_Board.Board, m_Player1.Score, m_Player2.Score);
                UI.TieMSG();
                UI.AfterRound(out reset);
                if (reset == true)
                {
                    m_Board.ClearBoard();
                    m_CurrPlayer.Score = (byte)((int)(m_CurrPlayer.Score) + 1);
                    o_DidGameEnd = false;
                }
                else
                {
                    o_DidGameEnd = true;
                }
            }
            else
            {
                o_DidGameEnd = false;
            }
        }
    }
}
