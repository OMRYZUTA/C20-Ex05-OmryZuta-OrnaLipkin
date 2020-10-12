using System;
using System.Collections.Generic;
using System.Text;

namespace C20_Ex02_Omry_308345826_Orna_043548734
{
    public class Player
    {
        private static readonly Random sr_Random = new Random();
        private readonly string r_Name;
        private readonly ePieceType r_PieceTag;
        private readonly bool r_IsComputer;
        private int m_Score;

        // CTOR for computer player
        public Player(ePieceType i_PieceType)
        {
            r_Name = "computer";
            r_PieceTag = i_PieceType;
            r_IsComputer = true;
            m_Score = 0;
        }

        // CTOR for human player
        public Player(string i_Name, ePieceType i_PieceType)
        {
            r_Name = i_Name;
            r_PieceTag = i_PieceType;
            r_IsComputer = false;
            m_Score = 0;
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public bool IsComputer
        {
            get
            {
                return r_IsComputer;
            }
        }

        public ePieceType PieceType
        {
            get
            {
                return r_PieceTag;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public Move ChooseMoveFromList(List<Move> i_LegalMoves)
        {
            return i_LegalMoves[sr_Random.Next(i_LegalMoves.Count)];
        }

        public Move CheckIfLegalMove(List<Move> i_LegalMoves, string i_MoveString)
        {
            Move move = null;
            foreach (Move legalMove in i_LegalMoves)
            {
                if (legalMove.MatchesString(i_MoveString))
                {
                    move = legalMove;
                    break;
                }
            }

            return move;
        }

        public override string ToString()
        {
            return IsComputer ? "<computer>" : Name;
        }
    }
}
