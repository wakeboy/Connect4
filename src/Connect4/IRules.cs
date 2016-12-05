namespace Connect4
{
    public interface IRules
    {
        bool IsWinningMove(IBoard board, ICell cell);

        bool ValidateMove(IBoard board, int column);
    }
}
