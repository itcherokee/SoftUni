namespace TheSlum.Items
{
    internal class Pill : Bonus
    {
        private const int InitialHealthEffect = 0;
        private const int InitialDefenseEffect = 0;
        private const int InitialAttackEffect = 100;

        public Pill(string id)
            : base(id, InitialHealthEffect, InitialDefenseEffect, InitialAttackEffect)
        {
            this.Timeout = 1;
            this.Countdown = 1;
            this.HasTimedOut = false;
        }
    }
}
