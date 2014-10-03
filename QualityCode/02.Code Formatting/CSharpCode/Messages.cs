namespace Events
{
    using System;
    using System.Text;

    public static class Messages
    {
        private static readonly StringBuilder output = new StringBuilder();

        public static string Output
        {
            get
            {
                return output.ToString();
            }

            private set
            {
                output.Append(value);
            }
        }

        public static void EventAdded()
        {
            Output = "Event added\n";
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output = string.Format("{0} events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            Output = "No events found\n";
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output = eventToPrint + "\n";
            }
            else
            {
                throw new ArgumentNullException("eventToPrint", "Parameter is null!");
            }
        }
    }
}
