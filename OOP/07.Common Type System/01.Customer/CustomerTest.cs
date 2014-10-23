namespace CustomerManagementSystem
{
    using System;
    using System.Collections.Generic;

    public class CustomerTest
    {
        public static void Main()
        {
            var customerOne = new Customer("Goshko", "Goshkov", "Georgiev", "1234567890", CustomerType.Golden);
            var customerTwo = customerOne.Clone();
            Console.WriteLine("Customers are one and the same object in memory: {0}", ReferenceEquals(customerOne, customerTwo));
            Console.WriteLine("Both students are equal (with same values): {0}\n", customerOne.Equals(customerTwo));
            customerTwo.MiddleName = "Petranov";
            customerTwo.MobilePhone = "0888 / 000 000";
            customerOne.Email = "goshko.goshkov.georgiev@dir.bg";
            var customerThree = new Customer("Pencho", "Petkov", "Grozdanov", "0987654321", CustomerType.Diamond);
            customerThree.AddListOfPayments(
                new List<Payment>() { new Payment("iPad", 1000000.0m), new Payment("Nokia", 100.0m) });

            var customers = new List<Customer>() { customerOne, customerTwo, customerThree };
            customers.Sort();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
