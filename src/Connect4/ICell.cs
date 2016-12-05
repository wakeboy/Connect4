namespace Connect4
{
    public interface ICell
    {
        State State { get; }

        int Column { get; }

        int Row { get; }

        void SetState(State state);
    }
}
