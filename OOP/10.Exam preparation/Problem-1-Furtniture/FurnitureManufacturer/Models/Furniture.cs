namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private MaterialType material;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Height = height;
            this.Material = material;
            this.Model = model;
            this.Price = price;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length < 3)
                {
                    throw new ArgumentException("Model cannot be null, empty or less than 3 characters.");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material.ToString();
            }

            private set
            {
                switch (value.ToLower())
                {
                    case "wooden":
                        this.material = MaterialType.Wooden;
                        break;
                    case "leather":
                        this.material = MaterialType.Leather;
                        break;
                    case "plastic":
                        this.material = MaterialType.Plastic;
                        break;
                    default:
                        throw new ArgumentException("Specified material is not valid.");
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentException("Price cannot be negative or zero.");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;

            }

            protected set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentException("Height cannot be negative or zero.");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name,
                this.Model,
                this.Material,
                this.Price,
                this.Height);

            return output.ToString();
        }
    }
}
