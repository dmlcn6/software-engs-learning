//AC - Accceptance Criteria
// 4 Functions - Add Sub Mult Div
// handle div errors by 0  
// Display output to user
// 2 point decimal outputs for div
// display equation
// show use of class functions to organize code

// accessModifier returnType FunctionName (parameters1, parameters2)

SimpCalc math = new SimpCalc();
//var add = math.Add();


Console.WriteLine("Simple Calculator ;)");
//Console.WriteLine(add);



public class SimpCalc
{
    Random Randle = new Random(); 
    int rand1;
    int rand2;
    int Answer;
    
    public SimpCalc()
    {
        rand1 = Randle.Next(100);
        rand2 = Randle.Next(100);
    }
     public void Add()
    {
        Answer = rand1 + rand2; 
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
    public int Div()
    {
        Answer = rand1 / rand2;
        return Answer;
    }
}        

