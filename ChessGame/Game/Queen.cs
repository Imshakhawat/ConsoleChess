using Board;
using ChessGame.Game;
using System.Drawing;
using Color = Board.Color;

namespace ChessGame.Game
{
    public class Queen : Piece
    {
        public Queen(ChessBoard board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matriz = new bool[Board.Lines, Board.Columns];

            Position pos = new(0, 0);

            // above
            pos.SetValuesForPosition(Position.Line - 1, Position.Column);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.SetValuesForPosition(pos.Line - 1, pos.Column);
            }

            // below
            pos.SetValuesForPosition(Position.Line + 1, Position.Column);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.SetValuesForPosition(pos.Line + 1, pos.Column);
            }

            // right
            pos.SetValuesForPosition(Position.Line, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.SetValuesForPosition(pos.Line, pos.Column + 1);
            }

            // left
            pos.SetValuesForPosition(Position.Line, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.SetValuesForPosition(pos.Line, pos.Column - 1);
            }

            // northwest
            pos.SetValuesForPosition(Position.Line - 1, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.SetValuesForPosition(pos.Line - 1, pos.Column - 1);
            }

            // north east
            pos.SetValuesForPosition(Position.Line - 1, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.SetValuesForPosition(pos.Line - 1, pos.Column + 1);
            }

            // southeast
            pos.SetValuesForPosition(Position.Line + 1, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.SetValuesForPosition(pos.Line + 1, pos.Column + 1);
            }

            // south-west
            pos.SetValuesForPosition(Position.Line + 1, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.SetValuesForPosition(pos.Line + 1, pos.Column - 1);
            }

            return matriz;
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}


//QUEEN
//Variables:

//None
//Methods:

//Queen(ChessBoard board, Color color)
//override bool[,] PossibleMoves()
//private bool CanMove(Position position)
//override string ToString()


/*
 
The class Queen is a subclass of Piece and represents a queen chess piece. It has the following methods:

Queen(ChessBoard board, Color color) - Constructor method that initializes a new instance of the Queen class. It takes two parameters, a ChessBoard object and a Color enumeration value indicating the color of the piece.

PossibleMoves() - Method that returns a two-dimensional boolean array representing the possible moves for the queen on the chess board. The method iterates over all possible directions of movement for a queen (up, down, left, right, and diagonal) and checks if the queen can move to the position. If the position is valid and the queen can move to that position, the corresponding element of the boolean array is set to true. The method then returns the boolean array.

CanMove(Position position) - Private method that checks if the queen can move to the specified Position. The method returns true if the position is empty or occupied by an opponent's piece and false otherwise.

ToString() - Method that returns a string representation of the queen. It returns the character "Q".


 
 */







