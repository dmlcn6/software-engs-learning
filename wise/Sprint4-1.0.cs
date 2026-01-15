// create a function that stores the players last inventory status, health status, AND damage status.
// A loop that leads back to the menu
// Last Progression 1/13/26-1.2

using System.Data;
using System.Runtime.CompilerServices;
using System.Security;
using CharactersBase;
using ItemsBase;
using Microsoft.VisualBasic;
using TopSide;



namespace Menu
{


    class Start
    {
        static void Main()
        {
            Console.WriteLine("Program.Start.Main has begun");
            var startNew = new TestA();
            startNew.TestAA();
        }
    }

}


/////////////////////////////////////////////////////////////////////


namespace TopSide
{
    public class TestA
    {
        public void TestAA()
        {
            var openRaider = new Raider();
            var rInventory = openRaider.inventory;
            Console.WriteLine($"Your players health: {openRaider.CallHealthAmount()}");
            Console.WriteLine($"Your players damage: {openRaider.CallDamageAmount()}");
            Console.WriteLine("What is your name?");
            openRaider.NameAdj(Console.ReadLine());
            Console.WriteLine($"Is your name {openRaider.CallName()}?");
            Console.WriteLine($"Item 3 is {rInventory[2].CallName()}");

            var startNew = new TestB();
            startNew.TestBB(openRaider);

        }
    }

    public class TestB
    {
        public void TestBB(Characters openRaider)
        {
            //topLevel

            Console.WriteLine("Welcome to Topside");
            var openArc = new Arc();

            do
            {

                if (openArc.CallHealthAmount() <= 0)
                {
                    openArc = new Arc();
                }

                bool? tempRule1 = false;
                do
                {

                    Console.WriteLine("an enemy has appeared");
                    Console.WriteLine("--stats menu--");
                    Console.WriteLine("--stats--");
                    Console.WriteLine($"Your stats HP:{openRaider.CallHealthAmount} DMG:{openRaider.CallDamageAmount}");
                    Console.WriteLine($"The Arc's stats HP:{openArc.CallHealthAmount} DMG:{openArc.CallDamageAmount}");
                    Console.WriteLine("----*----");
                    Console.WriteLine("");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("(A): Go to your inventory");
                    Console.WriteLine("(B): Attack the enemy");

                    switch (Console.ReadLine())
                    {
                        case "a":
                        case "A":
                            tempRule1 = true;
                            Console.WriteLine("you have chosen A");
                            // player's attack qoute and send attack message to attacker to collect damage amount then send damage amount to damage reciever on victim to deliever damage (enemy does the same) then show stats

                            break;
                        case "b":
                        case "B":
                            tempRule1 = true;
                            Console.WriteLine("you have chosen B");
                            //var inv = openRaider.inventory();
                            //foreach (int i in inv())
                            //{
                            //    Console.WriteLine($"{inv[i]}");
                            //    i++;
                            //}

                            //// show player the player their inventory and have the enemy attack the player then show stats
                            break;
                        default:
                            tempRule1 = false;
                            Console.WriteLine("Please Either enter (A) or (B)");
                            break;
                    }
                } while (tempRule1 == false);


                Console.WriteLine("--stats--");
                Console.WriteLine($"Your stats HP:{openRaider.CallHealthAmount} DMG:{openRaider.CallDamageAmount}");
                Console.WriteLine($"The Arc's stats HP:{openArc.CallHealthAmount} DMG:{openArc.CallDamageAmount}");
                Console.WriteLine("----*----");





            } while (openRaider.IsAlive() == true && openRaider.CallKillCount() < 3);


            if (openRaider.CallKillCount() == 3)
            {
                Console.WriteLine("You have WON!");
                return;
            }
            else
            {
                Console.WriteLine("You have Failed");
                return;
            }

        }
    }
}


/////////////////////////////////////////////////////////////////////

////////////-----1111
namespace CharactersBase
{
    public abstract class Characters
    {
        private string name = "--";
        private int health = 0;
        private int damage = 0;
        private int killcount = 0;
        public List<Items> inventory = new() { new Available(), new Available(), new Available(), new Available(), new Available() };


        public string Initname(string createdName)
        {
            name = createdName;

            return name;
        }
        public int IntiHealth(int amount)
        {
            health = amount;

            return health;
        }
        public int IntiDamage(int amount)
        {
            damage = amount;

            return damage;
        }

        //------------------

        public string CallName()
        {
            return name;
        }
        public int CallHealthAmount()
        {
            return health;
        }
        public int CallDamageAmount()
        {
            return damage;
        }
        public int CallKillCount()
        {
            return killcount;
        }
        public bool IsAlive()
        {

            if (CallHealthAmount() <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //------------------


        public string NameAdj(string changeName)
        {
            if (changeName != "")
            {
                name = changeName;
            }
            return name;
        }

        public int HealthAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    health += amount;
                    break;

                case "x":
                case "*":
                    health *= amount;
                    break;

                case "-":
                    health -= amount;
                    break;

                case "/":
                    health /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in in A Characters HealthAdj");
                    break;
            }

            return health;
        }

