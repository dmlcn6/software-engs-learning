using UnitBB.Logger;
using UnitBB.Items;
using UnitBB.Characters;
using System.Security.Cryptography;
using Microsoft.VisualBasic;



namespace UnitBB.Menu
{

    public class MenuData : IMenu
    {
        public Logs to = new Logs();

        //-----------|How many inventory slots|---------|1|--------------|2|--------------|3|--------------|4|--------------|5|--------------|6|--------------|7|--------------|8|--------------|9|-------------|10|-------------|11|-------------|12|-------------|13|-------------|14|-------------|15|-------------|16|-------------|17|-------------|18|-------------|19|-------------|20|--//
        public List<ItemsBase> safeInventory = new() { new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available(), new Available() };

        public bool SafeFull()
        {
            bool isFull = true;
            for (int i = 0; i < safeInventory.Count; i++)
            {
                if (safeInventory[i].GetType().ToString().Contains("Available")) // System things that any of the slots in safeInventory is == new Availabe()
                {
                    isFull = false;
                }
            }
            return isFull;
        }
        public void GainIt(ItemsBase it)
        {
            if (SafeFull() == false)
            {
                bool firstAvailableFound = false;
                int amountAvailable = 0;
                for (int i = 0; i < safeInventory.Count; i++)
                {
                    if (safeInventory[i].GetType().ToString().Contains("Available") && firstAvailableFound == false)
                    {
                        amountAvailable = i + 1;
                        int firstAvailableInt = i;
                        firstAvailableFound = true;

                        safeInventory[firstAvailableInt] = it;
                    }
                    else if (safeInventory[i].GetType().ToString().Contains("Available") && firstAvailableFound == true)
                    {
                        amountAvailable = i;
                    }
                }
                to.Log($"You have {amountAvailable} open safe slots remaining");
            }
            else
            {
                to.Log("You do not have any open slots");
            }
        }
        public ItemsBase MoveIt(int itIndex)
        {
            ItemsBase itemLeaving = safeInventory[itIndex];
            safeInventory[itIndex] = new Available();

            return itemLeaving;
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------------


        public void OpenSafe(CharactersBase player)
        {
            to.Log($"{player.CallName()}'s Inventory");
            for (int i = 0; i < player.inventory.Count; i++)
            {
                to.Log($"({i + 1}a){player.inventory[i].CallName()}");
            }
            to.Log($"");
            to.Log($"");
            to.Log($"");
            to.Log($"Inventory Safe");
            for (int i = 0; i < safeInventory.Count; i++)
            {
                to.Log($"({i + 1}d){safeInventory[i].CallName()}");
            }

            to.Log("Which inventory would you like to take from?");
            to.Log("(A) Take from your Safe");
            to.Log("(B) Take from your Inventory");
            to.Log("(C) Leave");

            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    if (!player.InventoryFull())
                    {
                        to.Log("");
                        to.Log("---------------------------------------------------");
                        for (int i = 0; i < safeInventory.Count; i++)
                        {
                            to.Log($"({i + 1}){safeInventory[i].CallName()}");
                        }
                        to.Log("---------");
                        to.Log("Which item would you like to move to your inventory?");
                        bool isValidIntA = int.TryParse(Console.ReadLine(), out int itemChoiceA);
                        to.Log("");
                        if (isValidIntA && itemChoiceA < player.inventory.Count)
                        {
                            player.GainIt(safeInventory[itemChoiceA - 1]);
                            player.GainIt(MoveIt(itemChoiceA - 1));
                        }
                        else
                        {
                            to.Log("");
                            to.Log("Please choose a number that is in your Safe List");
                            return;
                        }
                    }
                    else
                    {
                        to.Log("");
                        to.Log("You do not have enough space in your inventory");
                        return;
                    }

                    break;
                case "b":
                    if (!SafeFull())
                    {
                        to.Log("");
                        to.Log("---------------------------------------------------");
                        for (int i = 0; i < player.inventory.Count; i++)
                        {
                            to.Log($"({i + 1}){player.inventory[i].CallName()}");
                        }
                        to.Log("---------");
                        to.Log("Which item would you like to move to the Safe?");
                        bool isValidIntB = int.TryParse(Console.ReadLine(), out int itemChoiceB);
                        if (isValidIntB && itemChoiceB < safeInventory.Count)
                        {
                            GainIt(player.MoveIt(itemChoiceB - 1));
                        }
                    }
                    else
                    {
                        to.Log("");
                        to.Log("You do not have enough space in your Safe");
                        return;
                    }
                    break;
                case "c":
                    return;
                default:
                    OpenSafe(player);
                    return;
            }


        }

    }

}