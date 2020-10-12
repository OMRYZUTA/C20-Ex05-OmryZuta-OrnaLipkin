using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace C20_Ex02_Omry_308345826_Orna_043548734
{
    public class Board
    {
        private readonly int r_RowSize;
        private readonly Position[,] r_PositionsMatrix;

        public Board(eBoardSize i_BoardSize)
        {
            r_RowSize = (int)i_BoardSize;
            r_PositionsMatrix = new Position[r_RowSize, r_RowSize];
            initializeBoard();
        }

        public int Size
        {
            get
            {
                return r_RowSize;
            }
        }

        public Position GetPositionAt(int i_Row, int i_Column)
        {
            Position positionAt = null;

            if ((i_Row >= 0 && i_Row < r_RowSize) &&
                (i_Column >= 0 && i_Column < r_RowSize))
            {
                positionAt = r_PositionsMatrix[i_Row, i_Column];
            }

            return positionAt;
        }

        public void SetPosition(Position i_Position, Piece? i_Piece)
        {
            SetPosition(i_Position.Row, i_Position.Column, i_Piece);
        }

        public void SetPosition(int i_Row, int i_Column, Piece? i_Piece)
        {
            r_PositionsMatrix[i_Row, i_Column].OccupiedBy = i_Piece;
        }

        private void initializeBoard()
        {
            for (int i = 0; i < r_RowSize; i++)
            {
                for (int j = 0; j < r_RowSize; j++)
                {
                    r_PositionsMatrix[i, j] = new Position(i, j);
                }
            }

            initializeOCheckers(); // place player o checkers
            initializeXCheckers(); // place player x checkers
        }

        private void initializeOCheckers()
        {
            for (int i = 0; i < (r_RowSize / 2) - 1; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 1; j < r_RowSize; j += 2)
                    {
                        r_PositionsMatrix[i, j].OccupiedBy = new Piece(ePieceType.O);
                    }
                }
                else
                {
                    for (int j = 0; j < r_RowSize; j += 2)
                    {
                        r_PositionsMatrix[i, j].OccupiedBy = new Piece(ePieceType.O);
                    }
                }
            }
        }

        private void initializeXCheckers()
        {
            for (int i = (r_RowSize / 2) + 1; i < r_RowSize; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 1; j < r_RowSize; j += 2)
                    {
                        r_PositionsMatrix[i, j].OccupiedBy = new Piece(ePieceType.X);
                    }
                }
                else
                {
                    for (int j = 0; j < r_RowSize; j += 2)
                    {
                        r_PositionsMatrix[i, j].OccupiedBy = new Piece(ePieceType.X);
                    }
                }
            }
        }
                
        public int CalculateScoreDifference()
        {
            int xPiecesCounter = 0;
            int oPiecesCounter = 0;

            foreach (Position position in r_PositionsMatrix)
            {
                if (position.OccupiedBy.HasValue)
                {
                    Piece piece = (Piece)position.OccupiedBy;
                    addToOcountOrXcount(piece, ref oPiecesCounter, ref xPiecesCounter);
                }
            }

            return Math.Abs(xPiecesCounter - oPiecesCounter);
        }

        private void addToOcountOrXcount(
            Piece i_PieceScoreToAdd,
            ref int io_OPiecesCounter,
            ref int io_XPiecesCounter)
        {
            if (i_PieceScoreToAdd.PieceType == ePieceType.O && i_PieceScoreToAdd.IsKing)
            {
                io_OPiecesCounter += 4;
            }
            else if (i_PieceScoreToAdd.PieceType == ePieceType.O)
            {
                io_OPiecesCounter += 1;
            }
            else if (i_PieceScoreToAdd.PieceType == ePieceType.X && i_PieceScoreToAdd.IsKing)
            {
                io_XPiecesCounter += 4;
            }
            else
            {
                io_XPiecesCounter += 1;
            }
        }
    }
}
