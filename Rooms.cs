using Microsoft.VisualBasic;

namespace TextAdventure;

    public enum WallType
    {
        None, Door, Wall, Passage
    }

    public enum State
    {
        Active, Inactive, Open, Closed, NotVisited, CurrentLocation, Locked, Unlocked
    }

    public class Room
    {
        public Room(string name, string description, Creature monster, List<Item> loot, bool active,
                    Combat fight, string descriptionNoFight, Dictionary<Direction, RoomBoundary> connections)
        {
            Name = name;
            Description = description;
            Monster = monster;
            Loot = loot;
            RoomActive = active;
            Encounter = fight;
            DescriptionNoFight = descriptionNoFight;
            RoomConnections = connections;
        }

        // Name of the room.
        public string Name {get; set;}
    
        // Initial desctiption of the room.
        public string Description {get;}
    
        // Monster in the room.
        public Creature Monster {get; set;}
    
        // List of available loot in the room.
        public List<Item> Loot {get; set;}
    
        // Determines if player is currently in this room.
        public bool RoomActive {get; set;}
    
        // Instantiates the combat functionality. 
        public Combat Encounter {get; set;}
        public string DescriptionNoFight {get;}
        public Dictionary<Direction, RoomBoundary> RoomConnections;
    
    
        // FUNCTIONS a room can use:
    
        // Displays the Rooms description to the player.
        // Initial if Monster is still alive, AfterFight
        // if monster is dead or no monster is in this room.
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

        // Places player inside of room and loads all content
        // inside of this room. 
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
                // Ask player what to do. 
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


    // This needs to have a subclass : Door. 
    // Each door needs to have a direction and a NextRoom behind it.
    // Then we can say, if door: look at direction, and know which 
    // room is in that direction.
    // We can then simplify the doors and remove the Create.Door
    // method and create each door locally in the room. 
    // Normal Walls then don't need a key and all the other 
    // door specific stuff.
    
    // Do we need a new list for that, or can a list contain 
    // classes and subclasses mixed???

    public class RoomBoundary(int keyID, int indexOfRoom)
    {
        public int? KeyID {get;} = keyID;
        public int? NextRoom {get;} = indexOfRoom;
    }