namespace CombinationsWithRepetition
{
    using System;

    public class CombinationsWithRepetition
    {
        private static int n;
        private static int k;
        private static int[] array;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            array = new int[k];

            GenerateCombinations(1, 1);
        }

        private static void GenerateCombinations(int index, int next)
        {
            if (index > k)
            {
                return;
            }

            for (int i = next; i <= n; i++)
            {
                array[index - 1] = i;
                if (index == k)
                {
                    Print(index);
                }

                GenerateCombinations(index + 1, i);
            }
        }

        private static void Print(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
