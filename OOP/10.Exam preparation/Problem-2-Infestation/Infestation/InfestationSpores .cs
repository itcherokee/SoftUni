namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int InfestationSporesAggressionEffect = 20;
        private const int InfestationSporesHealthEffect = 0;
        private const int InfestationSporesPowerEffect = -1;

        public InfestationSpores()
            : base(InfestationSporesAggressionEffect, InfestationSporesHealthEffect, InfestationSporesPowerEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.AggressionEffect = 0;
                this.PowerEffect = 0;
            }
        }
    }
}