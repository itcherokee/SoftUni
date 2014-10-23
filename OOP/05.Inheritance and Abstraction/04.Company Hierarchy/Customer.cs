namespace Company
{
    using System;
    using System.Text;

    public class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;

        public Customer(string firstName, string lastName, uint id, decimal netPurchaseAmount)
            : base(firstName, lastName, id)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount
        {
            get
            {
                return this.netPurchaseAmount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total net purchase amount cannot be of negative value.");
                }

                this.netPurchaseAmount = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Position: Customer");
            output.AppendLine(base.ToString());
            output.AppendFormat("Purchase Amount: {0:C2}\n", this.NetPurchaseAmount);

            return output.ToString();
        }
    }
}
