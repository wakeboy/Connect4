namespace Connect4
{
    public class Player
    {
        public Player(State state)
        {
            State = state;
        }

        public State State { get; private set; }
    }
}
