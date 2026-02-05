using TestHH.Characters;
using TestHH.Items;
using TestHH.Logger;

namespace TestHH
{
    public class Program
    {
        public static Player player1 = new Player();
        public static AuditLog logger = new AuditLog();

        public static void Main(string[] args)
        {
            // i want to know how many enemies the player has killed
            //var killCount = 0;
            // i want the player to fight until the end
            var keepFighting = true;
            do
            {
                // create a tinymonster for the first 4 kills, then fight the boss for your final battle
                CharacterBase enemy;
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
                    logger.Log("You've endured your first set of Trials! and deserve a new Weapon");
                    logger.Log("You've won!");
                    logger.RecordWin();
                    return;
                }

            } while (keepFighting);

            logger.Log("You have died! Get a 5 monster kill streak to proceede.");
            logger.RecordLoss();
        }

        private static bool EnemyEncounter(CharacterBase enemy)
        {
            // I want to alternate attacking/ item use, starting with the player 
            // until someone dies

            do
            {
                logger.Log("");
                logger.Log("Select your action: number");
                logger.Log("");
                logger.Log("1. Attack");
                logger.Log("2. Use Item");

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
                            logger.Log("");
                            logger.Log("Here is your inventory: ");


                            var localInventory = player1._inventory;


                            for (var i = 0; i < localInventory.Count; i++)
                            {
                                logger.Log($"{i}: {localInventory[i].name}");
                            }
                            logger.Log("");
                            logger.Log("Select your item number: ");


                            var isItemChoice = int.TryParse(Console.ReadLine(), out int itemChoice);

                            if (isItemChoice)
                            {
                                var item = player1._inventory[itemChoice];

                                // TODO: the Use() is on on ConsumableItems, figure it out
                                if (item.isConsumable)
                                {
                                    // cast item as ConsumableItem which has the use() on it
                                    var consumableItem = (ConsumableItemBase)item;

                                    // use item and remove from inventory
                                    player1._hp = consumableItem.Use(player1._hp);
                                    player1._inventory.Remove(item);

                                    // log
                                    logger.Log("");
                                    logger.Log("Item used successfully");
                                    player1.ViewStats();
                                }
                                else
                                {
                                    // TODO: TEST THIS PATH
                                    EnemyEncounter(enemy);
                                }
                            }
                            else
                            {
                                // TODO: TEST THIS PATH
                                // you didnt provide a proper choice
                                EnemyEncounter(enemy);
                            }
                            break;
                    }
                }
                else
                {
                    // TODO: TEST THIS PATH
                    // you didnt provide a proper choise
                    EnemyEncounter(enemy);
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
}

