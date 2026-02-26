using System.ComponentModel;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using Reup.Characters;
using Reup.Items;
using Reup.Logger;

namespace Reup.Program
{
    public class Program
    {
        public static Player player = new Player();
        public static Stranger stranger = new Stranger();
        public static Bandit bandito = new Bandit();
        public static ILogger logger;
        public static string choice;
        public static string decision;
        public static int playerPos;
        public int random;
        public string item;
        public static int killCount = 0;
        public static Stranger stranger2 = new Stranger();
        public static ItemBase loot1 = new Knife();
        public static ItemBase loot2 = new Blick();
        public static ItemBase loot3 = new Armor();
        public static ItemBase loot4 = new Yercs();
        public static ItemBase loot5 = new Potion();
        public static Bandit bandito2 = new Bandit();
        public static Bandit bandito3 = new Bandit();
        public static Hazard hazard1 = new Hazard();
        public static Hazard hazard2 = new Hazard();
        public static Hazard hazard3 = new Hazard();
        public static Hazard hazard4 = new Hazard();
        public static Hazard hazard5 = new Hazard();

        public static object[,] array2DInitialization = {{null, hazard1, loot1, bandito3, null},
                                                        {hazard2, null, null, loot2, loot3},
                                                        {bandito2, stranger2, player, null, hazard3},
                                                        {hazard4, null, loot4, bandito, null},
                                                        {stranger, loot5, null, null, hazard5}};
        public static int newXCoords;
        public static int newYCoords;

