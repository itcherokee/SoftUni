namespace TheSlum.Characters
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Healer : CharacterWithInventory, IHeal
    {
        private const int InitialHealthPoints = 75;
        private const int InitialDefensePoints = 50;
        private const int InitialHealingPoints = 60;
        private const int InitialRange = 6;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, InitialHealthPoints, InitialDefensePoints, team, InitialRange)
        {
            this.HealingPoints = InitialHealingPoints;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var characterTeam = from character in targetsList
                                where character.Team == this.Team && character.Id != this.Id && character.IsAlive
                                select character;

            var target = (from theOne in characterTeam
                          where theOne.HealthPoints == characterTeam.Min(x => x.HealthPoints)
                          select theOne).FirstOrDefault();

            return target;
        }

        public override string ToString()
        {
            return string.Format("{0}, Healing: {1}", base.ToString(), this.HealingPoints);
        }
    }
}
