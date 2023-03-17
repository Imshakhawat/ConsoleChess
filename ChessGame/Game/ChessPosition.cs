  using Board;
using Game;
using System.Data.Common;

namespace Game
{
    public class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToBoardPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            return $"{Column}{Line}";
        }
    }
}

//CHESSPOSITION
//Variables:

//Column[char]
//Line[int]
//Methods:
//ChessPosition(char column, int line)
//Position ToBoardPosition()
//override string ToString()


//Methods of the ChessPosition class:

//public ChessPosition(char column, int line): Constructor method that takes a column character and a line integer as parameters and initializes the Column and Line properties of the ChessPosition object.

//public Position ToBoardPosition(): Method that returns a Position object that represents the position of the chessboard corresponding to the ChessPosition object. It converts the column and line properties to the row and column indices of the Position object using a simple formula.

//public override string ToString(): Method that overrides the default ToString() method of the object class to return a string representation of the ChessPosition object in the format "ColumnLine".





