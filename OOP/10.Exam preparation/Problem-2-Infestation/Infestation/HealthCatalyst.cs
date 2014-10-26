namespace Infestation
{
    public class HealthCatalyst : Supplement
    {
        private const int HealthCatalystsBasePowerEffect = 0;
        private const int HealthCatalystsBaseHealthEffect = 3;
        private const int HealthCatalystsBaseAggressionEffect = 0;

        public HealthCatalyst()
            : base(HealthCatalystsBaseAggressionEffect, HealthCatalystsBaseHealthEffect, HealthCatalystsBasePowerEffect)
        {
        }
    }
}