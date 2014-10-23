namespace StringUtils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class StringDisperser : ICloneable, IComparable, IComparable<StringDisperser>, IEnumerable<char>
    {
        private static readonly Random Generator = new Random();
        private readonly StringBuilder content;
        private readonly int uniqueId;

        public StringDisperser(params string[] input)
        {
            this.content = new StringBuilder();
            foreach (var singleItem in input)
            {
                if (singleItem == null)
                {
                    throw new ArgumentNullException("input", "None of input values must be null.");
                }

                this.content.Append(singleItem);
            }

            this.uniqueId = Generator.Next(100000000);
        }

        public static bool operator ==(StringDisperser disperserOne, StringDisperser disperserTwo)
        {
            if (ReferenceEquals(disperserOne, disperserTwo))
            {
                return true;
            }

            if (((object)disperserOne == null) || ((object)disperserTwo == null))
            {
                return false;
            }

            return disperserOne.CompareTo(disperserTwo) == 0;
        }

        public static bool operator !=(StringDisperser disperserOne, StringDisperser disperserTwo)
        {
            return !(disperserOne == disperserTwo);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var stringDisperser = obj as StringDisperser;
            if (stringDisperser != null)
            {
                return this.CompareTo(stringDisperser);
            }

            throw new ArgumentException("Object is not of a StringDisperser type.");
        }

        public int CompareTo(StringDisperser other)
        {
            var compareResult = string.Compare(
                this.content.ToString(), other.content.ToString(), StringComparison.Ordinal);

            return compareResult < 0 ? -1 : compareResult > 0 ? 1 : 0;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public StringDisperser Clone()
        {
            var newStringDisperser = new StringDisperser(this.content.ToString());

            return newStringDisperser;
        }

        public override int GetHashCode()
        {
            return this.content.Length ^ this.uniqueId;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int index = 0; index < this.content.Length; index++)
            {
                yield return this.content[index];
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var result = obj as StringDisperser;
            if (result == null)
            {
                return false;
            }

            return this.CompareTo(result) == 0;
        }

        public bool Equals(StringDisperser result)
        {
            if (result == null)
            {
                return false;
            }

            return this.CompareTo(result) == 0;
        }

        public override string ToString()
        {
            return this.content.ToString();
        }
    }
}
