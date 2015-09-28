using System;

public class NestedLoopsToRecursion
{
    private static int n;
    private static int[] loops;

    public static void Main()
    {
        n = int.Parse(Console.ReadLine());
        loops = new int[n];

        GenerateLoopCombinations(0);
    }

    private static void GenerateLoopCombinations(int currentLoop)
    {
        if (currentLoop == n)
        {
            Console.WriteLine(string.Join(" ", loops));
            return;
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                loops[currentLoop] = i;
                GenerateLoopCombinations(currentLoop + 1);
            }
        }
    }
}
