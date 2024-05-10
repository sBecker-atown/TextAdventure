namespace TextAdventure;

class InputAnalysis
{
    // Checks if the player...
    public static bool WantsToGoTo(string choice)
    {
        return choice.StartsWith("G", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Go", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToOpen(string choice)
    {
        return choice.StartsWith("O", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Open", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToSearch(string choice)
    {
        return choice.StartsWith("S", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Search", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToLeave(string choice)
    {  
        return choice.StartsWith("L", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Leave", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToOpenInventory(string choice)
    {
        return choice.StartsWith("I", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Inventory", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToCloseInventory(string choice)
    {
        return choice.StartsWith("C", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Close", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToExit(string choice)
    {
        return choice.StartsWith("E", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Exit", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToPickUp(string choice)
    {
        return choice.StartsWith("P", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Pick up", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToEquip(string choice)
    {
        return choice.StartsWith("E", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Equip", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToUnequip(string choice)
    {
        return choice.StartsWith("U", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Unequip", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToRun(string choice)
    {
        return choice.StartsWith("R", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Run", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToAttack(string choice)
    {
        return choice.StartsWith("A", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Attack", StringComparison.OrdinalIgnoreCase);
    }

    public static bool WantsToStopLooting(string choice)
    {
        return choice.StartsWith("S", StringComparison.OrdinalIgnoreCase) 
        || choice.Contains("Stop", StringComparison.OrdinalIgnoreCase);
    }
}