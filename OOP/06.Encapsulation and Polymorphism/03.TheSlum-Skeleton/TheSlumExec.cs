namespace TheSlum
{
    using Characters;
    using GameEngine;

    public class TheSlumExec
    {
        public static void Main()
        {
            Engine engine = new NewEngine();
            engine.Run();
        }
    }
}
