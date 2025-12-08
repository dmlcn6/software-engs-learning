using System;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("Program has started");

        var S1 = new Stage1();
        S1.StageAnnoucement1();
    }
}

// Program Stages----------------------------------

public class Stage1
{
    public string StageAnnoucement1()
    {
        Console.WriteLine("Stage 1 has started");

        var S1 = new Stage1();
        S1.Base1();
        
        return "StageAnnoucement1 Completed";
    }


    public string Base1()
    {
        Console.WriteLine("Welcome to Nucular Warfare!");

        var plyrInfo = new PlayerInfo();
        plyrInfo.GetPlayerName();
        
        var S2 = new Stage2();
        S2.StageAnnoucement2();

        return "Base1";
    }

}



public class Stage2
{
    public string StageAnnoucement2()
    {
        Console.WriteLine("Stage 2 has started");

        var S3 = new Stage3();
        S3.StageAnnoucement3();

        return "StageAnnoucement2 Completed";
    }
}



public class Stage3
{
    public string StageAnnoucement3()
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
            Console.WriteLine("What is your name");
            nameTemp1 = Console.ReadLine();
            
        } while (nameTemp1 == "");

        
        string? nameConf;
        do
        {
            Console.WriteLine($"Is your name ({nameTemp1})?");
            Console.WriteLine("A. YES");
            Console.WriteLine("B. NO");
            nameConf = Console.ReadLine();
        } while (nameConf != "A" && nameConf != "B");
        
        
        return "hello";
    }

    
    
}




