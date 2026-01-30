
using Reup.Interfaces;

namespace Reup.Items
{
    public class Knife : EquippableItem
    {
        public override int dmgBuff { get; set; }
        public override string itemName { get; set; }
        public Knife()
        {
            itemName = "Knife";
            dmgBuff = 5;

        }
        public override int Equip(int stat)
        {
            stat = stat + dmgBuff;
            return stat;
        }
    }
    public class Sword : EquippableItem
    {
        public override int dmgBuff { get; set; }
        public override string itemName { get; set; }
        public Sword()
        {
            itemName = "Sword";
            dmgBuff = 15;
        }
        public override int Equip(int stat)
        {
            stat = stat + dmgBuff;
            return stat;
        }
    }
    public class Blick : EquippableItem
    {
        public override int dmgBuff { get; set; }
        public override string itemName { get; set; }
        public Blick()
        {
            itemName = "Blick";
            dmgBuff = 30;
        }
        public override int Equip(int stat)
        {
             = stat + dmgBuff;
            return stat;
        }

    }
    public class Armor : EquippableItem
    {
        public int shield;
        public override int dmgBuff { get; set => dmgBuff = 0; }
        public override string itemName { get; set; }
        public Armor()
        {
            itemName = "Armor";
            shield = 100;
        }
        public override int Equip(int stat)
        {
            shield = stat + shield;
            return shield;
        }

    }
    public class Yercs : ConsumableItem
    {
        public override int healing { get; set; }
        public override string itemName { get; set; }
        public Yercs()
        {
            itemName = "Yercs";
            healing = 20;
        }
        public override int Equip(int stat)
        {
            stat = stat + healing;
            return stat;
        }
    }
    public class Potion : ConsumableItem
    {
        public override int healing { get; set; }
        public override string itemName { get; set; }
        public Potion()
        {
            itemName = "Potion";
            healing = 50;
        }
        public override int Equip(int stat)
        {
            stat = stat + healing;
            return stat;
        }
    }
}