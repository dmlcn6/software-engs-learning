using Reup.Interfaces;


namespace Reup.Items
{
    public abstract class ItemBase
    {
        public virtual string itemName { get; set; }
        public abstract bool isConsumable { get; set; }
        public abstract bool isEquippable { get; set; }

    }
}
