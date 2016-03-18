namespace Events
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Wintellect.PowerCollections;

    public class Events
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var builder = new StringBuilder();

            var events = new OrderedMultiDictionary<DateTime, string>(true);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string eventEntry = Console.ReadLine();
                var eventTokens = eventEntry.Split('|');
                string eventName = eventTokens[0].Trim();
                DateTime eventDate = DateTime.Parse(eventTokens[1].Trim());
                events.Add(eventDate, eventName);
            }

            int m = int.Parse(Console.ReadLine());

            builder.AppendLine();
            builder.AppendLine();

            for (int i = 0; i < m; i++)
            {
                string startEndPair = Console.ReadLine();
                var startEndPairTokens = startEndPair.Split('|');
                var start = DateTime.Parse(startEndPairTokens[0].Trim());
                var end = DateTime.Parse(startEndPairTokens[1].Trim());

                var eventsRange = events.Range(start, true, end, true);

                builder.AppendLine(eventsRange.KeyValuePairs.Count().ToString());
                foreach (var e in eventsRange)
                {
                    foreach (var singleEvent in e.Value)
                    {
                        builder.AppendLine(string.Format("{0} | {1}", singleEvent, e.Key));
                    }
                }

                builder.AppendLine();
                builder.AppendLine();
            }

            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
