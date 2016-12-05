namespace Connect4
{
    public interface IBoard
    {
        int Rows { get; }
        
        int Columns { get; }

        ICell[,] Cells { get; }

        ICell InsertPiece(int column, State state);
    }
}
