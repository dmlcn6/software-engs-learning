
using Reup.Interfaces;

namespace Reup.Items
{
    public class Knife : EquippableItem
    {
        public Knife()
        {
            itemName = "Knife";
            dmgBuff = 5;

        }
    }
    public class Sword : EquippableItem
    {
        public Sword()
        {
            itemName = "Sword";
            dmgBuff = 15;
        }
    }
    public class Blick : EquippableItem
    {
        public override string itemName { get; set; }
        public Blick()
        {
            itemName = "Blick";
            dmgBuff = 30;
        }
    }
    public class Armor : EquippableItem
    {
        public int shield;
        public override int dmgBuff { get; set => dmgBuff = 0; }
        public Armor()
        {
            itemName = "Armor";
            shield = 100;
        }


    }
    public class Yercs : ConsumableItem
    {
        public Yercs()
        {
            itemName = "Yercs";
            healing = 20;
        }
    }
    public class Potion : ConsumableItem
    {
        public Potion()
        {
            itemName = "Potion";
            healing = 50;
        }
    }
}