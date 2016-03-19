using Escape_from_Labyrinth;
using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

public class EscapeFromLabyrinth
{
    private const char VisitedCell = 's';
    private static int width;
    private static int height;
    private static char[,] labyrinth;

    public static void Main()
    {
        ReadLabyrinth();
        string path = FindShortestPathToExit();

        if (path == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (path == "")
        {
            Console.WriteLine("Start is at the exit!");
        }
        else
        {
            Console.WriteLine("Shortest exit: {0}", path);
        }
    }

    public static void ReadLabyrinth()
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());
        labyrinth = new char[height, width];

        for (int row = 0; row < height; row++)
        {
            var currentRow = Console.ReadLine();

            for (int col = 0; col < width; col++)
            {
                labyrinth[row, col] = currentRow[col];
            }
        }
    }

    public static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartPosition();
        if (startPosition == null)
        {
            return null;
        }

        queue.Enqueue(startPosition);
        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();
            if (IsExit(currentCell))
            {
                return TracePathBack(currentCell);
            }

            TryDirection(queue, currentCell, "L", 0, -1);
            TryDirection(queue, currentCell, "R", 0, 1);
            TryDirection(queue, currentCell, "D", +1, 0);
            TryDirection(queue, currentCell, "U", -1, 0);
        }

        return null;
    }

    private static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int deltaX, int deltaY)
    {
        int newX = currentCell.X + deltaX;
        int newY = currentCell.Y + deltaY;
        if (newX > 0 && newX < width && newY > 0 && newY < height && labyrinth[newX, newY] == '-')
        {
            labyrinth[newX, newY] = VisitedCell;
            var nextCell = new Point(newX, newY, direction, currentCell);
            queue.Enqueue(nextCell);
        }
    }

    private static string TracePathBack(Point currentCell)
    {
        var path = new StringBuilder();
        while (currentCell.PreviousPoint != null)
        {
            path.Append(currentCell.Direction);
            currentCell = currentCell.PreviousPoint;
        }

        var reversedPath = path.ToString().Reverse().ToArray();

        return new string(reversedPath);
    }

    private static bool IsExit(Point currentCell)
    {
        bool isOnBorderX = currentCell.X == 0 || currentCell.X == width - 1;
        bool isOnBorderY = currentCell.Y == 0 || currentCell.Y == height - 1;

        return isOnBorderX || isOnBorderY;
    }

    private static Point FindStartPosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (labyrinth[x, y] == VisitedCell)
                {
                    return new Point(x, y);
                }
            }
        }

        return null;
    }
}
