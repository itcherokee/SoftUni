namespace Events
{
    using System;
    using Wintellect.PowerCollections;

    internal class EventHolder
    {
        private readonly MultiDictionary<string, Event> eventByTitle = new MultiDictionary<string, Event>(true);
        private readonly OrderedBag<Event> eventByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);

            this.eventByTitle.Add(title.ToLower(), newEvent);
            this.eventByDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.eventByTitle[title])
            {
                removed++;
                this.eventByDate.Remove(eventToRemove);
            }

            this.eventByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow =
                this.eventByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
