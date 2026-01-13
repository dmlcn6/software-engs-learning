// create a function that stores the players last inventory status, health status, AND damage status.
// A loop that leads back to the menu
// Last Progression 1/13/26-1.2

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
            var startNew = new TestAA();
            startNew.TestBB();
        }
    }

}


/////////////////////////////////////////////////////////////////////


namespace TopSide
{
    public class TestAA
    {
        public void TestBB()
        {
            var OpenRaider = new Raider();
            var rInventory = OpenRaider.inventory;
            Console.WriteLine($"Your players health: {OpenRaider.CallHealthAmount()}");
            Console.WriteLine($"Your players damage: {OpenRaider.CallDamageAmount()}");
            Console.WriteLine("What is your name?");
            OpenRaider.NameAdj(Console.ReadLine());
            Console.WriteLine($"Is your name {OpenRaider.CallName()}?");
            Console.WriteLine($"Item 3 is {rInventory[2].CallName()}");

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
        public Items[] inventory = new Items[5] { new ArcCell(), new Available(), new Available(), new Available(), new Available() };


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



    }
    public class Raider : Characters
    {

        public Raider()
        {
            Initname("The Player");
            IntiHealth(100);
            IntiDamage(10);
            inventory[0] = new ArcCell();
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