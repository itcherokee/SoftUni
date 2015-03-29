using EFCodeFirst.Migrations;
using EFCodeFirst.Model;

namespace EFCodeFirst.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MountainsContext : DbContext
    {
        public MountainsContext() : base("Mountains")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MountainsContext, Configuration>());
        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Mountain> Mountains { get; set; }

        public IDbSet<Peak> Peaks { get; set; }
    }
}
