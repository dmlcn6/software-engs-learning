
namespace TestHH.Items
{
    public abstract class UsableItemBase
    {
        public abstract bool isConsumable { get; set; }
        public abstract bool isEquippable { get; set; }
        public abstract int amountOfEffectToHp { get; set; }
        public abstract string name { get; set; }

        public void Alert()
        {
            Console.WriteLine("Alert");
        }
    }
}

