namespace TheSlum.Items
{
    internal class Axe : Item
    {
        private const int InitialHealthEffect = 0;
        private const int InitialDefenseEffect = 0;
        private const int InitialAttackEffect = 75;

        public Axe(string id)
            : base(id, InitialHealthEffect, InitialDefenseEffect, InitialAttackEffect)
        {
        }
    }
}
