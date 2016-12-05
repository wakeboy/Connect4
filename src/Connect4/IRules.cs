namespace Connect4
{
    public interface IRules
    {
        /// <summary>
        /// Check if the board is full and no move moves can be made
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        bool BoardFull(IBoard board);

        /// <summary>
        /// Check if the last cell populated was a winning move
        /// </summary>
        /// <param name="board"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        bool IsWinningMove(IBoard board, ICell cell);

        /// <summary>
        /// Validate the move
        /// </summary>
        /// <param name="board"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        bool ValidateMove(IBoard board, int column);
    }
}
