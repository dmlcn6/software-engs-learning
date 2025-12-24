// declare a new variable of each type with a value;
// - string, int, decimal, char, array, list, 

<<<<<<< HEAD
using System.ComponentModel;

=======
>>>>>>> 469e51e5f1d5969b37fb25b0000949d7070bffbd
string myStringVariable = "test string";
int myIntVariable = 2;
decimal myDecimal = 1.476;
char myChar = "A";

// declare a new class of each type
// - abstract, public private, static

public class MyClass
{

}

public abstract class MyPublicAbstractClass
{

}

abstract class MyAbstractClass
{

}

static class MyStaticClass
{
    public static int MyStaticFunction()
    {

    }
}




// in class declaarations, access modifiers are optional
// accessModifier(optional) keywords(optional) class className{} 

// Encapsulation:
// - show 1 class that encapsulates the modification of a private class variable through the use of a function

<<<<<<< HEAD
=======
public class Player
{
    private int numberOfDeaths = 0;


    public void IncrementDeaths()
    {
        //conditional logic potentially for who can call this function
        AddDeaths();
    }

    private void AddDeaths()
    {

        numberOfDeaths += 1;
    }
}

>>>>>>> 469e51e5f1d5969b37fb25b0000949d7070bffbd

// Inheritance:
// - show 2 classes; one parent and one child;
// - show how a child can inherit a class member from its parent
// - show how a parent can have class memebers that its child dont inherit
// - show how a child can have a class memeber that its parents dont know about



//variable declaration outside of a class memeber
// Type variableName = value;

//variable declaraion inside of a class (aka a class member)
public class MyClass
{
    // class member

    // accessModifier(optional, if no accessModifier set, defaults to private) Type variableName; (optional to set a value) 
    // accessModifier(optional, if no accessModifier set, defaults to private) Type variableName = value; 

    public string myClassString;
    private int myClassInt = 0;
    decimal myClassDecimal = 1.9;
    private List<int> myNumberList;

    // class constructor 
    public MyClass()
    {
        myNumberList = new List<int>();
        myClassString = "New Class";
    }
<<<<<<< HEAD
}

// an abstract class that has 1 fully defined class variables
// and a function that is abstract
// a derived class that inherits from abstract and fully defined the class
// it has to work
// we are going use non top level entry point



// conditionals
// while loop conditional based on an existing class's bool field
// do while that checks a class's bool field and stops on false
// if statement with an arithmetic conditional statement
// if else statement with 2 arithmetic conditional statements
// switch based on user input for 4 choices and print something unique for each choice

public class Player
{
    public int numberOfDeaths = 0;

    public bool isDead = false;


    public void IncrementDeaths()
    {
        //conditional logic potentially for who can call this function
        AddDeaths();

    }

    private void AddDeaths()
    {

        numberOfDeaths += 1;
    }
}



var p1 = new Player();

while (!p1.isDead)
{
    // attack go crazy baladfkjasldfj;alsjdf
}

do
{

} while ()


// switch on Player class numberOfDeaths field
// conditional with multiple conditions
// these are called cases
switch (p1.numberOfDeaths)
{
    case 4:
    case 2:
        // logic
        break;
    case 3:
        // logic
        break;
    case 1:
    case 43256:
        // logic
        break;
    default:
        // logic
        break;
}

if ((1 + 1) > 3)
{

}
else
{
    // do this if conditional is not met
}

=======

}
>>>>>>> 469e51e5f1d5969b37fb25b0000949d7070bffbd
