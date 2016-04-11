namespace HanoiTowers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HanoiTowers
    {
        private static Stack<int> source;
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        private static int stepsTaken = 0;

        public static void Main()
        {
            int disksNumber = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, disksNumber).Reverse());
            PrintRods();
            MoveDisks(disksNumber, source, destination, spare);
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine("Step #{0}: Moved disk {1}", stepsTaken, bottomDisk);
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
    }
}
