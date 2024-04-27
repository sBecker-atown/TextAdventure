using System.Collections;
using System.Diagnostics.SymbolStore;

namespace TextAdventure;

    public enum Direction
    {
        None, North, East, South, West,
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Start Game with welcome message & intro text
            GameStart();

            // Instantiate player. 
            var player = Birth.Player();

            // Create list for all rooms.
            var AllRooms = new List<Room>();

            // Load all rooms.
            Load.Rooms(AllRooms);
            
            // Adding to List can also be done like this:
            // player.Inventory.Add(Create.Longsword());

            // Set Room as active / entered.
            AllRooms[0].EnterRoom(player, AllRooms);        
        }

        public static void GameStart()
        {
            // Greet the player.
            Console.WriteLine(Message.welcome);

            // Wait for player input to start the game.
            Console.WriteLine("Press ENTER to start.");
            Console.ReadLine();

            Console.WriteLine(Message.adventureIntro);
            Console.ReadLine();
        }

        public static void Inventory(Creature player)
        {
            // If Inventory empty, say inventory empty.
            if (player.Inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty\n");
                return;
            }
            else
            {
                // List all Inventory items
                foreach (var Item in player.Inventory)
                {
                    Console.WriteLine($"{Item.Name}");
                }
                Console.WriteLine();
                string playerAction = Ask.InventoryOptions();

                // TOCHECK
                // IEnumerable could be useful here?

                // TODO 
                // Also needs to check, if another item of the
                // same type is already equipt.
                // Added enum ItemCategory for that purpose.
                // We can now check if another item with same
                // Category has status active. 
                // Needs to loop through List of items again.

                if (playerAction.StartsWith('E')
                    || playerAction.StartsWith('e'))
                {
                    // Equip Item
                    InventoryEquip(player, playerAction);
                }
                else if (playerAction.StartsWith('U') 
                        || playerAction.StartsWith('u'))
                {
                    // Unequip Item
                    InventoryUnequip(player, playerAction);
                }
                else if (playerAction.StartsWith('C')
                        || playerAction.StartsWith('c'))
                {
                    // Close inventory
                    Console.WriteLine("Inventory closed.\n");
                    return;
                }
            }    
        }

        public static void InventoryEquip(Creature player, 
        string action)
        {
            var itemExists = false;
            foreach (var Item in player.Inventory)
            {
                if (action.Contains(Item.Name))
                {
                    // Get item position in list.
                    var index = player.Inventory.IndexOf(Item);

                    // TODO
                    // Check against other items in inventory
                    Item.UseItem(player);
                    itemExists = true;
                    return;
                }
            }
            if (itemExists == false)
            {
                Console.WriteLine("No such item\n");
            }                                
        }

        public static void InventoryUnequip(Creature player, 
        string action)
        {
            var itemExists = false;
            foreach (var Item in player.Inventory)
            {
                if (action.Contains(Item.Name))
                {
                    Item.UnequipItem(player);
                    itemExists = true;
                    return;
                }
            }
            if (itemExists == false)
            {
                Console.WriteLine("No such item\n");
            }                
        }

        public static void AddToInventory(Creature player, 
        Room room, string action)
        {
            var itemExists = false;
            foreach (var Item in room.Loot)
            {
                if (action.Contains(Item.Name))
                {
                    // Check if Item already exists and if so 
                    // increase amount. Else add item to inventory 
                    // and remove item from list of loot in this room.
                    var playerHasItem = false;
                    for (int i = 0; i < player.Inventory.Count; i++)
                    {
                        if (string.Compare(action, 
                        player.Inventory[i].Name) == 0)
                        {
                            player.Inventory[i].Amount++;
                            playerHasItem = true;
                            itemExists = true;
                            room.Loot.Remove(Item);
                            Console.WriteLine($"{Item.Name} added" +
                            " to inventory\n");
                            return;
                        }
                    }
                    if (playerHasItem == false)
                    {
                        player.Inventory.Add(Item);
                        playerHasItem = true;
                        itemExists = true;
                        room.Loot.Remove(Item);
                        Console.WriteLine($"{Item.Name} added to" +
                        " inventory\n");
                        return;
                    }       
                }
            }
            if (itemExists == false)
            {
                Console.WriteLine("No such item\n");
            }                                
        }
    }
