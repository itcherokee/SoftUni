using System.Text;

namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedStateHeight = 0.10m;
        private ChairState state;
        private decimal normalChairHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.state = ChairState.Normal;
        }

        public bool IsConverted
        {
            get
            {
                return this.state == ChairState.Converted;
            }
        }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.state = ChairState.Normal;
                this.Height = this.normalChairHeight;
            }
            else
            {
                this.state = ChairState.Converted;
                this.normalChairHeight = this.Height;
                this.Height = ConvertedStateHeight;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendFormat(", State: {0}", this.IsConverted ? "Converted" : "Normal");

            return output.ToString();
        }

        private enum ChairState
        {
            Converted,
            Normal
        }
    }
}