namespace TheSlum.Items
{
    internal class Shield : Item
    {
        private const int InitialHealthEffect = 0;
        private const int InitialDefenseEffect = 50;
        private const int InitialAttackEffect = 0;

        public Shield(string id)
            : base(id, InitialHealthEffect, InitialDefenseEffect, InitialAttackEffect)
        {
        }
    }
}
