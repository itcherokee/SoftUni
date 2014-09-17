namespace Learn
{
    public class JuniorTrainer : Trainer
    {
        /// <summary>
        /// Initialize an instance of <see cref="JuniorTrainer"/> class.
        /// </summary>
        /// <param name="fname">First name of the trainer.</param>
        /// <param name="lname">Last name of the trainer.</param>
        /// <param name="age">Current age of the trainer.</param>
        public JuniorTrainer(string fname, string lname, int age)
            : base(fname, lname, age)
        {
        }
    }
}
