namespace Infestation
{
    public class PowerCatalyst : Supplement
    {
        private const int PowerCatalystsBasePowerEffect = 3;
        private const int PowerCatalystsBaseHealthEffect = 0;
        private const int PowerCatalystsBaseAggressionEffect = 0;
        
        public PowerCatalyst()
            : base(PowerCatalystsBaseAggressionEffect, PowerCatalystsBaseHealthEffect, PowerCatalystsBasePowerEffect)
        {
        }
    }
}