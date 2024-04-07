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
                new List<Item>(){/*Hier Items rein*/}
            );

            // Create list for all rooms.
            var AllRooms = new List<Room>();

            // Load first Room.
            var room1 = Room.LoadRoom1();
            AllRooms.Add(room1);

            // Set Room as active / entered.
            room1.EnterRoom(player);

            Console.WriteLine($"Player HP: {player.hp}");
            // TODO 
            // Make Combat a part of Room, so we can use
            // room1.Fight(player).
            

            // TODO 
            // Room needs a state after fight, for player to loot
            // monster and room.
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
}