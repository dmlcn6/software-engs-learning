


using Microsoft.VisualBasic;
using UnitBB.Items;
using UnitBB.Interfaces;
using UnitBB.Logger;
using System.Text.Json.Serialization;
using System.Runtime.Intrinsics.X86;

namespace UnitBB.Characters
{
    public abstract class CharactersBase : IBoardPiece
    {
        Logs to = new();

        private string name = "--";

        private int health = 0;
        private int tempHealth
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        private int damage = 0;
        private int tempDamage
        {
            get
            {
                return damage;
            }
            set
            {
                if (value > 100)
                {
                    value = 100;
                }
                damage = value;
            }
        }

        private bool enemyEncountered = false;
        private int killCount = 0;
        private int killCountNow = 0;
        public (int, int) position = (-1, -1);

        public List<ItemsBase> inventory = new() { new Available(), new Available(), new Available(), new Available(), new Available() };
        public ItemsBase[] Equipped = new ItemsBase[2] { new Available(), new Available() };


        public string Initname(string createdName)
        {
            name = createdName;

            return name;
        }
        public int InitHealth(int amount)
        {
            tempHealth = amount;

            return tempHealth;
        }
        public int InitDamage(int amount)
        {
            tempDamage = amount;

            return tempDamage;
        }
        public (int, int) InitPosition(int startPositionX, int startPositionY)
        {
            position.Item1 = startPositionX;
            position.Item2 = startPositionY;

            return position;
        }

        //------------------

        public string CallName()
        {
            return name;
        }
        public int CallHealthAmount()
        {
            var to = new Logs();
            return tempHealth;
        }
        public int CallDamageAmount()
        {
            return tempDamage;
        }
        public bool InventoryFull()
        {
            bool isFull = true;
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].GetType().ToString().Contains("Available"))
                {
                    isFull = false;
                }
            }
            return isFull;
        }
        public bool CallEnemyEncountered()
        {
            return enemyEncountered;
        }
        public int CallKillCount()
        {
            return killCount;
        }
        public int CallKillCountNow()
        {
            return killCountNow;
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


        public string NameAdj()
        {
            to.Log("What is your name?");
            var changeNameTemp1 = Console.ReadLine();

            if (changeNameTemp1 != "")
            {
                to.Log($"Is {changeNameTemp1} your name?");
                to.Log("(A) YES");
                to.Log("(B) NO");
                switch (Console.ReadLine())
                {
                    case "A":
                    case "a":
                        name = changeNameTemp1;
                        break;
                    case "B":
                    case "b":
                        to.Log("Please enter your name");
                        NameAdj();
                        break;
                    default:
                        to.Log("Something went wrong");
                        break;
                }
            }
            else
            {
                to.Log("please enter a valid name");
                NameAdj();
            }
            return name;
        }

        // Find out if the item is usable or equippable then interact with it accordingly
        public void ObtainIt(ItemsBase it, string oper) // can i make this the players inventory instead of all items
        {
            int replaceIndex = inventory.IndexOf(it);

            if (it.CallItemType() == "equippable")
            {
                if (Equipped[0].CallItemType() != "equippable")
                {
                    Equipped[0] = it;
                    HDAdj(it.Interact().Item1, it.Interact().Item2, oper);
                    inventory[replaceIndex] = new Available();

                    to.Log($"You now have {it.CallName()} in your left-hand");
                }
                else if (Equipped[0].CallItemType() == "equippable" && Equipped[1].CallItemType() != "equippable")
                {
                    Equipped[1] = it;
                    HDAdj(it.Interact().Item1, it.Interact().Item2, oper);
                    inventory[replaceIndex] = new Available();

                    to.Log($"You now have {it.CallName()} in your right-hand");
                }
                else
                {
                    to.Log("You can only have two items equiped at once");
                    to.Log("Please attempt to equip again in Sparanza");
                }
            }
            else if (it.CallItemType() == "usable")
            {
                HDAdj(it.Interact().Item1, it.Interact().Item2, oper);
                inventory[replaceIndex] = new Available();

                to.Log($"You have used the {it.CallName()}");

            }
            else
            {
                to.Log("Something went wrong");
            }
        }
        public void GainIt(ItemsBase it)
        {
            if (InventoryFull() == false)
            {
                bool firstAvailableFound = false;
                int amountAvailable = 0;
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].GetType().ToString().Contains("Available") && firstAvailableFound == false)
                    {
                        amountAvailable = i + 1;
                        int firstAvailableInt = i;
                        firstAvailableFound = true;

                        inventory[firstAvailableInt] = it;
                    }
                    else if (inventory[i].GetType().ToString().Contains("Available") && firstAvailableFound == true)
                    {
                        amountAvailable = i;
                    }
                }
                to.Log($"You have {amountAvailable} open inventory slots remaining");
            }
            else
            {
                to.Log("You do not have any open slots");
            }
        }
        public ItemsBase MoveIt(int itIndex)
        {
            ItemsBase itemLeaving = inventory[itIndex];
            inventory[itIndex] = new Available();

            return itemLeaving;
        }
        public bool UnequipIt(int itIndex0)
        {
            to.Log($"!{itIndex0}!");
            bool didItWork = false;
            int itIndex1 = itIndex0;
            ItemsBase itemUnequipping = Equipped[itIndex1];
            Equipped[itIndex1] = new Available();
            GainIt(itemUnequipping);

            if (Equipped[itIndex1] != itemUnequipping)
            {
                didItWork = true;
            }


            return didItWork;
        }

        public (int, int) HDAdj(int healthAdj, int damageAdj, string oper)
        {
            switch (oper)
            {
                case "+":
                    tempHealth += healthAdj;
                    tempDamage += damageAdj;
                    break;

                case "x":
                case "*":
                    tempHealth *= healthAdj;
                    tempDamage += damageAdj;
                    break;

                case "-":
                    tempHealth -= healthAdj;
                    tempDamage += damageAdj;
                    break;

                case "/":
                    tempHealth /= healthAdj;
                    tempDamage += damageAdj;
                    break;

                default:
                    to.Log("Something Went Wrong in in A Characters HDAdj");
                    break;
            }

            return (tempHealth, tempDamage);
        }
        public void ResortInventory() // - 02/26/26 This currently does NOT work
        {
            for (int i1 = 0; i1 < inventory.Count; i1++)
            {
                int next = i1 + 1;
                if (inventory[i1] == new Available() && inventory[next] != new Available())
                {
                    for (int i2 = 0; inventory[i2] != new Available(); i2++)
                    {
                        if (inventory[i2] == new Available())
                        {
                            inventory[i2] = inventory[i1];
                            inventory[i1] = new Available();
                        }
                    }
                }
            }
        }
        public bool AdjEnemyEncountered(bool change)
        {
            enemyEncountered = change;
            return enemyEncountered;
        }
        public int KillCountAdj()
        {
            killCount++;
            killCountNow++;

            return killCount;
        }
        public int killCountNowRes()
        {
            killCountNow = 0;

            return killCountNow;
        }

        public abstract void AttackBase(CharactersBase target);

        public abstract int DamageRec(CharactersBase attacker);
    }

}

