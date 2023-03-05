﻿using Board;
using ChessGame;
using ChessGame.Game;
using Game;

namespace ChessGame
{
    public class Screen
    {
        //public static void PrintBoard(ChessBoard chessBoard)
        //{
        //    for (int i = 0; i < chessBoard.Lines; i++)
        //    {
        //        Console.Write((8 - i) + " ");
        //        for (int j = 0; j < chessBoard.Columns; j++)
        //        {
        //            PrintPiece(chessBoard.GetPiece(i, j));
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine("  A B C D E F G H");
        //}
        public static void PrintBoard(ChessBoard chessBoard)
        {
            for (int i = 0; i < chessBoard.Lines; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < chessBoard.Columns; j++)
                {
                    PrintPiece(chessBoard.GetPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }


        public static void PrintBoard(ChessBoard chessBoard, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changeBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < chessBoard.Lines; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < chessBoard.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = changeBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }

                    PrintPiece(chessBoard.GetPiece(i, j));

                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");

            Console.BackgroundColor = originalBackground;
        }

        //public static void PrintPiece(Piece piece)
        //{
        //    if (piece is null)
        //    {
        //        Console.Write("- ");
        //    }
        //    else
        //    {
        //        if (piece.Color == Color.White)
        //        {
        //            Console.Write(piece);
        //        }
        //        else
        //        {
        //            ConsoleColor auxColor = Console.ForegroundColor;
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.Write(piece);
        //            Console.ForegroundColor = auxColor;
        //        }
        //        Console.Write(" ");
        //    }
        //}
        public static void PrintPiece(Piece piece)
        {
            if (piece is null)
            {
                Console.Write("· ");
            }
            else
            {
                switch (piece)
                {
                    case King k when k.Color == Color.White:
                        Console.Write("\u2654");
                        break;
                    case Queen q when q.Color == Color.White:
                        Console.Write("♕ ");
                        break;
                    case Rook r when r.Color == Color.White:
                        Console.Write("♖ ");
                        break;
                    case Bishop b when b.Color == Color.White:
                        Console.Write("♗ ");
                        break;
                    case Horse n when n.Color == Color.White:
                        Console.Write("♘ ");
                        break;
                    case Pawn p when p.Color == Color.White:
                        Console.Write("\u2659 ");
                        break;
                    case King k when k.Color == Color.Black:
                        Console.Write("♚ ");
                        break;
                    case Queen q when q.Color == Color.Black:
                        Console.Write("♛ ");
                        break;
                    case Rook r when r.Color == Color.Black:
                        Console.Write("♜ ");
                        break;
                    case Bishop b when b.Color == Color.Black:
                        Console.Write("♝ ");
                        break;
                    case Horse n when n.Color == Color.Black:
                        Console.Write("♞ ");
                        break;
                    case Pawn p when p.Color == Color.Black:
                        Console.Write("♟ ");
                        break;
                }
            }
        }


        public static void PrintMatch(ChessMatch game)
        {
            Screen.PrintBoard(game.Board);
            Console.WriteLine();
            PrintCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine($"Turn: {game.Turn}");

            if (!game.GameOver)
            {
                Console.WriteLine($"Waiting for play: {game.CurrentPlayer}");
                if (game.Xeque)
                    Console.WriteLine("Xeque!");

            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"Win: {game.CurrentPlayer}");
            }
            
        }

        public static void PrintCapturedPieces(ChessMatch game)
        {
            Console.WriteLine("Caputred pieces:");

            Console.Write("Whites: ");
            PrintSet(game.AllPiecesCapturedPerColor(Color.White));
            Console.WriteLine();

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Black: ");
            PrintSet(game.AllPiecesCapturedPerColor(Color.Black));

            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            set.ToList().ForEach(x => Console.Write(x + " "));
            Console.Write("]");
        }

        public static ChessPosition ReadChessPosition(string dataPlayer)
        {
            char column = dataPlayer[0];
            int line = int.Parse(dataPlayer[1] + "");

            return new ChessPosition(column, line);
        }
    }
}

//SCREEN
//Variables: N / A
//Methods:

//PrintBoard(ChessBoard chessBoard)
//PrintBoard(ChessBoard chessBoard, bool[,] possiblePositions)
//PrintPiece(Piece piece)