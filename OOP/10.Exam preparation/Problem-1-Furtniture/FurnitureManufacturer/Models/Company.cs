using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FurnitureManufacturer.Interfaces;
using System.Linq;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private List<Furniture> furnitures;


        public Company(string name, string registrationNumber)
        {
            this.name = name;
            this.registrationNumber = registrationNumber;
            this.furnitures = new List<Furniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length < 5)
                {
                    throw new ArgumentException("Company name cannot be null, empty or less than 5 characters.");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                uint result = 0;
                if (value.Length == 10 && uint.TryParse(value, out result))
                {
                    this.registrationNumber = value;
                }
                else
                {
                    throw new ArgumentException("Invalid company's registration number provided.");
                }
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures.ToList<IFurniture>();
            }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("furniture", "Furniturre cannot be null.");
            }

            this.furnitures.Add(furniture as Furniture);
        }

        public void Remove(IFurniture furniture)
        {
            var foundFurniture = this.Find(furniture.Model);
            if (foundFurniture != null)
            {
                this.furnitures.Remove(foundFurniture as Furniture);
            }
        }

        public IFurniture Find(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Invalid model provided.");
            }

            return this.furnitures.FirstOrDefault(item => String.Equals(item.Model, model, StringComparison.CurrentCultureIgnoreCase));
        }

        public string Catalog()
        {
            var sortedReservations = this.furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model).ToList();
           var output = new StringBuilder();
            output.Append(this.ToString());
            if (sortedReservations.Count > 0)
            {
                output.AppendLine();
                output.Append(string.Join("\n", sortedReservations));
            }

            return output.ToString();
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            return output.ToString();
        }
    }
}