namespace ExceptionsHomework
{
    using System;

    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            if (this.MinGrade >= this.maxGrade)
            {
                throw new ArgumentOutOfRangeException(string.Format("MinGrade ({0}) cannot be greater or equal to MaxGrade ({1})!", this.MinGrade, this.maxGrade));
            }

            this.Grade = grade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Grade", "Grade can not be negative value!");
                }

                if (this.grade < this.MinGrade || this.grade > this.maxGrade)
                {
                    throw new ArgumentOutOfRangeException("Grade", string.Format("Grade ({0}) can not be less than minGrade ({1}) or bigger than maxGrade ({2})!", value, this.MinGrade, this.MaxGrade));
                }

                this.grade = value;
            }
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MinGrade", "MinGrade can not be negative value!");
                }

                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }

            private set
            {
                if (value <= this.minGrade)
                {
                    throw new ArgumentOutOfRangeException("MaxGrade", "MaxGrade can not be negative value!");
                }

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Comments", "Comments can not be null!");
                }
                
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Commnets", "Commnets can not be empty string or to contains only spaces!");
                }

                this.comments = value;
            }
        }
    }
}