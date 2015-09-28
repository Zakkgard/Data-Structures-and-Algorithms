using System;

public class CombinationsWithoutRepetition
{
    static int n;
    static int k;
    static int[] loops;

    public static void Main()
    {
        n = int.Parse(Console.ReadLine());
        k = int.Parse(Console.ReadLine());
        loops = new int[k];

        GenerateLoopCombinations(1, 0);
    }

    private static void GenerateLoopCombinations(int currentIndex, int after)
    {
        if (currentIndex > k)
            return;

        for (int j = after + 1; j <= n; j++)
        {
            loops[currentIndex - 1] = j;
            if (currentIndex == k)
            {
                PrintCombinations(currentIndex);
            }
            GenerateLoopCombinations(currentIndex + 1, j);
        }
    }

    private static void PrintCombinations(int length)
    {
        for (int i = 0; i < length; i++)
        {
            Console.Write(loops[i] + " ");
        }

        Console.WriteLine();
    }
}
