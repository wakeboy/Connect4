namespace Connect4
{
    public class Rules : IRules
    {
        public bool IsWinningMove(IBoard board, ICell cell)
        {
            if (IsWin(board, cell, 1, 0))  // Vertical win
            {
                return true;
            }
            if (IsWin(board, cell, 0, 1))  // Horizontal win
            {
                return true;
            }
            if (IsWin(board, cell, -1, -1)) // Diagonal top left to bottom right
            {
                return true;
            }
            if (IsWin(board, cell, -1, 1)) // Diagonal bottom left to top right
            {
                return true;
            }
            
            return false;
        }

        private bool IsWin(IBoard board, ICell lastMove, int rowDelta, int colDelta)
        {
            var count = 1;

            var rowIndex = lastMove.Row - rowDelta;
            var colIndex = lastMove.Column - colDelta;
            // Check the cells to the left of the last move
            while (CheckCell(board, rowIndex, colIndex, lastMove.State) && count < 4)
            {
                count++;
                colIndex = colIndex - colDelta;
                rowIndex = rowIndex - rowDelta;
            }

            rowIndex = lastMove.Row + rowDelta;
            colIndex = lastMove.Column + colDelta;
            // Check the cells to the right of the last move
            while (CheckCell(board, rowIndex, colIndex, lastMove.State) && count < 4)
            {
                count++;
                colIndex = colIndex + colDelta;
                rowIndex = rowIndex + rowDelta;
            }

            return count >= 4;
        }

        private bool CheckCell(IBoard board, int row, int col, State expectedState)
        {
            if (col < 0 || row < 0) return false;
            if (col >= board.Columns || row >= board.Rows) return false;

            return board.Cells[row, col].State == expectedState;
        }
        
        public bool ValidateMove(IBoard board, int column)
        {
            if (column < 0 || column > board.Columns-1)
            {
                return false;
            }
            
            if (board.Cells[0,  column].State != State.Empty)
            {
                return false;
            }

            return true;
        }
    }
}
