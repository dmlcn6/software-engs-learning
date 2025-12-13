



//Introduction to the game
using System.Net.Quic;
using System.Security.Cryptography.X509Certificates;

public class ProgramStart
{

    private static void Main()
    {
        Console.WriteLine("Welcome to Arc Raiders");
        Console.WriteLine("");
        Console.WriteLine("In this game you will...");

        var startGame = new Gamelobby();
        startGame.MainMenu();
    }

}



// Check if the player has died or won the game ends + Main game Loop
public class Gamelobby
{
    public void MainMenu()
    {

        var start = new Gamelobby();
        var addRaider = new Raider();
        var addArc = new Arc();
        string? mainChoice;
        do
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------");
            Console.WriteLine("Welcome to Speranza");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("A. Ready Up");
            Console.WriteLine("");
            Console.WriteLine("B. Go to Inventory");
            Console.WriteLine("");
            Console.WriteLine("C. Go to WorkBench");
            Console.WriteLine("------------------------");

            mainChoice = Console.ReadLine();
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^");

            if (mainChoice != "A" && mainChoice != "B" && mainChoice != "C")
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Please Answer with either (A), (B), or (C)");
            }


        } while (mainChoice != "A" && mainChoice != "B" && mainChoice != "C");

        string mainChoiceConf = mainChoice;

        if (mainChoiceConf == "A")
        {
            Console.WriteLine("Now going to topside...");
            Thread.Sleep(6000);
            Console.WriteLine("");
            Console.WriteLine("Good luck");
            Thread.Sleep(2000);


            start.TopSideMenu();
        }
        else if (mainChoiceConf == "B")
        {

            Console.WriteLine("Now going to your inventory");
            start.InventoryMenu();
        }
        else if (mainChoiceConf == "C")
        {
            Console.WriteLine("Now going to your Work Bench");
            start.WorkBenchMenu();
        }
        else
        {
            Console.WriteLine("Something went wrong");
            Console.WriteLine("");
            Console.WriteLine("Lets try this again");

            start.MainMenu();
        }

    }

    public void TopSideMenu()
    {
        var topRaider = new Raider();
        var topArc = new Arc();


        Console.WriteLine("");
        Console.WriteLine("------------------------------------------------");
        string topChoice;


        Console.WriteLine("you have encountered an Arc");

        do
        {

            do
            {
                Console.WriteLine("");
                Console.WriteLine("----------------------------");
                Console.WriteLine("*SYSTEM MESSAGE*");
                Console.WriteLine("How you would like to procede");
                Console.WriteLine("-----");
                Console.WriteLine("");
                Console.WriteLine("----------------------------");
                Console.WriteLine("*USER CHOICE*");
                Console.WriteLine("A. Attack the Arc");
                Console.WriteLine("B. Go to your inventory");
                Console.WriteLine("----------------------------");
                Console.WriteLine("");

                topChoice = Console.ReadLine();
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^");
                Thread.Sleep(3000);
                if (topChoice != "A" && topChoice != "B")
                {
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("*ERROR*");
                    Console.WriteLine("Please Answer with either (A) or (B)");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("");
                }
            } while (topChoice != "A" && topChoice != "B");

            string topChoiceConf = topChoice;
            if (topChoiceConf == "A")
            {
                Console.WriteLine("");
                Console.WriteLine("----------------------------");
                Console.WriteLine("*SYSTEM MESSAGE*");
                topRaider.AttackBase(topArc);
                Console.WriteLine("----------------------------");
                Console.WriteLine("");
                topArc.health -= topRaider.damage;
            }

            if (topChoiceConf == "B")
            {
                Console.WriteLine("");
                Console.WriteLine("----------------------------");
                Console.WriteLine("*SYSTEM MESSAGE*");
                Console.WriteLine("Inventory is still under maintenance");
                Console.WriteLine("----------------------------");
                Console.WriteLine("");
            }




            if (topArc.health < 1)
            {
                Console.WriteLine("-----");
                Console.WriteLine("*SYSTEM MESSAGE*");
                Console.WriteLine("The Arc has now been destroyed");
                Console.WriteLine("----------------------------");
                Console.WriteLine("");
            }
            else
            {
                topRaider.health -= topArc.damage;
                Console.WriteLine("-----");
                Console.WriteLine("*SYSTEM MESSAGE*");
                Console.WriteLine($"The Arc's health is now {topArc.health}");
                Console.WriteLine("----------------------------");
                Console.WriteLine("");
                Thread.Sleep(5000);
                Console.WriteLine("");
                Console.WriteLine("----------------------------");
                Console.WriteLine("The arc lines up it's turrent to your body and begins to shoot");
                Console.WriteLine($"Your health is now {topRaider.health}");
                Console.WriteLine("----------------------------");
                Console.WriteLine("");

            }

        } while (topArc.health > 0);





    }

    public void InventoryMenu()
    {

        var invRaider = new Raider();


        Console.WriteLine("inventory under maintenance...");

        invRaider.inventory[0].Name();


        Console.WriteLine("");
    }

    public void WorkBenchMenu()
    {
        Console.WriteLine("WorkBench under maintenance...");
    }





}




// Ref to all game dialogue
public class GameDialogue
{

}




// Base stats for any character on the game players AND NPC's
public abstract class Character
{
    public string name = "blank";

    public int health = 20;

    public int damage = 0;

    public int inventorySpace = 0;
    public Items[] inventory = new Items[5] { new Available(), new Available(), new Available(), new Available(), new Available() };

}

public abstract class Items
{

    public abstract void Name();

    public string name = "blank";
    public int itemSlot = -1;
    public int damage = 0;
    public int health = 0;

}








//------------------------------------------

// The Main Player
public class Raider : Character
{


    public Raider()
    {

        name = "Raider";
        health = 80;
        damage = 8;

        inventory[0] = new Rattler();
    }


    public void AttackBase(Character target)
    {
        Console.WriteLine("You take a deep breath to steady your aim");
        Console.WriteLine("");
        Console.WriteLine("BANG!");
        Console.WriteLine("----------------------------");
        Console.WriteLine("");

        Console.WriteLine($"You have successfully shot the {target} for {damage} damage");
        Console.WriteLine("");
        Console.WriteLine("----------------------------");

    }

}

// The base enemy
public class Arc : Character
{
    public Arc()
    {
        name = "Arc";
        health = 20;
        damage = 5;
    }
}



public class Rattler : Items
{

    public Rattler()
    {
        name = "Rattler";
        damage = 10;
        health = 0;
    }

    public override void Name()
    {
        Console.WriteLine($"{name}");
    }

}

public class Available : Items
{
    public override void Name()
    {
        Console.WriteLine($"{name}");
    }
}





//inventory[0] = new Rattler();
//inventory.SetValue(old Rattler(), 0);




