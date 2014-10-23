namespace Banking.Customers
{
    using System;
    using Utils;

    public class Company : Customer
    {
        private readonly bool isVatRegistered;
        private string eik;

        public Company(string name, string address, string bulstat, bool vatRegistered = false)
            : base(name, address)
        {
            this.Eik = bulstat;
            this.isVatRegistered = vatRegistered;
        }

        /// <summary>
        /// Gets and Sets Bulstat of the company.
        /// </summary>
        public string Eik
        {
            get
            {
                return this.eik;
            }

            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("value", "No Bulstat provided!");
                }

                try
                {
                    if (EikValidator.CalculateChecksumForNineDigitsEik(value))
                    {
                        this.eik = value;
                    }
                }
                catch (ArgumentException)
                {
                    // retransmit the inner error up
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets VAT if company registered with it.
        /// </summary>
        public string Vat
        {
            get
            {
                if (this.isVatRegistered)
                {
                    return "BG" + this.Eik;
                }

                return "not registered";
            }
        }
    }
}