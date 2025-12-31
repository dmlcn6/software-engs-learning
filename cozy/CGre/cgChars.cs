namespace GameCharacters
{
    public abstract class Character
    {
        public int health = 100;
        public int damage = 7;
        public string name;
        public bool alive = true;
        public Character()
        {

        }
        public string ViewStats()
        {
            return $"DMG: {damage}, HP: {health}";
        }
        public abstract void Attacked(Character attacker);
        public void Attack(Character victim)
        {
            victim.Attacked(this);
        }


    }
    public class Player : Character
    {
        public string playerName;
        public List<UsableItems> inventory = new List<UsableItems>() { new Sword() };
        public Player()
        {
            inventory[0].Equip(this);
        }
        public override void Attacked(Character attacker)
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
    public class Enemy : Character
    {
        public List<UsableItems> weapon = new List<UsableItems>() { new Knife() };
        public Enemy()
        {
            name = "Bandit";
            weapon[0].Equip(this);
        }
        public override void Attacked(Character attacker)
        {
            health = health - attacker.damage;

            if (health <= 0)
            {
                alive = false;
            }
        }
    }
    public class Stranger : Character
    {
        public List<UsableItems> tote = new List<UsableItems>() { new Blick(), new Armor() };
        public Stranger()
        {
            name = "???";
            tote[0].Equip(this);
            tote[1].Equip(this);
        }
        public override void Attacked(Character attacker)
        {
            health = health - attacker.damage;

            if (health <= 0)
            {
                alive = false;
            }
        }
    }
}