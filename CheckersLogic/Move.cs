using System;
using System.Collections.Generic;
using System.Text;

namespace C20_Ex02_Omry_308345826_Orna_043548734
{
    public class Move
    {
        private readonly Position r_From;
        private readonly Position r_To;
        private readonly eMoveType r_MoveType;

        public Move(Position i_From, Position i_To, eMoveType i_MoveType)
        {
            r_From = i_From;
            r_To = i_To;
            r_MoveType = i_MoveType;
        }

        public Position From
        {
            get
            {
                return r_From;
            }
        }

        public Position To
        {
            get
            {
                return r_To;
            }
        }

        public bool IsJump
        {
            get
            {
                return r_MoveType == eMoveType.Jump;
            }
        }

        public override string ToString()
        {
            string moveString = string.Format("{0}>{1}", r_From, r_To);

            return moveString;
        }

        public bool MatchesString(string i_MoveString)
        {
            return ToString() == i_MoveString;
        }
    }
}
