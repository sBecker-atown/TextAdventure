namespace TextAdventure;
using TextAdventure.Values;

    public class Creature
    {
        public string CreatureName { get; set; } = string.Empty;
        public int Attack {get; private set;}
        public int Damage {get; private set;}
        public int Defense {get; private set;}
        public int Hp {get; private set;}
        public List<Item> Inventory;
        public bool IsDead => Hp <= 0;
        
        // Equals
        /* IsDead
        {
            get
            {
                return Hp <= 0;
            }
        }*/

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

        public void TakeDamage(Creature creature)
        {
            if (creature.Attack >= Defense) 
            {
                FightMessage.Hit(creature, this);
                Hp -= creature.Damage;
                return;
            }
            Console.Write(FightMessage.attackBlocked);
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
                string playerAction = AskForInput.InventoryOptions();

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
            foreach (var item in Inventory)
            {
                if (action.Contains(item.Name))
                {
                    // Get item position in list.
                    var index = Inventory.IndexOf(item);

                    // TODO
                    // Check against other items in inventory
                    UseItem(item);
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
            foreach (var item in Inventory)
            {
                if (action.Contains(item.Name))
                {
                    UnequipItem(item);
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

        // Checks if Item is a Healing Item, if so applies
        // the Value stored in "Damage" to player.Hp and then
        // reduces amount in inventory by 1. If amount results in
        // 0, item is removed from inventory.
        // If item is not a Healing Item, applies all item boni
        // to player stats and sets Active status to true.
        // If item is already active, returns console message
        // informing player of such.
        public void UseItem(Item item)
        {
            if (item.Category == ItemCategory.Healing)
            {
                // Add Healing "Damage" to player HP
                // but don't go over max player hp. 
                Hp += item.Damage;
                Console.WriteLine($"\nYou were healed for {item.Damage} HP\n");
                if (Hp > HitPoints.Player)
                {
                    Hp = HitPoints.Player;
                }
                item.Amount--;
                if (item.Amount <=0)
                {
                    Inventory.Remove(item);
                }   
            }
            else if (item.Active == true)
            {
                Console.WriteLine("Item is already equiped.\n");
                return;
            }
            else
            {
                item.Active = true;
                Attack += item.AttackBonus;
                Damage += item.Damage;
                Defense += item.DefenseBonus;
                Console.WriteLine($"{item.Name} equiped.\n");
            }
        }

        // Checks if item is active, if it is not returns console
        // message, informing player that item is already unequiped.
        // If item is active and not a Healing Item, removes all 
        // item boni from players stats and sets Active status
        // to false.
        public void UnequipItem(Item item)
        {
            if (item.Active == false)
            {
                Console.WriteLine("Item is not equiped.\n");
                return;
            }
            else if (item.Active == true 
                    && item.Category != ItemCategory.Healing)
            {
                item.Active = false;
                Attack -= item.AttackBonus;
                Damage -= item.Damage;
                Defense -= item.DefenseBonus;
                Console.WriteLine($"{item.Name} unequiped.\n");
            }
        }
    }