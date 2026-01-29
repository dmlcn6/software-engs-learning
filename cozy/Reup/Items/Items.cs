namespace Reup.Items
{
    public class Knife : EquippableItem
    {
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
        public Blick()
        {
            itemName = "Blick";
            dmgBuff = 30;
        }
        public override int Equip(int stat)
        {
            stat = stat + dmgBuff;
            return stat;
        }

    }
    public class Armor : ConsumableItem
    {
        public Armor()
        {
            itemName = "Armor";
            shield = 100;
        }
        public override int Equip(int stat)
        {
            stat = stat + shield;
            return stat;
        }

    }
    public class Yercs : ConsumableItem
    {
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