using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        private int productionQuantity;

        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
        }

        public int Health { get; set; }

        public bool IsAlive
        {
            get
            {
                return this.Health <= 0;

            }
        }

        public int ProductionQuantity
        {
            get
            {
                return this.productionQuantity;

            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Production quntity cannot be a negative value.");
                }

                this.productionQuantity = value;
            }
        }

        public abstract Product GetProduct();
    }
}
