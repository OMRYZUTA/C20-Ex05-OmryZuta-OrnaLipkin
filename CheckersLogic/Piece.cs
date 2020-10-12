using System;
using System.Collections.Generic;
using System.Text;

namespace C20_Ex02_Omry_308345826_Orna_043548734
{
    public struct Piece
    {
        private readonly ePieceType r_PieceType;
        private eDirection m_Direction;
        private bool m_IsKing;

        public Piece(ePieceType i_PieceType)
        {
            r_PieceType = i_PieceType;
            m_IsKing = false;

            if (i_PieceType == ePieceType.O)
            {
                m_Direction = eDirection.Down;
            }
            else
            {
                m_Direction = eDirection.Up;
            }
        }

        public ePieceType PieceType
        {
            get
            {
                return r_PieceType;
            }
        }

        public bool IsKing
        {
            get
            {
                return m_IsKing;
            }
        }

        public eDirection Direction
        {
            get
            {
                return m_Direction;
            }

            set
            {
                m_Direction = value;
            }
        }

        public void Crown()
        {
            m_IsKing = true;
            m_Direction = eDirection.Both;
        }

        public override string ToString()
        {
            string pieceSymbol;

            if (m_IsKing)
            {
                pieceSymbol = (PieceType == ePieceType.O) ?
                                  eKingType.U.ToString() : eKingType.K.ToString();
            }
            else
            {
                pieceSymbol = PieceType.ToString();
            }

            return pieceSymbol;
        }

        public bool IsOpponent(Piece i_OtherPiece)
        {
            return r_PieceType != i_OtherPiece.r_PieceType;
        }
    }
}