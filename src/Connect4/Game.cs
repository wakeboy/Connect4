using Connect4.Exceptions;

namespace Connect4
{
    public class Game : IGame
    {
        Player player1, player2;
        private readonly IRules rules;

        public Game(IBoard board, IRules rules)
        {
            Board = board;
            this.rules = rules;
            this.player1 = new Player(State.Red);
            this.player2 = new Player(State.Yellow);

            ActivePlayer = this.player1;
        }

        public void Move(int column)
        {
            if (this.rules.ValidateMove(Board, column))
            {
                var cell = Board.InsertPiece(column, ActivePlayer.State);

                if (this.rules.IsWinningMove(Board, cell))
                {
                    HasWinner = true;
                }
                else
                {
                    SwapActivePlayer();
                }
            }
            else
            {
                throw new InvalidMoveException();
            }
        }

        public void SwapActivePlayer()
        {
            if (ActivePlayer == player1)
            {
                ActivePlayer = player2;
            }
            else
            {
                ActivePlayer = player1;
            }
        }

        public IBoard Board { get; private set; }

        public Player ActivePlayer { get; private set; }

        public bool HasWinner { get; private set; }
    }
}
