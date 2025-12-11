

namespace AdventureGame
{
    #region GAME LOGIC
    public class Game
    {

        public static void Main(string[] args)
        {


        }
    }
    #endregion

    #region CHARACTERS

    public abstract class Character
    {
        private int dmg = 4;

        private int hp = 20;

        public abstract string name;

        public List<UsableItem> inventory;

        public Character()
        {
            // create players new inventory
            inventory = new List<UsableItem>();

            // player spawn with base item
            inventory.Add(new Sword());
        }

        public void ViewStats()
        {
            Console.WriteLine($"DMG: {dmg}, HP: {hp}");
        }

        public void AttackedBy(Character attacker)
        {
            hp = hp - attacker.dmg;
        }

        public void Attack(Character victim)
        {
            victim.AttackedBy(this);
        }
    }

    public class Player : Character
    {
        public Player()
        {
            name = "Player 1";
            inventory.Add(new Potion());
        }
    }

    public class TinyMonster : Character
    {
        public TinyMonster()
        {
            name = "Tiny Monster";
        }
    }

    #endregion

    #region ITEMS
    public abstract class UsableItem
    {
        public abstract int amountOfEffectToHp;
        public abstract int Use(DamagableObject victim);

        public void Alert()
        {
            Console.WriteLine("Alert");
        }
    }

    public class Potion : UsableItem
    {
        public Potion()
        {
            amountOfEffectToHp = 10;
        }

        public override void Use(Character player)
        {
            player.hp = amountOfEffectToHp + player.hp;
        }
    }

    public class Sword : UsableItem
    {
        public Sword()
        {
            amountOfEffectToHp = 10;
        }

        public void Use(Character player)
        {
            player.hp = player.hp - amountOfEffectToHp;
        }
    }
    #endregion
}
