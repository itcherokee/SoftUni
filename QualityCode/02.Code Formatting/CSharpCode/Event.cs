namespace Events
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Location", message: "Location cannot be null!");
                }

                this.location = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Title", "Title cannot be null!");
                }

                this.title = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Date", "Date cannot be null!");
                }

                this.date = value;
            }
        }

        public int CompareTo(object obj)
        {
            var other = obj as Event;
            if (other != null)
            {
                int eventByDate = this.Date.CompareTo(other.Date);
                int eventByTitle = string.Compare(this.Title, other.Title, StringComparison.Ordinal);
                int eventByLocation = string.Compare(this.Location, other.Location, StringComparison.Ordinal);

                if (eventByDate == 0)
                {
                    if (eventByTitle == 0)
                    {
                        return eventByLocation;
                    }

                    return eventByTitle;
                }

                return eventByDate;
            }

            throw new ArgumentNullException("obj in CompareTo", "Object to compare cannot be null!");
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            output.Append(" | " + this.Title);
            if (!string.IsNullOrEmpty(this.Location))
            {
                output.Append(" | " + this.Location);
            }

            return output.ToString();
        }
    }
}