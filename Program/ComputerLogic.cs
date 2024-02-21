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
            Ai
        }

        private static Random m_Random = new Random();

        internal static void GetTokenPlacement
            (Connect4BoardLogic i_BoardState, Connect4BoardLogic.eSlots i_ComputerToken, eAiType i_AiType, out byte o_ColumnChosen)
        {
            byte chosenColumn = 0;

            if (i_AiType == eAiType.RandomAi)
            {
                bool possibleInput;
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
                chosenColumn = FindBestColumn(i_BoardState.Clone(), i_ComputerToken);
            }

            o_ColumnChosen = chosenColumn;
        }

        private static byte GetRandomColumn(byte i_NumOfColumns)
        {
            byte o_randomIndex;

            o_randomIndex = (byte)m_Random.Next(Connect4BoardLogic.k_FirstRow, i_NumOfColumns);

            return o_randomIndex;
        }

        private static byte FindBestColumn(Connect4BoardLogic i_BoardInstance, Connect4BoardLogic.eSlots i_ComputerToken)
        {
            byte bestSelfClosness = 0;
            byte worstEnemyClosness = GameInterface.k_VictoryConnectCondition;
            byte bestSelfClosnessColumn = Connect4BoardLogic.k_FirstColumn;
            Connect4BoardLogic.eSlots enemyToken;

            if(i_ComputerToken == Connect4BoardLogic.eSlots.Player1Token)
            {
                enemyToken = Connect4BoardLogic.eSlots.Player2Token;
            }
            else
            {
                enemyToken = Connect4BoardLogic.eSlots.Player1Token;
            }

            for (byte column = 1; column <= i_BoardInstance.Board.NumOfColumns; column++) 
            {
                bool successfulEntry;
                byte currCloseness;
                Connect4BoardLogic boardInstanceCopy = i_BoardInstance.Clone();

                boardInstanceCopy.EnterToken(column, i_ComputerToken, out currCloseness, out successfulEntry);
                if (successfulEntry == true)
                {
                    byte currEnemyClosness;
                    byte maxEnemyClosness = 0;

                    if (currCloseness == GameInterface.k_VictoryConnectCondition)
                    {
                        bestSelfClosnessColumn = column;
                        break;
                    }

                    for (byte enemyColumn = 1; enemyColumn <=  i_BoardInstance.Board.NumOfColumns; enemyColumn++)
                    {
                        Connect4BoardLogic boardInstanceCopyCopy = boardInstanceCopy.Clone();

                        boardInstanceCopyCopy.EnterToken(enemyColumn, enemyToken, out currEnemyClosness, out successfulEntry);
                        if (successfulEntry == true)
                        {
                            if(maxEnemyClosness < currEnemyClosness)
                            {
                                maxEnemyClosness = currEnemyClosness;
                            }
                            if(currEnemyClosness >= GameInterface.k_VictoryConnectCondition - 1)
                            {
                                bestSelfClosnessColumn = enemyColumn;
                                currCloseness = GameInterface.k_VictoryConnectCondition;
                                maxEnemyClosness = 0;
                            }
                        }
                    }

                    if(maxEnemyClosness < worstEnemyClosness && currCloseness > bestSelfClosness)
                    {
                        worstEnemyClosness = maxEnemyClosness;
                        bestSelfClosness = currCloseness;
                        bestSelfClosnessColumn = column;
                    }
                }
            }
            return bestSelfClosnessColumn;
        }
    }
}
