using Reup.Items;
namespace Reup.Characters
{
    public class Player : ICharacter
    {
        public string playerName;
        public List<IUsableItems> inventory = new List<IUsableItems>() { new Sword() };
        public Player()
        {
            damage = inventory[0].Equip(damage);
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
    public class Bandit : ICharacter
    {
        public List<IUsableItems> weapon = new List<IUsableItems>() { new Knife() };
        public Bandit()
        {
            name = "Bandit";
            damage = weapon[0].Equip(damage);
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
        public List<IUsableItems> tote = new List<IUsableItems>() { new Blick(), new Armor() };
        public Stranger()
        {
            name = "???";
            damage = tote[0].Equip(damage);
            health = tote[1].Equip(health);
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