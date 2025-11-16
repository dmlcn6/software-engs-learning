using System;

int int1 = 32; // value variable
int int2 = 0;

string name = "VSCode"; // ref variable

var var1 = "string";



//variableType variableName = value
Console.WriteLine("Test");
Console.WriteLine(name);
Console.WriteLine($"Your IDE is currently: {name}");

//int[] numbers = {1,2,3,4,5,6,7,8,9,10};
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
        if (rand3 == 0)
        {
            message = "cannot divide by 0!";
        }
        else
        {
            answer = rand1 / rand3;
            operation = "/";
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
    



Console.WriteLine($"{rand1} {operation} {rand3} = {answer}{(string.IsNullOrWhiteSpace(message) ? message : "")}");