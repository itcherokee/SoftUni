namespace CustomerManagementSystem
{
    using System;

    /// <summary>
    /// Defines a single payment that includes product and its price.
    /// </summary>
    public class Payment : IPayment
    {
        private string name;
        private decimal price;

        public Payment(string productName, decimal productPrice)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }

        /// <summary>
        /// Gets or sets the price of the product in current (instance) payment.
        /// </summary>
        public decimal ProductPrice
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Product price cannot be a negative value.");
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the product in current (instance) payment.
        /// </summary>
        public string ProductName
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name cannot be null, empty or white space.");
                }

                this.name = value;
            }
        }
    }
}
