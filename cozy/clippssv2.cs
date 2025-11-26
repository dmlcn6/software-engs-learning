//AC - Accceptance Criteria
// 4 Functions - Add Sub Mult Div DONE
// handle div errors by 0  DONE
// Display output to user DONE
// 2 point decimal outputs for div DONE
// display equation DONE
// show use of class functions to organize code DONE

// accessModifier returnType FunctionName (parameters1, parameters2)

SimpCalc math = new SimpCalc();
var add = math.Add();
var sub = math.Sub();
var mult = math.Mult();





Console.WriteLine("Super Scuffed Simple Calculator :P");
math.Add();
math.Sub();
math.Mult();
math.Div();

public class SimpCalc
{
    Random Randle = new Random(); 
    public int rand1;
    public int rand2;
    int Answer;
    double Result;
    
    
    public SimpCalc()
    {
        
    }
     public int Add()
    {
        rand1 = Randle.Next(100);
        rand2 = Randle.Next(100);
        Answer = rand1 + rand2; 
        Console.Writeline($)

        return Answer;      
    }
    public int Sub()
    {
        rand1 = Randle.Next(100);
        rand2 = Randle.Next(100);
        Answer = rand1 - rand2;
        return Answer;
    }
    public int Mult()
    {
        rand1 = Randle.Next(100);
        rand2 = Randle.Next(100);
        Answer = rand1 * rand2;
        return Answer;
    }
    public void Div()
    {
        rand1 = Randle.Next(100);
        rand2 = Randle.Next(100);
        if (rand2 == 0)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        else
        {
            Result = (double)rand1/rand2;
            Console.WriteLine($"{rand1}/{rand2}={Result.ToString("F")}");
        }    
    }
}