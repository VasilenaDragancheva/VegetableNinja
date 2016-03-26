namespace VegetableNinja
{
    using Core;

    using UI;

    public class Program
    {
        public static void Main(string[] args)
        {
            var engine = new Engine(new ConsoleReader(), new ConsoleRenderer(), new VegetableFactory());
            engine.Run();
        }
    }
}