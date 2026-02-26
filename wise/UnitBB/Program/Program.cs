// See https://aka.ms/new-console-template for more information


// [RECENT COMMIT NAME]         git commit UnitBB -m "Began trying to build out the base Menu. Currently attempting to add a feature that allows the player to move items between inventory REMEMBER TO CHECK IF EITHER INVENTORIES ARE FULL BEFORE RUNNING THE TASK"        [RECENT COMMIT NAME]

// 1/29/26 - Big loop that leads back to sparanza

// TO-DO
// - Create an inventory that does not live on the player and can be accessed in the menu
// - When a player uses an item in the inventory. The items resort to fill the earlier slots if they are available
// - Give the player an option to get out of inventory without interacting with an item
// - When a player selects an item in their inventory it gives them a description and the effects before they confirm to interact
// - Give the player the option to unequip an item




using UnitBB.Characters;
using UnitBB.Logger;
using UnitBB.Interfaces;
using UnitBB.Terrain;
using System.IO.Compression;
using System.Formats.Asn1;

// object[,] array2DInitialization = { openRaider, Null },
//                                   { openRaider, Null },
//                                   { openRaider, Null };
namespace UnitBB
{


    class Start
    {
        static void Main()
        {
            Logs to = new();
            var openRaider = new Raider();
            to.Log($"Program.Start.Main has begun", "C:/Users/Tyree/SWE01/Proj1/software-engs-learning/wise/UnitBB/Inbox/Announcements.txt");
            var startNew = new Sparanza();

            // Start off information
            openRaider.NameAdj();

            // Load the game
            startNew.MainMenu(openRaider);
        }
    }


    public class Sparanza
    {
        Logs to = new();
        public void MainMenu(CharactersBase openRaider)
        {
            // Pre-exsisting Objects
            var rInventory = openRaider.inventory;

            // While the player is alive
            do
            {
                // Inform the player of their stats
                to.Log($"Your players health: {openRaider.CallHealthAmount()}");
                to.Log($"Your players damage: {openRaider.CallDamageAmount()}");
                to.Log($"Your players kill count: {openRaider.CallKillCount()}");

                // What do we do next?
                to.Log($"What would you like to do {openRaider.CallName()}?");
                to.Log("(A) Ready Up (B) Go to Inventory (C) Go to WorkBench");
                switch (Console.ReadLine())
                {
                    case "A":
                    case "a":
                        var goTopside = new Topside();
                        goTopside.TopsideAA(openRaider);
                        break;
                    case "B":
                    case "b":
                        to.Log("Not yet available");
                        break;
                    case "C":
                    case "c":
                        to.Log("Not yet available");
                        break;
                    default:
                        to.Log("Something went wrong");
                        break;
                }
            } while (openRaider.IsAlive() == true);

        }
    }

    public class Topside
    {
        Logs to = new();


