// AC for our work item
// user must be identified by player name (input) DONE
// at least 5 prompts before one of the endings
// 2 endings: Win or Lose
// show use of constructors, static classes DONE
// 4 Object Oriented Programming principles (inheritance, encapsulation, poly, abstraction) 
// player (with or without hp)
// meter, counter, hp, progress tracking, 
// combat/competition
// Usable items in inventory
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Game
{
    public class CozyGame
    {
        public static string playerName;
        public static string choice;
        public static void Main()
        {
            //CozyGame.Intro();
            //CozyGame.Begin();
            CozyGame.Gameplay();
        }
        // Get player name and start the game
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
            playerName = Console.ReadLine();
            Console.WriteLine($"So your name is {playerName}? That's cute lol");
            Thread.Sleep(1000);
            Console.WriteLine($"Today you'll embark on an adventure, {playerName}, to decide your fate!");
            Thread.Sleep(1000);
            Console.WriteLine("Every decision you make will determine the outcome of your story.");
            Thread.Sleep(1000);
            Console.WriteLine("Do you think you have what it takes to make it to the end?");
            Console.WriteLine("Please type Yes or No");
            choice = Console.ReadLine();
        }
        // Have player decide if they want to play or not
        public static void Begin()
        {
            if (choice == "Yes")
            {
                Console.WriteLine("I thought you looked brave. Let's get started :)");
                CozyGame.Gameplay();
            }
            else if (choice == "No")
            {
                Console.WriteLine("That's disappointing.");
                Thread.Sleep(1000);
                Console.WriteLine("Welp, Goodbye...");
            }
            else
            {
                Console.WriteLine("Please type Yes or No");
                choice = Console.ReadLine();
                CozyGame.Begin();
            }
        }
        // Start the game. Player begins the adventure.
        public static void Gameplay()
        {
            //I need var player 1 to get the game started
            //Game is built like a board game. Total of 20 spaces
            //Different events happen on different spaces
            //Player has 5 Lives to survive until the end
            //Four different events: Loot, Enemy, Stranger, Hazard
            //Create New Gameboard
            GameBoard gameBoard = new GameBoard();
            //Player begins by rolling 6 sided dice
            gameBoard.DiceRoll();


        }
        public class GameBoard
        {
            //Gameboard has 20 spaces
            //Player rolls dice for position on board
            public int playerPos;
            public int random;
            public string item;

            public GameBoard()
            {
                playerPos = 0;
            }
            public void BoardEvents()
            {
                Random random = new Random();
                switch (playerPos)
                {
                    //Loot
                    case 2:
                    case 3:
                    case 7:
                    case 12:
                    case 18:
                        lootItem = random.Next(4);
                        UsableItems item;
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
                        else
                        {
                            item = new Blick();
                        }

                        inventory.Add(item);
                        Console.WriteLine($"{item} was added to your inventory.");

                        break;
                    //Stranger
                    case 4:
                    case 9:
                    case 11:
                    case 17:
                    case 20:


                        break;
                    //Hazard
                    case 1:
                    case 8:
                    case 13:
                    case 14:
                    case 19:

                        break;
                    //Enemy
                    case 5:
                    case 6:
                    case 10:
                    case 15:
                    case 16:

                        break;
                }
            }
            public void DiceRoll()
            {
                Console.WriteLine($"Current Position: {playerPos}");
                Random random = new Random();
                //roll the dice
                int sixDice = random.Next(1, 6);
                playerPos = playerPos + sixDice;
                Console.WriteLine($"You rolled a {sixDice}!");
                Console.WriteLine($"New Position: {playerPos}");
            }
        }
        public abstract class UsableItems
        {
            public int dmgBuff;
            public int healing;
            public int shield;

        }
        public class Sword : UsableItems
        {
            Sword()
            {
                dmgBuff = 10;
            }
        }
        public class Blick : UsableItems
        {
            public Blick()
            {
                dmgBuff = 20;
            }

        }
        public class Armor : UsableItems
        {
            public Armor()
            {
                shield = 50;
            }
        }
        public class Yercs : UsableItems
        {
            public Yercs()
            {
                healing = 20;
            }
        }

        public abstract class Character
        {
            private int health = 100;
            private int damage = 7;
            public string name;
            public Character()
            {

            }
        }
        public abstract class Player : Character
        {
            public List<UsableItems> inventory = new List<UsableItems>();
            public Player()
            {
                name = playerName;

            }
        }

        public abstract class Enemy : Character
        {
            public Enemy()
            {
                name = "Bandit";
            }
        }
    }
}