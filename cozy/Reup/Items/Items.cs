namespace Reup.Items
{
    public class Knife : IUsableItems
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
    public class Sword : IUsableItems
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
    public class Blick : IUsableItems
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
    public class Armor : IUsableItems
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
    public class Yercs : IUsableItems
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
    public class Potion : IUsableItems
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