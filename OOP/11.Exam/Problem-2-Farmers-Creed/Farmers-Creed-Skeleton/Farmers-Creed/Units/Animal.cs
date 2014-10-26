namespace FarmersCreed.Units
{
    using Interfaces;

    public abstract class Animal : FarmUnit
    {
        protected const int AnimalStarveIndex = 1;

        protected Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public abstract void Eat(IEdible food, int quantity);

        public virtual void Starve()
        {
            this.Health -= AnimalStarveIndex;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}), {1}",
                base.ToString(),
                this.IsAlive ? string.Format("Health: {0}", this.Health) : "DEAD");
       }
    }
}
