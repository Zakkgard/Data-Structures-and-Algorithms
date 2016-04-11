namespace ReverseArray
{
    using System;
    using System.Linq;

    public class ReverseArray
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Reverse(array, 0);
            Print(array);
            Console.ReadLine();
        }

        private static void Reverse(int[] array, int index)
        {
            if (index > array.Length / 2 - 1)
            {
                return;
            }

            Reverse(array, index + 1);

            int length = array.Length;
            int temp = array[index];
            array[index] = array[length - index - 1];
            array[length - index - 1] = temp;
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(",", array));
        }
    }
}
