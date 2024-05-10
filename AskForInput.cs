﻿using System.Diagnostics;

namespace TextAdventure;

public class AskForInput
{
    private static string _whatToDo =
        "\nWhat do you want to do?\n\n" +
        "Open (I)nventory, (G)o (direction),\n" + 
        "(S)earch Room, (E)xit dungeon\n";

    private static string _whatToDoPassage =
        "\nYou are facing an archway.\n" +
        "Behind the passage you can see the boundaries of " +
        " the next room.\n\n" +
        "What do you want to do?\n\n" +
        "Open (I)nventory, (G)o (direction), (L)eave Room\n" +
        "(S)earch Room, (E)xit dungeon\n";

    private static string _whatToDoDoor =
        "\nYou are facing a door.\n\n" +
        "What do you want to do?\n\n" +
        "(O)pen door, Open (I)nventory, (G)o (direction),\n" +
        "(S)earch Room, (E)xit dungeon\n";
        
    private static string _whatToDoWall =
        "\nYou are facing a wall.\n" +
        "There is no way forward here.\n\n" +
        "What do you want to do?\n\n" +
        "Open (I)nventory, (G)o (direction),\n" +
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

    public static void WhatToDoAtPassage()
    {
        Console.WriteLine(_whatToDoPassage);
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
        "(A)ttack, (R)un, Open (I)nventory\n";
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