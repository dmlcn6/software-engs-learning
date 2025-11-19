using System;

int int1 = 32; // value variable
int int2 = 0;

string name = "VSCode"; // ref variable

var var1 = "string";



//variableType variableName = value
Console.WriteLine("Test");
Console.WriteLine(name);
Console.WriteLine($"Your IDE is currently: {name}");

int[] operations = {0,1,2,3};

var rnd = new Random();
Random rnd1 = new();

int rand1 = rnd.Next(100);
int rand2 = rnd.Next(operations.Length);
int rand3 = rnd.Next(100);
 
float answer = 0;
string message = "";

string operation = "";

switch (rand2)
{
    // add
    case 0:
        answer = rand1 + rand3;
        operation = "+";
        break;
    // sub
    case 1:
        answer = rand1 - rand3;
        operation = "-";
        break;
    // div
    case 2:
        operation = "/";
        if (rand3 == 0)
        {
            message = " Cannot divide by 0!";
        }
        else
        {
            answer = rand1 / rand3;
        }
        break;
    // multi
    case 3:
        answer = rand1 * rand3;
        operation = "*";
        break;
    default:
        return;
}
    


Console.WriteLine($"{rand1} {operation} {rand3} = {answer}{message}");

object() - Type


public class Vehicle
//accessModifier class ClassName
{
    private string Make;
    public string Model;
}

public class Car : Vehicle
{
    
}

public class Motorcycle : Vehicle
{
    public double GetTopSpeed()
    //accessModifier returnType FunctionName (parameters1, parameters2)
    {
        return 2150;
    }

    public void FixTire()
    {
        // here is where we fix the tire
        
    }
 
    static void Main()
    {
        Motorcycle hondaMoto = new Motorcycle();
        Motorcycle redMoto = new Motorcycle();
        Motorcycle moto = new Motorcycle();
        //type variableName = value;

        moto.StartEngine();
        moto.AddGas(15);
        moto.Drive(5, 20);
        double speed = moto.GetTopSpeed();
        moto.Model = "500cc";
        moto.FixTire();
        Console.WriteLine($"My top speed is {speed}");
    }
}