using Microsoft.VisualBasic;

namespace TextAdventure;

    public class Room(string name, string description, 
                     Creature monster, List<Item> loot, bool active,
                     Combat fight, string descriptionNoFight)
    {
        // Name of the room.
        public string Name {get; set;} = name;
    
        // Initial desctiption of the room.
        public string Description {get;} = description;
    
        // Monster in the room.
        public Creature Monster {get; set;} = monster;
    
        // List of available loot in the room.
        public List<Item> Loot {get; set;} = loot;
    
        // Determines if player is currently in this room.
        public bool Active {get; set;} = active;
    
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
            Active = true;
            PresentRoom();
            if (!Monster.Dead())
            {
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
                    string playerAction = Ask.WhatToDo();

                    // Open Inventory
                    if (playerAction.StartsWith('I') ||
                            playerAction.StartsWith('i'))
                    {
                        Console.WriteLine();
                        Program.Inventory(player);
                    }

                    // TODO
                    // Go in direction
                    // Needs to set Active = false, 
                    // if player walks through door.

                    // Leave dungeon
                    if (playerAction.StartsWith('L') 
                        || playerAction.StartsWith('l'))
                    {
                        Active = false;
                        Console.WriteLine(Message.gameOver);
                    }

                    // Search dungeon
                    if (playerAction.StartsWith('S')
                        || playerAction.StartsWith('s'))
                    {
                        SearchRoom(player);
                    }
                }
                while (Active == true);
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