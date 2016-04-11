namespace PathsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PathsInMatrix
    {
        private static char[,] matrix =
        {
            {' ', ' ', ' ', ' '},
            {' ', '*', '*', ' '},
            {' ', '*', '*', ' '},
            {' ', '*', 'e', ' '},
            {' ', ' ', ' ', ' '},
        };
        private static int pathsFound = 0;
        private static char[] path = new char[matrix.GetLength(1) * matrix.GetLength(1)];
        private static int stepsTaken = 0;

        public static void Main()
        {
            FindPath(0, 0, ' ');
            Console.WriteLine("Total paths founds: {0}", pathsFound);
        }

        private static void FindPath(int row, int col, char direction)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            path[stepsTaken++] = direction;

            if (matrix[row, col] == 'e')
            {
                pathsFound++;
                Console.WriteLine(string.Join("", path));
            }

            if (matrix[row, col] == ' ')
            {
                matrix[row, col] = 's';
                FindPath(row + 1, col, 'D');
                FindPath(row - 1, col, 'U');
                FindPath(row, col + 1, 'R');
                FindPath(row, col - 1, 'L');
                matrix[row, col] = ' ';
            }

            stepsTaken--;
        }
    }
}
