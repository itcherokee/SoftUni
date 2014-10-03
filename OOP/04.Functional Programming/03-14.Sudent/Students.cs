namespace University
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Students : IEnumerable
    {
        /// <summary>
        /// Instantiates the list to be used for storing Student objects
        /// </summary>
        public Students()
        {
            this.AllStudents = new List<Student>();
        }

        /// <summary>
        /// Total number of Students within the list.
        /// </summary>
        public int Count
        {
            get
            {
                return this.AllStudents.Count;
            }
        }

        private List<Student> AllStudents { get; set; }

        /// <summary>
        /// Sets or gets an Student item at the specified index.
        /// </summary>
        /// <param name="index">Index in the list, where is the Student item located.</param>
        /// <returns>Student object.</returns>
        public Student this[int index]
        {
            get
            {
                return this.AllStudents[index];
            }
        }

        /// <summary>
        /// Returns read-only collection of Student objects in the list.
        /// </summary>
        /// <returns>List of currently holded Students.</returns>
        public IList<Student> GetAllStudents()
        {
            return this.AllStudents.AsReadOnly();
        }

        /// <summary>
        /// Adds element of type Student to the list. Required in order to befit from object initializers in the code.
        /// </summary>
        /// <param name="student">Single instance of Student type</param>
        public void Add(Student student)
        {
            this.AllStudents.Add(student);
        }

        /// <summary>
        /// Discovers students who's first name is before their last name alphabeticaly.
        /// </summary>
        /// <returns>Custom IEnumerable<Student> list of elements fulfiling the condition.</Student></returns>
        public IEnumerable<Student> FirstBeforeLast() 
        {
            var query = from student in this.AllStudents
                        where string.Compare(student.FirstName, student.LastName, StringComparison.Ordinal) < 0
                        select student;
            return query;
        }

        /// <summary>
        /// Discovers students names where the age is between 18 and 24 years.
        /// </summary>
        /// <returns>IEnumerable list of anonymous type containg first name, last name and age.</returns>
        public IEnumerable AgeBetween(int startAge, int endAge)
        {
            var query = from student in this.AllStudents
                        where student.Age >= startAge && student.Age <= endAge
                        select new { student.FirstName, student.LastName, student.Age };
            return query;
        } 

        /// <summary>
        /// Sorts list by using Extension methods & lambda in descending order
        /// </summary>
        /// <returns>Sorted IEnumerable list - FirstName descending, LastName descending</returns>
        public IEnumerable SortExtension()
        {
            var query = this.AllStudents
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName)
                .Select(x => x);
            return query;
        } 

        /// <summary>
        /// Sorts list by using LINQ in descending order
        /// </summary>
        /// <returns>Sorted IEnumerable list - FirstName descending, LastName descending</returns>
        public IEnumerable SortLinq()
        {
            var query = from student in this.AllStudents
                        orderby student.FirstName descending, student.LastName descending
                        select student;
            return query;
        } 

        /// <summary>
        /// Filter students using LINQ on GroupMember number.
        /// </summary>
        /// <param name="groupNumber">Group memebership.</param>
        /// <returns>Students from required Group, sorted by FirstName.</returns>
        public IEnumerable<Student> GroupMemberLinq(uint groupNumber)
        {
            var query = from student in this.AllStudents
                        where student.GroupNumber == groupNumber
                        orderby student.FirstName
                        select student;
            return query;
        }  

        /// <summary>
        /// Filter students using LINQ based on e-mail domain.
        /// </summary>
        /// <param name="emailDomain">E-mail domain as filter criteria.</param>
        /// <returns>Student object with e-mail in requested e-mail domain.</returns>
        public IEnumerable<Student> MatchEmailDomain(string emailDomain)
        {
            var query = from student in this.AllStudents
                        where student.Email.EndsWith(emailDomain)
                        select student;
            return query;
        } 

        /// <summary>
        /// Filter students using LINQ based on phones starting with custom area codes.
        /// </summary>
        /// <param name="codes">An string array with phone area codes.</param>
        /// <returns>List of students with phone numbers from requested areas.</returns>
        public IEnumerable<Student> MatchPhoneCode(string[] codes)
        {
            IEnumerable<Student> result = Enumerable.Empty<Student>();
            foreach (string code in codes)
            {
                string currentCode = code;
                var query = from student in this.AllStudents
                            where student.Phone.StartsWith(currentCode) || student.Phone.StartsWith(currentCode) || student.Phone.StartsWith(currentCode)
                            select student;
                result = result.Union(query);
            }

            return result;
        } 

        /// <summary>
        /// Extracts all students with matched mark.
        /// </summary>
        /// <param name="mark">Mark to be searched within each student marks.</param>
        /// <returns>An list of students with such a mark.</returns>
        public IEnumerable MatchMark(byte mark)
        {
            var query = from student in this.AllStudents
                        where student.Marks.Contains(mark)
                        select new { FullName = student.FirstName + " " + student.LastName, student.Marks };

            return query;
        } 

        /// <summary>
        /// Extracts all students with matched mark count times.
        /// </summary>
        /// <param name="mark">Mark to be searched within each student marks.</param>
        /// <param name="count">How many times the mark must be present.</param>
        /// <returns>An anonymous type list of students.</returns>
        public IEnumerable MatchMarkCount(byte mark, int count)
        {
            var query = this.AllStudents
                .Where(student => student.Marks.Count(x => x == 2) == 2)
                .Select(student => new { FullName = student.FirstName + " " + student.LastName, student.Marks });

            return query;
        } 

        /// <summary>
        /// Extracts all students with matched mark count times where this mark and count represent all marks of a student.
        /// </summary>
        /// <param name="mark">Mark to be searched within each student marks.</param>
        /// <param name="count">How many times the mark must be present.</param>
        /// <returns>An anonymous type list of students.</returns>
        public IEnumerable MatchMarkCountDistinct(byte mark, int count)
        {
            var query = this.AllStudents
                .Where(student => student.Marks.Count(x => x == 2) == 2 && student.Marks.Count() == 2)
                .Select(student => new { FullName = student.FirstName + " " + student.LastName, student.Marks });

            return query;
        }

        /// <summary>
        /// Filter students using LINQ based on year enrolled.
        /// </summary>
        /// <param name="year">Year when student enrolled.</param>
        /// <returns>List of enrolled students in that year.</returns>
        public IEnumerable<Student> Enrolled(uint year)
        {
            var yearStr = year.ToString(CultureInfo.InvariantCulture);
            var query = from student in this.AllStudents
                        where student.FacultyNumber.ToString(CultureInfo.InvariantCulture).Substring(4, 2) == yearStr.Substring(yearStr.Length - 2, 2)
                        select student;
            return query;
        } 

        /// <summary>
        /// Convert and creates custom look of the Students class to be printed
        /// </summary>
        /// <returns>String.string</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            foreach (var studentName in this.AllStudents)
            {
                output.AppendLine("\nStudent:");
                output.Append(studentName);
            }

            return output.ToString();
        }

        /// <summary>
        /// Enumerating over AllStudents list
        /// </summary>
        /// <returns>Element from the list</returns>
        public IEnumerator GetEnumerator()
        {
            return this.AllStudents.GetEnumerator();
        }
    }
}