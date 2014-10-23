namespace MySchool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class School
    {
        private readonly Dictionary<string, Class> classes;

        /// <summary>
        /// Instantiates an object of type School. 
        /// It also instantiates the Dictionary collection to hold instances of type Class.
        /// </summary>
        public School()
        {
            this.classes = new Dictionary<string, Class>();
        }

        /// <summary>
        /// Gets readonly list with currently enrolled classes in the school.
        /// </summary>
        public IEnumerable<Class> Classes
        {
            get
            {
                return this.classes.Select(x => x.Value).ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Add Instance of a Class to school list of student classes.
        /// </summary>
        /// <param name="studentClass">Instance of a student class to be added to the list of school classes.</param>
        public void AddClass(Class studentClass)
        {
            if (studentClass != null)
            {
                if (!this.Classes.Contains(studentClass))
                {
                    this.classes.Add(studentClass.Id, studentClass);
                }
                else
                {
                    throw new ArgumentException("This instance of class already exist in the school list of classes!");
                }
            }
            else
            {
                throw new ArgumentNullException("studentClass", "Class instance can not be null!");
            }
        }

        /// <summary>
        /// Remove class instance from school.
        /// If class instance is not discovered, no changes are applied.
        /// </summary>
        /// <param name="studentClass">Instance of a student class to be removed from school list.</param>
        public void RemoveClass(Class studentClass)
        {
            if (studentClass != null)
            {
                if (this.Classes.Contains(studentClass))
                {
                    this.classes.Remove(studentClass.Id);
                }
            }
            else
            {
                throw new ArgumentNullException("studentClass", "Class instance can not be null!");
            }
        }

        /// <summary>
        ///  Converts the School instance to a string representation.
        /// </summary>
        /// <returns>Instance formated as string.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            if (this.Classes.Count() != 0)
            {
                // Classes list is not empty, so we can enumerate
                foreach (var item in this.Classes)
                {
                    output.AppendLine(item.ToString());
                }
            }
            else
            {
                output.Append("None");
            }

            return output.ToString();
        }
    }
}