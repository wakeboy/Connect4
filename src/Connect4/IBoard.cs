using Connect4.Enums;

namespace Connect4
{
    public interface IBoard
    {
        /// <summary>
        /// Number of rows on the board
        /// </summary>
        int Rows { get; }
        
        /// <summary>
        /// Number of columns on the baord
        /// </summary>
        int Columns { get; }

        /// <summary>
        /// The array of cells the board contains
        /// </summary>
        ICell[,] Cells { get; }

        /// <summary>
        /// Adds a piece to the baords
        /// </summary>
        /// <param name="column"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        ICell InsertPiece(int column, State state);
    }
}
