using System.Diagnostics;

namespace TextAdventure;

public class AskForInput
{
    private static string _whatToDo =
        "\nWhat do you want to do?\n\n" +
        "Open (I)nventory,  Show (H)ealth,\n" +
        "(G)o (direction), (S)earch Room, (E)xit dungeon\n";

    private static string _whatToDoPassage =
        "\nYou are facing an archway.\n" +
        "Behind the passage you can see the boundaries of " +
        " the next room.\n\n" +
        "What do you want to do?\n\n" +
        "(L)eave Room, Open (I)nventory, Show (H)ealth,\n" +
        "(G)o (direction), (S)earch Room, (E)xit dungeon\n";

    private static string _whatToDoDoor =
        "\nYou are facing a door.\n\n" +
        "What do you want to do?\n\n" +
        "(O)pen door, Open (I)nventory, Show (H)ealth,\n" + 
        "(G)o (direction), (S)earch Room, (E)xit dungeon\n";

    private static string _whatToDoOpenDoor =
        "\nYou are facing an open door.\n" +
        "Through the doorframe you can see " +
        "the boundaries of the next room.\n\n" +
        "What do you want to do?\n\n" +
        "(L)eave Room, Open (I)nventory, Show (H)ealth\n" +
        "(G)o (direction), (S)earch Room, (E)xit dungeon\n";
        
    private static string _whatToDoWall =
        "\nYou are facing a wall.\n" +
        "There is no way forward here.\n\n" +
        "What do you want to do?\n\n" +
        "Open (I)nventory, Show (H)ealth, (G)o (direction),\n" +
        "(S)earch Room, (E)xit dungeon\n";


    // Methods.

    public static void WhatToDo()
    {
        Console.WriteLine(_whatToDo);
    }

    public static void WhatToDoAtWall()
    {
        Console.WriteLine(_whatToDoWall);
    }

    public static void WhatToDoAtDoor()
    {
        Console.WriteLine(_whatToDoDoor);
    }

    public static void WhatToDoAtPassage(bool? isADoor)
    {
        switch (isADoor)
        {
            case false:
                Console.WriteLine(_whatToDoPassage);
                break;
            case true:
                Console.WriteLine(_whatToDoOpenDoor);
                break;
        }
    }

    public static string InventoryOptions()
    {
        string inventoryOptions =
        "What do you want to do?\n\n" +
        "(E)quip (Item), (U)nequipt (Item), (C)lose Inventory\n";
        Console.WriteLine(inventoryOptions);
        string choice;

        do
        {
            choice = Console.ReadLine()!;
        }
        while (string.IsNullOrEmpty(choice));
        
        return choice;
    }

    public static string LootOptions()
    {
        string lootOptions =
        "What do you want to do?\n\n" +
        "(P)ick up (Item), (S)top looting\n";
        Console.WriteLine(lootOptions);
        string choice;

        do
        {
            choice = Console.ReadLine()!;
        }
        while (string.IsNullOrEmpty(choice));
        
        return choice;
    }
    public static string FightOptions()
    { 
        string fightOptions = 
        "What do you want to do?\n" +
        "(A)ttack, (R)un, Open (I)nventory, Show (H)ealth\n";
        Console.WriteLine(fightOptions);

        string choice;
        do
        {
            choice = Console.ReadLine()!;
        }
        while (string.IsNullOrEmpty(choice));
        
        return choice;
    }
}