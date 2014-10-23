namespace TheSlum.Characters
{
    using System.Collections.Generic;
    using System.Linq;

    public class Mage : AttacableCharacter
    {
        private const int InitialHealthPoints = 150;
        private const int InitialDefensePoints = 50;
        private const int InitialAttackPoints = 300;
        private const int InitialRange = 5;

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, InitialHealthPoints, InitialDefensePoints, InitialAttackPoints, team, InitialRange)
        {
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList.LastOrDefault(x => x.Team != this.Team && x.IsAlive);
            return target;
        }
    }
}