        public static void Main()
        {
            player = new Player();
            bandito = new Bandit();
            stranger = new Stranger();
            logger = new AuditLog();


            Program.Intro();
            Program.Begin();
        }
        public static void Coordinates()
        {
            player.xCoords = 2;
            player.yCoords = 2;

            bandito3.xCoords = 0;
            bandito3.yCoords = 3;

            loot1.xCoords = 0;
            loot1.yCoords = 2;

            hazard1.xCoords = 0;
            hazard1.yCoords = 1;

            loot2.xCoords = 1;
            loot2.yCoords = 3;

            loot3.xCoords = 1;
            loot3.yCoords = 4;

            hazard2.xCoords = 1;
            hazard2.yCoords = 0;

            bandito2.xCoords = 2;
            bandito2.yCoords = 0;

            stranger2.xCoords = 2;
            stranger2.yCoords = 1;

            hazard3.xCoords = 2;
            hazard3.yCoords = 4;

            hazard4.xCoords = 3;
            hazard4.yCoords = 0;

            loot4.xCoords = 3;
            loot4.yCoords = 2;

            bandito.xCoords = 3;
            bandito.yCoords = 3;

            stranger.xCoords = 4;
            stranger.yCoords = 0;

            loot5.xCoords = 4;
            loot5.yCoords = 1;

            hazard5.xCoords = 4;
            hazard5.yCoords = 4;
        }
        public static void Intro()
        {
            logger.Log("Hi, My name is Cozy :)");
            Thread.Sleep(1000);
            logger.Log("Let's play a game");
            Thread.Sleep(1000);
            logger.Log("Don't worry, it'll be fun...");
            Thread.Sleep(1000);
            logger.Log("Before we get started, I need to know what to call you.");
            Thread.Sleep(1000);
            logger.Log("What is your name?");
            player.playerName = Console.ReadLine();
            logger.Log($"So your name is {player.playerName}? That's cute lol");
            Thread.Sleep(1000);
            logger.Log($"Today you'll embark on an adventure, {player.playerName}, to decide your fate!");
            Thread.Sleep(1000);
            logger.Log("Every decision you make will determine the outcome of your story.");
            Thread.Sleep(1000);
            logger.Log("Do you think you have what it takes to make it to the end?");
            logger.Log("Please type Yes or No");
            choice = Console.ReadLine().ToLower();
        }
        public static void Begin()
        {
            DateTime localTime = DateTime.Now;
            Coordinates();
            //int killCount = 0;
            if (choice == "yes")
            {
                logger.Log("I thought you looked brave. Let's get started :)");
                Thread.Sleep(1000);
                logger.Log("Rid the land of all the bandits.");
                do
                {
                    Program.Gameplay();
                } while (player.alive && killCount < 3);
                if (player.alive == false)
                {
                    logger.Log("You Died!");
                    Thread.Sleep(1000);
                    logger.Log("Better Luck Next Time!");
                    logger.Log($"{player.playerName} ain't got the skills for this. {localTime}", "./gamelog.txt");
                }
                else
                {
                    logger.Log("Congratulations! You have completed the game!");
                    Thread.Sleep(1000);
                    logger.Log("I knew you could do it! :)");
                    logger.Log($"{player.playerName} conquered the CozyGame! {localTime}", "./gamelog.txt");
                }
            }
            else if (choice == "no")
            {
                logger.Log("That's disappointing.");
                Thread.Sleep(1000);
                logger.Log("Welp, Goodbye...");
            }
            else
            {
                logger.Log("Please type Yes or No");
                choice = Console.ReadLine().ToLower();
                Program.Begin();
            }
        }
        public static void Gameplay()
        {
            // create loop managing how players will move arround the map
            // capture the input from the arrow keys to determine the direction the player moves
            // determine what happens when a player moves around the array
            // players can use items before moving if they choose.
            logger.Log("Enter a number to select an action");
            logger.Log("");
            logger.Log("1. View inventory");
            logger.Log("2. View Stats");
            logger.Log("3. Move Position");
            var isDecision = int.TryParse(Console.ReadLine(), out int decision);

            if (isDecision)
            {
                switch (decision)
                {
                    case 1:
                        logger.Log("");
                        logger.Log("Here is your inventory: ");
                        var localInventory = player.inventory;
                        for (var i = 0; i < localInventory.Count; i++)
                        {
                            logger.Log($"{i}: {localInventory[i].itemName}");
                        }
                        logger.Log("");
                        logger.Log("Select your item number: ");
                        var isItemChoice = int.TryParse(Console.ReadLine(), out int itemChoice);

                        if (isItemChoice)
                        {
                            //grab the item
                            //compare type of item
                            var item = player.inventory[itemChoice];
                            if (item.GetType().ToString().Contains("Potion") ||
                                item.GetType().ToString().Contains("Yercs"))
                            {
                                player.UseItem(player._health);
                                player.inventory.Remove(item);
                            }
                            else if (item.GetType().ToString().Contains("Armor"))
                            {
                                player.UseItem(player.shield);
                                player.inventory.Remove(item);
                            }
                            else
                            {
                                player.UseItem(player._damage);
                                player.inventory.Remove(item);
                            }

                            logger.Log("");
                            logger.Log("Item used successfully");
                            logger.Log($"{player.ViewStats()}");
                            logger.Log("");
                        }
                        break;
                    case 2:
                        logger.Log($"{player.ViewStats()}");
                        break;
                    case 3:
                        logger.Log("Please enter the direction you want to move");
                        var movement = Console.ReadLine();


                        if (movement.ToLower() == "north")
                        {
                            if (player.xCoords - 1 < 0)
                            {
                                logger.Log("You can't go that way.");
                            }
                            else
                            {
                                newXCoords = player.xCoords - 1;
                                newYCoords = player.yCoords;
                                BoardEvents(newXCoords, newYCoords);
                            }
                        }
                        else if (movement.ToLower() == "south")
                        {
                            if (player.xCoords + 1 > 4)
                            {
                                logger.Log("You can't go that way.");
                            }
                            else
                            {
                                newXCoords = player.xCoords + 1;
                                newYCoords = player.yCoords;
                                BoardEvents(newXCoords, newYCoords);
                            }
                        }
                        else if (movement.ToLower() == "east")
                        {
                            if (player.yCoords + 1 > 4)
                            {
                                logger.Log("You can't go that way.");
                            }
                            else
                            {
                                newXCoords = player.xCoords;
                                newYCoords = player.yCoords + 1;
                                BoardEvents(newXCoords, newYCoords);
                            }
                        }
                        else if (movement.ToLower() == "west")
                        {
                            if (player.yCoords - 1 < 0)
                            {
                                logger.Log("You can't go that way.");
                            }
                            else
                            {
                                newXCoords = player.xCoords;
                                newYCoords = player.yCoords - 1;
                                BoardEvents(newXCoords, newYCoords);
                            }
                        }
                        break;
                }
            }
        }
        public static void BoardEvents(int newXCoords, int newYCoords)
        {
            var newSpace = array2DInitialization[newXCoords, newYCoords];

            if (newSpace?.GetType().ToString().Contains("Item") ?? false)
            {
                var utility = (ItemBase)newSpace;
                //identify item on space
                player.inventory.Add(utility);
                logger.Log("LOOT!!");
                Thread.Sleep(1000);
                logger.Log($"You found {utility.itemName}!");

                //add item to iventory
                //if item is a hazard, use immediately
                if (newSpace?.GetType().ToString().Contains("Hazard") ?? false)
                {
                    player.inventory.Add(utility);
                    player.UseItem(player.inventory.IndexOf(utility));
                    logger.Log("You were injured by a booby trap!");
                    logger.Log($"{player.ViewStats()}");
                }
                //move player to space and change previous space to null
                MoveToNull();
            }
            else if (newSpace?.GetType().ToString().Contains("Character") ?? false)
            {
                if (newSpace?.GetType().ToString().Contains("Stranger") ?? false)
                {

                    //is the character an enemy or a stranger
                    //if it is an enemy, trigger combat method
                    StrangerEncounter((Stranger)newSpace);
                    MoveToNull();
                }
                else if (newSpace?.GetType().ToString().Contains("Bandit") ?? false)
                {
                    //if player wins fight, change spot to null
                    //if it is a stranger, determine if you will fight or not
                    //move player to space and change previous spot to null
                    logger.Log($"Bandit! Get ready for battle!");
                    Combat(player, (Bandit)newSpace);
                    MoveToNull();
                }
            }
            else if (newSpace == null)
            {
                //move player to new space
                logger.Log("Pretty quiet over here...");
                MoveToNull();
            }
        }
        private static void MoveToNull()
        {
            //move player
            array2DInitialization[player.xCoords, player.yCoords] = null;


            player.xCoords = newXCoords;
            player.yCoords = newYCoords;
            array2DInitialization[newXCoords, newYCoords] = player;
            logger.Log($"Current Position: {player.xCoords}, {player.yCoords}");
        }


