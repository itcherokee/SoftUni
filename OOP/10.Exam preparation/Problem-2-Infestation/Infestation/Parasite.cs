using System.Collections.Generic;
using System.Linq;

namespace Infestation
{
    public class Parasite : Infestor
    {
        private const int ParasiteBasePower = 1;
        private const int ParasiteBaseHealth = 1;
        private const int ParasiteBaseAggression = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, ParasiteBaseHealth, ParasiteBasePower, ParasiteBaseAggression)
        {
        }
    }
}