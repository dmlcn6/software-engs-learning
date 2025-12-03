//- **Sprint 2: 
//- Tue 12/2: we are creating AC for our work item
//- user must be identified by player name (input)
//- at least 5 prompts before one of the endings
//- 2 endings: Win or Lose//
//- show use of constructors, static classes
//- 4 Object Oriented Programming principles (inheritance, encapsulation, poly, abstraction) 
//- player (with or without hp)
//- meter, counter, hp, progress tracking, 
//- combat/competition
//- Usable items in inventory








public class GameBase
{



    private static void Main()
    {
        Console.WriteLine("We Have Begun");
        var newIns = new GameBase();
        string newUser = newIns.GetUsername();
    }

    public string GetUsername()
    {
        
        Console.WriteLine("Enter Your Name");
        
        string? username;
        do
        {
            username = Console.ReadLine();
        } while (username == "");


        Console.WriteLine($"{username}. This U?");
        return "Something went wrong";
    }



}