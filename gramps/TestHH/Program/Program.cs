using TestHH.Characters;
using TestHH.Items;
using TestHH.Logger;

namespace TestHH
{
    public class Program
    {
        public static object[,] array2DInitialization = new object[4, 4];
        public static Player player1 = new Player();
        public static AuditLog logger = new AuditLog();

        public static void Main()
        {
            // i want to know how many enemies the player has killed
            //var killCount = 0;
            // i want the player to fight until the end
            var keepAdventuring = true;

            do
            {
                #region  coordiantes
                CharacterBase enemy = new TinyMonster();
                CharacterBase enemy1 = new TinyMonster();


                UsableItemBase loot = new Armor();
                UsableItemBase loot2 = new Potion();
                UsableItemBase loot3 = new HiPotion();

                // manual init
                /*
                {
                    { null, null, null, null },
                    { loot3, loot, null, null   },
                    { enemy, player1, null , null  },
                    { loot2, enemy1, null, null  }
                };
                */




                array2DInitialization[1, 0] = loot3;
                loot3.xCoords = 1;
                loot3.yCoords = 0;

                array2DInitialization[1, 1] = loot;
                loot.xCoords = 1;
                loot.yCoords = 1;

                array2DInitialization[2, 0] = enemy;
                enemy.xCoords = 2;
                enemy.yCoords = 0;

                array2DInitialization[2, 1] = player1;
                player1.xCoords = 2;
                player1.yCoords = 1;


                array2DInitialization[3, 0] = loot2;
                loot2.xCoords = 3;
                loot2.yCoords = 0;
                #endregion

                int newXCoord = -1;
                int newYCoord = -1;

                //get direction the user wants to move
                var results = Console.ReadLine() ?? "";

                // figure outt nwe coords
                if (results.ToString() == "UpArrow")
                {
                    if ((player1.xCoords - 1) < 0)
                    {
                        // you cant move out of the bounds of the array
                    }

                    newXCoord = player1.xCoords - 1;
                    newYCoord = player1.yCoords;
                }
                else if (results.ToString() == "RightArrow")
                {
                    if ((player1.yCoords + 1) > 3)
                    {
                        // you cant move out of the bounds of the array
                    }

                    newXCoord = player1.xCoords;
                    newYCoord = player1.yCoords + 1;
                }
                else if (results.ToString() == "LeftArrow")
                {
                    if ((player1.yCoords - 1) < 0)
                    {
                        // you cant move out of the bounds of the array
                    }

                    newXCoord = player1.xCoords;
                    newYCoord = player1.yCoords - 1;
                }
                else if (results.ToString() == "DownArrow")
                {
                    if ((player1.xCoords + 1) > 3)
                    {
                        // you cant move out of the bounds of the array
                    }

                    newXCoord = player1.xCoords + 1;
                    newYCoord = player1.yCoords;
                }
                else
                {
                    newXCoord = 0;
                    newYCoord = 0;
                }

                // see if the new spot is occupied
                var theThingInTheSpaceIWantToMoveTo = array2DInitialization[newXCoord, newYCoord];

                // check what character options are, given whatever is in the new space
                AllCharacterOptions(theThingInTheSpaceIWantToMoveTo, newXCoord, newYCoord);

                // keepAdventuring is true when the player Is Alive and did not get 1 kills yet
                // if the player died in the enemey encounter or their kills count is 1 or more
                // then keepAdventuring will be false
                keepAdventuring = player1.IsAlive() && player1.killCount < 1;

                // after each encounter, checke if the player won
                if (player1.killCount == 1)
                {
                    logger.Log("You've endured your first set of Trials! and deserve a new Weapon");
                    logger.Log("You've won!");
                    logger.RecordWin();
                    return;
                }

            } while (keepAdventuring);

            logger.Log("You have died! Get a 1 monster kill streak to proceede.");
            logger.RecordLoss();
        }

        private static void AllCharacterOptions(object theThingInTheSpaceIWantToMoveTo, int newXCoord, int newYCoord)
        {
            // interact with whatever is in the space

            if (theThingInTheSpaceIWantToMoveTo?.GetType().ToString().Contains("Item") ?? false)
            {
                // user must loot
                var loot = (UsableItemBase)theThingInTheSpaceIWantToMoveTo;
                LootEncounter(loot);

                // move the player
                MoveUserToNullSpace(newXCoord, newYCoord);
            }
            else if (theThingInTheSpaceIWantToMoveTo?.GetType().ToString().Contains("Character") ?? false)
            {
                // user must fight until someone wins and takes the spot
                // if they win, move player
                // run the encounter, until someone dies

                var enemy = (CharacterBase)theThingInTheSpaceIWantToMoveTo;

                // EnemyEncounter returns if player survived
                if (EnemyEncounter(enemy))
                {
                    // set old enemy space to null
                    array2DInitialization[enemy.xCoords, enemy.yCoords] = null;

                    // move the player
                    MoveUserToNullSpace(newXCoord, newYCoord);
                }
            }
            else if (theThingInTheSpaceIWantToMoveTo == null)
            {
                MoveUserToNullSpace(newXCoord, newYCoord);
            }
        }

        private static void MoveUserToNullSpace(int newXCoord, int newYCoord)
        {
            // move player  
            // user turn is over
            array2DInitialization[player1.xCoords, player1.yCoords] = null;

            player1.xCoords = newXCoord;
            player1.yCoords = newYCoord;

            array2DInitialization[newXCoord, newYCoord] = player1;
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

        private static void LootEncounter(UsableItemBase loot)
        {
            // check that loot is on gameboard
            if (loot.xCoords == null || loot.yCoords == null)
                return;

            // add the loot to the player inventory
            player1._inventory.Add(loot);

            // remove from gameboard
            array2DInitialization[(int)loot.xCoords!, (int)loot.yCoords!] = null;
        }

    }
}

