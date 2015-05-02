namespace BugTracker.RestServices.Models.BindingModels
{
    public class BugFilter
    {
        private string[] statuses;

        public BugFilter()
        {
            this.statuses = new string[0];
        }

        public string Keyword { get; set; }

        public string[] Statuses
        {
            get
            {
                return this.statuses;
            }

            set
            {
                this.statuses = value;
            }
        }

        public string Author { get; set; }
    }
}