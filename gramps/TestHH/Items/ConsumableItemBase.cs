
namespace TestHH.Items
{
    public abstract class ConsumableItemBase : UsableItemBase
    {
        public override bool isConsumable { get; set; }
        public override bool isEquippable { get; set; }

        public ConsumableItemBase()
        {
            isConsumable = true;
            isEquippable = false;
        }

        public abstract int Use(int stat);
    }
}

