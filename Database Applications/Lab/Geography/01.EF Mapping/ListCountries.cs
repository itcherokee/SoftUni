namespace ListCountries
{
    using System;

    public class ListCountries
    {
        public static void Main()
        {
            using (var context = new GeographyEntities())
            {
                foreach (var country in context.Countries)
                {
                  Console.WriteLine(country.CountryName); 
                } 
            }
        }
    }
}
