namespace Connect4
{
    public interface IGame
    {
        Player ActivePlayer { get; }

        bool HasWinner { get; }

        void Move(int column);

        void SwapActivePlayer();
    }
}
