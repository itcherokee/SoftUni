namespace GenericList
{
    using System;

    public class GenericListExec
    {
        public static void Main()
        {
            var numbers = new GenericList<int>();
            numbers.Add(11);
            numbers.Add(211);
            numbers.Add(1);
            numbers.Add(999);
            numbers.Add(2);
            numbers.Add(4);
            numbers.Add(111);
            numbers.Add(0);
            Console.WriteLine(numbers);
            Console.WriteLine(numbers.Count);
            Console.WriteLine("Max number: " + numbers.Max());
            Console.WriteLine("Min number: " + numbers.Min());
            Console.WriteLine(numbers[3]);
            Console.WriteLine(numbers.IndexOf(0));
            numbers.RemoveAt(3);
            Console.WriteLine(numbers);
            Console.WriteLine(numbers[3]);
            Console.WriteLine(numbers.IndexOf(0));
            numbers.InsertAt(0, 99999);
            Console.WriteLine(numbers);

            var persons = new GenericList<Person>(3);
            persons.Add(new Person("Pesho"));
            persons.Add(new Person("Gosho"));
            persons.Add(new Person("Tosho"));
            persons.Add(new Person("Totka"));
            persons.Add(new Person("Petka"));
            persons.Add(new Person("Nakov"));
            var wasabi = new Person("Wasabi");
            persons.Add(wasabi);
            persons.Add(new Person("..."));
            Console.WriteLine(persons);
            Console.WriteLine("Max element: " + persons.Max());
            Console.WriteLine("Min element: " + persons.Min());
            Console.WriteLine(persons[2]);
            Console.WriteLine(persons.IndexOf(wasabi));
            persons.RemoveAt(3);
            Console.WriteLine(persons);
            Console.WriteLine(persons[3]);
            Console.WriteLine(persons.IndexOf(wasabi));
            persons.InsertAt(4, new Person("Baracuda"));
            Console.WriteLine(persons);
            Console.WriteLine(persons.Count);
        }

        private class Person : IComparable, IComparable<Person>
        {
            private readonly string name;

            public Person(string name)
            {
                this.name = name;
            }

            public override string ToString()
            {
                return this.name;
            }

            public int CompareTo(object obj)
            {
                return this.name.CompareTo((obj as Person).name);
            }

            public int CompareTo(Person other)
            {
                return this.name.CompareTo(other.name);
            }
        }
    }
}
