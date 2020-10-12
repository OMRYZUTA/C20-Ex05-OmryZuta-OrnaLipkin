using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace C20_Ex02_Omry_308345826_Orna_043548734
{
    public class Position
    {
        private readonly int r_Row;
        private readonly int r_Column;
        private Piece? m_OccupiedBy;

        public event Action<Position> ReportChangedDelegates;

        public Position(int i_Row, int i_Column, Piece? i_OccupiedBy = null)
        {
            r_Row = i_Row;
            r_Column = i_Column;
            m_OccupiedBy = i_OccupiedBy;
        }

        public Piece? OccupiedBy
        {
            get
            {
                return m_OccupiedBy;
            }

            set
            {
                m_OccupiedBy = value;
                notifyChangedListeners();
            }
        }

        public int Row
        {
            get
            {
                return r_Row;
            }
        }

        public int Column
        {
            get
            {
                return r_Column;
            }
        }

        public bool IsEmpty()
        {
            return m_OccupiedBy == null;
        }

        public bool IsOccupiedByPlayer(Player i_Player)
        {
            bool samePlayer = false;

            if (OccupiedBy.HasValue)
            {
                if (OccupiedBy.Value.PieceType == i_Player.PieceType)
                {
                    samePlayer = true;
                }
            }

            return samePlayer;
        }

        public override string ToString()
        {
            StringBuilder rowAndCol = new StringBuilder();

            rowAndCol.Append((char)('A' + r_Column));
            rowAndCol.Append((char)('a' + r_Row));

            return rowAndCol.ToString();
        }

        private void notifyChangedListeners()
        {
            if (ReportChangedDelegates != null)
            {
                ReportChangedDelegates.Invoke(this);
            }
        }
    }
}
