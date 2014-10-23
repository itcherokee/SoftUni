namespace MySchool
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Class : ICommentable
    {
        private string id;

        /// <summary>
        /// Instantiate an object of type Class. 
        /// It also instantiates both lists holding collections of Student & Teacher objects.
        /// </summary>
        /// <param name="id">String value holding class nameID.</param>
        public Class(string id)
        {
            this.Id = id;
            this.Students = new Dictionary<uint, Student>();
            this.Teachers = new List<Teacher>();
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.id = value;
                }
                else
                {
                    throw new ArgumentException("Class name could not be null, empty or whitespace!");
                }
            }
        }

        /// <summary>
        /// Gets or sets Students within the class.
        /// </summary>
        public Dictionary<uint, Student> Students { get; private set; }

        /// <summary>
        /// Gets or sets teachers assigned to this instance of a class.
        /// </summary>
        public List<Teacher> Teachers { get; private set; }

        public string Details { get; set; }

        /// <summary>
        /// Add Student to the list 
        /// </summary>
        /// <param name="student">Student object</param>
        public void AddStudent(Student student)
        {
            if (!this.Students.ContainsKey(student.ClassNumber))
            {
                this.Students.Add(student.ClassNumber, student);
            }
            else
            {
                throw new ArgumentException("Provided Student's ClassNumber is not unique!");
            }
        }

        /// <summary>
        /// Add Teacher to the list of Teachers leading lectures in that class.
        /// </summary>
        /// <param name="teacher">Teacher instance to be added.</param>
        public void AddTeacher(Teacher teacher)
        {
            if (!this.Teachers.Contains(teacher))
            {
                this.Teachers.Add(teacher);
            }
        }

        /// <summary>
        /// Removes Student from the list.
        /// If Student instance (student with that ClassNumber) is not found no change is applied.
        /// </summary>
        /// <param name="student">Student object</param>
        public void RemoveStudent(Student student)
        {
            if (student != null)
            {
                if (this.Students.ContainsKey(student.ClassNumber))
                {
                    this.Students.Remove(student.ClassNumber);
                }
            }
            else
            {
                throw new ArgumentNullException("student", "Student instance cannot be null!");
            }
        }

        /// <summary>
        /// Removes Teacher from the list.
        /// If Teacher instance is not found, no change is applied.
        /// </summary>
        /// <param name="teacher">Instance of Teacher to be removed.</param>
        public void RemoveTeacher(Teacher teacher)
        {
            if (teacher != null)
            {
                if (this.Teachers.Contains(teacher))
                {
                    this.Teachers.Remove(teacher);
                }
            }
            else
            {
                throw new ArgumentNullException("teacher", "Teacher instance cannot be null!");
            }
        }

        /// <summary>
        /// Format object's Class details in special modified string format.
        /// </summary>
        /// <returns>Class instance as String value.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Class ID: {0}\n", this.Id));
            output.AppendLine("Students in this class:");
            if (this.Students.Count != 0)
            {
                // Students list is not empty, so we can enumerate
                foreach (var student in this.Students)
                {
                    output.AppendLine(student.Value.ToString());
                }

                output.Append("\n");
            }
            else
            {
                output.Append("None");
            }

            output.AppendLine("Teachers in this class:");
            if (this.Teachers.Count != 0)
            {
                // Teacher list is not empty, so we can enumerate
                foreach (var teacher in this.Teachers)
                {
                    output.AppendLine(teacher.ToString());
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