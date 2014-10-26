using System;

namespace FarmersCreed.Units
{
    public class CherryTree : FoodPlant
    {
        private const int CherryTreeBaseHealth = 14;
        private const int CherryTreeBaseGrowTime = 3;
        private const int CherryTreeBaseProductionQuantity = 4;
        private const int CherryTreeBaseHealthEffect = 2;

        public CherryTree(string id)
            : base(id, CherryTreeBaseHealth, CherryTreeBaseProductionQuantity, CherryTreeBaseGrowTime)
        {
        }

        public override Product GetProduct()
        {
            if (this.IsAlive)
            {
                return new Food(this.Id + "Product", ProductType.Cherry, FoodType.Organic,
                    this.ProductionQuantity, CherryTreeBaseHealthEffect);
            }
            else
            {
                throw new InvalidOperationException("Currently the operation is not alowed");
            }
        }
    }
}