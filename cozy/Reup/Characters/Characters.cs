using Reup.Characters;

namespace Reup.Characters
{
    public class Player : ICharacter
    {
        public string playerName;
        public List<UsableItems> inventory = new List<UsableItems>() { new Sword() };
        public Player()
        {
            inventory[0].Equip(this);
        }
        public override void Attacked(ICharacter attacker)
        {
            health = health - attacker.damage;

            if (health <= 0)
            {
                alive = false;
                Console.WriteLine("GAME OVER! You have died.");
                Thread.Sleep(1000);
                Console.WriteLine("It seems I overestimated you...");
            }
        }
    }
    public class Enemy : ICharacter
    {
        public List<UsableItems> weapon = new List<UsableItems>() { new Knife() };
        public Enemy()
        {
            name = "Bandit";
            weapon[0].Equip(this);
        }
        public override void Attacked(ICharacter attacker)
        {
            health = health - attacker.damage;

            if (health <= 0)
            {
                alive = false;
            }
        }
    }
    public class Stranger : ICharacter
    {
        public List<UsableItems> tote = new List<UsableItems>() { new Blick(), new Armor() };
        public Stranger()
        {
            name = "???";
            tote[0].Equip(this);
            tote[1].Equip(this);
        }
        public override void Attacked(ICharacter attacker)
        {
            health = health - attacker.damage;

            if (health <= 0)
            {
                alive = false;
            }
        }
    }
}