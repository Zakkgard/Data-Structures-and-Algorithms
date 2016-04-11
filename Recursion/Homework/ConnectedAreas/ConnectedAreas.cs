using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedAreas
{
    public class ConnectedAreas
    {
        private static char[,] matrix =
        {
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        };
        private static int size = 0;
        private static SortedSet<Area> foundAreas = new SortedSet<Area>();

        public static void Main()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        TraverseMatrix(row, col);
                        foundAreas.Add(new Area(size, row, col));
                        size = 0;
                    }
                }
            }

            if (foundAreas.Count == 0)
            {
                Console.WriteLine("No areas had been found!");
            }
            else
            {
                Console.WriteLine(string.Format("Total areas found: {0}", foundAreas.Count));
                int position = 1;

                foreach (var area in foundAreas)
                {
                    Console.WriteLine(string.Format("Area #{0} at {1}", position, area));
                }

                position++;
            }
        }

        private static void TraverseMatrix(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 's' || matrix[row, col] == '*')
            {
                return;
            }

            size++;
            matrix[row, col] = 's';

            TraverseMatrix(row, col + 1);
            TraverseMatrix(row + 1, col);
            TraverseMatrix(row, col - 1);
            TraverseMatrix(row - 1, col);
        }
    }
}
