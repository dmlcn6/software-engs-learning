using Reup.Interfaces;


namespace Reup.Items
{
    public abstract class ItemBase
    {
        public abstract string itemName { get; set; }
        public abstract bool isConsumable { get; set; }
        public abstract bool isEquippable { get; set; }
        public abstract int Equip(int stat);

    }
}
