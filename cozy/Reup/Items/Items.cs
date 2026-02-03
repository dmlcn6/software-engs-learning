
using Reup.Interfaces;

namespace Reup.Items
{
    public class Knife : EquippableItem
    {
        public Knife()
        {
            itemName = "Knife";
            buff = 5;

        }
    }
    public class Sword : EquippableItem
    {
        public Sword()
        {
            itemName = "Sword";
            buff = 15;
        }
    }
    public class Blick : EquippableItem
    {
        public override string itemName { get; set; }
        public Blick()
        {
            itemName = "Blick";
            buff = 30;
        }
    }
    public class Armor : EquippableItem
    {
        public int shield;
        public override int buff { get; set => buff = 0; }
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