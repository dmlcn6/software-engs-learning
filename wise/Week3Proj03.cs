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















int NumA = 8;
int NumB = 10;
string EQ = "multi";







Calculator start = new Calculator();
start.FunctionA(NumA,NumB,EQ);
//Console.WriteLine($"{output}");                     //Not neccsary {prints the answer a second time}


public class Calculator ()
{

    public string FunctionA (int intA, int intB, string EQ)
    {



        if (EQ == "add")
        {
            AnswerB($"{intA}+{intB}={intA+intB}");
            //Console.WriteLine($"{intA}+{intB}={answer}");
        }
        else if (EQ == "sub")
        {
            AnswerB($"{intA}-{intB}={intA-intB}");
        }
        else if (EQ == "multi")
        {
            AnswerB($"{intA}x{intB}={intA*intB}");
        }
        else if (EQ == "divi")
        {
            AnswerB($"{intA}/{intB}={intA/intB}");
        }
        else
        {
            Console.WriteLine("Something Went Wrong");
        }
        return "Something Went Wrong";
    }

    public string AnswerB (string output)
    {
        Console.WriteLine($"{output}");
        return output;
    }

}