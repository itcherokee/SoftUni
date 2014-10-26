using System.Collections.Generic;
using System.Linq;

namespace Infestation
{
    public abstract class Infestor : Unit
    {
        protected Infestor(string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where(this.CanAttackUnit);

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            var unitInfos = attackableUnits as IList<UnitInfo> ?? attackableUnits.ToList();
            optimalAttackableUnit = unitInfos.OrderBy(x => x.Health).FirstOrDefault();

            return optimalAttackableUnit;
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = this.Id != unit.Id;

            return attackUnit;
        }
    }
}