namespace MySchool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Teacher : Person
    {
        // Using HashSet in order to overcome duplicate records and faster access than List<T>
        private readonly HashSet<Discipline> disciplines;

        /// <summary>
        /// Instantiate an object of type Teacher. 
        /// It also instantiates an empty HashSet collection to hold objects of type Discipline
        /// </summary>
        /// <param name="firstName">String value holding first name of the Teacher</param>
        /// <param name="lastName">String value holding last name of the Teacher</param>
        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        {
            this.disciplines = new HashSet<Discipline>();
        }

        /// <summary>
        /// Instantiate an object of type Teacher. 
        /// It also instantiates the HashSet collection to hold objects of type Discipline
        /// </summary>
        /// <param name="firstName">String value holding first name of the Teacher</param>
        /// <param name="lastName">String value holding last name of the Teacher</param>
        /// <param name="discipline">A discipline to be attached to Teacher instance.</param>
        public Teacher(string firstName, string lastName, Discipline discipline)
            : this(firstName, lastName)
        {
            this.AddDiscipline(discipline);
        }

        /// <summary>
        /// Gets list of disciplines that teacher is enrolled to lead as a ReadOnly list 
        /// in order to prevent changes to that list from outside the Teacher class.
        /// </summary>
        public IEnumerable<Discipline> Disciplines
        {
            get
            {
                return this.disciplines.ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Add discipline to the list of disciplines lead by the teacher.
        /// If discipline already exist in the list, no changes are applied.
        /// </summary>
        /// <param name="discipline">Discipline instance to be added to the list.</param>
        public void AddDiscipline(Discipline discipline)
        {
            if (discipline != null)
            {
                if (!this.Disciplines.Contains(discipline))
                {
                    this.disciplines.Add(discipline);
                }
            }
            else
            {
                throw new ArgumentNullException("discipline", "You can add null discipline reference to list!");
            }
        }

        /// <summary>
        /// Remove discipline from the list of disciplines lead by the teacher.
        /// If discipline is not available, no exception is thrown as well as no change is introduced.
        /// </summary>
        /// <param name="discipline">Discipline instance to be removed.</param>
        public void Remove(Discipline discipline)
        {
            if (discipline != null)
            {
                if (this.Disciplines.Contains(discipline))
                {
                    this.disciplines.Remove(discipline);
                }
            }
            else
            {
                throw new ArgumentNullException("discipline", "Discipline instance can not be null!");
            }
        }

        /// <summary>
        /// Converts this Teacher instance to a string representation.
        /// </summary>
        /// <returns>Teacher object in string format.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(string.Format("Name: {0}\n", this.FullName));
            output.Append("Teaches Disciplines: \n\t");
            output.Append(
                this.disciplines.Count != 0 ? string.Join("\n\t", this.disciplines) : "None");

            return output.ToString();
        }
    }
}