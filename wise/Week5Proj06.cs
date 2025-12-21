



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
            //ReadyForPost Thread.Sleep(6000);
            Console.WriteLine("");
            Console.WriteLine("Good luck");
            //ReadyForPost Thread.Sleep(2000);


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
        int arcDestroyed = 0;
        int gameController = 1;

        Console.WriteLine("");
        Console.WriteLine("------------------------------------------------");
        string topChoice;


        Console.WriteLine("you have encountered an Arc");

        do
        {
            if (topArc.CallHealthAmount() < 1)
            {
                topArc = new Arc();
                Console.WriteLine($"New arc health is {topArc.CallHealthAmount()}");
            }


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
                //ReadyForPost Thread.Sleep(3000);
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

            }

            if (topChoiceConf == "B")
            {
                Console.WriteLine("");
                Console.WriteLine("----------------------------");
                Console.WriteLine("*SYSTEM MESSAGE*");
                Console.WriteLine("Inventory is still under maintenance");
                Console.WriteLine($"{topRaider.inventory[0]}, {topRaider.inventory[1]}, {topRaider.inventory[2]}, {topRaider.inventory[3]}, {topRaider.inventory[4]}");
                Console.WriteLine("----------------------------");
                Console.WriteLine("");
            }



            if (topRaider.CallHealthAmount() < 1)
            {
                Console.WriteLine("You have failed!");
                gameController = 0;
                GameOver();
            }
            else if (topArc.CallHealthAmount() < 1 && arcDestroyed == 2)
            {
                Console.WriteLine("-----");
                Console.WriteLine("*SYSTEM MESSAGE*");
                Console.WriteLine("The Arc has now been destroyed");
                Console.WriteLine("----------------------------");
                Console.WriteLine("");
                Console.WriteLine("You have won");
                arcDestroyed += 1;
                gameController = 0;
                GameOver();
            }
            else if (topArc.CallHealthAmount() < 1 && arcDestroyed < 2)
            {
                Console.WriteLine("-----");
                Console.WriteLine("*SYSTEM MESSAGE*");
                Console.WriteLine("The Arc has now been destroyed");
                Console.WriteLine("A new one appears");
                Console.WriteLine("----------------------------");
                Console.WriteLine("");
                arcDestroyed += 1;
            }
            else
            {
                //ReadyForPost Thread.Sleep(5000);
                topArc.AttackBase(topRaider);

                Console.WriteLine("----------------------------");
                Console.WriteLine("");
            }

        } while (gameController == 1);





    }

    public void GameOver()
    {
        Console.WriteLine("Its over");
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

    private int health = 20;

    public int damage = 0;

    public int inventorySpace = 0;
    public Items[] inventory = new Items[5] { new Available(), new Available(), new Available(), new Available(), new Available() };
    public int CallHealthAmount()
    {

        return health;
    }

    public abstract int DamageReciever(Character attacker, int attackerDamage);

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
        damage = 8;

        inventory[0] = new Rattler();
    }

    int health = 80;
    int damage = 8;

    // send damage to the victim and annouce the attack
    public int AttackBase(Character target)
    {
        Console.WriteLine("You take a deep breath to steady your aim");
        Console.WriteLine("");
        Console.WriteLine("BANG!");
        Console.WriteLine("----------------------------");
        Console.WriteLine("");

        target.DamageReciever(this, damage);
        Console.WriteLine($"You have successfully shot the {target} for {damage} damage");
        Console.WriteLine("");
        Console.WriteLine("----------------------------");

        return damage;
    }


    // take health away from the raider and annouce the amount left
    public override int DamageReciever(Character attacker, int attackerDamage)
    {

        DamageRecieverAction(attacker, attackerDamage);

        if (health < 1)
        {
            Console.WriteLine("You have failed!");
        }
        Console.WriteLine($"Raider currenlty has {health} health remaining");


        return health;
    }



    private void DamageRecieverAction(Character attacker, int attackerDamage)
    {
        health -= attackerDamage;

        if (health < 1)
        {
            attacker.inventory[1] = new Rattler();
        }
    }

    public int CallHealthAmount()
    {

        return health;
    }

}

// The base enemy
public class Arc : Character
{
    public Arc()
    {
        name = "Arc";
    }

    int health = 20;
    int damage = 3;

    // send damage to the victim and annouce the attack
    public int AttackBase(Character target)
    {
        Console.WriteLine("");
        Console.WriteLine("----------------------------");
        Console.WriteLine("The Arc lines up it's turrent to your body and begins to shoot");
        target.DamageReciever(this, damage);
        Console.WriteLine($"The Arc has successfully shot you for {damage} damage");

        return damage;
    }

    // take health away from the arc and annouce the amount left
    public override int DamageReciever(Character attacker, int attackerDamage)
    {
        DamageRecieverAction(attacker, attackerDamage);

        if (health < 1)
        {
            Console.WriteLine($"Arc currenlty has {health} health remaining");
        }

        return health;
    }

    private void DamageRecieverAction(Character attacker, int attackerDamage)
    {
        health -= attackerDamage;
        if (health < 1)
        {
            attacker.inventory[1] = new Rattler();
        }
    }

    public int CallHealthAmount()
    {

        return health;
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




