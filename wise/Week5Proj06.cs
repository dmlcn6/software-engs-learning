
//- **Sprint 2: 
//- Tue 12/2: we are creating AC for our work item 
//- user must be identified by player name (input) ^
//- at least 5 prompts before one of the endings ^
//- 2 endings: Win or Lose ^
//- show use of constructors, static classes ^
//- 3 Object Oriented Programming principles (inheritance, encapsulation, abstraction) ^
//- player (with or without hp) ^
//- meter, counter, hp, progress tracking, ^
//- combat/competition ^
//- Usable items in inventory^



//Introduction to the game
using System.Net.Quic;
using System.Security.Cryptography.X509Certificates;

public static class ProgramStart
{

    private static void Main()
    {
        Console.WriteLine("Welcome to Arc Raiders");
        Console.WriteLine("");
        Console.WriteLine("In this game you will...");

        var startGame = new Gamelobby();
        var player = new Raider();
        player.GetPlayerName();
        startGame.MainMenu(player);
    }

}



// Check if the player has died or won the game ends + Main game Loop
public class Gamelobby
{
    public void MainMenu(Raider addRaider)
    {

        var start = new Gamelobby();
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


            start.TopSideMenu(addRaider);
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

            start.MainMenu(addRaider);
        }

    }

    public void TopSideMenu(Raider topRaider)
    {

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
                Console.WriteLine($"1. {topRaider.inventory[0]},      2. {topRaider.inventory[1]},      3. {topRaider.inventory[2]},      4. {topRaider.inventory[3]},      5. {topRaider.inventory[4]}");
                Console.WriteLine("----------------------------");
                Console.WriteLine("");
                string tempChoice = Console.ReadLine();

                // Give the player a buff or nurf depending on the item they choose.
                if (tempChoice == "1")
                {

                    int giveChange = topRaider.inventory[0].damage;
                    topRaider.DamageBuff(giveChange);
                }
                else if (tempChoice == "2")
                {
                    int giveChange = topRaider.inventory[1].damage;
                    topRaider.DamageBuff(giveChange);
                }
                else if (tempChoice == "3")
                {
                    int giveChange = topRaider.inventory[2].damage;
                    topRaider.DamageBuff(giveChange);
                }
                else if (tempChoice == "4")
                {
                    int giveChange = topRaider.inventory[3].damage;
                    topRaider.DamageBuff(giveChange);
                }
                else if (tempChoice == "5")
                {
                    int giveChange = topRaider.inventory[4].damage;
                    topRaider.DamageBuff(giveChange);
                }

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

    private int health = 0;

    public int damage = 0;

    public int inventorySpace = 0;
    public Items[] inventory = new Items[5] { new Available(), new Available(), new Available(), new Available(), new Available() };
    public int HealthInital(int startAmount)
    {
        health = startAmount;

        return health;
    }
    public int HealthChange(int changeAmount)
    {
        health -= changeAmount;

        return health;
    }
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

        name = "blank";
        damage = 8;
        HealthInital(80);


        inventory[0] = new Rattler();
    }


    // Get the player's name
    public string GetPlayerName()
    {
        Console.WriteLine("What is your name?");
        name = Console.ReadLine();
        Console.WriteLine($"your player name is {name}");

        return name;
    }


    // send damage to the victim and annouce the attack
    public int AttackBase(Character target)
    {
        Console.WriteLine($" {name} takes a deep breath to steady their aim");
        Console.WriteLine("");
        Console.WriteLine("BANG!");
        Console.WriteLine("----------------------------");
        Console.WriteLine("");

        target.DamageReciever(this, damage);
        Console.WriteLine($"{name} has successfully shot the {target} for {damage} damage");
        Console.WriteLine("");
        Console.WriteLine("----------------------------");

        return damage;
    }


    // take health away from the raider and annouce the amount left
    public override int DamageReciever(Character attacker, int attackerDamage)
    {

        DamageRecieverAction(attacker, attackerDamage);


        return 1001;
    }



    private void DamageRecieverAction(Character attacker, int attackerDamage)
    {
        HealthChange(attackerDamage);

        if (CallHealthAmount() < 1)
        {
            Console.WriteLine("You have failed!");
        }
        Console.WriteLine($"{name} currenlty has {CallHealthAmount()} health remaining");
    }

    public int DamageBuff(int buffAmount)
    {
        damage += buffAmount;
        return damage;
    }


}

// The base enemy
public class Arc : Character
{
    public Arc()
    {
        name = "Arc";
        damage = 3;
        HealthInital(20);
    }


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

        if (CallHealthAmount() > 1)
        {
            Console.WriteLine($"Arc currenlty has {CallHealthAmount()} health remaining");
        }

        return 1001;
    }

    private void DamageRecieverAction(Character attacker, int attackerDamage)
    {
        HealthChange(attackerDamage);
        if (CallHealthAmount() < 1)
        {
            attacker.inventory[1] = new Rattler();
        }
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




