using Connect4.Enums;

namespace Connect4
{
    public interface IGame
    {
        /// <summary>
        /// The current players whos turn it is
        /// </summary>
        Player ActivePlayer { get; }

        /// <summary>
        /// The games state
        /// </summary>
        GameState GameState { get; }

        /// <summary>
        /// Move/Insert the chip
        /// </summary>
        /// <param name="column"></param>
        void Move(int column);

        /// <summary>
        /// Swap who the active player is
        /// </summary>
        void SwapActivePlayer();
    }
}
