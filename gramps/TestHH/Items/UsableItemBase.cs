
namespace TestHH.Items
{
    public abstract class UsableItemBase
    {
        public abstract bool isConsumable { get; set; }
        public abstract bool isEquippable { get; set; }
        public abstract int hp { get; set; }
        public abstract int dmg { get; set; }
        public abstract string name { get; set; }

        public int? xCoords;
        public int? yCoords;

        public void Alert()
        {
            Console.WriteLine("Alert");
        }
    }
}

