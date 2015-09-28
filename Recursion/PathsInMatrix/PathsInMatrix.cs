using System;
using System.Collections.Generic;

public class PathsInMatrix
{
    private static char[,] matrix =
    {
        {' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', ' ', '*', ' '},
        {' ', '*', '*', ' ', '*', ' '},
        {' ', '*', 'e', ' ', ' ', ' '},
        {' ', ' ', ' ', '*', ' ', ' '},
    };
    private static int pathsFound = 0;
    private static char[] path = new char[matrix.GetLength(1) * matrix.GetLength(1)];
    private static int position = 0;

    public static void Main()
    {
        FindPath(0, 0, 's');
        Console.WriteLine($"Total paths found {pathsFound}");
    }

    private static void FindPath(int row, int col, char direction)
    {
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
        {
            return;
        }

        path[position++] = direction;

        if (matrix[row, col] == 'e')
        {
            pathsFound++;

            for (int i = 1; i < position; i++)
            {
                Console.Write(path[i]);
            }

            Console.WriteLine();
        }

        if (matrix[row, col] == ' ')
        {
            matrix[row, col] = 's';

            FindPath(row + 1, col, 'D');
            FindPath(row, col + 1, 'R');
            FindPath(row - 1, col, 'U');
            FindPath(row, col - 1, 'L');

            matrix[row, col] = ' ';
        }

        position--;
    }
}
