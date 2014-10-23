namespace Animals
{
    public abstract class Animal
    {
        /// <summary>
        /// Instantiates an animal in derived classes
        /// </summary>
        /// <param name="name">Name of the animal</param>
        /// <param name="age">Age of the animal</param>
        /// <param name="sex">Gender of the animal</param>
        protected Animal(string name, ushort age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public virtual Gender Sex { get; set; }
    }
}