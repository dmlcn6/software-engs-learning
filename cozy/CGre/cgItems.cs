namespace Items
{
    public abstract class UsableItems
    {
        public int dmgBuff;
        public int healing;
        public int shield;
        public string itemName;
        public int playerHP;
        public abstract void Equip(Character character);
    }
    public class Knife : UsableItems
    {
        public Knife()
        {
            itemName = "Knife";
            dmgBuff = 5;
        }
        public override void Equip(Character character)
        {
            character.damage = character.damage + dmgBuff;
        }
    }
    public class Sword : UsableItems
    {
        public Sword()
        {
            itemName = "Sword";
            dmgBuff = 15;
        }
        public override void Equip(Character character)
        {
            character.damage = character.damage + dmgBuff;
        }
    }
    public class Blick : UsableItems
    {
        public Blick()
        {
            itemName = "Blick";
            dmgBuff = 30;
        }
        public override void Equip(Character character)
        {
            character.damage = character.damage + dmgBuff;
        }

    }
    public class Armor : UsableItems
    {
        public Armor()
        {
            itemName = "Armor";
            shield = 100;
        }
        public override void Equip(Character character)
        {
            character.health = character.health + shield;
        }
    }
    public class Yercs : UsableItems
    {
        public Yercs()
        {
            itemName = "Yercs";
            healing = 20;
        }
        public override void Equip(Character character)
        {
            character.health = character.health + healing;
        }
    }
    public class Potion : UsableItems
    {
        public Potion()
        {
            itemName = "Potion";
            healing = 50;
        }
        public override void Equip(Character character)
        {
            character.health = character.health + healing;
        }
    }

}