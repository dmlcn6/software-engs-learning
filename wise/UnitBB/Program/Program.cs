// See https://aka.ms/new-console-template for more information


// Left Off Notes: I cannot call the Items folder inside of the ICharacter's file which will be neccsary in order to create a characters's inventory before beginning the game.


using UnitBB.Characters;
using UnitBB.Items;


namespace UnitBB
{


    class Start
    {
        static void Main()
        {
            Console.WriteLine("Program.Start.Main has begun");
            var startNew = new TestA();
            startNew.TestAA();
        }
    }


    public class TestA
    {
        public void TestAA()
        {
            var openRaider = new Raider();
            var rInventory = openRaider.inventory;
            Console.WriteLine($"Your players health: {openRaider.CallHealthAmount()}");
            Console.WriteLine($"Your players damage: {openRaider.CallDamageAmount()}");
            Console.WriteLine("What is your name?");
            openRaider.NameAdj(Console.ReadLine());
            Console.WriteLine($"Is your name {openRaider.CallName()}?");
            Console.WriteLine($"Item 3 is {rInventory[2].CallName()}");

            var startNew = new TestB();
            startNew.TestBB(openRaider);

        }
    }

    public class TestB
    {
        public void TestBB(ICharacters openRaider)
        {
            //topLevel

            Console.WriteLine("Welcome to Topside");
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

                    Console.WriteLine("an enemy has appeared");
                    Console.WriteLine("--stats--");
                    Console.WriteLine($"Your stats HP:{openRaider.CallHealthAmount()} DMG:{openRaider.CallDamageAmount()}");
                    Console.WriteLine($"The Arc's stats HP:{openArc.CallHealthAmount()} DMG:{openArc.CallDamageAmount()}");
                    Console.WriteLine("----*----");
                    Console.WriteLine("");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("(A): Attack the enemy");
                    Console.WriteLine("(B): Go to your inventory");

                    switch (Console.ReadLine())
                    {
                        case "a":
                        case "A":
                            tempRule1 = true;
                            Console.WriteLine("you have chosen A");
                            // player's attack qoute and send attack message to attacker to collect damage amount then send damage amount to damage reciever on victim to deliever damage (enemy does the same) then show stats
                            openRaider.AttackBase(openArc);
                            openArc.AttackBase(openRaider);

                            break;
                        case "b":
                        case "B":
                            tempRule1 = true;
                            Console.WriteLine("you have chosen B");

                            // create and put the raider's inventory into a variable
                            foreach (IItems i in openRaider.inventory)
                            {
                                Console.WriteLine($"{i.CallName()}");
                            }

                            //// show player the player their inventory and have the enemy attack the player then show stats
                            openArc.AttackBase(openRaider);
                            break;
                        default:
                            tempRule1 = false;
                            Console.WriteLine("Please Either enter (A) or (B)");
                            break;
                    }
                } while (tempRule1 == false);


                Console.WriteLine("--stats--");
                Console.WriteLine($"Your stats HP:{openRaider.CallHealthAmount()} DMG:{openRaider.CallDamageAmount()}");
                Console.WriteLine($"The Arc's stats HP:{openArc.CallHealthAmount()} DMG:{openArc.CallDamageAmount()}");
                Console.WriteLine("----*----");





            } while (openRaider.IsAlive() == true && openRaider.CallKillCount() < 3);


            if (openRaider.CallKillCount() == 3)
            {
                Console.WriteLine("You have WON!");
                return;
            }
            else
            {
                Console.WriteLine("You have Failed");
                return;
            }

        }
    }
}






// [RECENT COMMIT NAME]         git commit UnitBB -m "File Organization 01/07/26(2)"        [RECENT COMMIT NAME]