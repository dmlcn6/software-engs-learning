
namespace TestHH.Items
{
    public class Potion : ConsumableItemBase
    {
        public override int hp { get; set; }
        public override int dmg { get; set; }
        public override string name { get; set; }

        public Potion()
        {
            hp = 50;
            dmg = 0;
            name = "Potion";
        }

        public override int Use(int stat)
        {
            stat = hp + stat;
            return stat;
        }
    }

    public class HiPotion : ConsumableItemBase
    {
        public override int hp { get; set; }
        public override int dmg { get; set; }
        public override string name { get; set; }

        public HiPotion()
        {
            hp = 150;
            dmg = 0;
            name = "Hi Potion";
        }

        public override int Use(int stat)
        {
            stat = hp + stat;
            return stat;
        }
    }

    public class Sword : EquippableItemBase
    {
        public override int hp { get; set; }
        public override int dmg { get; set; }
        public override string name { get; set; }

        public Sword()
        {
            hp = 0;
            dmg = 12;
            name = "Sword";
        }
    }

    public class Armor : EquippableItemBase
    {
        public override int hp { get; set; }
        public override int dmg { get; set; }
        public override string name { get; set; }

        public Armor()
        {
            hp = 10;
            dmg = 12;
            name = "Armor";
        }
    }
}