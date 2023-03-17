using Board;
using ChessGame.Game;
using System.Drawing;
using Color = Board.Color;

namespace ChessGame.Game
{
    public class Horse : Piece
    {
        public Horse(ChessBoard board, Color color) : base(board, color)
        {
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] matriz = new bool[Board.Lines, Board.Columns];

            List<int[]> directions = new List<int[]>{
        new int[] {-1, -2},
        new int[] {-2, -1},
        new int[] {-2, 1},
        new int[] {-1, 2},
        new int[] {1, 2},
        new int[] {2, 1},
        new int[] {2, -1},
        new int[] {1, -2}
    };

            foreach (int[] direction in directions)
            {
                Position pos = new Position(Position.Line + direction[0], Position.Column + direction[1]);
                if (Board.IsPositionValid(pos) && CanMove(pos))
                    matriz[pos.Line, pos.Column] = true;
            }

            return matriz;
        }


        //public override bool[,] PossibleMoves()
        //{
        //    bool[,] matriz = new bool[Board.Lines, Board.Columns];

        //    Position pos = new(0, 0);

        //    pos.SetValuesForPosition(Position.Line - 1, Position.Column -2);
        //    if (Board.IsPositionValid(pos) && CanMove(pos))
        //        matriz[pos.Line, pos.Column] = true;

        //    pos.SetValuesForPosition(Position.Line - 2, Position.Column - 1);
        //    if (Board.IsPositionValid(pos) && CanMove(pos))
        //        matriz[pos.Line, pos.Column] = true;

        //    pos.SetValuesForPosition(Position.Line - 2, Position.Column + 1);
        //    if (Board.IsPositionValid(pos) && CanMove(pos))
        //        matriz[pos.Line, pos.Column] = true;

        //    pos.SetValuesForPosition(Position.Line - 1, Position.Column + 2);
        //    if (Board.IsPositionValid(pos) && CanMove(pos))
        //        matriz[pos.Line, pos.Column] = true;

        //    pos.SetValuesForPosition(Position.Line + 1, Position.Column + 2);
        //    if (Board.IsPositionValid(pos) && CanMove(pos))
        //        matriz[pos.Line, pos.Column] = true;

        //    pos.SetValuesForPosition(Position.Line + 2, Position.Column + 1);
        //    if (Board.IsPositionValid(pos) && CanMove(pos))
        //        matriz[pos.Line, pos.Column] = true;

        //    pos.SetValuesForPosition(Position.Line + 2, Position.Column - 1);
        //    if (Board.IsPositionValid(pos) && CanMove(pos))
        //        matriz[pos.Line, pos.Column] = true;

        //    pos.SetValuesForPosition(Position.Line + 1, Position.Column - 2);
        //    if (Board.IsPositionValid(pos) && CanMove(pos))
        //        matriz[pos.Line, pos.Column] = true;

        //    return matriz;
        //}

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}



//HORSE
//Variables:
//None

//Methods:

//Horse(ChessBoard board, Color color)
//bool[,] PossibleMoves()
//bool CanMove(Position position)
//string ToString()


//Methods:

//Horse(ChessBoard board, Color color)
// - Constructor method that initializes a new instance of the Horse class with a reference to the ChessBoard and the color of the piece.

//bool[,] PossibleMoves()
// - Public method that returns a 2D Boolean array representing the possible moves of the horse on the current board.
// - It checks each of the 8 possible moves that a knight can make and sets the corresponding element in the matrix to true if the move is valid and can be made by the horse.

//bool CanMove(Position position)
// - Private helper method that checks if a given position on the board can be moved to by the horse.
// - It returns true if the position is empty or contains an opponent's piece and false otherwise.

//string ToString()
// - Public method that returns a string representation of the horse piece.
// - It returns the string "H".