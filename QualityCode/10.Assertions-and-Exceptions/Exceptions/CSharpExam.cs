namespace ExceptionsHomework
{
    using System;

    public class CSharpExam : Exam
    {
        private readonly int minGrade = 0;
        private readonly int maxGrade = 100;
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value >= 0 && value <= 100)
                {
                    this.score = value;
                }

                throw new ArgumentOutOfRangeException("Score", string.Format("Score can not be below {0} or above {1}!", this.minGrade, this.maxGrade));
            }
        }

        public override ExamResult Check()
        {
            var result = new ExamResult(this.Score, this.minGrade, this.maxGrade, "Exam results calculated by score.");
            return result;
        }
    }
}