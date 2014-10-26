namespace FarmersCreed.Units
{
    public abstract class Plant : FarmUnit
    {
        protected const int PlantGrowTime = 1;
        protected const int PlantWitherIndex = 1;
        protected const int PlantWaterIndex = 2;

        protected Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get
            {
                return this.GrowTime == 0;
            }
        }

        public int GrowTime { get; set; }

        public virtual void Water()
        {
            this.Health += PlantWaterIndex;
        }

        public virtual void Wither()
        {
            this.Health -= PlantWitherIndex;
        }

        public virtual void Grow()
        {
            this.GrowTime -= PlantGrowTime;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}), {1}",
                base.ToString(),
                this.IsAlive ? string.Format("Health: {0}, Grown: {1} ", this.Health, this.HasGrown ? "Yes" : "No") : "DEAD");
        }
    }
}
