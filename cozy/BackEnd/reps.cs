using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace RepsUp
{
    //Declare a new variable type of each type with a value
    //    - string, int, decimal, char, array, list
    class Experi
    {
        string myString = "Spider-man";
        int myInts = 5;
        decimal myDeci = 4.2M;
        char myChar = 'H';
    }

    //declare a new class of each type
    //    - abstract, public, private, static

    //public class
    public class FirstClasse
    {

    }

    //type is automatically private unless its explicitly set public
    //abstract class
    abstract class NonChal
    {

    }
    //public static class
    public static class StaticShock
    {

    }
    //private class. all classes are implicitly private. 
    class Speakeasy
    {

    }


    //Encapsulation
    //     - show 1 class that encapsulates the modification of a private class varirable through the use of a function

    public class MethodMan
    {
        private int speed = 750;

        public void SpeedTest()
        {
            Console.WriteLine($"Your Speed is {speed}");
        }

    }


    // Inheritance:
    // - show 2 classes; one parent and one child;
    // - show how a child can inherit a class member from its parent
    // - show how a parent can have a class members that its child doesnt inherit
    // - show how a child can have a class member that its parents dont know about

    //parent class
    public class AirBus
    {
        public string name = "PGC Jet";
        private int capacity = 80;
    }

    //child class
    public class FirstClass : AirBus
    {
        private bool smoking = true;
    }

    // an abstract class that has 1 fully defined class variables
    // and a function that is abstract
    // a derived class that inherits from abstract and fully defines the class
    // it has to work
    public class RealOutput
    {
        public static void Main()
        {
            //AnimeMans goat = new AnimeMans();
            //goat.MyHero();
            MoreLoops loops = new MoreLoops();
            loops.FirstLoop();
            Console.WriteLine("-----------------------------");
            loops.SecondLoop();
            Console.WriteLine("-----------------------------");
            loops.ThirdLoop();


        }

    }
    public abstract class FavHero
    {
        string heroName;
        public bool retired = true;
        public bool alive;
        public abstract void MyHero();
        public int injuries;
    }
    // REPS 4 CONDITIONALS
    public class AnimeMans : FavHero
    {
        public override void MyHero()
        {
            string heroName = "Deku";
            // while loop conditional based on a class's bool field
            while (retired)
            {
                Console.WriteLine($"{heroName} is the greatest hero!");
                retired = false;
            }
            // do while that checks a class's bool field and stop on false
            do
            {
                //POP YO SHI TWIN
            } while (alive);
            // if statement with arithmetic conditional statement
            if ((2026 - 1994) > 40)
            {
                //it might be time to face it!
            }
            else
            {
                //this could be the day that we push through!
            }
            // if else statement with 2 arithmetic conditional statements
            if ((617 + 718) < 2000)
            {
                //do tha math idk
            }
            else if ((101 + 103) > 200)
            {
                //ykwtfgo
            }
            else
            {
                //*does my lil dancey dance*
            }
            // switch based on user input for 4 choices and print something unique for each choice
            switch (injuries)
            {
                case 1:
                case 2:
                    // we gucci bruh
                    break;
                case 3:
                    // aite whats goin on...
                    break;
                case 4:
                    // thinks its time to do something else
                    break;
            }
        }
    }
    public class MoreLoops
    {
        // iterate thru lists
        // loop thru list elements
        // for every element in list, increment + 1
        // console log the result     
        List<int> myList = [1, 2, 3, 4];
        // while loop
        public void FirstLoop()
        {
            int numbers = 0;
            while (numbers < myList.Count)
            {
                myList[numbers] += 1;
                Console.WriteLine(myList[numbers]);
                numbers++;
            }
        }
        // for loop
        public void SecondLoop()
        {
            for (var index = 0; index < myList.Count; index++)
            {
                myList[index] += 1;
                Console.WriteLine(myList[index]);
            }
        }
        // for each loop
        public void ThirdLoop()
        {
            foreach (var number in myList)
            {
                int nums = number;
                nums += 1;
                Console.WriteLine(nums);
            }
        }
    }
}
