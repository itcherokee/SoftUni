namespace CustomerManagementSystem
{
    public interface IPayment
    {
        /// <summary>
        /// Gets or sets the price of the product in current (instance) payment.
        /// </summary>
        decimal ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the name of the product in current (instance) payment.
        /// </summary>
        string ProductName { get; set; }
    }
}