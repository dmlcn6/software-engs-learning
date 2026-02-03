namespace Reup.Items
{
    public abstract class EquippableItem : ItemBase
    {
        public virtual int buff { get; set; }
        public override bool isConsumable { get; set; }
        public override bool isEquippable { get; set; }
        public EquippableItem()
        {
            isConsumable = false;
            isEquippable = true;
        }
    }
}