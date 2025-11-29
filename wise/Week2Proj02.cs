// AC - Acceptance Criteria 
//  4 functions - Add Div Subtract Multi ----> conditional function
//  Display output to user ------------------> Console.WriteLine($"{}");
//  - display equation ----------------------> Console.WriteLine($"{}");
//  - display divide by 0 error 
//  2 point decimal outputs for division

// Show use of classes functions to organize code.

//accessModifier Class ClassName
//accessModifier returnType functionName (parameter1, parameter2)

//dotnet run <filename>


//int int1 = 4;
//int int2 = 6;
//string EQ = "x";
//int answer;
















int NumA = 2;
int NumB = 5;
string EQ = "multi";







Calculator start = new Calculator();
int sum = start.FunctionA(NumA,NumB,EQ);
Console.WriteLine(sum);                     //Not neccsary {prints the answer a second time}


public class Calculator ()
{

    public int FunctionA (int intA, int intB, string SymB)
    {

        int answer;


        if (SymB == "add")
        {
            answer = intA + intB;

            //Console.WriteLine($"{intA}+{intB}={answer}");
        }
        else if (SymB == "sub")
        {
            answer = intA - intB;
            Console.WriteLine($"{intA}-{intB}={answer}");
        }
        else if (SymB == "multi")
        {
            answer = intA * intB;
            Console.WriteLine($"{intA}x{intB}={answer}");
        }
        else if (SymB == "divi")
        {
            answer = intA / intB;
            Console.WriteLine($"{intA}/{intB}={answer}");
        }
        else
        {
            answer = 0;
            Console.WriteLine("Something Went Wrong");
        }

        return answer;
    }
}