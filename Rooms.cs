using Microsoft.VisualBasic;

namespace TextAdventure;

    public enum WallType
    {
        None, Door, Wall, Passage
    }

    public enum State
    {
        Active, Inactive, Open, Closed
    }

    public class Room(string name, List<RoomBoundary> walls, 
                     string description, Creature monster, 
                     List<Item> loot, bool active,
                     Combat fight, string descriptionNoFight)
    {
        // Name of the room.
        public string Name {get; set;} = name;

        // Walls of the room.
        public List<RoomBoundary> Walls {get;} = walls;
    
        // Initial desctiption of the room.
        public string Description {get;} = description;
    
        // Monster in the room.
        public Creature Monster {get; set;} = monster;
    
        // List of available loot in the room.
        public List<Item> Loot {get; set;} = loot;
    
        // Determines if player is currently in this room.
        public bool RoomActive {get; set;} = active;
    
        // Instantiates the combat functionality. 
        public Combat Encounter {get; set;} = fight;
        public string DescriptionNoFight {get;} 
                      = descriptionNoFight;
    
    
        // FUNCTIONS a room can use:
    
        // Displays the Rooms description to the player.
        // Initial if Monster is still alive, AfterFight
        // if monster is dead or no monster is in this room.
        public void PresentRoom()
        {
            switch (Monster.Dead())
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
            if (!Monster.Dead())
            {
                PresentRoom();
                Encounter.Fight(player, Monster, AllRooms);
            }
            if (!player.Dead())
            {
                PresentRoom();
                // Ask player what to do till player 
                // leaves this room or the dungeon.
                do 
                {
                    // Ask player what to do. 
                    string playerAction = Ask.WhatToDo(this);

                    // TODO
                    // Go in direction
                    // Needs to set Active = false, 
                    // if player walks through door.
                    if (playerAction.StartsWith('G') ||
                        playerAction.StartsWith('g'))
                    {
                        if (playerAction.ToUpper().Contains("NORTH"))
                        {
                            Walls[0].State = State.Active;
                            playerAction = Ask.WhatToDo(this);
                        }
                        else if (playerAction.ToUpper().Contains("EAST"))
                        {
                            Walls[1].State = State.Active;
                            playerAction = Ask.WhatToDo(this);
                        }
                        else if (playerAction.ToUpper().Contains("SOUTH"))
                        {
                            Walls[2].State = State.Active;
                            playerAction = Ask.WhatToDo(this);
                        }
                        else if (playerAction.ToUpper().Contains("WEST"))
                        {
                            Walls[3].State = State.Active;
                            playerAction = Ask.WhatToDo(this);
                        }
                        else
                        {
                            Console.WriteLine("No valid direction!\n");
                        }
                    }

                    // Open door.
                    if (playerAction.StartsWith('O') ||
                        playerAction.StartsWith('o'))
                    {
                        // TODO
                    }

                    // Leave dungeon.
                    if (playerAction.StartsWith('L') ||
                        playerAction.StartsWith('l'))
                    {
                        foreach (var Wall in Walls)
                        {
                            Wall.State = State.Inactive;
                        }
                        RoomActive = false;
                        Console.WriteLine(Message.gameOver);
                    }

                    // Search room.
                    if (playerAction.StartsWith('S') ||
                       playerAction.StartsWith('s'))
                    {
                        SearchRoom(player);
                    }

                    // Open Inventory
                    if (playerAction.StartsWith('I') ||
                        playerAction.StartsWith('i'))
                    {
                        Console.WriteLine();
                        Program.Inventory(player);
                    }
                }
                while (RoomActive == true);
            }
        }

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
                string playerAction = Ask.LootOptions();

                if (playerAction.StartsWith('p') || playerAction.StartsWith('P'))
                {
                    Program.AddToInventory(player, this, playerAction);
                }
            }
        }
    }

    public class RoomBoundary(WallType type, bool key, string keyName)
    {
        public WallType Type {get;} = type;
        public string? KeyName {get;} = keyName;
        public bool Key {get;} = key;
        public State State = State.Inactive;
    }