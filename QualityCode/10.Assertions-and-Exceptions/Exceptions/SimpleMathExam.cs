namespace ExceptionsHomework
{
    using System;

    public class SimpleMathExam : Exam
    {
        private readonly int minGrade = 2;
        private readonly int maxGrade = 6;
        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            set
            {
                if (value >= 0 && value <= 10)
                {
                    this.problemsSolved = value;
                }

                throw new ArgumentOutOfRangeException("ProblemsSolved", string.Format("Invalid value! Value must be in the range [{0} - {1}", this.minGrade, this.maxGrade));
            }
        }

        public override ExamResult Check()
        {
            if (this.ProblemsSolved == 0)
            {
                return new ExamResult(2, this.minGrade, this.maxGrade, "Failed: nothing done.");
            }
            else if (this.ProblemsSolved >= 1 && this.ProblemsSolved <= 3)
            {
                return new ExamResult(3, this.minGrade, this.maxGrade, "Bad result: Almost nothing done.");
            }
            else if (this.ProblemsSolved >= 4 && this.ProblemsSolved <= 6)
            {
                return new ExamResult(4, this.minGrade, this.maxGrade, "Average result: could be better.");
            }
            else if (this.ProblemsSolved >= 7 && this.ProblemsSolved <= 8)
            {
                return new ExamResult(5, this.minGrade, this.maxGrade, "Very good result: well done.");
            }
            else if (this.ProblemsSolved >= 9 && this.ProblemsSolved <= 10)
            {
                return new ExamResult(6, this.minGrade, this.maxGrade, "Excelent result: perfectly done.");
            }

            throw new ArgumentOutOfRangeException("ProblemsSolved", string.Format("Invalid value! Value must be in the range [{0} - {1}", this.minGrade, this.maxGrade));
        }
    }
}