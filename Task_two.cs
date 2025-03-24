using System;

class Program
{
	static void Main()
	{
		int rows = 6;
		int cols = 6;

		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				// Print '&' for the first and last rows, or for the diagonal
				if (i == 0 || i == rows - 1 || j == i)
				{
					Console.Write("& ");
				}
				else
				{
					Console.Write("* ");
				}
			}
			Console.WriteLine(); // Move to the next line after each row
		}
	}
}
