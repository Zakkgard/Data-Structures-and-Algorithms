namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Phonebook
    {
        public static void Main()
        {
            var phonebook = new HashTable<string, string>();
            var input = Console.ReadLine();

            while (input != "search")
            {
                var name = input.Split('-')[0];
                var number = input.Split('-')[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, number);
                }

                input = Console.ReadLine();
            }

            while (true)
            {
                var name = Console.ReadLine();

                if (!phonebook.ContainsKey(name))
                {
                    Console.WriteLine("Contact {0} does not exist.", name);
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                }
            }
        }
    }
}
