


namespace UnitBB.Items
{

    public class Available : ItemsBase
    {
        public Available()
        {
            Initname("Empty");
        }
        public override string CallItemType()
        {
            return "--";
        }
        public override (int, int) Interact()
        {
            return (0, 0);
        }
    }
    public class ArcCell : UsableItemBase
    {
        public ArcCell()
        {
            Initname("ArcCell");
            InitHBuff(10);
        }
    }
    public class Rattler : EquippableItemBase
    {
        public Rattler()
        {
            Initname("Rattler");
            InitDamageIncrease(20);
        }
    }

}