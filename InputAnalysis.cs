namespace TextAdventure;

class InputAnalysis
{
    // Checks if the player...
    public static bool WantsToGoTo(string choice)
    {
        if (choice.ToUpper().StartsWith('G'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("GO"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToOpen(string choice)
    {
        if (choice.ToUpper().StartsWith('O'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("OPEN"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToSearch(string choice)
    {
        if (choice.ToUpper().StartsWith('S'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("SEARCH"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToLeave(string choice)
    {
        if (choice.ToUpper().StartsWith('E'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("EXIT"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToOpenInventory(string choice)
    {
        if (choice.ToUpper().StartsWith('I'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("INVENTORY"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToCloseInventory(string choice)
    {
        if (choice.ToUpper().StartsWith('C'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("CLOSE"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToExit(string choice)
    {
        if (choice.ToUpper().StartsWith('E'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("EXIT"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToPickUp(string choice)
    {
        if (choice.ToUpper().StartsWith('P'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("PICK UP"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToEquip(string choice)
    {
        if (choice.ToUpper().StartsWith('E'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("EQUIP"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToUnequip(string choice)
    {
        if (choice.ToUpper().StartsWith('U'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("UNEQUIP"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToRun(string choice)
    {
        if (choice.ToUpper().StartsWith('R'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("RUN"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToAttack(string choice)
    {
        if (choice.ToUpper().StartsWith('A'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("ATTACK"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool WantsToStopLooting(string choice)
    {
        if (choice.ToUpper().StartsWith('S'))
        {
            return true;
        }
        else if (choice.ToUpper().Contains("STOP"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}