        public static void StrangerEncounter(Stranger enemy)
        {
            Potion potion = new Potion();
            logger.Log("You have encountered a stranger...attack?");
            logger.Log("Please type Yes or No");
            choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                Combat(player, enemy);
            }
            else if (choice == "no")
            {
                logger.Log($"Hello, {player.playerName}. I have something for you...");
                Thread.Sleep(1000);
                logger.Log("You gained a potion!");
                player.inventory.Add(potion);
            }
            else
            {
                StrangerEncounter((Stranger)enemy);
            }
        }


        public static void Combat(Player player, CharacterBase enemy)
        {
            do
            {
                logger.Log("Get ready for battle!");
                logger.Log($"Your stats: {player.ViewStats()}");
                logger.Log($"Enemy stats: {enemy.ViewStats()}");
                logger.Log("");
                logger.Log("Enter a number to select an action");
                logger.Log("");
                logger.Log("1. Attack");
                logger.Log("2. Use Item");
                var isChoice = int.TryParse(Console.ReadLine(), out int choice);

                if (isChoice)
                {
                    switch (choice)
                    {
                        case 1:
                            player.Attack(enemy);
                            break;
                        case 2:
                            logger.Log("");
                            logger.Log("Here is your inventory: ");
                            var localInventory = player.inventory;
                            for (var i = 0; i < localInventory.Count; i++)
                            {
                                logger.Log($"{i}: {localInventory[i].itemName}");
                            }
                            logger.Log("");
                            logger.Log("Select your item number: ");
                            var isItemChoice = int.TryParse(Console.ReadLine(), out int itemChoice);

                            if (isItemChoice)
                            {
                                //grab the item
                                //compare type of item
                                var item = player.inventory[itemChoice];
                                if (item.GetType().ToString().Contains("Potion") ||
                                    item.GetType().ToString().Contains("Armor") ||
                                    item.GetType().ToString().Contains("Yercs"))
                                {
                                    player.UseItem(player._health);
                                }
                                else
                                {
                                    player.UseItem(player._damage);
                                }

                                logger.Log("");
                                logger.Log("Item used successfully");
                                logger.Log($"{player.ViewStats()}");
                            }
                            break;
                    }
                }
                if (enemy.alive)
                {
                    enemy.Attack(player);
                }
                else
                {
                    killCount += 1;
                }
            } while (player.alive && enemy.alive);
        }
    }
}

