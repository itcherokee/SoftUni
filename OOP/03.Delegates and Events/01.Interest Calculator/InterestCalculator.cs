namespace Interest
{
    using System.Globalization;

    public delegate decimal CalculateInterest(decimal money, double interest, double years);

    public class InterestCalculator
    {
        private readonly decimal calculatedInterest;

        public InterestCalculator(decimal money, double interest, double years, CalculateInterest calculate)
        {
            this.calculatedInterest = calculate(money, interest, years);
        }

        public override string ToString()
        {
            return this.calculatedInterest.ToString("F4", CultureInfo.InvariantCulture);
        }
    }
}
