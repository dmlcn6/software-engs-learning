//Declare a new variable type of each type with a value
//    - string, int, decimal, char, array, list
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

string myString = "Spider-man";
int myInts = 5;
decimal myDeci = 4.200;
char myChar = "H";

//declare a new class of each type
//    - abstract, public, private, static

//public class
public class FirstClass
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