        public int DamageAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    damage += amount;
                    break;

                case "x":
                case "*":
                    damage *= amount;
                    break;

                case "-":
                    damage -= amount;
                    break;

                case "/":
                    damage /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in A Characters DamageAdj");
                    break;
            }

            return damage;
        }

        public int KillCountAdj()
        {
            killcount++;

            return killcount;
        }

        public abstract void AttackBase(Characters target);

        public abstract int DamageRec(Characters attacker);



    }
    public class Raider : Characters
    {

        public Raider()
        {
            Initname("Raider");
            IntiHealth(100);
            IntiDamage(10);
            inventory[0] = new ArcCell();
        }

        public override void AttackBase(Characters Target)
        {
            Console.WriteLine("take a deep breath... Bang!");
            Console.WriteLine($"{CallName()} has hit the Arc for {CallDamageAmount}");
            Target.DamageRec(this);

        }
        public override int DamageRec(Characters attacker)
        {
            HealthAdj(attacker.CallDamageAmount(), "-");
            Console.WriteLine($"The {CallName()} health is currently {CallHealthAmount()}");

            if (CallHealthAmount() <= 0)
            {
                attacker.KillCountAdj();
            }

            return CallHealthAmount();
        }




    }
    public class Arc : Characters
    {

        public Arc()
        {
            Initname("Arc");
            IntiHealth(100);
            IntiDamage(10);
        }

        public override void AttackBase(Characters Target)
        {
            Console.WriteLine("zzzrrrzrzrzrz... Zap!");
            Console.WriteLine($"{CallName()} has hit the Arc for {CallDamageAmount}");
            Target.DamageRec(this);
        }
        public override int DamageRec(Characters attacker)
        {
            HealthAdj(attacker.CallDamageAmount(), "-");
            Console.WriteLine($"The {CallName()} health is currently {CallHealthAmount()}");

            if (CallHealthAmount() <= 0)
            {
                attacker.KillCountAdj();
            }

            return CallHealthAmount();
        }


    }
}

////////////-----2222
namespace WeaponsBase

{
    public abstract class Weapons
    {
        string name = "--";
        private int durability = 0;
        private int damage = 0;

        //------------------

        public string Initname(string createdName)
        {
            name = createdName;

            return name;
        }
        public int IntiDurability(int amount)
        {
            durability = amount;

            return durability;
        }
        public int IntiDamage(int amount)
        {
            damage = amount;

            return damage;
        }

        //------------------

        public int DurabilityAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    durability += amount;
                    break;

                case "x":
                case "*":
                    durability *= amount;
                    break;

                case "-":
                    durability -= amount;
                    break;

                case "/":
                    durability /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in A Weapons DurabilityAdj");
                    break;
            }

            return durability;
        }

        public int DamageAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    damage += amount;
                    break;

                case "x":
                case "*":
                    damage *= amount;
                    break;

                case "-":
                    damage -= amount;
                    break;

                case "/":
                    damage /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in A Weapons DamageAdj");
                    break;
            }

            return damage;
        }

    }


}

////////////-----3333
namespace ItemsBase
{

    public abstract class Items
    {
        private string name = "--";
        private int buff = 0;
        private int debuff = 0;

        //------------------

        public string Initname(string createdName)
        {
            name = createdName;

            return name;
        }
        public int InitBuff(int amount)
        {
            buff = amount;

            return buff;
        }
        public int InitDebuff(int amount)
        {
            debuff = amount;

            return debuff;
        }

        //------------------

        public string CallName()
        {
            return name;
        }

        //------------------

        public int BuffAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    buff += amount;
                    break;

                case "x":
                case "*":
                    buff *= amount;
                    break;

                case "-":
                    buff -= amount;
                    break;

                case "/":
                    buff /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in a Item BuffAdj");
                    break;
            }

            return buff;
        }
        public int DebuffAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    debuff += amount;
                    break;

                case "x":
                case "*":
                    debuff *= amount;
                    break;

                case "-":
                    debuff -= amount;
                    break;

                case "/":
                    debuff /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in A Item debuffAdj");
                    break;
            }

            return debuff;
        }
        public int Use()
        {
            int effects = buff + debuff;
            Console.WriteLine($"Your {this.name} has just been used");

            return effects;
        }

    }
    public class Available : Items
    {
        public Available()
        {
            Initname("Empty");
            InitBuff(0);
            InitDebuff(0);
        }
    }
    public class ArcCell : Items
    {
        public ArcCell()
        {
            Initname("ArcCell");
            InitBuff(10);
            InitDebuff(0);
        }
    }

}











// Last Progression1/13/26-1.2