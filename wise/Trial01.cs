// declare a new variable of each type with a value;
// - string, int, decimal, char, array, list, 

// declare a new class of each type
// - abstract, public private, static

// Encapsulation:
// - show 1 class that encapsulates the modification of a private class variable through the use of a function

// Inheritance:
// - show 2 classes; one parent and one child;
// - show how a child can inherit a class member from its parent
// - show how a parent can have class memebers that its child dont inherit
// - show how a child can have a class memeber that its parents dont know about



using Microsoft.VisualBasic;

public static class Program
{
    private static void Main()
    {
        Console.WriteLine("The Program has started");
        var startNext = new VaseChild01();
        start.annoucement();
    }

    

}



public abstract class VaseParent
{

    string Vase01 = "This is a Vase";
    int Vase02 = 1;
    float Vase03 = 1.1;
    char Vase04 = "A";
    string[] Vase05 = new string[4] { "V1", "V2", "V3", "V4" };
    List<string> Vase06 = new List<string>() { "V1", "V2", "V3", "V4" };

    public abstract void annoucement();

}



public class VaseChild01 : VaseParent
{
    public override void annoucement()
    {
        Console.WriteLine("This is a Private VaseChild Class");
        var startNext = new VaseChild02();
        start.annoucement();
    }

}



public class VaseChild02 : VaseParent
{
    private int vaseNum = 10;

    public override void annoucement()
    {
        Console.WriteLine("This is a Public VaseChild Class");
        VaseBreakOutside(3);
    }


    public void VaseBreakOutside(int BreakNum)
    {
        VaseBreakInside(BreakNum);
    }

    private void VaseBreakInside(int breakNum)
    {
        if (breakNum < -1 && breakNum < -20)
        {
            vaseNum -= breakNum;
            Console.WriteLine($"you have {vaseNum} remaining");

        }
        else
        {
            Console.WriteLine("You can only enter negative numbers between 1 - 20");
        }
    }


}


private class VaseChild03 : VaseParent
{

}