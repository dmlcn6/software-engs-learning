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
            AnimeMans goat = new AnimeMans();
            goat.MyHero();

        }

    }
    public abstract class FavHero
    {
        string heroName;
        public abstract void MyHero();
    }
    public class AnimeMans : FavHero
    {

        public override void MyHero()
        {
            string heroName = "Deku";
            Console.WriteLine($"{heroName} is the greatest hero!");
        }
    }
}