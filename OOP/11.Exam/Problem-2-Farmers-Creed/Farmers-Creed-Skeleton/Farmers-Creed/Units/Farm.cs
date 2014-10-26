using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using System.Linq;

    public class Farm : GameObject, IFarm
    {
        public Farm(string id)
            : base(id)
        {
            this.Plants = new List<Plant>();
            this.Animals = new List<Animal>();
            this.Products = new List<Product>();
        }

        public List<Plant> Plants { get; private set; }

        public List<Animal> Animals { get; private set; }

        public List<Product> Products { get; private set; }

        public void AddProduct(Product product)
        {
            Product existingProduct = this.Products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
            }
            else
            {
                this.Products.Add(product);
            }
        }

        public void Exploit(IProductProduceable productProducer)
        {
            if (productProducer != null)
            {
                this.AddProduct(productProducer.GetProduct());
            }
            else
            {
                throw new ArgumentNullException("productProducer", "Product producer cannot be null.");
            }
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            foreach (var plant in this.Plants)
            {
                if (plant.IsAlive)
                {
                    if (plant.HasGrown)
                    {
                        //o	All live plants which have already grown start to wither
                        plant.Wither();
                    }
                    else
                    {
                        //o	All plants which are added to the farm start growing
                        plant.Grow();
                    }

                }
            }

            foreach (var animal in this.Animals.Where(animal => animal.IsAlive))
            {
                animal.Starve();
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            if (this.Animals.Count > 0)
            {
                var animals = this.Animals.Where(x => x.IsAlive).OrderBy(x => x.Id);
                foreach (var animal in animals)
                {
                    output.AppendLine(animal.ToString());
                }
            }

            if (this.Plants.Count > 0)
            {
                var plants = this.Plants.Where(x => x.IsAlive).OrderBy(x => x.Health).ThenBy(x => x.Id);
                foreach (var plant in plants)
                {
                    output.AppendLine(plant.ToString());
                }
            }

            if (this.Products.Count > 0)
            {

                var products = from product in this.Products
                               orderby product.ProductType, product.Quantity descending, product.Id
                               select product;

                foreach (var product in products)
                {
                    output.AppendLine(product.ToString());
                }
            }


            return output.ToString();
        }
    }
}
