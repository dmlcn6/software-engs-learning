
namespace TestHH.Items
{
    public class Potion : UsableItemBase
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public override bool isConsumable { get; set; }

        public Potion()
        {
            amountOfEffectToHp = 50;
            name = "Potion";
            isConsumable = true;
        }

        public override int Use(int stat)
        {
            stat = amountOfEffectToHp + stat;
            return stat;
        }
    }

    public class HiPotion : UsableItemBase
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public override bool isConsumable { get; set; }

        public HiPotion()
        {
            amountOfEffectToHp = 150;
            name = "Hi Potion";
            isConsumable = true;
        }

        public override int Use(int stat)
        {
            stat = amountOfEffectToHp + stat;
            return stat;
        }
    }

    public class Sword : UsableItemBase
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public override bool isConsumable { get; set; }

        public Sword()
        {
            amountOfEffectToHp = 10;
            name = "Sword";
            isConsumable = false;
        }

        public override int Use(int stat)
        {
            stat -= amountOfEffectToHp;
            return stat;
        }
    }
}