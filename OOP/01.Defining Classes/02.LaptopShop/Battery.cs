namespace LaptopShop
{
    using System;

    /// <summary>
    /// Represents a Battery.
    /// </summary>
    public class Battery
    {
        private int life;

        /// <summary>
        /// Initializes a new instance of the <see cref="Battery" /> class with default 
        /// time-life as zero hours and type as unknown.
        /// </summary>
        public Battery()
            : this(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Battery" /> class.
        /// </summary>
        /// <param name="lifeTime">Battery life-time in hours.</param>
        /// <param name="type">Battery type.</param>
        public Battery(int lifeTime, BatteryType type = BatteryType.Unknown)
        {
            this.life = lifeTime;
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets battery lifetime in hours.
        /// </summary>
        public int LifeTime
        {
            get
            {
                return this.life;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid life time for battery provided!");
                }

                this.life = value;
            }
        }

        /// <summary>
        /// Gets or sets battery type.
        /// </summary>
        public BatteryType Type { get; set; }

        /// <summary>
        /// Convert internal state of Battery instance to string.
        /// </summary>
        /// <returns>Hours of battery life-time as a string.</returns>
        public override string ToString()
        {
            return string.Format("{0} - {1} hours.", this.Type, this.LifeTime);
        }
    }
}