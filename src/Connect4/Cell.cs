namespace Connect4
{
    public class Cell : ICell
    {
        public State State { get; private set; } = State.Empty;

        public int Column { get; private set; }

        public int Row { get; private set; }

        public Cell(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public void SetState(State state)
        {
            State = state;
        }
    }
}
