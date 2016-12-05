using Connect4.Enums;

namespace Connect4
{
    public interface ICell
    {
        /// <summary>
        /// The cells state
        /// </summary>
        State State { get; }

        /// <summary>
        /// The cells column index
        /// </summary>
        int Column { get; }

        /// <summary>
        /// The cells row index
        /// </summary>
        int Row { get; }

        /// <summary>
        /// Set the cells state
        /// </summary>
        /// <param name="state"></param>
        void SetState(State state);
    }
}
