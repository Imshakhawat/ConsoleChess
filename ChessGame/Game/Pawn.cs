using Board;
using ChessGame.Game;
using Game;
using System.Drawing;
using System.Text.RegularExpressions;
using Color = Board.Color;

namespace ChessGame.Game
{
    public class Pawn : Piece
    {
        private ChessMatch Match;

        public Pawn(ChessBoard board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        private bool ThereIsEnemy(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece.Color != Color;
        }

        private bool Free(Position position)
        {
            return Board.GetPiece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            List<Position> positions = new List<Position>();
            int direction = (Color == Color.White) ? -1 : 1;

            // normal moves
            Position pos = new Position(Position.Line + direction, Position.Column);
            if (Board.IsPositionValid(pos) && Free(pos))
            {
                positions.Add(pos);
            }

            if (NumberOfMoves == 0)
            {
                pos = new Position(Position.Line + 2 * direction, Position.Column);
                Position pos2 = new Position(Position.Line + direction, Position.Column);
                if (Board.IsPositionValid(pos) && Free(pos) &&
                    Board.IsPositionValid(pos2) && Free(pos2))
                {
                    positions.Add(pos);
                }
            }

            pos = new Position(Position.Line + direction, Position.Column - 1);
            if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
            {
                positions.Add(pos);
            }

            pos = new Position(Position.Line + direction, Position.Column + 1);
            if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
            {
                positions.Add(pos);
            }

            // en passant
            if (Position.Line == 3 || Position.Line == 4)
            {
                Position leftPosition = new Position(Position.Line, Position.Column - 1);
                Position rightPosition = new Position(Position.Line, Position.Column + 1);

                if (Board.IsPositionValid(leftPosition) && ThereIsEnemy(leftPosition) &&
                    Board.GetPiece(leftPosition) == Match.PossibleEnPassant)
                {
                    positions.Add(new Position(Position.Line + direction, Position.Column - 1));
                }

                if (Board.IsPositionValid(rightPosition) && ThereIsEnemy(rightPosition) &&
                    Board.GetPiece(rightPosition) == Match.PossibleEnPassant)
                {
                    positions.Add(new Position(Position.Line + direction, Position.Column + 1));
                }
            }

            bool[,] matriz = new bool[Board.Lines, Board.Columns];
            foreach (Position p in positions)
            {
                matriz[p.Line, p.Column] = true;
            }

            return matriz;
        }


        //public override bool[,] PossibleMoves()
        //{
        //    bool[,] matriz = new bool[Board.Lines, Board.Columns];

        //    Position pos = new(0, 0);

        //    if (Color == Color.White)
        //    {
        //        pos.SetValuesForPosition(Position.Line - 1, Position.Column);
        //        if (Board.IsPositionValid(pos) && Free(pos))
        //        {
        //            matriz[pos.Line, pos.Column] = true;
        //        }

        //        pos.SetValuesForPosition(Position.Line - 2, Position.Column);
        //        Position position2 = new(Position.Line - 1, Position.Column);
        //        if (Board.IsPositionValid(position2) && Free(position2) &&
        //            Board.IsPositionValid(pos) && Free(pos) &&
        //            NumberOfMoves == 0)
        //        {
        //            matriz[pos.Line, pos.Column] = true;
        //        }

        //        pos.SetValuesForPosition(Position.Line - 1, Position.Column - 1);
        //        if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
        //        {
        //            matriz[pos.Line, pos.Column] = true;
        //        }

        //        pos.SetValuesForPosition(Position.Line - 1, Position.Column + 1);
        //        if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
        //        {
        //            matriz[pos.Line, pos.Column] = true;
        //        }

        //        // #especial move en passant
        //        if (Position.Line == 3)
        //        {
        //            Position leftPosition = new(Position.Line, Position.Column - 1);

        //            if (Board.IsPositionValid(leftPosition) && ThereIsEnemy(leftPosition) &&
        //                Board.GetPiece(leftPosition) == Match.PossibleEnPassant)
        //            {
        //                matriz[leftPosition.Line -1, leftPosition.Column] = true;
        //            }

        //            Position rightPosition = new(Position.Line, Position.Column + 1);

        //            if (Board.IsPositionValid(rightPosition) && ThereIsEnemy(rightPosition) &&
        //                Board.GetPiece(rightPosition) == Match.PossibleEnPassant)
        //            {
        //                matriz[rightPosition.Line -1, rightPosition.Column] = true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        pos.SetValuesForPosition(Position.Line + 1, Position.Column);
        //        if (Board.IsPositionValid(pos) && Free(pos))
        //        {
        //            matriz[pos.Line, pos.Column] = true;
        //        }

        //        pos.SetValuesForPosition(Position.Line + 2, Position.Column);
        //        Position position2 = new Position(Position.Line + 1, Position.Column);
        //        if (Board.IsPositionValid(position2) && Free(position2) &&
        //            Board.IsPositionValid(pos) && Free(pos) &&
        //            NumberOfMoves == 0)
        //        {
        //            matriz[pos.Line, pos.Column] = true;
        //        }

        //        pos.SetValuesForPosition(Position.Line + 1, Position.Column - 1);
        //        if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
        //        {
        //            matriz[pos.Line, pos.Column] = true;
        //        }

        //        pos.SetValuesForPosition(Position.Line + 1, Position.Column + 1);
        //        if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
        //        {
        //            matriz[pos.Line, pos.Column] = true;
        //        }

        //        // #especial move en passant
        //        if (Position.Line == 4)
        //        {
        //            Position leftPosition = new(Position.Line, Position.Column - 1);

        //            if (Board.IsPositionValid(leftPosition) && ThereIsEnemy(leftPosition) &&
        //                Board.GetPiece(leftPosition) == Match.PossibleEnPassant)
        //            {
        //                matriz[leftPosition.Line + 1, leftPosition.Column] = true;
        //            }

        //            Position rightPosition = new(Position.Line, Position.Column + 1);

        //            if (Board.IsPositionValid(rightPosition) && ThereIsEnemy(rightPosition) &&
        //                Board.GetPiece(rightPosition) == Match.PossibleEnPassant)
        //            {
        //                matriz[rightPosition.Line + 1, rightPosition.Column] = true;
        //            }
        //        }
        //    }

        //    return matriz;
        //}

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
//PAWN
//Variables:

//Match[ChessMatch]
//Methods:

//Pawn(ChessBoard board, Color color, ChessMatch match)
//bool ThereIsEnemy(Position position)
//bool Free(Position position)
//bool[,] PossibleMoves()

//The Pawn class is a subclass of the Piece class, which represents a pawn in the game of chess. Here are the methods of the Pawn class:

//public Pawn(ChessBoard board, Color color, ChessMatch match) : base(board, color): Constructor that initializes a new instance of the Pawn class with the specified board, color, and chess match. It also calls the base constructor of the Piece class, passing in the board and color parameters.

//private bool ThereIsEnemy(Position position): Private helper method that checks whether there is an enemy piece at the specified position. It returns true if there is an enemy piece, and false otherwise.

//private bool Free(Position position): Private helper method that checks whether the specified position on the board is free (i.e., there is no piece occupying that position). It returns true if the position is free, and false otherwise.

//public override bool[,] PossibleMoves(): Public method that returns a 2D boolean array representing the possible moves for the pawn on the chess board. It checks all the possible moves for the pawn, including normal moves, captures, and the special move en passant. It returns a 2D boolean array where each element is true if the corresponding position on the board is a possible move for the pawn, and false otherwise.

//private bool CanMove(Position position): Private helper method that checks whether the specified position on the board is a valid move for the pawn. It returns true if the position is either empty or occupied by an enemy piece, and false otherwise.

//public override string ToString(): Public method that returns a string representation of the pawn. It returns the character "P", which is commonly used to represent pawns in chess notation.