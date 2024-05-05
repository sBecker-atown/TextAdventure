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
    }
