namespace Connect4
{
    public class Board : IBoard
    {

        public Board(int rows, int columns)
        {
            this.Columns = columns;
            this.Rows = rows;

            Cells = new Cell[rows, columns];
            
            for (var i = Rows - 1; i >= 0; i--)
            {
                for(int j = 0; j < columns; j++)
                {
                    Cells[i,j] = new Cell(i,j);
                }
            }
        }

        public int Columns { get; private set; }

        public int Rows { get; private set; }

        public ICell[,] Cells { get; private set; }
        
        public ICell InsertPiece(int column, State state)
        {
            ICell cell = null;

            for (var i = Rows-1; i >= 0; i--)
            {
                if (Cells[i, column].State == State.Empty)
                {
                    cell = Cells[i, column];
                    cell.SetState(state);
                    break;
                }
            }

            return cell;
        }
    }
}
