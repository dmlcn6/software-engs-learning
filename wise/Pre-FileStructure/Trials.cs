// Reps 12/29/25

// use these below loops to iterate thru lists
// while loops
// for loop
// for each

// for every element in list, increment + 1
// console log the result

// This should output  2  3  4  5 





// while (int i = 0; i < 4; )

using System.Security.Authentication.ExtendedProtection;
using Microsoft.VisualBasic;

public class Program
{
    private static void Main()
    {
        First122925 Start = new();
        Start.FirstOne();
    }
}

public class First122925
{


    public void FirstOne()
    {
        List<int> mylist = new List<int>() { 1, 2, 3, 4 };
        int i = 0;
        Console.WriteLine($"|Wave 1|___________");
        //////////////////////////////////////////////////////////////////////////////////////
        while (i < mylist.Count)
        {
            mylist[i] += 1;
            Console.WriteLine($"{mylist[i]}");

            i += 1;
        }
        //------------------------------------------------------------------------------------//
        FirstTwo();
    }

    public void FirstTwo()
    {
        List<int> mylist = new List<int>() { 5, 6, 7, 8 };
        Console.WriteLine($"|Wave 2|___________");
        //////////////////////////////////////////////////////////////////////////////////////
        for (int i = 0; i < mylist.Count; i++)
        {
            mylist[i] += 1;
            Console.WriteLine($"{mylist[i]}");
        }
        //------------------------------------------------------------------------------------//
        FirstThree();
    }

    public void FirstThree()
    {
        List<int> mylist = new List<int>() { 9, 10, 11, 12 };
        Console.WriteLine($"|Wave 3|___________");
        //////////////////////////////////////////////////////////////////////////////////////
        foreach (int i in mylist)
        {
            Console.WriteLine($"{i + 1}");
        }
        //------------------------------------------------------------------------------------//
    }

    // kinda scared to run this...
    public void InfiniteDomain()
    {
        while (3 != 4)
        {
            string answer = Console.ReadLine();
            if (answer == "^C")
            {
                Console.WriteLine("NOPE! Nice Try!");
            }
            else
            {
                Console.WriteLine("I didnt hear you...");
            }

            Console.WriteLine("Say Something to ME!!");
        }
    }

}








