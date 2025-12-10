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
namespace Game
{
    public class CozyGame
    {
         public static string PlayerName;
         public static string Choice;
        public static void Main()
    {    
        CozyGame.Intro();
        CozyGame.Begin();
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
        PlayerName = Console.ReadLine();
        Console.WriteLine($"So your name is {PlayerName}? That's cute lol");
        Thread.Sleep(1000);
        Console.WriteLine($"Today you'll embark on an adventure, {PlayerName}, to decide your fate!");
        Thread.Sleep(1000);
        Console.WriteLine("Every decision you make will determine the outcome of your story.");
        Thread.Sleep(1000);
        Console.WriteLine("Do you think you have what it takes to make it to the end?");
        Console.WriteLine("Please type Yes or No");
        Choice = Console.ReadLine();
    }
    // Have player decide if they want to play or not
    public static void Begin()
    {
        if (Choice == "Yes")
        {
            Console.WriteLine("I thought you looked brave. Let's get started :)");
            CozyGame.Gameplay();
        }    
        else if (Choice == "No")
        {
            Console.WriteLine("That's disappointing.");
            Thread.Sleep(1000);
            Console.WriteLine("Welp, Goodbye...");
        }
        else
        {
            Console.WriteLine("Please type Yes or No");
            Choice = Console.ReadLine();
            CozyGame.Begin();
        }
    }
    // Start the game. Player begins the adventure.
    public static void Gameplay()
    {
        
    } 
}
    public abstract class Player
    {
    
        public Player()
        {
            
        }
    }






}
