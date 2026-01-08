// See https://aka.ms/new-console-template for more information

using UnitBB.Characters;


namespace UnitBB
{
    class Start
    {

        private static void Main()
        {
            Console.WriteLine("Entry has started");
            var startNext = new Test();
            startNext.Output();
        }

    }
    class Test
    {

        public void Output()
        {
            var MainRaider = new Raider();
            Console.WriteLine($"Raider's Damage is at {MainRaider.CallDamageAmount()}");
        }
    }
}
