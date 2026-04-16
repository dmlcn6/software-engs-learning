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
    public void StageOneAnnoucement()
    {
        Console.WriteLine("Character Customization");

        var S1 = new Stage1();
        S1.Wave0();

    }


    public void Wave0()
    {
        var plyrInfo = new PlayerInfo();
        string playerName = plyrInfo.GetPlayerName();

        Console.WriteLine($"HI {playerName}!");

        var S2 = new Stage2();
        S2.StageTwoAnnoucement();


    }

    public void Wave1_0()
    {
        Thread.Sleep(10000);
        //Console.WriteLine("this is where we end");
        var DiaOpen = new StageDia1();
        Console.WriteLine($"{DiaOpen.DialogueCont(0)}");


    }



}



public class Stage2
{
    public void StageTwoAnnoucement()
    {
        Console.WriteLine("Stage 2 has started");

        var S3 = new Stage3();
        S3.StageThreeAnnoucement();


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

            if (nameTemp1 == "")
            {
                Console.WriteLine($"{stageOpen.DialogueNeg(0)}");
            }

        } while (nameTemp1 == "");


        string? nameConf = "empty";
        do
        {
            var stageOpen = new StageDia1();
            Console.WriteLine($"{stageOpen.DialoguePos(0)} ({nameTemp1})?");
            Console.WriteLine("A. YES");
            Console.WriteLine("B. NO");
            nameConf = Console.ReadLine();

            if (nameConf != "A" && nameConf != "B")
            {
                Console.WriteLine($"{stageOpen.DialogueNeg(1)}");
            }

        } while (nameConf != "A" && nameConf != "B");


        if (nameConf == "A")
        {
            nameConf = nameTemp1;
            Console.WriteLine(".....");
            Console.WriteLine("EW");
            Console.WriteLine("You may continue");
        }

        else if (nameConf == "B")
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

    public string[] diaTreeContext = new string[2] { "A nucular explosion erupts from a distance.", "You know radiation is coming" };
    public string[] diaTreePrompt = new string[2] { "What is your name?", "In order to not recieve any burns how far away would you stand?" };
    public string[] diaTreePos = new string[1] { "Is your name" };
    public string[] diaTreeNeg = new string[2] { "Please enter a name", "Please Either Enter (A) for YES. |OR| (B) for NO." };

    string stage = "test";
    public string DialoguePrompt(int placeHolder)
    {


        //string[] stage1 = {"test1", "test2", "test3"};
        string stage = diaTreePrompt[placeHolder];

        return stage;
    }

    public string DialogueNeg(int placeHolder)
    {
        string stage = diaTreeNeg[placeHolder];

        return stage;
    }

    public string DialoguePos(int placeHolder)
    {
        string stage = diaTreePos[placeHolder];

        return stage;
    }

    public string DialogueCont(int placeHolder)
    {
        string stage = diaTreeContext[placeHolder];

        return stage;
    }




}




