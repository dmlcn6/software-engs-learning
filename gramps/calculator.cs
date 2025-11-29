//AC - Acceptance Criteria
//  4 functions - Add Div Subtract Multi
//  Display output to user
//  - disply equation
//  - display divide by 0 error
//  2 point decimal outputs for division

//  Show use of classes/functions to organize code

using Test;

var calc = new Calc();
// Console.WriteLine(calc.name);  cant use this directly with dot notation (.) becuase it is private access modifier


calc.Add();
calc.Divide();
calc.Subtract();
calc.Multiply();

namespace Test
{
    public class Calc
    {
        Random randGenerator = new Random();
        public int rand1;
        public int rand2;
        string name = "Calculator v1.0";
 
        // THIS IS A CONSTRUCTOR
        public Calc()
        {
            Console.WriteLine($"Welcome to {name}");
            rand1 = randGenerator.Next(100);
            rand2 = randGenerator.Next(100);
        }

        // functions are unique based on accessModifer returnType input paramters

        public void Add(int number1, int number2)
        {
            LogAnswer($"{number1} + {number2} = {number1+number2}");
        }

        public void Add()
        {
            LogAnswer($"{rand1} + {rand2} = {rand1+rand2}");
        }

        public void Subtract(int number1, int number2)
        {
            LogAnswer($"{number1} - {number2} = {number1-number2}");
        }
        public void Subtract()
        {
            LogAnswer($"{rand1} - {rand2} = {rand1-rand2}");
        }

        public void Divide(int number1, int number2)
        {
            string message = "";
            if (number2 == 0)
            {
                message = "cannot divide by 0";
            }
            else
            {
                message = $"{number1} / {number2} = {(double)number1/number2}";    
            }
            LogAnswer(message);
        }

        public void Divide()
        {
            string message = "";
            if (rand2 == 0)
            {
                message = "cannot divide by 0";
            }
            else
            {
                //result = (double)rand1/rand2;
                message = $"{rand1} / {rand2} = {(double)rand1/rand2}";    
            }
            LogAnswer(message);
        }

        public void Multiply(int number1, int number2)
        {
            LogAnswer($"{number1} * {number2} = {number1*number2}");
        }

        public void Multiply()
        {
            LogAnswer($"{rand1} * {rand2} = {rand1*rand2}");
        }

        private void LogAnswer(string message)
        {
            Console.WriteLine(message);
        }


        public string ReadName()
        {
            return name;
        }
    }
}

