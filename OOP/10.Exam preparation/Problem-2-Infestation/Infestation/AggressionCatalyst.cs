namespace Infestation
{
    public class AggressionCatalyst : Supplement
    {
        private const int AggressionCatalystsBasePowerEffect = 0;
        private const int AggressionCatalystsBaseHealthEffect = 0;
        private const int AggressionCatalystsBaseAggressionEffect = 3;

        public AggressionCatalyst()
            : base(AggressionCatalystsBaseAggressionEffect, AggressionCatalystsBaseHealthEffect, AggressionCatalystsBasePowerEffect)
        {
        }
    }
}