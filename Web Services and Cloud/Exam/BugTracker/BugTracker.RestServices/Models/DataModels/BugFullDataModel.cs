namespace BugTracker.RestServices.Models.DataModels
{
    using System;
    using System.Collections.Generic;

    public class BugFullDataModel
    {
        private IList<CommentDataModel> comments;

        public BugFullDataModel()
        {
            this.comments = new List<CommentDataModel>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual IList<CommentDataModel> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}