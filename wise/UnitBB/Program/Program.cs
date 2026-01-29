// See https://aka.ms/new-console-template for more information


// [RECENT COMMIT NAME]         git commit UnitBB -m "Adding The Logger 01/21/26(1)"        [RECENT COMMIT NAME]



using System.Runtime.CompilerServices;
using UnitBB.Characters;
using UnitBB.Items;
using UnitBB.Logger;


namespace UnitBB
{


    class Start
    {


        static void Main()
        {
            var to = new Logs();
            to.Log($"Program.Start.Main has begun", "../Inbox/Announcements.txt");
            var startNew = new TestA();
            startNew.TestAA();
        }
    }


    public class TestA
    {
        public void TestAA()
        {
            // Pre-exsisting Objects
            var to = new Logs();
            var openRaider = new Raider();
            var rInventory = openRaider.inventory;

            // Start off information
            to.Log("What is your name?");
            openRaider.NameAdj(Console.ReadLine());
            to.Log($"Is your name {openRaider.CallName()}?");
            to.Log($"Item 3 is {rInventory[2].CallName()}");

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



                // Topside Begins!
                var startNew = new TestB();
                startNew.TestBB(openRaider);

            } while (openRaider.IsAlive() == true);

        }
    }

    public class TestB
    {
        public void TestBB(CharactersBase openRaider)
        {
            //topLevel
            var to = new Logs();
            to.Log("Welcome to Topside");
            var openArc = new Arc();

            do
            {

                if (openArc.CallHealthAmount() <= 0)
                {
                    openArc = new Arc();
                }

                bool? escape1 = false;
                do
                {

                    to.Log("an enemy has appeared");
                    to.Log("--stats--");
                    to.Log($"Your stats HP:{openRaider.CallHealthAmount()} DMG:{openRaider.CallDamageAmount()}");
                    to.Log($"The Arc's stats HP:{openArc.CallHealthAmount()} DMG:{openArc.CallDamageAmount()}");
                    to.Log("----*----");
                    to.Log("");
                    to.Log("What would you like to do?");
                    to.Log("(A): Attack the enemy");
                    to.Log("(B): Go to your inventory");

                    switch (Console.ReadLine())
                    {
                        case "a":
                        case "A":
                            escape1 = true;
                            to.Log("you have chosen A");
                            // player's attack qoute and send attack message to attacker to collect damage amount then send damage amount to damage reciever on victim to deliever damage (enemy does the same) then show stats
                            openRaider.AttackBase(openArc);
                            openArc.AttackBase(openRaider);

                            break;
                        case "b":
                        case "B":
                            escape1 = true;
                            to.Log("you have chosen B");

                            // create and put the raider's inventory into a variable
                            int tempTracker = 1;
                            foreach (ItemsBase i in openRaider.inventory)
                            {
                                to.Log($"({tempTracker}){i.CallName()}");
                                tempTracker++;
                            }

                            bool escape2 = false;
                            do
                            {
                                var plyrInv = openRaider.inventory;
                                to.Log("Which item would you like to use?");

                                var itemChoice0 = int.TryParse(Console.ReadLine(), out int itemChoice1);

                                if (itemChoice1 <= plyrInv.Count && itemChoice1 >= 1)
                                {
                                    itemChoice1 -= 1;
                                    to.Log($"Are you sure you want to use {plyrInv[itemChoice1].CallName()}");
                                    to.Log("(A) Yes (B) No");

                                    switch (Console.ReadLine())
                                    {
                                        case "a":
                                        case "A":
                                            var itemChoice3 = plyrInv[itemChoice1];
                                            var results = plyrInv[itemChoice1].Interact();
                                            openRaider.HDAdj(results.Item1, results.Item2, "+");
                                            //to.Log($"Your stats HP:{openRaider.CallHealthAmount()} DMG:{openRaider.CallDamageAmount()}");

                                            escape2 = true;
                                            break;

                                        case "b":
                                        case "B":
                                            to.Log("Please choose the Item you want to use");
                                            foreach (ItemsBase i in openRaider.inventory)
                                            {
                                                to.Log($"{i.CallName()}");
                                            }
                                            escape2 = false;

                                            break;

                                        default:
                                            to.Log("Something went wrong");
                                            break;
                                    }

                                }

                                //int itemChoice = Console.ReadLine();


                            } while (escape2 == false);



                            //// show player the player their inventory and have the enemy attack the player then show stats
                            openArc.AttackBase(openRaider);
                            break;
                        default:
                            escape1 = false;
                            to.Log("Please Either Enter (A) or (B)");
                            break;
                    }
                } while (escape1 == false);


                to.Log("--stats--");
                to.Log($"Your stats HP:{openRaider.CallHealthAmount()} DMG:{openRaider.CallDamageAmount()}");
                to.Log($"The Arc's stats HP:{openArc.CallHealthAmount()} DMG:{openArc.CallDamageAmount()}");
                to.Log("----*----");





            } while (openRaider.IsAlive() == true && openRaider.CallKillCount() < 3);


            if (openRaider.CallKillCount() == 3)
            {
                to.Log("You have WON!");
                return;
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