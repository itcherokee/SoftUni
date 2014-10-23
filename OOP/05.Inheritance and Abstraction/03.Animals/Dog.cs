namespace Animals
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, ushort age, Gender sex)
            : base(name, age, sex)
        {
        }

        public string DoVoice()
        {
            return "Bauuuu!";
        }
    }
}
