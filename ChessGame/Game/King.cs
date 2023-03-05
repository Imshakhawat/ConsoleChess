using Board;
using Game;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using Color = Board.Color;

namespace Game
{
    public class King : Piece
    {
        private ChessMatch match;

        public King(ChessBoard board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        private bool TesteRookForRoque(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece is Rook && piece.Color == Color && NumberOfMoves == 0;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matriz = new bool[Board.Lines, Board.Columns];

            Position pos = new(0, 0);

            // above
            pos.SetValuesForPosition(Position.Line - 1, Position.Column);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                matriz[pos.Line, pos.Column] = true;

            // north east
            pos.SetValuesForPosition(Position.Line - 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                matriz[pos.Line, pos.Column] = true;

            // right
            pos.SetValuesForPosition(Position.Line, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                matriz[pos.Line, pos.Column] = true;

            // southeast
            pos.SetValuesForPosition(Position.Line + 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                matriz[pos.Line, pos.Column] = true;

            // below
            pos.SetValuesForPosition(Position.Line + 1, Position.Column);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                matriz[pos.Line, pos.Column] = true;

            // south-west
            pos.SetValuesForPosition(Position.Line + 1, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                matriz[pos.Line, pos.Column] = true;

            // left
            pos.SetValuesForPosition(Position.Line, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                matriz[pos.Line, pos.Column] = true;

            // northwest
            pos.SetValuesForPosition(Position.Line - 1, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                matriz[pos.Line, pos.Column] = true;

            // #especial move roque
            if (NumberOfMoves == 0 && !match.Xeque)
            {
                // short roque
                Position positionRook = new(Position.Line, Position.Column + 3);

                if (TesteRookForRoque(positionRook))
                {
                    Position positionKing1 = new(Position.Line, Position.Column + 1);
                    Position positionKing2 = new(Position.Line, Position.Column + 2);

                    if (Board.GetPiece(positionKing1) is null &&
                        Board.GetPiece(positionKing2) is null)
                    {
                        matriz[Position.Line, Position.Column + 2] = true;
                    }
                }

                // long roque
                Position positionRook2 = new(Position.Line, Position.Column - 4);

                if (TesteRookForRoque(positionRook2))
                {
                    Position positionKing1 = new(Position.Line, Position.Column - 1);
                    Position positionKing2 = new(Position.Line, Position.Column - 2);
                    Position positionKing3 = new(Position.Line, Position.Column - 3);

                    if (Board.GetPiece(positionKing1) is null &&
                        Board.GetPiece(positionKing2) is null &&
                        Board.GetPiece(positionKing3) is null)
                    {
                        matriz[Position.Line, Position.Column - 2] = true;
                    }
                }
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
            return "K";
        }
    }
}



//KING
//Variables:

//match[ChessMatch]
//Methods:

//King(ChessBoard board, Color color, ChessMatch match)
//bool TesteRookForRoque(Position position)
//bool[,] PossibleMoves()
//private bool CanMove(Position position)
//override string ToString()


//The class King inherits from the abstract class Piece, representing a King piece in a game of chess. It has the following methods:

//public King(ChessBoard board, Color color, ChessMatch match) : base(board, color): constructor method that receives a chess board, a color (black or white), and a chess match as parameters, and calls the constructor of the base class Piece passing the board and color.
//private bool TesteRookForRoque(Position position): private method that receives a Position object as parameter and returns a boolean value. It checks if there is a Rook piece of the same color as the King in the specified position and if the King and the Rook have never moved before.
//public override bool[,] PossibleMoves(): public override method that returns a boolean matrix representing the possible moves that the King can make from its current position. It checks for all the 8 adjacent positions and marks them as possible moves if they are empty or have an opponent's piece. It also checks for a special move called "roque" (castling), which is only possible if the King and the Rook involved have never moved before, there are no pieces between them, and the King is not in check.
//private bool CanMove(Position position): private method that receives a Position object as parameter and returns a boolean value. It checks if the specified position is empty or has an opponent's piece.

//public override string ToString(): public override method that returns a string representation of the King piece, which is "K".