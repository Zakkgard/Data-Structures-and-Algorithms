namespace CountSymbols
{
    using System;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main()
        {
            var dictionary = new HashTable<char, int>();
            var input = Console.ReadLine();

            foreach (var character in input)
            {
                if (!dictionary.ContainsKey(character))
                {
                    dictionary.Add(character, 1);
                }
                else
                {
                    dictionary[character]++;
                }
            }

            foreach (var element in dictionary
                .OrderBy(element => element.Key))
            {
                Console.WriteLine("{0}: {1} time/s", element.Key, element.Value);
            }

        }
    }
}
