// declare a new variable of each type with a value;
// - string, int, decimal, char, array, list, 

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

}