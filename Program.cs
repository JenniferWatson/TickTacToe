using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDemo1 
{
	class Program
	{
		static void Main(string[] args)
		{
			var stillPlaying = true;

			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("-----------------------");
			Console.WriteLine("Welcome to Tic Tac Toe!");
			Console.WriteLine("-----------------------\n");
			Console.ResetColor();

			while (stillPlaying)
			{
				Console.WriteLine("What would you like to do:");
				Console.WriteLine("1. Start a new game");
				Console.WriteLine("2. Quit\n");

				Console.Write("Type a number and hit <enter>: ");

				var choice = GetUserInput("[12]");

				switch (choice)
				{
					case "1":
						PlayGame();
						Console.Clear();
						break;
					case "2":
						stillPlaying = false;
						break;
				}
			}
		}

		private static string GetUserInput(string validPattern = null)
		{
			var input = Console.ReadLine();
			input = input.Trim();

			if (validPattern != null && !System.Text.RegularExpressions.Regex.IsMatch(input, validPattern))
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("\"" + input + "\" is not valid.\n");
				Console.ResetColor();
				return null;
			}

			return input;
		}

		private static void PlayerSetup()
		{
			string numRowsChoice = null;
			while (numRowsChoice == null)
			{
				Console.Write("How many rows do you want to have? (3, 4, or 5) ");
				numRowsChoice = GetUserInput("[345]");
			}
			{
				Console.Write("How many players?");
				string sCount = Console.ReadLine(); // a string.

				int count = int.Parse(sCount); // ERROR if non-number is entered, causing App to crash!
			}

			{
				Console.Write("What is your name?");
				var name = Console.ReadLine(); // user enters their name then presses ENTER

				Console.WriteLine($"Hi {name}, welcome to Tic Tac Toe.");
				Console.Read(); // pause application here
			}

			{
				Console.Write("What is your name?");
				var name = Console.ReadLine(); // user enters their name then presses ENTER

				Console.WriteLine($"Hi {name}, welcome to Tic Tac Toe.");
				Console.Read(); // pause application here
			}

			var boardSize = (int)Math.Pow(int.Parse(numRowsChoice), 2);
			var board = new string[boardSize];

			var turn = "X";
			while (true)
			{
				Console.Clear();
			}
		}

		private static void AnnounceResult(string message, string[] board)
		{
			Console.WriteLine();
			DrawBoard(board);

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine(message);
			Console.ResetColor();

			Console.Write("\nPress any key to continue...");
			Console.CursorVisible = false;
			Console.ReadKey();
			Console.CursorVisible = true;
		}

		private static void DrawBoard(string[] board)
		{
			var numRows = (int)Math.Sqrt(board.Length);

			Console.WriteLine();

			for (int row = 0; row < numRows; row++)
			{
				if (row != 0)
					Console.WriteLine(" " + string.Join("|", Enumerable.Repeat("---", numRows)));

				Console.Write(" " + string.Join("|", Enumerable.Repeat("   ", numRows)) + "\n ");

				for (int col = 0; col < numRows; col++)
				{
					if (col != 0)
						Console.Write("|");
					var space = board[row * numRows + col] ?? " ";
					if (space.Length > 1)
						Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.Write(" " + space[0] + " ");
					Console.ResetColor();
				}

				Console.WriteLine("\n " + string.Join("|", Enumerable.Repeat("   ", numRows)));
			}

			Console.WriteLine();
		}
		private static int PromptInteger(string message)
		{
			int x = 0;
			while (x == 0)
			{
				Console.Write(message);
				if (!int.TryParse(Console.ReadLine(), out x))
				{
					Console.WriteLine("Enter an integer value (Example: 3)");
				}
			}
			return x;
		}
	}
}