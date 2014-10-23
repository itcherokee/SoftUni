namespace TheSlum.Items
{
    internal class Injection : Bonus
    {
        private const int InitialHealthEffect = 200;
        private const int InitialDefenseEffect = 0;
        private const int InitialAttackEffect = 0;

        public Injection(string id)
            : base(id, InitialHealthEffect, InitialDefenseEffect, InitialAttackEffect)
        {
            this.Timeout = 3;
            this.Countdown = 3;
            this.HasTimedOut = false;
        }
    }
}
