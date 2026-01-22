// See https://aka.ms/new-console-template for more information


// [RECENT COMMIT NAME]         git commit UnitBB -m "File Organization 01/15/26(1)"        [RECENT COMMIT NAME]



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
            var to = new Logs();
            var openRaider = new Raider();
            var rInventory = openRaider.inventory;
            to.Log($"Your players health: {openRaider.CallHealthAmount()}");
            to.Log($"Your players damage: {openRaider.CallDamageAmount()}");
            to.Log("What is your name?");
            openRaider.NameAdj(Console.ReadLine());
            to.Log($"Is your name {openRaider.CallName()}?");
            to.Log($"Item 3 is {rInventory[2].CallName()}");

            var startNew = new TestB();
            startNew.TestBB(openRaider);

        }
    }

    public class TestB
    {
        public void TestBB(ICharacters openRaider)
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

                bool? tempRule1 = false;
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
                            tempRule1 = true;
                            to.Log("you have chosen A");
                            // player's attack qoute and send attack message to attacker to collect damage amount then send damage amount to damage reciever on victim to deliever damage (enemy does the same) then show stats
                            openRaider.AttackBase(openArc);
                            openArc.AttackBase(openRaider);

                            break;
                        case "b":
                        case "B":
                            tempRule1 = true;
                            to.Log("you have chosen B");

                            // create and put the raider's inventory into a variable
                            foreach (IItems i in openRaider.inventory)
                            {
                                to.Log($"{i.CallName()}");
                                to.Log("Which item would you like to use?");
                            }


                            //// show player the player their inventory and have the enemy attack the player then show stats
                            openArc.AttackBase(openRaider);
                            break;
                        default:
                            tempRule1 = false;
                            to.Log("Please Either Enter (A) or (B)");
                            break;
                    }
                } while (tempRule1 == false);


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