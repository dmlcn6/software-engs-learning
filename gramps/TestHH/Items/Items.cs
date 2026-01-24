
namespace TestHH.Items
{
    public class Potion : ConsumableItemBase
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public Potion()
        {
            amountOfEffectToHp = 50;
            name = "Potion";
        }

        public override int Use(int stat)
        {
            stat = amountOfEffectToHp + stat;
            return stat;
        }
    }

    public class HiPotion : ConsumableItemBase
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public HiPotion()
        {
            amountOfEffectToHp = 150;
            name = "Hi Potion";
        }

        public override int Use(int stat)
        {
            stat = amountOfEffectToHp + stat;
            return stat;
        }
    }

    public class Sword : EquippableItemBase
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public Sword()
        {
            amountOfEffectToHp = 10;
            name = "Sword";
        }
    }
}