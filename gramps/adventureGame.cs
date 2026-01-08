using AdventureGame;


namespace AdventureGame
{
    #region GAME LOGIC
    public static class Game
    {
        // player declaration lives on the class
        public static Player player1;

        public static void Main(string[] args)
        {
            //i want to fill in the class variable with the new instance
            player1 = new Player();
            // i want to know how many enemies the player has killed
            var killCount = 0;
            // i want the player to fight until the end
            var keepFighting = true;
            do
            {
                // create a tinymonster for the first 4 kills, then fight the boss for your final battle
                Character enemy;
                if (player1.killCount < 4)
                {
                    enemy = new TinyMonster();
                }
                else
                {
                    player1._inventory.Add(new HiPotion());
                    enemy = new Boss();
                }

                // run the encounter, until someone dies
                var player1SurvivedFight = EnemyEncounter(enemy);

                // keepfighting is true when the player survived the encounter and did not get 5 kills yet
                // if the player died in the enemey encounter or their kills count is 5 or more
                // then keepfighting will be false
                keepFighting = player1SurvivedFight && player1.killCount < 5;

                // after each encounter, checke if the player won
                if (player1.killCount == 5)
                {
                    Console.WriteLine("You've endured your first set of Trials! and deserve a new Weapon");
                    Console.WriteLine("You've won!");
                    return;
                }

            } while (keepFighting);

            Console.WriteLine("You have died! Get a 5 monster kill streak to proceede.");
            Console.WriteLine("GAMEOVER!");
        }

        private static bool EnemyEncounter(Character enemy)
        {
            // I want to alternate attacking/ item use, starting with the player 
            // until someone dies

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Select your action: number");
                Console.WriteLine("");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Item");

                // get the users input w ConsoleReadLine
                // try to parse it to an integer
                // whether the parse is succ or not, the function TryParse() returns a bool the bool is captured in isChoice
                // if the parse is successful, TryParse() will output the parsed string into the new variable type
                var isChoice = int.TryParse(Console.ReadLine(), out int choice);

                if (isChoice)
                {
                    switch (choice)
                    {
                        case 1:
                            player1.Attack(enemy);
                            break;

                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("Here is your inventory: ");


                            var localInventory = player1._inventory;


                            for (var i = 0; i < localInventory.Count; i++)
                            {
                                Console.WriteLine($"{i}: {localInventory[i].name}");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Select your item number: ");


                            var isItemChoice = int.TryParse(Console.ReadLine(), out int itemChoice);

                            if (isItemChoice)
                            {
                                player1._inventory[itemChoice].Use(player1);
                                Console.WriteLine("");
                                Console.WriteLine("Item used successfully");
                                player1.ViewStats();
                            }
                            else
                            {
                                // you didnt provide a proper choice
                            }
                            break;
                    }
                }
                else
                {
                    // you didnt provide a proper choise
                }

                if (enemy.IsAlive())
                {
                    enemy.Attack(player1);
                }
            } while (player1.IsAlive() && enemy.IsAlive());


            // returns if the player survived the encounter
            return player1.IsAlive();
        }
    }
    #endregion

    #region ITEMS
    public abstract class UsableItem
    {
        public abstract int amountOfEffectToHp { get; set; }

        public abstract string name { get; set; }

        public abstract int Use(Character victim);

        public void Alert()
        {
            Console.WriteLine("Alert");
        }
    }

    public class Potion : UsableItem
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public Potion()
        {
            amountOfEffectToHp = 50;
            name = "Potion";
        }

        public override int Use(Character character)
        {
            character._hp = amountOfEffectToHp + character._hp;
            character._inventory.Remove(this);
            return character._hp;
        }
    }

    public class HiPotion : UsableItem
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public HiPotion()
        {
            amountOfEffectToHp = 150;
            name = "Hi Potion";
        }

        public override int Use(Character character)
        {
            character._hp = amountOfEffectToHp + character._hp;
            character._inventory.Remove(this);
            return character._hp;
        }
    }

    public class Sword : UsableItem
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public Sword()
        {
            amountOfEffectToHp = 10;
            name = "Sword";
        }

        public override int Use(Character character)
        {
            character._hp -= amountOfEffectToHp;
            return character._hp;
        }
    }
    #endregion

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
}