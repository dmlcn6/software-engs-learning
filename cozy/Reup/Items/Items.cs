using Reup.Characters;
namespace Reup.Items
{
    public class Knife : IUsableItems
    {
        public Knife()
        {
            itemName = "Knife";
            dmgBuff = 5;
        }
        public override void Equip(ICharacter character)
        {
            character.damage = character.damage + dmgBuff;
        }
    }
    public class Sword : IUsableItems
    {
        public Sword()
        {
            itemName = "Sword";
            dmgBuff = 15;
        }
        public override void Equip(ICharacter character)
        {
            character.damage = character.damage + dmgBuff;
        }
    }
    public class Blick : IUsableItems
    {
        public Blick()
        {
            itemName = "Blick";
            dmgBuff = 30;
        }
        public override void Equip(ICharacter character)
        {
            character.damage = character.damage + dmgBuff;
        }

    }
    public class Armor : IUsableItems
    {
        public Armor()
        {
            itemName = "Armor";
            shield = 100;
        }
        public override void Equip(ICharacter character)
        {
            character.health = character.health + shield;
        }
    }
    public class Yercs : IUsableItems
    {
        public Yercs()
        {
            itemName = "Yercs";
            healing = 20;
        }
        public override void Equip(ICharacter character)
        {
            character.health = character.health + healing;
        }
    }
    public class Potion : IUsableItems
    {
        public Potion()
        {
            itemName = "Potion";
            healing = 50;
        }
        public override void Equip(ICharacter character)
        {
            character.health = character.health + healing;
        }
    }
}