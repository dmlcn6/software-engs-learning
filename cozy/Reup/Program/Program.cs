using Reup.Characters;
using Reup.Items;
using Reup.Logger;

namespace Reup.Program
{
    public class Program
    {
        public static Player player;
        public static Stranger stranger;
        public static Bandit bandito;
        public static ILogger logger;
        public static string choice;
        public static string decision;
        public static int playerPos;
        public int random;
        public string item;


        public static void Main()
        {
            player = new Player();
            bandito = new Bandit();
            stranger = new Stranger();
            logger = new AuditLog();
            Program.Intro();
            Program.Begin();
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
            if (choice == "yes")
            {
                logger.Log("I thought you looked brave. Let's get started :)");
                do
                {
                    Program.Gameplay();
                } while (player.alive && playerPos <= 21);
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
            //I need var player 1 to get the game started
            //Game is built like a board game. Total of 20 spaces
            //Different events happen on different spaces
            //Player has 5 Lives to survive until the end
            //Four different events: Loot, Enemy, Stranger, Hazard
            //Player begins by rolling 6 sided dice
            //player can use an item before and after they decide to roll
            logger.Log("Enter a number to select an action");
            logger.Log("");
            logger.Log("1. View inventory");
            logger.Log("2. View Stats");
            logger.Log("3. Roll Dice");
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
                                item.GetType().ToString().Contains("Armor") ||
                                item.GetType().ToString().Contains("Yercs"))
                            {
                                item.Equip(player.health);
                            }
                            else
                            {
                                item.Equip(player.damage);
                            }

                            logger.Log("");
                            logger.Log("Item used successfully");
                            logger.Log($"{player.ViewStats()}");
                        }
                        break;
                    case 2:
                        logger.Log($"{player.ViewStats()}");
                        break;
                    case 3:
                        DiceRoll();
                        BoardEvents();
                        break;

                }
            }
        }
        public static void BoardEvents()
        {
            int lootItem;
            Random random = new Random();
            switch (playerPos)
            {
                //Loot
                case 2:
                case 3:
                case 7:
                case 12:
                case 18:
                    lootItem = random.Next(5);
                    ItemBase item;
                    logger.Log("You found an item!");

                    if (lootItem == 0)
                    {
                        item = new Yercs();
                    }
                    else if (lootItem == 1)
                    {
                        item = new Armor();
                    }
                    else if (lootItem == 2)
                    {
                        item = new Sword();
                    }
                    else if (lootItem == 3)
                    {
                        item = new Blick();
                    }
                    else
                    {
                        item = new Potion();
                    }
                    player.inventory.Add(item);
                    logger.Log($"{item.itemName} was added to your inventory.");

                    break;
                //Stranger
                case 4:
                case 9:
                case 11:
                case 17:
                case 20:
                    Potion potion = new Potion();
                    logger.Log("You have encountered a stranger...attack?");
                    logger.Log("Please type Yes or No");
                    choice = Console.ReadLine().ToLower();

                    if (choice == "yes")
                    {
                        Combat(player, stranger);
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
                        logger.Log("Please type Yes or No");
                        choice = Console.ReadLine().ToLower();
                    }
                    break;
                //Hazard
                case 1:
                case 8:
                case 13:
                case 14:
                case 19:
                    logger.Log("Rats! You Got Caught in a BoobyTrap!");
                    logger.Log("You lost 15 HP!");
                    player.health = player.health - 10;
                    break;
                //Enemy
                case 5:
                case 6:
                case 10:
                case 15:
                case 16:
                    logger.Log("You've encountered an enemy!");
                    Combat(player, bandito);
                    break;
            }
        }
        public static void DiceRoll()
        {
            logger.Log($"Current Position: {playerPos}");
            Random random = new Random();
            int sixDice = random.Next(1, 6);
            playerPos = playerPos + sixDice;
            logger.Log($"You rolled a {sixDice}!");
            logger.Log($"New Position: {playerPos}");
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
                                    item.Equip(player.health);
                                }
                                else
                                {
                                    item.Equip(player.damage);
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
            } while (player.alive && enemy.alive);
        }
    }
}

