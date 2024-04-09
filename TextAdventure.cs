using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

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
        none, north, east, south, west,
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
            // TODO
            // If no Item in player.Inventory
                // WriteLine("Your inventory is empty.")

            foreach (var Item in player.Inventory)
            {
                Console.WriteLine($"{Item.Name}");
            }
            Console.WriteLine();
            Console.WriteLine(Message.inventoryOptions);
            string choice = Console.ReadLine()!;

            if (choice.StartsWith('E'))
            {
                // TODO 
                // Identify substring in choice, where substring
                // equals an ItemName in Inventory.
                // Then check if that Item is already active.
                    // If so, say "Item already equipt. Do you 
                    // want to unequipt {ItemName}?"
                        // If ReadLine() == 'Y'
                            // Set this.Item.Active = false.
                        // Else if ReadLine() == 'N'
                            // Leave as is.
                    // If Item not active
                        // Set this.Item.Active = true.
                // Also needs to check, if another item of the
                // same type is already equipt.
            }
        }
    }
}