namespace RopeStringEditing
{
    using System;
    using System.Text;

    using Wintellect.PowerCollections;

    public class RopeStringEditing
    {
        public static void Main()
        {
            var rope = new BigList<char>();
            var builder = new StringBuilder();
            var input = Console.ReadLine().Split();

            while (input[0] != "PRINT")
            {
                var command = input[0];

                switch (command)
                {
                    case "INSERT":
                        Insert(rope, builder, input[1]);
                        break;
                    case "APPEND":
                        Append(rope, builder, input[1]);
                        break;
                    case "DELETE":
                        Delete(rope, builder, int.Parse(input[1]), int.Parse(input[2]));
                        break;
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(builder.ToString().Trim());
        }

        private static void Delete(BigList<char> rope, StringBuilder builder, int startIndex, int count)
        {
            try
            {
                rope.RemoveRange(startIndex, count);
            }
            catch
            {
                builder.AppendLine("ERROR");
            }
        }

        private static void Append(BigList<char> rope, StringBuilder builder, string value)
        {
            rope.AddRange(value);
            builder.AppendLine("OK");
        }

        private static void Insert(BigList<char> rope, StringBuilder builder, string value)
        {
            rope.AddRangeToFront(value);
            builder.AppendLine("OK");
        }
    }
}
