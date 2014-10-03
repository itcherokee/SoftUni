namespace School
{
    using System;
    using System.Globalization;

    public class Student
    {
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                var args = new PropertyChangedEventArgs("Name", this.Name, value);
                this.name = value;
                this.OnPropertyChanged(this, args);
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                var args = new PropertyChangedEventArgs(
                    "Age",
                    this.Age.ToString(CultureInfo.InvariantCulture),
                    value.ToString(CultureInfo.InvariantCulture));
                this.age = value;
                this.OnPropertyChanged(this, args);
            }
        }

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(sender, e);
            }
        }
    }
}
