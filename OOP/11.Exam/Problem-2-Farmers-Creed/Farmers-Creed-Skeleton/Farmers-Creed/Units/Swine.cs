using System;

namespace FarmersCreed.Units
{
    using FarmersCreed.Interfaces;

    public class Swine : Animal
    {
        private const int SwineBaseHealth = 20;
        private const int SwineBaseProductionQuantity = 1;
        private const int SwineBaseHealthEffect = 4;

        public Swine(string id)
            : base(id, SwineBaseHealth, SwineBaseProductionQuantity)
        {
        }

        public override Product GetProduct()
        {
            if (this.IsAlive)
            {
                Product product = new Food(
                    this.Id + "Product", ProductType.PorkMeat, FoodType.Meat, this.ProductionQuantity, SwineBaseHealthEffect);
                this.Health = 0;

                return product;
            }
            else
            {
                throw new InvalidOperationException("Currently the operation is not alowed");
            }
        }

        public override void Starve()
        {
            this.Health -= 3 * AnimalStarveIndex;
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Invalid quantity of food to be eaten (negative)");
            }

            // - tuka moje da se naloji da se umnojava po quantity
            var healthImpact = food.HealthEffect * 2;
            switch (food.FoodType)
            {
                case FoodType.Organic:
                case FoodType.Meat:
                    this.Health += healthImpact;
                    break;
            }
        }
    }
}