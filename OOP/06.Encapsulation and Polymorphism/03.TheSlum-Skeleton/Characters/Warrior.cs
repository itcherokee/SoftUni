namespace TheSlum.Characters
{
    using System.Collections.Generic;
    using System.Linq;

    public class Warrior : AttacableCharacter
    {
        private const int InitialHealthPoints = 200;
        private const int InitialDefensePoints = 100;
        private const int InitialAttackPoints = 150;
        private const int InitialRange = 2;

        public Warrior(string id, int x, int y, Team team)
            : base(id, x, y, InitialHealthPoints, InitialDefensePoints, InitialAttackPoints, team, InitialRange)
        {
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList.FirstOrDefault(x => x.Team != this.Team && x.IsAlive);
            return target;
        }
    }
}
