using System;
using System.Collections.Generic;

namespace ConnectedAreasInMatrix
{
    public class ConnectedAreasInMatrix
    {
        private static char[,] matrix =
        {
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        };
        private static int areaSize = 0;
        private static SortedSet<Area> foundAreas = new SortedSet<Area>();

        static void Main()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        Traverse(row, col);
                        foundAreas.Add(new Area(areaSize, row, col));
                        areaSize = 0;
                    }
                }
            }

            if (foundAreas.Count == 0)
            {
                Console.WriteLine("No areas had been found!");
            }
            else
            {
                Console.WriteLine($"Total areas found: {foundAreas.Count}");
                int position = 1;

                foreach (var area in foundAreas)
                {
                    Console.WriteLine($"Area #{position} at {area}");
                }

                position++;
            }
        }

        private static void Traverse(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 's' || matrix[row, col] == '*')
            {
                return;
            }

            areaSize++;
            matrix[row, col] = 's';

            Traverse(row, col + 1);
            Traverse(row + 1, col);
            Traverse(row, col - 1);
            Traverse(row - 1, col);
        }
    }
}
    