        public void TopsideAA(CharactersBase openRaider)
        {
            //topLevel
            to.Log($"Welcome to Topside {openRaider.CallName()}");
            to.Log("");
            bool exitTicket = false;
            var openArc1 = new Arc();
            var openArc2 = new Arc();
            var openArc3 = new Arc();
            var tGrass = new Grass();

            IBoardPiece[,] WholeMap = new IBoardPiece[3, 3];
            WholeMap[0, 0] = openArc1;
            WholeMap[0, 1] = openArc2;
            WholeMap[0, 2] = openArc3;
            WholeMap[1, 0] = tGrass;
            WholeMap[1, 1] = tGrass;
            WholeMap[1, 2] = tGrass;
            WholeMap[2, 0] = tGrass;
            WholeMap[2, 1] = tGrass;
            WholeMap[2, 2] = tGrass;

            WholeMap[openRaider.position.Item1, openRaider.position.Item2] = openRaider; //(object, object, object, object, object, object, object, object, object) bSlot = ((IBoardPiece)WholeMap[0, 0], (IBoardPiece)WholeMap[0, 1], (IBoardPiece)WholeMap[0, 2], (IBoardPiece)WholeMap[1, 0], (IBoardPiece)WholeMap[1, 1], (IBoardPiece)WholeMap[1, 2], (IBoardPiece)WholeMap[2, 0], (IBoardPiece)WholeMap[2, 1], (IBoardPiece)WholeMap[2, 2]);

            do
            {
                to.Log($"{WholeMap[0, 0].CallName()},{WholeMap[0, 1].CallName()},{WholeMap[0, 2].CallName()}.");
                to.Log($"{WholeMap[1, 0].CallName()},{WholeMap[1, 1].CallName()},{WholeMap[1, 2].CallName()}.");
                to.Log($"{WholeMap[2, 0].CallName()},{WholeMap[2, 1].CallName()},{WholeMap[2, 2].CallName()}.");

                to.Log("Please Chose a direction to walk in Using W,A,S,D");

                var directionChoice = Console.ReadKey();                 //var directionChoice = Console.ReadKey();
                //var itemChoice0 = int.TryParse(Console.ReadLine(), out int itemChoice1);
                to.Log("");

                to.Log($">>{directionChoice.Key}<<");                                   //to.Log($">>{directionChoice.Key}<<");
                switch (directionChoice.Key)                                   //switch (directionChoice.Key)
                {
                    case ConsoleKey.W:                                         //case ConsoleKey.W:
                        WholeMap[openRaider.position.Item1, openRaider.position.Item2] = tGrass;
                        if (openRaider.position.Item1 - 1 < 0)
                        {
                            to.Log("You have reached the edge of the map and can no longer continue in this direction");
                        }
                        else if (WholeMap[openRaider.position.Item1 - 1, openRaider.position.Item2] == openArc1 || WholeMap[openRaider.position.Item1 - 1, openRaider.position.Item2] == openArc2 || WholeMap[openRaider.position.Item1 - 1, openRaider.position.Item2] == openArc3)
                        {
                            openRaider.AdjEnemyEncountered(true);
                            openRaider.position.Item1--;
                        }
                        else
                        {
                            openRaider.position.Item1--;
                        }
                        WholeMap[openRaider.position.Item1, openRaider.position.Item2] = openRaider;
                        break;
                    case ConsoleKey.S:                                         //case ConsoleKey.S:
                        WholeMap[openRaider.position.Item1, openRaider.position.Item2] = tGrass;
                        if (openRaider.position.Item1 + 1 > 3)
                        {
                            to.Log("You have reached the edge of the map and can no longer continue in this direction");
                        }
                        else if (WholeMap[openRaider.position.Item1 + 1, openRaider.position.Item2] == openArc1 || WholeMap[openRaider.position.Item1 + 1, openRaider.position.Item2] == openArc2 || WholeMap[openRaider.position.Item1 + 1, openRaider.position.Item2] == openArc3)
                        {
                            openRaider.AdjEnemyEncountered(true);
                            openRaider.position.Item1++;
                        }
                        else
                        {
                            openRaider.position.Item1++;
                        }
                        WholeMap[openRaider.position.Item1, openRaider.position.Item2] = openRaider;
                        break;
                    case ConsoleKey.A:                                         //case ConsoleKey.A:
                        WholeMap[openRaider.position.Item1, openRaider.position.Item2] = tGrass;
                        if (openRaider.position.Item2 - 1 < 0)
                        {
                            to.Log("You have reached the edge of the map and can no longer continue in this direction");
                        }
                        else if (WholeMap[openRaider.position.Item1, openRaider.position.Item2 - 1] == openArc1 || WholeMap[openRaider.position.Item1, openRaider.position.Item2 - 1] == openArc2 || WholeMap[openRaider.position.Item1, openRaider.position.Item2 - 1] == openArc3)
                        {
                            openRaider.AdjEnemyEncountered(true);
                            openRaider.position.Item2--;
                        }
                        else
                        {
                            openRaider.position.Item2--;
                        }
                        WholeMap[openRaider.position.Item1, openRaider.position.Item2] = openRaider;
                        break;
                    case ConsoleKey.D:                                         //case ConsoleKey.D:
                        WholeMap[openRaider.position.Item1, openRaider.position.Item2] = tGrass;
                        if (openRaider.position.Item2 + 1 > 3)
                        {
                            to.Log("You have reached the edge of the map and can no longer continue in this direction");
                        }
                        if (WholeMap[openRaider.position.Item1, openRaider.position.Item2 + 1] == openArc1 || WholeMap[openRaider.position.Item1, openRaider.position.Item2 + 1] == openArc1 || WholeMap[openRaider.position.Item1, openRaider.position.Item2 + 1] == openArc1)
                        {
                            openRaider.AdjEnemyEncountered(true);
                            openRaider.position.Item2++;
                        }
                        else
                        {
                            openRaider.position.Item2++;
                        }
                        WholeMap[openRaider.position.Item1, openRaider.position.Item2] = openRaider;
                        break;
                    default:
                        to.Log("Not cases met");
                        break;
                }

                while (openRaider.CallEnemyEncountered() == true && openRaider.IsAlive() == true) //(openRaider.IsAlive() == true && openRaider.CallKillCount() < 3);
                {

                    bool? isNew = false;
                    if (openArc1.CallHealthAmount() <= 0)
                    {
                        openArc1 = new Arc();
                        isNew = true;
                    }

                    bool? escape1 = false;

                    do
                    {

                        if (isNew == true)
                        {
                            to.Log("an enemy has appeared");
                            to.Log("--stats--");
                            to.Log($"Your stats HP:{openRaider.CallHealthAmount()} DMG:{openRaider.CallDamageAmount()}");
                            to.Log($"The Arc's stats HP:{openArc1.CallHealthAmount()} DMG:{openArc1.CallDamageAmount()}");
                            to.Log("----*----");
                            to.Log("");
                        }

                        // Give the player an option to attack or go to their inventory
                        to.Log("What would you like to do?");
                        to.Log("(A): Attack the enemy");
                        to.Log("(B): Go to your inventory");

                        switch (Console.ReadLine())
                        {
                            case "a":
                            case "A":
                                // Show the player selection feedback and attack the enemy
                                escape1 = true;
                                to.Log("you have chosen A");
                                // player's attack qoute and send attack message to attacker to collect damage amount then send damage amount to damage reciever on victim to deliever damage
                                openRaider.AttackBase(openArc1);

                                break;
                            case "b":
                            case "B":
                                // Show the player selection feedback and go to player inventory
                                escape1 = true;
                                var plyrInv = openRaider.inventory;
                                to.Log("you have chosen B");

                                // Show the player their inventory
                                for (int i = 0; i < plyrInv.Count; i++)
                                {
                                    to.Log($"({i + 1}){plyrInv[i].CallName()}");
                                }

                                // Give the player the option to choose an item
                                bool escape2 = false;
                                do
                                {
                                    to.Log("Which item would you like to use?");

                                    var itemChoice0 = int.TryParse(Console.ReadLine(), out int itemChoice1);

                                    // Check to see if the item is valid, give the player a selection feedback, then confirm if the choice is correct
                                    if (itemChoice1 <= plyrInv.Count && itemChoice1 >= 1)
                                    {
                                        itemChoice1 -= 1;
                                        to.Log($"Are you sure you want to use {plyrInv[itemChoice1].CallName()}");
                                        to.Log("(A) Yes (B) No");

                                        switch (Console.ReadLine())
                                        {
                                            case "a":
                                            case "A":
                                                // Obtain the chosen item
                                                var itemChoice1A = plyrInv[itemChoice1];
                                                openRaider.ObtainIt(itemChoice1A, "+");

                                                escape2 = true;

                                                break;

                                            case "b":
                                            case "B":
                                                // Give the player another chance to choose their desired item
                                                to.Log("Please choose the Item you want to use");
                                                for (int i = 0; i < plyrInv.Count; i++)
                                                {
                                                    to.Log($"({i + 1}){plyrInv[i].CallName()}");
                                                }
                                                escape2 = false;

                                                break;

                                            default:
                                                to.Log("Something went wrong in the Inventory");
                                                break;
                                        }

                                    }



                                } while (escape2 == false);
                                break;

                            default:
                                // Alert the player that they've put in an invalid response
                                escape1 = false;
                                isNew = true;
                                to.Log("Please Either Enter (A) or (B)");
                                break;
                        }
                    } while (escape1 == false);

                    if (openArc1.IsAlive())
                    {
                        openArc1.AttackBase(openRaider);

                        to.Log("--stats--");
                        to.Log($"Your stats HP:{openRaider.CallHealthAmount()} DMG:{openRaider.CallDamageAmount()}");
                        to.Log($"The Arc's stats HP:{openArc1.CallHealthAmount()} DMG:{openArc1.CallDamageAmount()}");
                        to.Log("----*----");
                    }
                    else if (!openArc1.IsAlive() && openRaider.IsAlive() && openRaider.CallKillCount() == 3) // If the player destroys the enemy AND NOW has 3 total kills in sparanza they get to choose to go home or stay topside
                    {
                        openRaider.AdjEnemyEncountered(false);
                        to.Log("You Have Successfully Completed Your Mission!");
                        to.Log("Would you like to stay topside or go back to Sparanza?");
                        to.Log("(A): Stay topside");
                        to.Log("(B): Go to Sparanza");
                        switch (Console.ReadLine())
                        {
                            case "A":
                            case "a":
                                to.Log("Staying Topside");
                                openRaider.killCountNowRes();
                                TopsideAA(openRaider);
                                break;
                            case "B":
                            case "b":
                                to.Log("Going to Sparanza Now.");
                                openRaider.killCountNowRes();
                                var startNext = new Sparanza();
                                startNext.MainMenu(openRaider);
                                break;
                            default:
                                to.Log("Something went wrong when choosing menu action");
                                break;
                        }
                    }
                    else if (!openArc1.IsAlive() && openRaider.IsAlive() && openRaider.CallKillCount() < 3) // If the player destroys the enemy AND NOW has LESS than 3 kills they go back to the map
                    {
                        openRaider.AdjEnemyEncountered(false);
                        to.Log("You have destoryed the Arc");
                    }
                    else if (!openRaider.IsAlive()) // If the player dies they go back to the menu without any loot
                    {
                        openRaider.AdjEnemyEncountered(false);
                        to.Log("You Have Died");
                        return;
                    }
                    else // If something goes wrong
                    {
                        to.Log("Something went wrong when trying to detect if the player or the arc came out of combat alive");
                    }
                }

            } while (exitTicket == false);




        }
    }

}






// [RECENT COMMIT NAME]         git commit UnitBB -m "File Organization 01/15/26(1)"        [RECENT COMMIT NAME]