namespace NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursion
    {
        private static int n;
        private static int[] array;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            array = new int[n];

            SimulateLoops(0);
        }

        private static void SimulateLoops(int loop)
        {
            if (loop == n)
            {
                Print();
                return;
            }


            for (int i = 1; i <= n; i++)
            {
                array[loop] = i;
                SimulateLoops(loop + 1);
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
