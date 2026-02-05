// See https://aka.ms/new-console-template for more information


// [RECENT COMMIT NAME]         git commit UnitBB -m "Starting Path 2! 01/31/26(4)"        [RECENT COMMIT NAME]

// 1/29/26 - Big loop that leads back to sparanza




using UnitBB.Characters;
using UnitBB.Logger;


namespace UnitBB
{


    class Start
    {
        static void Main()
        {
            Logs to = new();
            var openRaider = new Raider();
            to.Log($"Program.Start.Main has begun", "../Inbox/Announcements.txt");
            var startNew = new TestA();
            startNew.TestAA(openRaider);
        }
    }


    public class TestA
    {
        Logs to = new();
        public void TestAA(CharactersBase openRaider)
        {
            // Pre-exsisting Objects
            var rInventory = openRaider.inventory;

            // Start off information
            openRaider.NameAdj();

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
            to.Log("Welcome to Topside");
            to.Log("an enemy has appeared");
            var openArc = new Arc();

            do
            {

                bool? isNew = false;
                if (openArc.CallHealthAmount() <= 0)
                {
                    openArc = new Arc();
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
                        to.Log($"The Arc's stats HP:{openArc.CallHealthAmount()} DMG:{openArc.CallDamageAmount()}");
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
                            openRaider.AttackBase(openArc);

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
                                            to.Log("Something went wrong");
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

                if (openArc.IsAlive() == true)
                {
                    openArc.AttackBase(openRaider);

                    to.Log("--stats--");
                    to.Log($"Your stats HP:{openRaider.CallHealthAmount()} DMG:{openRaider.CallDamageAmount()}");
                    to.Log($"The Arc's stats HP:{openArc.CallHealthAmount()} DMG:{openArc.CallDamageAmount()}");
                    to.Log("----*----");
                }





            } while (openRaider.IsAlive() == true && openRaider.CallKillCount() < 3);


            if (openRaider.CallKillCount() == 3)
            {
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
                        var startNext = new TestA();
                        startNext.TestAA(openRaider);
                        break;
                    default:
                        to.Log("Something went wrong");
                        break;
                }
            }

            else
            {
                to.Log("You have Failed");
                return;
            }

        }
    }

}






// [RECENT COMMIT NAME]         git commit UnitBB -m "File Organization 01/15/26(1)"        [RECENT COMMIT NAME]