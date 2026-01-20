
namespace TestHH.Items
{
    public abstract class IUsableItem
    {
        public abstract bool isConsumable { get; set; }
        public abstract int amountOfEffectToHp { get; set; }

        public abstract string name { get; set; }

        public abstract int Use(int stat);

        public void Alert()
        {
            Console.WriteLine("Alert");
        }
    }
}

