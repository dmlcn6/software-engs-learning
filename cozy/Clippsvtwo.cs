//AC - Accceptance Criteria
// 4 Functions - Add Sub Mult Div DONE
// handle div errors by 0  DONE
// Display output to user DONE
// 2 point decimal outputs for div
// display equation DONE
// show use of class functions to organize code DONE

// accessModifier returnType FunctionName (parameters1, parameters2)

SimpCalc math = new SimpCalc();
var add = math.Add();
var sub = math.Sub();
var mult = math.Mult();





Console.WriteLine("Super Scuffed Simple Calculator :P");
Console.WriteLine($"{math.rand1}+{math.rand2}={add}");
Console.WriteLine($"{math.rand1}-{math.rand2}={sub}");
Console.WriteLine($"{math.rand1}*{math.rand2}={mult}");
math.Div();

public class SimpCalc
{
    Random Randle = new Random(); 
    public int rand1;
    public int rand2;
    int Answer;
    //int deci;
    
    public SimpCalc()
    {
        rand1 = Randle.Next(100);
        rand2 = Randle.Next(100);
    }
     public int Add()
    {
        Answer = rand1 + rand2; 
        return Answer;      
    }
    public int Sub()
    {
        Answer = rand1 - rand2;
        return Answer;
    }
    public int Mult()
    {
        Answer = rand1 * rand2;
        return Answer;
    }
    public void Div()
    {
        if (rand2 == 0)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        else
        {
            Answer = rand1 / rand2;
            Console.WriteLine($"{rand1}/{rand2}={(double)Answer}");
        }    
    }
}
