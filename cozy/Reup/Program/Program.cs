using Reup.Characters;
using Reup.Items;
namespace Reup.Program
{
    public class CozyGame
    {
        public static Player player;
        public static Stranger stranger;
        public static Enemy bandito;
        public static string choice;
        public static int playerPos;
        public int random;
        public string item;

        public static void Main()
        {
            player = new Player();
            bandito = new Enemy();
            stranger = new Stranger();
            CozyGame.Intro();
            CozyGame.Begin();
        }
        public static void Intro()
        {
            Console.WriteLine("Hi, My name is Cozy :)");
            Thread.Sleep(1000);
            Console.WriteLine("Let's play a game");
            Thread.Sleep(1000);
            Console.WriteLine("Don't worry, it'll be fun...");
            Thread.Sleep(1000);
            Console.WriteLine("Before we get started, I need to know what to call you.");
            Thread.Sleep(1000);
            Console.WriteLine("What is your name?");
            player.playerName = Console.ReadLine();
            Console.WriteLine($"So your name is {player.playerName}? That's cute lol");
            Thread.Sleep(1000);
            Console.WriteLine($"Today you'll embark on an adventure, {player.playerName}, to decide your fate!");
            Thread.Sleep(1000);
            Console.WriteLine("Every decision you make will determine the outcome of your story.");
            Thread.Sleep(1000);
            Console.WriteLine("Do you think you have what it takes to make it to the end?");
            Console.WriteLine("Please type Yes or No");
            choice = Console.ReadLine().ToLower();
        }
        public static void Begin()
        {
            if (choice == "yes")
            {
                Console.WriteLine("I thought you looked brave. Let's get started :)");
                do
                {
                    CozyGame.Gameplay();
                } while (player.alive && playerPos <= 21);
                if (player.alive == false)
                {
                    Console.WriteLine("You Died!");
                    Thread.Sleep(1000);
                    Console.WriteLine("Better Luck Next Time!");
                }
                else
                {
                    Console.WriteLine("Congratulations!");
                    Thread.Sleep(1000);
                    Console.WriteLine("You have completed the game!");
                    Thread.Sleep(1000);
                    Console.WriteLine("I knew you could do it! :)");
                }
            }
            else if (choice == "no")
            {
                Console.WriteLine("That's disappointing.");
                Thread.Sleep(1000);
                Console.WriteLine("Welp, Goodbye...");
            }
            else
            {
                Console.WriteLine("Please type Yes or No");
                choice = Console.ReadLine().ToLower();
                CozyGame.Begin();
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
            Console.WriteLine("Please press enter to roll the dice.");
            Console.ReadLine();
            DiceRoll();
            BoardEvents();


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
                    IUsableItems item;
                    Console.WriteLine("You found an item!");

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
                    Console.WriteLine($"{item.itemName} was added to your inventory.");

                    break;
                //Stranger
                case 4:
                case 9:
                case 11:
                case 17:
                case 20:
                    Potion potion = new Potion();
                    Console.WriteLine("You have encountered a stranger...attack?");
                    Console.WriteLine("Please type Yes or No");
                    choice = Console.ReadLine().ToLower();

                    if (choice == "yes")
                    {
                        Combat(player, stranger);
                    }
                    else if (choice == "no")
                    {
                        Console.WriteLine($"Hello, {player.playerName}. I have something for you...");
                        Thread.Sleep(1000);
                        Console.WriteLine("You gained a potion!");
                        player.inventory.Add(potion);
                    }
                    else
                    {
                        Console.WriteLine("Please type Yes or No");
                        choice = Console.ReadLine().ToLower();
                    }
                    break;
                //Hazard
                case 1:
                case 8:
                case 13:
                case 14:
                case 19:
                    Console.WriteLine("Rats! You Got Caught in a BoobyTrap!");
                    Console.WriteLine("You lost 15 HP!");
                    player.health = player.health - 10;
                    break;
                //Enemy
                case 5:
                case 6:
                case 10:
                case 15:
                case 16:
                    Console.WriteLine("You've encountered an enemy!");
                    Combat(player, bandito);
                    break;
            }
        }
        public static void DiceRoll()
        {
            Console.WriteLine($"Current Position: {playerPos}");
            Random random = new Random();
            int sixDice = random.Next(1, 6);
            playerPos = playerPos + sixDice;
            Console.WriteLine($"You rolled a {sixDice}!");
            Console.WriteLine($"New Position: {playerPos}");
        }
        public static void Combat(Player player, ICharacter enemy)
        {
            do
            {
                Console.WriteLine("Get ready for battle!");
                Console.WriteLine($"Your stats: {player.ViewStats()}");
                Console.WriteLine($"Enemy stats: {enemy.ViewStats()}");
                Console.WriteLine("");
                Console.WriteLine("Enter a number to select an action");
                Console.WriteLine("");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Item");
                var isChoice = int.TryParse(Console.ReadLine(), out int choice);

                if (isChoice)
                {
                    switch (choice)
                    {
                        case 1:
                            player.Attack(enemy);
                            break;
                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("Here is your inventory: ");
                            var localInventory = player.inventory;
                            for (var i = 0; i < localInventory.Count; i++)
                            {
                                Console.WriteLine($"{i}: {localInventory[i].itemName}");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Select your item number: ");
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

                                Console.WriteLine("");
                                Console.WriteLine("Item used successfully");
                                player.ViewStats();
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

