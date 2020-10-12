using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C20_Ex02_Omry_308345826_Orna_043548734;

namespace WinFormsCheckers
{
    internal sealed class WhiteButton : Button
    {
        private const int k_ButtonSize = 45;
        private Position m_Position;
        private bool m_IsClicked = false;

        public WhiteButton(Position i_CurrentPosition, Point i_StartLocation)
        {
            Position = i_CurrentPosition;
            BackColor = Color.White;
            Width = k_ButtonSize;
            Height = k_ButtonSize;
            Location = new Point(
                (k_ButtonSize * i_CurrentPosition.Column) + i_StartLocation.X,
                (k_ButtonSize * i_CurrentPosition.Row) + i_StartLocation.Y);
            TabStop = false;
            if (i_CurrentPosition.OccupiedBy != null)
            {
                Text = i_CurrentPosition.OccupiedBy.ToString();
            }
        }

        public Position Position
        {
            get
            {
                return m_Position;
            }

            set
            {
                if (m_Position != null)
                {
                    m_Position.ReportChangedDelegates -= Position_Changed;
                }

                m_Position = value;
                m_Position.ReportChangedDelegates += Position_Changed;
            }
        }

        public bool IsClicked
        {
            get
            {
                return m_IsClicked;
            }

            set
            {
                m_IsClicked = value;
            }
        }

        private void Position_Changed(Position i_Position)
        {
            Text = i_Position.OccupiedBy != null ? i_Position.OccupiedBy.ToString() : string.Empty;
        }

        public void ResetPosition(Position i_Position)
        {
            Position = i_Position;
            Text = i_Position.OccupiedBy.ToString();
        }
    }
}
