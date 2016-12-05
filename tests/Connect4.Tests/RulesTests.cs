using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Tests
{
    [TestFixture]
    public class RulesTests
    {
        private IBoard board;
        private IRules rules;
        
        [SetUp]
        public void SetUp()
        {
            board = new Board(5, 5);
            this.rules = new Rules();
        }
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void should_be_a_valid_move(int column)
        {
            var result = rules.ValidateMove(this.board, column);

            result.Should().BeTrue();
        }

        [TestCase(-1)]
        [TestCase(5)]
        public void should_be_a_invalid_move(int column)
        {
            var result = rules.ValidateMove(this.board, column);

            result.Should().BeFalse();
        }

        [Test]
        public void should_be_a_invalid_move_column_full()
        {
            board.Cells[4, 2].SetState(State.Red);
            board.Cells[3, 2].SetState(State.Yellow);
            board.Cells[2, 2].SetState(State.Red);
            board.Cells[1, 2].SetState(State.Yellow);
            board.Cells[0, 2].SetState(State.Red);

            var result = rules.ValidateMove(this.board, 2);

            result.Should().BeFalse();
        }
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void should_be_horizontal_win(int column)
        {
            board.Cells[0, 3].SetState(State.Red);
            board.Cells[0, 2].SetState(State.Red);
            board.Cells[0, 1].SetState(State.Red);
            board.Cells[0, 0].SetState(State.Red);

            var result = rules.IsWinningMove(this.board, board.Cells[0, column]);
            result.Should().BeTrue();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void should_be_virtical_win(int row)
        {
            board.Cells[1, 1].SetState(State.Red);
            board.Cells[2, 1].SetState(State.Red);
            board.Cells[3, 1].SetState(State.Red);
            board.Cells[4, 1].SetState(State.Red);

            var result = rules.IsWinningMove(this.board, board.Cells[0, row]);
            result.Should().BeTrue();
        }

    }
}
