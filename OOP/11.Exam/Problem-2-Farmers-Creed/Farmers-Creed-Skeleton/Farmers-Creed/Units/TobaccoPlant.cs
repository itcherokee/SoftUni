using System;

namespace FarmersCreed.Units
{
    public class TobaccoPlant : Plant
    {
        private const int TobaccoPlantBaseHealth = 12;
        private const int TobaccoPlantBaseGrowTime = 4;
        private const int TobaccoPlantBaseProductionQuantity = 10;

        public TobaccoPlant(string id)
            : base(id, TobaccoPlantBaseHealth, TobaccoPlantBaseProductionQuantity, TobaccoPlantBaseGrowTime)
        {
        }

        public override Product GetProduct()
        {
            if (this.IsAlive && this.GrowTime > 0)
            {
                return new Product(this.Id + "Product", ProductType.Tobacco, this.ProductionQuantity);
            }
            else
            {
                throw new InvalidOperationException("Currently the operation is not alowed");
            }
        }

        public override void Grow()
        {
            this.GrowTime -= 2 * PlantGrowTime;
        }
    }
}