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
// --------------------------------------------------------------------------------------------------------------------------------
// an abstract class that has 1 fully defined class variables
// and a function that is abstract
// a derived class that inherits from abstract and fully defined the class
// it has to work
// we are going use non top level entry point









using System.Threading.Tasks.Dataflow;

public static class Program
{
    private static void Main()
    {
        var start = new VaseChild01();

        Console.WriteLine("The Program has started");
        var startNext = new VaseChild01();
        start.Annoucement();
    }



}



public abstract class VaseParent
{

    string Vase01 = "This is a Vase";
    int Vase02 = 1;
    double Vase03 = 1.1;
    char Vase04 = 'A';
    string[] Vase05 = new string[4] { "V1", "V2", "V3", "V4" };
    List<string> Vase06 = new List<string>() { "V1", "V2", "V3", "V4" };

    public abstract void Annoucement();

}



public class VaseChild01 : VaseParent
{
    public override void Annoucement()
    {
        var start = new VaseChild02();

        Console.WriteLine("Public class successful");
        var startNext = new VaseChild02();
        start.Annoucement();
    }

}



class VaseChild02 : VaseParent
{
    private int vaseNum = 10;

    public override void Annoucement()
    {
        Console.WriteLine("Private class successful");
        Console.WriteLine($"We have {vaseNum} Vases in total. How many would you like to proceed?");

        Console.WriteLine("A. Break a vase");
        Console.WriteLine("B. buy a vase");
        string? input1;
        input1 = Console.ReadLine();


        var input2 = int.TryParse(Console.ReadLine(), out int inputConf);
        VaseOutside(inputConf, input1);




    }


    public void VaseOutside(int changeNum, string Operation)
    {
        if (Operation == "A" || Operation == "a")
        {
            Operation = "A";
            VaseInside(changeNum, Operation);
        }
        else if (Operation == "B" || Operation == "b")
        {
            Operation = "B";
            VaseInside(changeNum, Operation);
        }
        else
        {
            Console.WriteLine("Something went wrong");
            var startOver = new VaseChild02();
            startOver.Annoucement();
        }
    }

    private void VaseInside(int Num, string Oper)
    {
        if (vaseNum > 0 && vaseNum < 20 && Num > 0 && Num < 20 && Oper == "A")
        {
            vaseNum -= Num;
            Console.WriteLine($"you have {vaseNum} remaining");

        }
        else if (vaseNum > 0 && vaseNum < 20 && Num > 0 && Num < 20 && Oper == "B")
        {
            vaseNum += Num;
            Console.WriteLine($"you have {vaseNum} remaining");
        }
        else
        {
            Console.WriteLine("You can only enter numbers between 0 - 20");
            var startOver = new VaseChild02();
            startOver.Annoucement();
        }
    }


}