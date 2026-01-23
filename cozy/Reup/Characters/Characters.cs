using Reup.Items;
namespace Reup.Characters
{
    public class Player : CharacterBase
    {
        public string playerName;
        public List<ItemBase> inventory = new List<ItemBase>() { new Sword() };
        public Player()
        {
            damage = inventory[0].Equip(damage);
        }

    }
    public class Bandit : CharacterBase
    {
        public List<ItemBase> weapon = new List<ItemBase>() { new Knife() };
        public Bandit()
        {
            name = "Bandit";
            damage = weapon[0].Equip(damage);
        }

    }
    public class Stranger : CharacterBase
    {
        public List<ItemBase> tote = new List<ItemBase>() { new Blick(), new Armor() };
        public Stranger()
        {
            name = "???";
            damage = tote[0].Equip(damage);
            health = tote[1].Equip(health);
        }
    }
}

