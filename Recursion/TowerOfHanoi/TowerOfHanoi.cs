using System;
using System.Collections.Generic;
using System.Linq;

public class TowerOfHanoi
{
    private static int stepsTaken = 0;
    private static int disksNumber = 0;
    private static Stack<int> source;
    private static readonly Stack<int> destination = new Stack<int>();
    private static readonly Stack<int> spare = new Stack<int>();

    static void Main()
    {
        disksNumber = int.Parse(Console.ReadLine());
        source = new Stack<int>(Enumerable.Range(1, disksNumber).Reverse());
        PrintRods();
        MoveDisks(disksNumber, source, destination, spare);
    }

    private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        if (bottomDisk == 1)
        {
            stepsTaken++;
            destination.Push(source.Pop());
            Console.WriteLine("Step {0}: Moved disk: {1}", stepsTaken, bottomDisk);
            PrintRods();
        }
        else
        {
            MoveDisks(bottomDisk - 1, source, spare, destination);

            stepsTaken++;
            destination.Push(source.Pop());
            Console.WriteLine("Step {0}: Moved disk: {1}", stepsTaken, bottomDisk);
            PrintRods();

            MoveDisks(bottomDisk - 1, spare, destination, source);
        }
    }

    private static void PrintRods()
    {
        Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
        Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
        Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
        Console.WriteLine();
    }
}
