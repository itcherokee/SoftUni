namespace Company
{
    using System;

    public class Project : OperationalItem, IProject
    {
        private DateTime startDate;
        private string details;
        private ProjectState state;

        public Project(string name, DateTime startDate, string details)
            : base(name)
        {
            this.State = ProjectState.Open;
            this.StartDate = startDate;
            this.Details = details;
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Start date of project cannot be null.");
                }

                this.startDate = value;
            }
        }

        public ProjectState State
        {
            get
            {
                return this.state;
            }

            private set
            {
                if (Enum.IsDefined(typeof(ProjectState), value))
                {
                    this.state = value;
                }
                else
                {
                    throw new ArgumentException("Invalid enum value provided for project state.");
                }
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Project details cannot be null or empty.");
                }

                this.details = value;
            }
        }

        public void CloseProject()
        {
            this.State = ProjectState.Closed;
        }

        public override string ToString()
        {
            return string.Format(
                "Project: {0}\n\t StartDate: {1}\n\t State: {2}\n\t Details: {3}",
                this.Name,
                this.StartDate,
                this.State,
                this.Details);
        }
    }
}
