namespace TextAdventure
{
    public class Bonus
    {
        public const int None = 0;
        public const int Weak = 1;
        public const int Normal = 2;
        public const int Strong = 4;
        public const int Magic = 6;
    }
    public class Damage
    {
        public const int None = 0;
        public const int Minor = 2;
        public const int Normal = 4;
        public const int Major = 6;
        public const int Heavy = 8;
        public const int Powerful = 10; 
    }

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
            var player = new Creature
            (
                "Player 1", 
                Bonus.Normal,
                Damage.Minor,
                Bonus.Normal, 
                HitPoints.Player,
                new List<Item>()
                    {
                    Create.Candle(), 
                    Create.HealingPotion()
                    /*Hier Items rein*/ 
                    }
            );

            // Create list for all rooms.
            var AllRooms = new List<Room>();

            // Load first Room.
            var room0 = Load.Room0();
            AllRooms.Add(room0);
            
            // Adding to List can also be done like this:
            // player.Inventory.Add(Create.Longsword());

            // Set Room as active / entered.
            room0.EnterRoom(player, AllRooms);

            Console.WriteLine($"Player HP: {player.Hp}");         
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
                Console.WriteLine(Message.inventoryOptions);
                string choice = Console.ReadLine()!;

                // TOCHECK
                // IEnumerable could be useful here?
                // TODO 
                // Also needs to check, if another item of the
                // same type is already equipt.
                // Added enum ItemCategory for that purpose.
                // We can now check if another item with same
                // Category has status active. 
                // Needs to loop through List of items again.

                if (choice.StartsWith('E'))
                {
                    // Equip Item
                    InventoryEquip(player, choice);
                }
                else if (choice.StartsWith('U'))
                {
                    // Unequip Item
                    InventoryUnequip(player, choice);
                }
            }    
        }

        public static void InventoryEquip(Creature player, string choice)
        {
            int c = 0;
            foreach (var Item in player.Inventory)
            {
                if (choice.Contains(Item.Name))
                {
                    Item.UseItem(player);
                    c++;
                    return;
                }
            }
            if (c == 0)
            {
                Console.WriteLine("No such item\n");
            }                                
        }

        public static void InventoryUnequip(Creature player, string choice)
        {
            int c = 0;
            foreach (var Item in player.Inventory)
            {
                if (choice.Contains(Item.Name))
                {
                    Item.UnequipItem(player);
                    c++;
                    return;
                }
            }
            if (c == 0)
            {
                Console.WriteLine("No such item\n");
            }                
        }
    }
}