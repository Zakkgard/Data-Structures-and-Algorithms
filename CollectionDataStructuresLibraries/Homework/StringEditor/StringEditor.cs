namespace StringEditor
{
    using System;
    using System.Text;

    using Wintellect.PowerCollections;

    public class StringEditor
    {
        public static void Main()
        {
            var rope = new BigList<char>();
            var builder = new StringBuilder();
            var input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                var command = input[0];

                switch (command)
                {
                    case "INSERT":
                        Insert(rope, builder, int.Parse(input[1]), input[2]);
                        break;
                    case "APPEND":
                        Append(rope, builder, input[1]);
                        break;
                    case "DELETE":
                        Delete(rope, builder, int.Parse(input[1]), int.Parse(input[2]));
                        break;
                    case "PRINT":
                        Print(rope, builder);
                        break;
                    case "REPLACE":
                        Replace(rope, builder, int.Parse(input[1]), int.Parse(input[2]), input[3]);
                        break;
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(builder.ToString().Trim());
        }

        private static void Replace(BigList<char> rope, StringBuilder builder, int startIndex, int count, string value)
        {
            try
            {
                rope.RemoveRange(startIndex, count);
                rope.InsertRange(startIndex, value);
            }
            catch (Exception)
            {
                builder.AppendLine("ERROR");
                return;
            }

            builder.AppendLine("OK");
        }

        private static void Print(BigList<char> rope, StringBuilder builder)
        {
            builder.AppendLine(string.Join(string.Empty, rope));
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
                return;
            }

            builder.AppendLine("OK");
        }

        private static void Append(BigList<char> rope, StringBuilder builder, string value)
        {
            rope.AddRange(value);
            builder.AppendLine("OK");
        }

        private static void Insert(BigList<char> rope, StringBuilder builder, int position, string value)
        {
            rope.InsertRange(position, value);
            builder.AppendLine("OK");
        }
    }
}
