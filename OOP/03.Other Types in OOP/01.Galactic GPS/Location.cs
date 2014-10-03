namespace Gps
{
    using System;
    using System.Text;

    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Latitude", "Latitude cannot be of negative value!");
                }

                this.latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Longitude", "Longitude cannot be of negative value!");
                }

                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get
            {
                return this.planet;
            }

            set
            {
                this.planet = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet));
            return output.ToString();
        }
    }
}