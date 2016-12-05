using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private IBoard board;

        [SetUp]
        public void SetUp ()
        {
            board = new Board(5, 6);
        }

        [TearDown]
        public void TearDown()
        {
            board = null;
        }

        [Test]
        public void should_create_baord_with_set_dimension()
        {
            board.Rows.Should().Be(5);
            board.Columns.Should().Be(6);

            board.Cells.GetLength(0).ShouldBeEquivalentTo(board.Rows);
            board.Cells.GetLength(1).ShouldBeEquivalentTo(board.Columns);
        }

        [Test]
        public void should_set_all_cells_to_empty()
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    board.Cells[i, j].State.Should().Be(State.Empty);
                }
            }
        }

        [Test]
        public void should_set_sell_to_state()
        {
            board.InsertPiece(0, State.Red);
            board.InsertPiece(0, State.Yellow);

            board.Cells[4, 0].State.Should().Be(State.Red);
            board.Cells[3, 0].State.Should().Be(State.Yellow);
        }
    }
}
