namespace PC
{
    using System.Globalization;
    using System.Text;

    public class Component
    {
        /// <summary>
        /// Component name.
        /// </summary>
        private string name;

        /// <summary>
        /// Additional information about the component (optional).
        /// </summary>
        private string details;

        /// <summary>
        /// Price of a component.
        /// </summary>
        private decimal price;

        /// <summary>
        /// Initialize a new instance of <see cref="Component"/> class.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="price"></param>
        /// <param name="details">Additional information</param>
        public Component(string name, decimal price, string details = null)
        {
            this.Price = price;
            this.Details = details ?? string.Empty;
            this.Name = name;
        }

        /// <summary>
        /// Component name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Utils.ValidateStringInput(value, "Componenet-Name");
                this.name = value;
            }
        }

        /// <summary>
        /// Additional information about the component (optional).
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Price of a component.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Utils.ValidateNumericInput(value, "Componenet-Price");
                this.price = value;
            }
        }

        /// <summary>
        /// Converts the value of this instance to a string representation.
        /// </summary>
        /// <returns>Returns System.String.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Name: {0}", this.Name));
            output.AppendLine(string.Format("Price: {0}", this.Price.ToString("C2", new CultureInfo("bg-BG"))));
            if (!string.IsNullOrWhiteSpace(this.Details))
            {
                output.AppendLine(string.Format("Details: {0}", this.Details));
            }

            return output.ToString();
        }
    }
}