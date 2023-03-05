using Board;
using Game;
using System.Drawing;
using Color = Board.Color;

namespace Game
{
    public class Rook : Piece
    {
        public Rook(ChessBoard board, Color color) : base(board, color)
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

                pos.Line--;
            }

            // below
            pos.SetValuesForPosition(Position.Line+ 1, Position.Column);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.Line++;
            }

            // right
            pos.SetValuesForPosition(Position.Line, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.Column++;
            }

            // left
            pos.SetValuesForPosition(Position.Line, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                    break;

                pos.Column--;
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
            return "R";
        }
    }
}

//ROOK
//Variables:
//None

//Methods:

//Rook(ChessBoard board, Color color)
//bool[,] PossibleMoves()
//private bool CanMove(Position position)
//string ToString()

/*
This is a C# class called "Rook" that represents a rook piece in a chess game. Here are the methods:

Constructor:
Takes two parameters: a ChessBoard object and a Color enum.
Calls the base constructor (Piece) passing the board and color arguments.
PossibleMoves():
Overrides the abstract method PossibleMoves() inherited from the base class (Piece).
Returns a boolean 2D array of size [board.Lines, board.Columns] representing all possible moves that the rook can make from its current position.
The algorithm works by simulating the rook's movement in all four possible directions: above, below, right, and left.
It starts at the current position and continues moving one square at a time until it reaches the end of the board or an obstacle (either a piece of its own color or an opponent's piece).
If the obstacle is an opponent's piece, the method sets the corresponding position in the boolean array to true and stops the movement in that direction.
If the obstacle is a piece of the same color or the edge of the board, the method stops the movement in that direction without setting any positions in the array to true.
CanMove(Position position):
A private helper method that takes a Position object as a parameter and returns a boolean indicating whether the rook can move to that position.
If the position is empty or occupied by an opponent's piece, the method returns true. Otherwise, it returns false.
ToString():
Overrides the ToString() method inherited from the base class (Object).
Returns a string representation of the rook piece, which is just the letter "R".




Regenerate response
 
 */