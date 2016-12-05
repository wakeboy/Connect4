using Connect4.Enums;

namespace Connect4
{
    public interface IGame
    {
        Player ActivePlayer { get; }

        GameState GameState { get; }

        void Move(int column);

        void SwapActivePlayer();
    }
}
