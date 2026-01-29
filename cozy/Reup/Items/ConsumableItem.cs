namespace Reup.Items
{
    public abstract class ConsumableItem : ItemBase
    {
        public override bool isConsumable { get; set; }
        public override bool isEquippable { get; set; }
        public ConsumableItem()
        {
            isConsumable = true;
            isEquippable = false;
        }
    }
}