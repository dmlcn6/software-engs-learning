
namespace TestHH.Items
{
    public abstract class EquippableItemBase : UsableItemBase
    {
        public override bool isConsumable { get; set; }
        public override bool isEquippable { get; set; }

        public EquippableItemBase()
        {
            isConsumable = false;
            isEquippable = true;
        }


    }
}

