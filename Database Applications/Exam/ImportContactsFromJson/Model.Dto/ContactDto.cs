namespace ImportContactsFromJson.Model.Dto
{
    public class ContactDto
    {
        private string[] emails;
        private string[] phones;

        public ContactDto()
        {
            this.emails = new string[0];
            this.phones = new string[0];
        }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Site { get; set; }

        public string Notes { get; set; }


        public string[] Emails
        {
            get
            {
                return this.emails;
            }

            set
            {
                this.emails = value;
            }
        }

        public string[] Phones
        {
            get
            {
                return this.phones;
            }

            set
            {
                this.phones = value;
            }
        }
    }
}
