namespace TextAdventure;

    public class Creature
    {
        public string CreatureName { get; set; } = string.Empty;
        public int Attack;
        public int Damage;
        public int Defense;
        public int Hp;
        public List<Item> Inventory;

        // Constructor.
        public Creature(string name, int atk, int dmg, 
        int def, int life, List<Item> inventory)
        {
            CreatureName = name;
            Attack = atk;
            Damage = dmg;
            Defense = def;
            Hp = life;
            Inventory = inventory;
        }

        // Checks if creature is dead (HP <= 0). Returns a bool.
        public bool Dead()
        {
            if (Hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OpenInventory()
        {
            // If Inventory empty, say inventory empty.
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty\n");
                return;
            }
            else
            {
                // List all Inventory items
                foreach (var Item in Inventory)
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

                if (InputAnalysis.WantsToEquip(playerAction))
                {
                    // Equip Item
                    InventoryEquip(playerAction);
                }
                else if (InputAnalysis.WantsToUnequip(playerAction))
                {
                    // Unequip Item
                    InventoryUnequip(playerAction);
                }
                else if (InputAnalysis.WantsToCloseInventory(playerAction))
                {
                    // Close inventory
                    Console.WriteLine("Inventory closed.\n");
                    return;
                }
            }    
        }

        public void InventoryEquip(string action)
        {
            var itemExists = false;
            foreach (var Item in Inventory)
            {
                if (action.Contains(Item.Name))
                {
                    // Get item position in list.
                    var index = Inventory.IndexOf(Item);

                    // TODO
                    // Check against other items in inventory
                    Item.UseItem(this);
                    itemExists = true;
                    return;
                }
            }
            if (itemExists == false)
            {
                Console.WriteLine("No such item\n");
            }                                
        }

        public void InventoryUnequip(string action)
        {
            var itemExists = false;
            foreach (var Item in Inventory)
            {
                if (action.Contains(Item.Name))
                {
                    Item.UnequipItem(this);
                    itemExists = true;
                    return;
                }
            }
            if (itemExists == false)
            {
                Console.WriteLine("No such item\n");
            }                
        }

        public void AddToInventory(Room room, string action)
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
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (action.Contains($"{Inventory[i].Name}"))
                        {
                            Inventory[i].Amount++;
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
                        Inventory.Add(Item);
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