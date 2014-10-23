namespace Company
{
    using System;
    using System.Collections.Generic;

    public class TestExec
    {
        public static void Main()
        {
            var managers = new List<IEmployee>();
            var managerOne = new Manager("Product", "Productov", 1, 1000m, Department.Production);
            managers.Add(managerOne);
            var managerTwo = new Manager("Accountant", "Accountov", 2, 1100m, Department.Accounting);
            managers.Add(managerTwo);
            var managerThree = new Manager("Market", "Marketov", 3, 1500m, Department.Marketing);
            managers.Add(managerThree);
            var managerFour = new Manager("Sale", "Salelov", 4, 2000m, Department.Sales);
            managers.Add(managerFour);

            var sherps = new List<IRegularEmployee>();
            var employeeOne = new Developer("Kopach", "One", 6, 500m, Department.Production);
            employeeOne.AddItem(new Project("Visual Studio", new DateTime(2014, 11, 22), "Abe nishto nyama da izlezne!"));
            managerOne.AddEmployee(employeeOne);
            sherps.Add(employeeOne);
            var employeeTwo = new Developer("Kopach", "Two", 7, 500m, Department.Production);
            employeeTwo.AddItem(new Project("Visual Studio", new DateTime(2014, 11, 22), "Abe nishto nyama da izlezne!"));
            managerOne.AddEmployee(employeeTwo);
            sherps.Add(employeeTwo);
            var employeeThree = new Developer("Kopach", "Three", 8, 3500m, Department.Production);
            employeeThree.AddItem(new Project("Golyamoto Nishto", new DateTime(2010, 01, 01), "Mi sha vidim"));
            managerOne.AddEmployee(employeeThree);
            sherps.Add(employeeThree);
            var employeeFour = new SalesEmployee("Tyrgash", "One", 9, 9500m, Department.Sales);
            employeeFour.AddItem(new Sale("Golyamo Mente", new DateTime(2014, 01, 20), 1000m));
            managerFour.AddEmployee(employeeFour);
            sherps.Add(employeeFour);

            var customers = new List<ICustomer>()
            {
                new Customer("Kupuvach", "Kupuvachkov", 1, 0),
                new Customer("Kupuvachka", "Kupuvachkova", 2, 0)
            };

            List<IPerson> allOfThem = new List<IPerson>();
            allOfThem.AddRange(managers);
            allOfThem.AddRange(sherps);
            allOfThem.AddRange(customers);

            foreach (var person in allOfThem)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
