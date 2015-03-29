

using System.Collections.Generic;

namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Data;
    using EFCodeFirst.Model;



    internal sealed class Configuration : DbMigrationsConfiguration<MountainsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MountainsContext context)
        {
            if (!context.Countries.Any())
            {
               var rilaPeaks = new List<Peak>
                {
                    new Peak {Name = "Musala", Elevation = 2925},
                    new Peak {Name = "Malyovitsa", Elevation = 2729}
                };

                var pirinPeaks = new List<Peak>
                {
                    new Peak {Name = "Vihren", Elevation = 2914}
                };

                var mountains = new List<Mountain>
                {
                    new Mountain {Name = "Rila", Peaks = rilaPeaks},
                    new Mountain {Name = "Pirin", Peaks = pirinPeaks},
                    new Mountain {Name = "Rhodopes"}
                };

                var bulgaria = new Country { Name = "Bulgaria", Code = "BG", Mountains = mountains };
                var germany = new Country { Name = "Germany", Code = "DE" };

                context.Countries.Add(bulgaria);
                context.Countries.Add(germany);
            }

        }
    }
}
