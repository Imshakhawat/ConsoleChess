using Board;
using ChessGame.Game;
using System.Drawing;
using Color = Board.Color;

namespace ChessGame.Game
{
    public class Bishop : Piece
    {
        public Bishop(ChessBoard board, Color color) : base(board, color)
        {
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] matriz = new bool[Board.Lines, Board.Columns];

            List<(int, int)> directions = new List<(int, int)>
    {
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1),           (0, 1),
        (1, -1),  (1, 0),  (1, 1)
    };

            foreach ((int dLine, int dColumn) in directions)
            {
                Position pos = new Position(Position.Line + dLine, Position.Column + dColumn);
                while (Board.IsPositionValid(pos) && CanMove(pos))
                {
                    matriz[pos.Line, pos.Column] = true;

                    if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                        break;

                    pos.SetValuesForPosition(pos.Line + dLine, pos.Column + dColumn);
                }
            }

            return matriz;
        }



        //public override bool[,] PossibleMoves()
        //{
        //    bool[,] matriz = new bool[Board.Lines, Board.Columns];

        //    Position pos = new(0, 0);

        //    // northwest
        //    pos.SetValuesForPosition(Position.Line - 1, Position.Column - 1);
        //    while (Board.IsPositionValid(pos) && CanMove(pos))

        //    {
        //        matriz[pos.Line, pos.Column] = true;

        //        if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
        //            break;

        //        pos.SetValuesForPosition(pos.Line - 1, pos.Column - 1);
        //    }

        //    // north east
        //    pos.SetValuesForPosition(Position.Line - 1, Position.Column + 1);
        //    while (Board.IsPositionValid(pos) && CanMove(pos))
        //    {
        //        matriz[pos.Line, pos.Column] = true;

        //        if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
        //            break;

        //        pos.SetValuesForPosition(pos.Line - 1, pos.Column + 1);
        //    }

        //    // southeast
        //    pos.SetValuesForPosition(Position.Line + 1, Position.Column + 1);
        //    while (Board.IsPositionValid(pos) && CanMove(pos))
        //    {
        //        matriz[pos.Line, pos.Column] = true;

        //        if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
        //            break;

        //        pos.SetValuesForPosition(pos.Line + 1, pos.Column + 1);
        //    }

        //    // south-west
        //    pos.SetValuesForPosition(Position.Line + 1, Position.Column - 1);
        //    while (Board.IsPositionValid(pos) && CanMove(pos))
        //    {
        //        matriz[pos.Line, pos.Column] = true;

        //        if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
        //            break;

        //        pos.SetValuesForPosition(pos.Line + 1, pos.Column - 1);
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
            return "B";
        }
    }
}


//BISHOP
//Variables:
//None

//Methods:

//Bishop(ChessBoard board, Color color)
//override bool[,] PossibleMoves()
//private bool CanMove(Position position)
//override string ToString()