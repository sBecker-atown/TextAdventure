using Microsoft.VisualBasic;

namespace TextAdventure;

public class Room
{
    // Le Constructeur
    public Room(int roomIndex, string name, string description, Creature monster, List<Item> loot, bool active,
                Combat fight, string descriptionNoFight, Dictionary<Direction, RoomBoundary> boundaries)
    {
        RoomIndex = roomIndex;
        Name = name;
        Description = description;
        Monster = monster;
        Loot = loot;
        RoomActive = active;
        Encounter = fight;
        DescriptionNoFight = descriptionNoFight;
        RoomBoundaries = boundaries;
    }

    public int RoomIndex;

    public string Name;

    public string Description;

    public Creature Monster;

    public List<Item> Loot;

    public bool RoomActive;

    public Combat Encounter;
    public string DescriptionNoFight;
    
    public Dictionary<Direction, RoomBoundary> RoomBoundaries;


    // FUNCTIONS a room can use:

    private void PresentRoom()
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
    public void EnterRoom(Creature player, List<Room> AllRooms)
    {
        RoomActive = true;
        if (!Monster.IsDead)
        {
            PresentRoom();
            Encounter.Fight(player, Monster, AllRooms);
        }
        if (player.IsDead)
        {
            return;
        }
        PresentRoom();

        // Ask player what to do till player 
        // leaves this room or the dungeon.
        do 
        {
            string playerAction = Gameworld.WhatToDo(this);
            // TODO
            // Go in direction
            // Needs to set Active = false, 
            // if player walks through door.
            if (InputAnalysis.WantsToGoTo(playerAction))
            {
                if (playerAction.ToUpper().Contains("NORTH"))
                {
                    Walls[0].PlayerLocation = true;
                    playerAction = Gameworld.WhatToDo(this);
                }
                else if (playerAction.ToUpper().Contains("EAST"))
                {
                    Walls[1].PlayerLocation = true;
                    playerAction = Gameworld.WhatToDo(this);
                }
                else if (playerAction.ToUpper().Contains("SOUTH"))
                {
                    Walls[2].PlayerLocation = true;
                    playerAction = Gameworld.WhatToDo(this);
                }
                else if (playerAction.ToUpper().Contains("WEST"))
                {
                    Walls[3].PlayerLocation = true;
                    playerAction = Gameworld.WhatToDo(this);
                }
                else
                {
                    Console.WriteLine("No valid direction!\n");
                }
            }
            // Open door.
            if (InputAnalysis.WantsToOpen(playerAction))
            {
                OpenDoor(player);
            }
            // Leave dungeon.
            if (InputAnalysis.WantsToLeave(playerAction))
            {
                foreach (var Wall in Walls)
                {
                    Wall.PlayerLocation = false;
                }
                RoomActive = false;
                Console.WriteLine(Message.gameOver);
            }
            // Search room.
            if (InputAnalysis.WantsToSearch(playerAction))
            {
                SearchRoom(player);
            }
            // Open Inventory
            if (InputAnalysis.WantsToOpenInventory(playerAction))
            {
                Console.WriteLine();
                player.OpenInventory();
            }
            // Exit Room
            if (InputAnalysis.WantsToExit(playerAction))
            {
                int nextRoom = AllRooms.IndexOf(this);
                foreach (var Wall in Walls)
                {
                    if (Wall.PlayerLocation && 
                        Wall.State == State.Open)
                    {
                        nextRoom = Wall.NextRoom;
                    }
                }
                RoomActive = false;
                AllRooms[nextRoom].EnterRoom(player, AllRooms);
            }
        }
        while (RoomActive == true);
    }

    private void OpenDoor(Creature player)
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
    }

    private void SearchRoom(Creature player)
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
            string playerAction = Ask.LootOptions();
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