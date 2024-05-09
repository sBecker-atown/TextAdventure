using Microsoft.VisualBasic;

namespace TextAdventure;

public class Room
{
    // Le Constructeur
    public Room(int roomIndex, string name, string description, Creature monster, List<Item> loot, bool active,
                string descriptionNoFight, Dictionary<Direction, RoomBoundary> boundaries)
    {
        RoomIndex = roomIndex;
        Name = name;
        Description = description;
        Monster = monster;
        Loot = loot;
        RoomActive = active;
        DescriptionNoFight = descriptionNoFight;
        RoomBoundaries = boundaries;
    }

    public int RoomIndex;

    public string Name;

    public string Description;

    public Creature Monster;

    public List<Item> Loot;

    public bool RoomActive;

    public string DescriptionNoFight;
    
    public Dictionary<Direction, RoomBoundary> RoomBoundaries;


    // FUNCTIONS a room can use:

    public void PresentRoom()
    {
        switch (Monster.IsDead)
        {
            case false:
                Console.WriteLine(Description);
                break;
            case true:
                Console.WriteLine(DescriptionNoFight);
                break;
        }
        
    }
    

    /*private void OpenDoor(Creature player)
    {
        var playerHasKey = false;
        // Check if Door needs Key.
        foreach (var Wall in Walls)
        {
            if (Wall.PlayerLocation && Wall.NeedsKey)
            {
                // Check if player has Key.
                foreach (var Item in player.Inventory)
                {
                    if (Item.ID == Wall.KeyID)
                    {
                        playerHasKey = true;
                    }
                }
            }
            if (playerHasKey || !Wall.NeedsKey && 
            Wall.Type == WallType.Door)
            {
                // Open Door.
                Wall.State = State.Open;
                Console.WriteLine("You open the door.");
            }
            else if (!playerHasKey && Wall.NeedsKey)
            {
                Console.WriteLine("You don't have " +
                "the Key for that.");
            }
            else if (!playerHasKey && !Wall.NeedsKey)
            {
                Console.WriteLine("You can't do that.");
            }
        }
    } */

    public void SearchRoom(Creature player)
    {
        if (Loot.Count == 0)
        {
            Console.WriteLine("No Loot found in this room :(\n");
            return;
        }
        else
        {
            // List all Loot items
            foreach (var Item in Loot)
            {
                Console.WriteLine($"{Item.Name}");
            }
            Console.WriteLine();
            string playerAction = AskForInput.LootOptions();
            if (InputAnalysis.WantsToPickUp(playerAction))
            {
                player.AddToInventory(this, playerAction);
            }
            if (InputAnalysis.WantsToStopLooting(playerAction))
            {
                return;
            }
        }
    }
}