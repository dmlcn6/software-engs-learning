using System;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("Program has started");

        var S1 = new Stage1();
        S1.StageOneAnnoucement();
    }
}

// Program Stages----------------------------------

public class Stage1
{
    public string StageOneAnnoucement()
    {
        Console.WriteLine("Stage 1 has started");

        var S1 = new Stage1();
        S1.Wave1();
        
        return "StageAnnoucement1 Completed";
    }


    public string Wave1()
    {
        Console.WriteLine("Welcome to Nucular Warfare!");

        var plyrInfo = new PlayerInfo();
        plyrInfo.GetPlayerName();
        
        var S2 = new Stage2();
        S2.StageTwoAnnoucement();

        return "Wave1";
    }

}



public class Stage2
{
    public string StageTwoAnnoucement()
    {
        Console.WriteLine("Stage 2 has started");

        var S3 = new Stage3();
        S3.StageThreeAnnoucement();

        return "StageAnnoucement2 Completed";
    }
}



public class Stage3
{
    public string StageThreeAnnoucement()
    {
        Console.WriteLine("Stage 3 has started");

        return "StageAnnoucement3 Completed";
    }
}

// Program Stages ENDED-----------------------------



// Libraries ----------------

public class PlayerInfo
{
    public string GetPlayerName()
    {
        string? nameTemp1;
        do
        {
            var stageOpen = new StageDia1();
            Console.WriteLine($"{stageOpen.DialoguePrompt(0)}");   
            nameTemp1 = Console.ReadLine();
            
        } while (nameTemp1 == "");

        
        string? nameConf = "empty";
        do
        {
            var stageOpen = new StageDia1();
            Console.WriteLine($"{stageOpen.DialoguePrompt(1)} ({nameTemp1})?");
            Console.WriteLine("A. YES");
            Console.WriteLine("B. NO");
            nameConf = Console.ReadLine();

            if(nameConf != "A" && nameConf != "B")
            {
                Console.WriteLine("Please Either Enter (A) for YES. |OR| (B) for NO.");
            }
            
        } while (nameConf != "A" && nameConf != "B");


        if (nameConf == "A")
        {
            nameConf = nameTemp1;
            Console.WriteLine(".....");
            Console.WriteLine("EW");
            Console.WriteLine("You may continue");
        }

        else if ( nameConf == "B")
        {
            nameConf = "empty";
            Console.WriteLine("Okay then");
            Console.WriteLine("I have one question for you");
            var startOver = new PlayerInfo();
            startOver.GetPlayerName();
        }
        
        else
        {
            nameConf = "empty";
            Console.WriteLine("Something went wrong");
            var startOver = new PlayerInfo();
            startOver.GetPlayerName();
        }

        
        
        return nameConf;
    }

    
    
}





public class StageDia1
{

    string[] diaTreePrompt = {"What is your name", "Is your name", "test3"};

    string stage = "test";
    public string DialoguePrompt (int placeHolder)
    {


        //string[] stage1 = {"test1", "test2", "test3"};
        string stage = diaTreePrompt[placeHolder];

        return stage;
    }





}




