using System;

namespace FarmersCreed.Units
{
    public class Cow : Animal
    {
        private const int CowBaseHealth = 15;
        private const int CowBaseProductionQuantity = 6;
        private const int CowBaseHealthEffect = 4;
        private const int CowProductionHealthImpactIndex = 2;

        public Cow(string id)
            : base(id, CowBaseHealth, CowBaseProductionQuantity)
        {
        }

        public override void Eat(Interfaces.IEdible food, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Invalid quantity of food to be eaten (negative)");
            }

            var healthImpact = food.HealthEffect * quantity;
            switch (food.FoodType)
            {
                case FoodType.Organic:
                    this.Health += healthImpact;
                    break;
                case FoodType.Meat:
                    this.Health -= healthImpact;
                    break;
            }
        }

        public override Product GetProduct()
        {
            if (this.IsAlive)
            {
                this.Health -= CowProductionHealthImpactIndex;
                return new Food(
                    this.Id + "Product", ProductType.Milk, FoodType.Organic, this.ProductionQuantity,
                    CowBaseHealthEffect);
            }
            else
            {
                throw new InvalidOperationException("Currently the operation is not alowed");
            }
        }
    }
}