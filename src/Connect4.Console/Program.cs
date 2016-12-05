using Connect4;
using Connect4.Enums;
using Connect4.Exceptions;
using System;

namespace App
{
    public class Program
    {
        private static IGame game;
        private static IBoard board;

        public static void Main(string[] args)
        {
            IRules rules = new Rules();
            board = new Board(5, 5);
            game = new Game(board, rules);
            
            while(game.GameState == GameState.Playing)
            {
                Console.Write($"> {game.ActivePlayer.State}s Turn: ");
                
                var col = int.MinValue;
                if (int.TryParse(Console.ReadLine(), out col))
                {
                    Move(col);
                }
                else
                {
                    PrintInvalieMove();
                }
            }

            WriteResult();

            Console.Read();
        }

        private static void WriteResult()
        {
            if (game.GameState == GameState.Won)
            {
                Console.WriteLine($"{game.ActivePlayer.State} WINS!!");
            }
            else if (game.GameState == GameState.Draw)
            {
                Console.WriteLine("No Winner we have a Draw");
            }
        }

        private static void Move(int column)
        {
            try
            {
                game.Move(column);
                PrintBoard();
            }
            catch (InvalidMoveException ex )
            {
                PrintInvalieMove();
            }
        }

        private static void PrintInvalieMove()
        {
            Console.WriteLine("Invalid Move Try Again");
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintCell(board.Cells[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void PrintCell(ICell cell)
        {
            if (cell.State == State.Empty)
            {
                Console.Write("O ");
            }
            else if (cell.State == State.Red)
            {
                Console.Write("R ");
            }
            else if (cell.State == State.Yellow)
            {
                Console.Write("Y ");
            }
        }
    }
}
