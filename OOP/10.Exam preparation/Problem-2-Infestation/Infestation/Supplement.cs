namespace Infestation
{
    using System;

    public abstract class Supplement : ISupplement
    {
        private int powerEffect;
        private int healthEffect;
        private int aggressionEffect;


        protected Supplement(int aggressionEffect = 0, int healthEffect = 0, int powerEffect = 0)
        {
            this.AggressionEffect = aggressionEffect;
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }

        public int PowerEffect
        {
            get
            {
                return this.powerEffect;

            }

            protected set
            {
                this.powerEffect = value;
            }
        }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;

            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Health effect can not be negative.");
                }

                this.healthEffect = value;
            }
        }

        public int AggressionEffect
        {
            get
            {
                return this.aggressionEffect;

            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Aggression effect can not be negative.");
                }

                this.aggressionEffect = value;
            }
        }
    }
}