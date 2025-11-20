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



Calculator math = new Calculator();
int sum = math.Equations(3,5,"add");
Console.WriteLine(sum);


public class Calculator ()
{

    public int Equations (int intA, int intB, string SymB)
    {

        int answer;


        if (SymB == "add")
        {
            answer = intA + intB;
            Console.WriteLine($"{intA}+{intB}={answer}");
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

