using Connect4.Exceptions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace Connect4.Tests
{
    [TestFixture]
    public class GameTests
    {
        private IGame game;
        private Mock<IBoard> board;
        private Mock<IRules> rules;

        [SetUp]
        public void SetUp()
        {
            this.board = new Mock<IBoard>();
            this.rules = new Mock<IRules>();

            this.game = new Game(board.Object, rules.Object);
        }

        [Test]
        public void should_set_game_to_have_winner()
        {
            var moveCell = new Cell(1, 1);

            this.rules.Setup(m => m.ValidateMove(It.IsAny<IBoard>(), It.IsAny<int>())).Returns(true);
            this.rules.Setup(m => m.IsWinningMove(It.IsAny<IBoard>(), moveCell)).Returns(true);
            this.board.Setup(m => m.InsertPiece(It.IsAny<int>(), It.IsAny<State>())).Returns(moveCell);

            game.Move(1);

            game.ActivePlayer.State.Should().Be(State.Red);
            game.HasWinner.Should().BeTrue();
        }

        [Test]
        public void should_swap_player_after_valid_move()
        {
            var moveCell = new Cell(1,1);

            this.rules.Setup(m => m.ValidateMove(It.IsAny<IBoard>(), It.IsAny<int>())).Returns(true);
            this.rules.Setup(m => m.IsWinningMove(It.IsAny<IBoard>(), moveCell)).Returns(false);
            this.board.Setup(m => m.InsertPiece(It.IsAny<int>(), It.IsAny<State>())).Returns(moveCell);

            game.Move(1);

            game.ActivePlayer.State.Should().Be(State.Yellow);
        }

        [Test]
        public void should_thorw_invalid_move_exception()
        {
            this.rules.Setup(m => m.ValidateMove(It.IsAny<IBoard>(), It.IsAny<int>())).Returns(false);

            Action result = () => game.Move(-1);
            
            result.ShouldThrow<InvalidMoveException>()
                  .WithMessage("Invalid Move");

            game.ActivePlayer.State.Should().Be(State.Red);  // Active player did not change
        }

    }
}