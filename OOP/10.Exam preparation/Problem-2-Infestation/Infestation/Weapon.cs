namespace Infestation
{
    public class Weapon : Supplement
    {
        private const int WeaponAggressionEffect = 3;
        private const int WeaponPowerEffect = 10;

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.AggressionEffect = WeaponAggressionEffect;
                this.PowerEffect = WeaponPowerEffect;
            }
        }

    }
}