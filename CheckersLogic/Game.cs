using System;
using System.Collections.Generic;
using System.Text;

namespace C20_Ex02_Omry_308345826_Orna_043548734
{
    public class Game
    {
        private readonly eBoardSize r_BoardSize;
        private readonly Player r_PlayerO;
        private readonly Player r_PlayerX;
        private CurrentState m_CurrentState;

        public event Action<Game> ReportOverDelegates;

        public Player CurrentPlayer
        {
            get
            {
                return (m_CurrentState.CurrentPlayer == null) ? null : m_CurrentState.CurrentPlayer;
            }
        }

        // opposite to currentPlayer
        public Player Opponent
        {
            get
            {
                return (m_CurrentState.CurrentPlayer == r_PlayerO) ? r_PlayerX : r_PlayerO;
            }
        }

        public Board Board
        {
            get
            {
                return m_CurrentState == null ? null : m_CurrentState.Board;
            }
        }

        public Player PlayerO
        {
            get
            {
                return r_PlayerO;
            }
        }

        public Player PlayerX
        {
            get
            {
                return r_PlayerX;
            }
        }

        public Game(eBoardSize i_BoardSize, Player i_Player1, Player i_Player2)
        {
            r_BoardSize = i_BoardSize;
            r_PlayerX = i_Player1;
            r_PlayerO = i_Player2;
        }

        public void ResetGameState()
        {
            m_CurrentState = new CurrentState(r_BoardSize, r_PlayerX);
        }

        public List<Move> FindAllLegalMoves()
        {
            return m_CurrentState.FindAllLegalMoves();
        }

        public List<Move> FindLegalMovesFromPosition(Position i_Position)
        {
            return m_CurrentState.FindLegalMovesFromPosition(i_Position);
        }

        public bool ApplyMove(Move i_Move)
        {
            bool switchTurn = m_CurrentState.ApplyMove(i_Move);

            if (switchTurn)
            {
                m_CurrentState.CurrentPlayer = (m_CurrentState.CurrentPlayer == r_PlayerO) ? r_PlayerX : r_PlayerO;
            }

            return switchTurn;
        }

        public bool IsGameOver()
        {
            bool result = FindAllLegalMoves().Count == 0;

            if (result)
            {
                notifyOverListeneers();
            }

            return result;
        }

        public void CheckIfTieOrWin(out Player o_Winner)
        {
            o_Winner = null;

            // current player doesn't have moves
            if (FindAllLegalMoves().Count == 0)
            {
                // need to check if opponent has moves, so we switch current player before FindAllLegalMoves               
                m_CurrentState.CurrentPlayer = Opponent;
                if (FindAllLegalMoves().Count > 0)
                {
                    o_Winner = CurrentPlayer; // the player who still has moves wins
                }
            }
        }

        private void notifyOverListeneers()
        {
            if (ReportOverDelegates != null)
            {
                ReportOverDelegates.Invoke(this);
            }
        }
    }
}
