//AC - Accceptance Criteria
// 4 Functions - Add Sub Mult Div
// handle div errors by 0  
// Display output to user
// 2 point decimal outputs for div
// display equation
// show use of class functions to organize code

// accessModifier returnType FunctionName (parameters1, parameters2)

Console.WriteLine("It's Mathematical!");
string[] operation = new string [4] {"+","-","*","/"};
SimpCalc math = new SimpCalc();
var add = math.Add;

Console.WriteLine(math.Add);



public class SimpCalc
{
    Random rand1 = new Random(); 
    Random rand2 = new Random();
    public int answer;

     public int Add(int rand1, int rand2)
    {
        return answer = rand1 + rand2;
    }
    public int Sub(int rand1, int rand2)
    {
        return answer = rand1 - rand2;
    }
    public int Mult(int rand1, int rand2)
    {
        return answer = rand1 * rand2;
    }
    public int Div(int rand1, int rand2)
    {
        return answer = rand1 / rand2;
    }
}        

