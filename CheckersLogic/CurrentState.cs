using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace C20_Ex02_Omry_308345826_Orna_043548734
{
    public class CurrentState
    {
        private readonly Board r_Board;
        private Player m_CurrentPlayer; // the player whose turn is it

        public CurrentState(eBoardSize i_BoardSize, Player i_Player)
        {
            r_Board = new Board(i_BoardSize);
            m_CurrentPlayer = i_Player;
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public Board Board
        {
            get
            {
                return r_Board;
            }
        }

        public List<Move> FindFollowupMoves(Position i_From)
        {
            List<Move> followupMoves = FindLegalMovesFromPosition(i_From);

            return findAllPossibleJumps(followupMoves);
        }

        public List<Move> FindAllLegalMoves()
        {
            List<Move> legalMoves = new List<Move>();
            for (int i = 0; i < r_Board.Size; i++)
            {
                for (int j = 0; j < r_Board.Size; j++)
                {
                    Position currentPosition = r_Board.GetPositionAt(i, j);

                    if (currentPosition.IsOccupiedByPlayer(m_CurrentPlayer))
                    {
                        legalMoves.AddRange(FindLegalMovesFromPosition(currentPosition));
                    }
                }
            }

            List<Move> jumpOnlyMoves = findAllPossibleJumps(legalMoves);

            if (jumpOnlyMoves.Count > 0)
            {
                legalMoves = jumpOnlyMoves;
            }

            return legalMoves;
        }

        // ApplyMove method returns true if we should switch turns
        public bool ApplyMove(Move i_Move)
        {
            bool switchTurn = true;
            Piece? pieceToMove = i_Move.From.OccupiedBy;

            // clear the previous position and set the piece in the new position
            r_Board.SetPosition(i_Move.From, null);
            r_Board.SetPosition(i_Move.To, pieceToMove);
            CrownIfApplicable(i_Move.To);

            // if the move was a jump we want to check if there are follow-up jumps
            if (i_Move.IsJump)
            {
                captureOpponentPiece(i_Move);
                List<Move> possibleFollowUpMoves = findAllPossibleJumps(FindLegalMovesFromPosition(i_Move.To));
                switchTurn = possibleFollowUpMoves.Count == 0;
            }

            return switchTurn;
        }

        private void captureOpponentPiece(Move i_Move)
        {
            r_Board.SetPosition(
                (i_Move.From.Row + i_Move.To.Row) / 2,
                (i_Move.From.Column + i_Move.To.Column) / 2,
                null);
        }

        private List<Move> findAllPossibleJumps(List<Move> i_MovesList)
        {
            List<Move> jumpsList = new List<Move>();

            if (i_MovesList.Count > 0)
            {
                foreach (Move move in i_MovesList)
                {
                    if (move.IsJump)
                    {
                        jumpsList.Add(move);
                    }
                }
            }

            return jumpsList;
        }

        public List<Move> FindLegalMovesFromPosition(Position i_Position)
        {
            List<Move> positionLegalMoves = new List<Move>();
            Piece? possiblePiece = i_Position.OccupiedBy;

            if (possiblePiece.HasValue)
            {
                // now piece can be non-nullable
                Piece piece = (Piece)i_Position.OccupiedBy;

                if (piece.IsKing)
                {
                    piece.Direction = eDirection.Up; // setting 1st row-direction for a king
                    positionLegalMoves.AddRange(findLeftAndRightMoves(i_Position, piece.Direction));
                    piece.Direction = eDirection.Down; // switching row-direction for next possible-move-checks
                }

                positionLegalMoves.AddRange(findLeftAndRightMoves(i_Position, piece.Direction));
            }

            return positionLegalMoves;
        }

        private Move findSingleLegalMove(
            Position i_Position,
            eDirection i_RowDirection,
            eDirection i_ColDirection)
        {
            Move move = null;
            Piece piece = (Piece)i_Position.OccupiedBy;
            Position possiblePosition = r_Board.GetPositionAt(
                i_Position.Row + (int)i_RowDirection,
                i_Position.Column + (int)i_ColDirection);

            // if null the position isn't in the board
            if (possiblePosition != null)
            {
                analizePossiblePosition(
                    ref possiblePosition,
                    ref move,
                    i_Position,
                    ref piece,
                    i_RowDirection,
                    i_ColDirection);
            }

            return move;
        }

        private void analizePossiblePosition(
            ref Position io_PossiblePosition,
            ref Move io_Move,
            Position i_Position,
            ref Piece io_Piece,
            eDirection i_RowDirection,
            eDirection i_ColDirection)
        {
            if (io_PossiblePosition.IsEmpty())
            {
                // add regular move
                io_Move = new Move(i_Position, io_PossiblePosition, eMoveType.Regular);
            }
            else
            {
                // position is occupied
                if (io_Piece.IsOpponent((Piece)io_PossiblePosition.OccupiedBy))
                {
                    Position positionAfterJump = r_Board.GetPositionAt(
                        io_PossiblePosition.Row + (int)i_RowDirection,
                        io_PossiblePosition.Column + (int)i_ColDirection);

                    // if the position is within the board and isn't occupied, we can jump
                    if (positionAfterJump != null && positionAfterJump.IsEmpty())
                    {
                        io_Move = new Move(i_Position, positionAfterJump, eMoveType.Jump);
                    }
                }
            }
        }

        private List<Move> findLeftAndRightMoves(Position i_Position, eDirection i_RowDirection)
        {
            List<Move> legalMoves = new List<Move>();

            Move possibleMove = findSingleLegalMove(i_Position, i_RowDirection, eDirection.Right);

            if (possibleMove != null)
            {
                legalMoves.Add(possibleMove);
            }

            possibleMove = findSingleLegalMove(
                i_Position,
                i_RowDirection,
                eDirection.Left);

            if (possibleMove != null)
            {
                legalMoves.Add(possibleMove);
            }

            return legalMoves;
        }

        public void CrownIfApplicable(Position io_Position)
        {
            if (io_Position.OccupiedBy.HasValue)
            {
                Piece piece = (Piece)io_Position.OccupiedBy;

                // if piece reached last row
                if ((piece.PieceType == ePieceType.X && io_Position.Row == 0) ||
                     (piece.PieceType == ePieceType.O && io_Position.Row == r_Board.Size - 1))
                {
                    piece.Crown();
                    r_Board.SetPosition(io_Position, piece); // in order To save the king on board
                }
            }
        }

        public int GetCurrentScore()
        {
            return r_Board.CalculateScoreDifference();
        }
    }
}
