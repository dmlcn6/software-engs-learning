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
        // Instructs user to enter their name.
        Console.WriteLine("Enter Your Name");

        // In case the user does not enter a value.
        string? username;
        do
        {
            // Get the user's name and put it into a variable.
            username = Console.ReadLine();

        // Make the user repeat if they do not enter a value. 
        } while (username == "");


        // Restate the user's name.
        Console.WriteLine($"{username}. This U?");
        
        // Instruct the user of their options.
        Console.WriteLine("1. YES");
        Console.WriteLine("2. NO");

       string? result;
       result = PlayerDialogue.CloseEnded();

        if (result == "2")
        {
            // Give the user feedback that they will get another chance to enter a name.
            Console.WriteLine("Learn to type pal. Try again");
        }
        else
        {
            // Give the user feedback that they have succesfully entered a name.
            Console.WriteLine("It's okay... I have a terrible name too. Move forward");
        }

        //Console.WriteLine($"{new GameEnvi().stage1_1}");
        Console.WriteLine($"{new Stage1().message1}");


        return "Something went wrong";
    }



}





public class GameEnvi
{
    

    
    public string stage1_1 = "would you like to choose to be a warrior or a mage";
    public string stage1_2 = "";
    public string stage1_3 = "";
    public string stage1_4 = "";
    public string stage1_5 = "";
    //Thread.Sleep(10000);
    //do {} while (closeEnded != "NO" || closeEnded != "YES");
    //do {} while (closeEnded != "NO" && closeEnded != "YES");
}




//public class NewIns
//{
    
//}

//public class PlayerInfo
//{
    
//}

//public class Item
//{
    
//}

public class Stage1
{
    public string message1 = "would you like to choose to be a warrior or a mage";
    //public string message2 = "";
    //public string message3 = "";
    //public string message4 = "";
    //public string message5 = "";


}

public class PlayerDialogue
{
    public static string CloseEnded()
    {
        string? input;
        do
        {
        input = Console.ReadLine();
        } while (input != "1" && input != "2");

        return input;
    }

}