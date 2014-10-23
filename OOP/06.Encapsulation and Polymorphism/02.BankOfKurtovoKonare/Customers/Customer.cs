namespace Banking.Customers
{
    using System;
    using System.Text;

    public abstract class Customer
    {
        private readonly Guid customerId;
        private string name;
        private string address;

        protected Customer(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.customerId = Guid.NewGuid();
        }

        public string CustomerId
        {
            get
            {
                return this.customerId.ToString();
            }
        }

        /// <summary>
        /// Gets and Sets Name of the customer.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("No Name provided!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets and Sets Name of the customer.
        /// </summary>
        public string Address
        {
            get
            {
                return this.address;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("No Address provided!");
                }

                this.address = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(string.Format("Customer: {0} ({1})", this.Name, this.GetType().Name));
            return output.ToString();
        }
    }
}