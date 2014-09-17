namespace LaptopShop
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a laptop characteristics.
    /// </summary>
    public class Laptop
    {
        private string model;
        private string manufacturer;
        private string cpu;
        private string gpu;
        private Battery battery;
        private double screenSize;
        private decimal price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Laptop" /> class.
        /// </summary>
        /// <param name="model">Model of the laptop.</param>
        /// <param name="manufacturer">Manufacturer of the laptop.</param>
        /// <param name="processor">Processor model.</param>
        /// <param name="graphicCard">Build in graphic card.</param>
        /// <param name="battery">Battery specifications.</param>
        /// <param name="screenSize">Size of the screen in inches.</param>
        /// <param name="price">Laptop price in Euro.</param>
        public Laptop(string model, string manufacturer, string processor, string graphicCard, Battery battery = null, double screenSize = 4.0, decimal price = 0.0m)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.GraphicCard = graphicCard;
            this.ScreenSize = screenSize;
            this.Price = price;
            this.Battery = battery ?? new Battery();
        }

        /// <summary>
        /// Gets or sets laptop model.
        /// </summary>
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                Utils.ValidateStringInput(value, "Model");
                this.model = value;
            }
        }

        /// <summary>
        /// Gets or sets laptop manufacturer.
        /// </summary>
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                Utils.ValidateStringInput(value, "Manufacturer");
                this.manufacturer = value;
            }
        }

        /// <summary>
        /// Gets or sets laptop processor (CPU) type.
        /// </summary>
        public string Processor
        {
            get
            {
                return this.cpu;
            }

            set
            {
                Utils.ValidateStringInput(value, "Processor");
                this.cpu = value;
            }
        }

        /// <summary>
        /// Gets or sets laptop build-in graphic card (GPU).
        /// </summary>
        public string GraphicCard
        {
            get
            {
                return this.gpu;
            }

            set
            {
                Utils.ValidateStringInput(value, "GraphicCard");
                this.gpu = value;
            }
        }

        /// <summary>
        /// Gets or sets laptop battery characteristics.
        /// </summary>
        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Battery specifications must be specified!");
                }

                this.battery = value;
            }
        }

        /// <summary>
        /// Gets or sets laptop screen size (in inches).
        /// </summary>
        public double ScreenSize
        {
            get
            {
                return this.screenSize;
            }

            set
            {
                Utils.ValidateNumericInput((decimal)value, "ScreenSize");
                this.screenSize = value;
            }
        }

        /// <summary>
        /// Gets or sets laptop price (in Euro).
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Utils.ValidateNumericInput(value, "Price");
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
            output.AppendLine(string.Format("Model: {0}", this.Model));
            output.AppendLine(string.Format("Manufacturer: {0}", this.Manufacturer));
            output.AppendLine(string.Format("Processor: {0}", this.Processor));
            output.AppendLine(string.Format("Graphic card: {0}", this.GraphicCard));
            output.AppendLine(string.Format("Battery: {0}", this.Battery));
            output.AppendLine(string.Format("Screen Size: {0} inches", this.ScreenSize));
            output.AppendLine(string.Format("Price: {0} Euro", this.Price));
            return output.ToString();
        }
    }
}
