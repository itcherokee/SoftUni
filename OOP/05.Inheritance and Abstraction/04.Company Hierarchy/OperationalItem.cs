namespace Company
{
    using System;

    public abstract class OperationalItem : IOperationalItem
    {
        private string name;

        protected OperationalItem(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Sale name cannot be null, empty or white space.");
                }

                this.name = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is OperationalItem))
            {
                return false;
            }

            return this.Name == ((OperationalItem)obj).Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
