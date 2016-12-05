﻿using Connect4;
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
            
            while(!game.HasWinner)
            {
                Console.Write($"> {game.ActivePlayer.State}s Turn: ");
                var col = Console.ReadLine();
                Move(int.Parse(col));
            }

            Console.WriteLine($"Winner {game.ActivePlayer.State}!!");

            Console.Read();
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
                Console.WriteLine("Invalid Move Try Again");
            }
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    Console.Write(board.Cells[i,j].State + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
