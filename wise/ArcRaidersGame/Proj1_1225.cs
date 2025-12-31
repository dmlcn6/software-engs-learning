// DESTROY THE MONOLITH!!!!!! CREATING MODULARIZATION
// separate all interfaces/abstracts into separate files
// rename them properly
// separate all derived class into one file
// ITEMS
// CHARACTERS   
// re organize main function into one main cs file
// this will help us learn using statements

// have a file called Program.cs that is the entry point to your game
// have a folder that encloses your full game and all its code









//Loading into the game

using System.Runtime;
using System.Security.Cryptography.X509Certificates;

public static class ProgramStart
{
    private static void Main()
    {
        // Loading feedback
        Console.WriteLine("Your shaders are compiling");

    }
}












namespace objects
{
    public static class StoredInfo
    {
        // Create a blank static variable for name to set at start
        public string playerName = "";

        public List<Items> playerInventory = new() { };

    }

    public abstract class Characters
    {

        private int health = 0;
        private int damage = 0;



        // Call the user's current health stats
        public int CallHealthAmount()
        {
            return health;
        }

        // Call the user's current damage stats
        public int CallDamageAmount()
        {
            return damage;
        }

        // Change the character's health depending on the operation using true for + and false for -.
        public int HealthChange(bool oper, int amount)
        {
            if (oper == true)
            {
                health += amount;
            }
            else if (oper == false)
            {
                health -= amount;
            }
            else
            {
                Console.WriteLine("Something went wrong in the healthChange function");
            }

        }

        // Change the character's starting health.
        public int HealthStart(int amount)
        {
            health = amount;
        }

        // Change the character's damage depending on the operation using true for + and false for -.
        public int DamageChange(bool oper, int amount)
        {
            if (oper == true)
            {
                damage += amount;
            }
            else if (oper == false)
            {
                damage -= amount;
            }
            else
            {
                Console.WriteLine("Something went wrong in the damageChange function");
            }
        }

        // Change the character's starting damage.
        public int DamageStart(int amount)
        {
            damage = amount;
        }

        // Start an attack
        public abstract int AttackBase(Characters victim);

        // Recieving an attack
        public abstract int DamageReciever(Characters Attacker);

    }
    public class Player : Characters
    {
        public Player()
        {
            HealthStart(100);
            DamageStart(20);
        }

        List<Items> inventory = new() { EmptySlot, EmptySlot, EmptySlot, EmptySlot, EmptySlot };

        public override int AttackBase(int damageAmount)
        {
            victim.DamageReciever(damageAmount);
        }

    }
    public class Arc : Characters
    {

    }

    public abstract class Items
    {
        private int amp = 0;

        // Remove an item from the players inventory after using the item
        public abstract void Use(Characters user);

        // Create the amp start amount 
        public int AmpStart(int amount)
        {
            amp = amount;
            return amp;
        }

        // Call the current amp amount 
        public int CallAmpAmount()
        {
            return amp;
        }

    }
    public class ArcCell : Items
    {
        public ArcCell()
        {
            AmpStart(25);
        }
        public override void Use(Characters user)
        {
            user.healthChange(true, CallAmpAmount);
        }


    }
    public class Adrenaline : Items
    {
        public Adrenaline()
        {
            AmpStart(10);
        }
        public override void use(Characters user)
        {
            user.DamageChange(true, CallAmpAmount);
        }
    }
    public class EmptySlot : Items
    {
        public override void Use(Characters user)
        {
            Console.WriteLine("There is nothing here");
        }
    }

    public abstract class Weapon
    {
        int damage = 0;

        // Remove an item from the players inventory after using the item
        public abstract void Use(Characters user);

        // Call the weapons start damage
        public int DmgStart(int amount)
        {
            damage = amount;

            return damage;
        }

        // Call the current damage amount 
        public int CallDmgAmount()
        {
            return damage;
        }



    }

}















namespace Game
{
    public class Root
    {
        public void MainMenu()
        {
            // Greet the player
            Console.WriteLine("Welcome to Sparanza");
            Console.WriteLine("Where would you like to go?");
            Console.WriteLine("---------------------------");

            // Give player options
            Console.WriteLine("(A)TopSide");
            Console.WriteLine("(B)Inventory");
            Console.WriteLine("(C)WorkBench [Currently unavailable]");

            // Get player response
            var mm_response = Console.ReadLine();

            switch (mm_response)
            {
                case A:
                case a:
                    ConsoleWriteLine("Going to TopSide");
                    MainInventory();
                    break;

                case B:
                case b:
                    ConsoleWriteLine("Going to your inventory");
                    MainInventory();
                    break;

                case C:
                case c:
                    ConsoleWriteLine("This option is not available");
                    MainMenu();
                    break;
            }


        }
        ///////////////////////



        public void TopSide()
        {



        }

        public void Inventory()
        {



        }

        public void WorkBench()
        {



        }


    }

}
