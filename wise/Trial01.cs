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
// --------------------------------------------------------------------------------------------------------------------------------
// conditionals
// while loop conditional based on an existing class's bool field
// do while that checks a class's bool field and stops on false
// if statement with an arithmetic conditional statement
// if else statement with 2 arithmetic conditional statements
// switch based on user input for 4 choices and print something unique for each choice








using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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
    private bool vaseExist = true;
    public int num = 0;
    public string oper = "blank";
    public bool keepGoing = true;

    public override void Annoucement()
    {
        do
        {
            Console.WriteLine("Private class successful");
            Console.WriteLine($"We have {vaseNum} Vases in total. How many would you like to proceed?");

            Console.WriteLine("A. Break a vase");
            Console.WriteLine("B. buy a vase");
            string? choice;
            choice = Console.ReadLine();


            switch (choice)
            {
                case "A":
                case "a":
                    oper = "A";
                    Console.WriteLine("How many Vases would you like to break?");
                    break;

                case "B":
                case "b":
                    oper = "B";
                    Console.WriteLine("How many Vases would you like to buy?");
                    break;

                default:
                    Console.WriteLine("Something went wrong");
                    var startOver = new VaseChild02();
                    startOver.Annoucement();
                    break;
            }





            var changeNum0 = int.TryParse(Console.ReadLine(), out int num1);
            if (num1 < 1 && num1 > 20)
            {
                Console.WriteLine("You can only enter numbers between 0 - 20");
                keepGoing = false;
            }
            num = num1;


        } while (keepGoing == false);



        VaseInside(num, oper);

    }


    private void VaseInside(int num, string oper)
    {


        if (vaseNum > 0 && vaseNum < 20 && num > 0 && num < 20 && oper == "A")
        {
            vaseNum -= num;
            if (vaseNum < 1)
            {
                Console.WriteLine("why would you break them all... the game is over.");
                return;
            }
            Console.WriteLine($"you have {vaseNum} remaining");
            Annoucement();
        }
        else if (vaseNum > 0 && vaseNum < 20 && num > 0 && num < 20 && oper == "B")
        {
            vaseNum += num;
            if (vaseNum > 20)
            {
                Console.WriteLine("Okay you don't need to play anymore");
                return;
            }
            Console.WriteLine($"you have {vaseNum} remaining");
            Annoucement();
        }
        else
        {
            Console.WriteLine("Something went wrong");
            Annoucement();
        }
    }




}