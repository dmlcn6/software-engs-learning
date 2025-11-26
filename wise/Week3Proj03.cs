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

//Console.WriteLine($"{(double)intA+intB.ToString("f2")}");

//Console.WriteLine($"{(intA+intB).ToString("f2")}");

//int int1 = 4;
//int int2 = 6;
//string EQ = "x";
//int answer;















double EntreeA = 17.25;
double EntreeB = 66.66;
string EQ = "divi";







Calculator start = new Calculator();
start.FunctionA(EntreeA,EntreeB,"add");
start.FunctionA(EntreeA,EntreeB,"sub");
start.FunctionA(EntreeA,EntreeB,"multi");
start.FunctionA(EntreeA,EntreeB,"divi");
//Console.WriteLine($"{output}");                     //Not neccsary {prints the answer a second time}


public class Calculator ()
{

    public string FunctionA (double numA, double numB, string EQ)
    {

        double additionNum = numA+numB;
        double subtractionNum = numA-numB;
        double multiplicationNum = numA*numB;
        double divisionNum = numA/numB;

        string additionStr = additionNum.ToString("f2");
        string subtractionStr = subtractionNum.ToString("f2");
        string multiplicationStr = multiplicationNum.ToString("f2");
        string divisionStr = divisionNum.ToString("f2");


        if (EQ == "add")
        {
            AnswerB($"{numA} + {numB} = {additionStr}");
        }
        else if (EQ == "sub")
        {
            AnswerB($"{numA} - {numB} = {subtractionStr}");
        }
        else if (EQ == "multi")
        {
            AnswerB($"{numA} x {numB} = {multiplicationStr}");
        }
        else if (EQ == "divi")
        {
            AnswerB($"{numA} / {numB} = {divisionStr}");
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