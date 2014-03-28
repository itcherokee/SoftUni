namespace ConsoleInOut
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 2: A company has name, address, phone number, fax number, web site and manager. 
    ///         The manager has first name, last name, age and a phone number. Write a program 
    ///         that reads the information about a company and its manager and prints it back 
    ///         on the console.
    /// </summary>
    public class PrintCompanyInformation
    {
        public static void Main()
        {
            Console.Title = "Enter and print details for Company & Manager";
            string[] companyFields = new string[5] { "Company Name", "Company Address", "Phone number", "Fax number", "Web site" };
            string[] managerFields = new string[4] { "Manager first Name", "Manager last Name", "Manager age", "Manager phone" };
            List<Item> manager = new List<Item>();
            List<Item> company = new List<Item>();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter details for the Company:");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i <= companyFields.Length - 1; i++)
            {
                Console.Write("{0}: ", companyFields[i]);
                Item companyDetails = new Item();
                companyDetails.Field = companyFields[i];
                companyDetails.Value = Console.ReadLine();
                company.Add(companyDetails);
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter details for the Manager of the company:");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i <= managerFields.Length - 1; i++)
            {
                Console.Write("{0}: ", managerFields[i]);
                Item managerDetails = new Item();
                managerDetails.Field = managerFields[i];
                managerDetails.Value = Console.ReadLine();
                manager.Add(managerDetails);
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Full information for the Company and it's Manager:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Company details:");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in company)
            {
                Console.WriteLine("{0}: {1}", item.Field, item.Value);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Manager details:");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in manager)
            {
                Console.WriteLine("{0}: {1}", item.Field, item.Value);
            }

            Console.ReadKey();
        }

        public struct Item
        {
            public string Field { get; set; }

            public string Value { get; set; }
        }
    }
}