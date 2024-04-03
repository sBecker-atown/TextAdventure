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
    public static class Damage
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
            // Instantiate player. 
            var player = new Creature
            (
                "Player 1", 
                Bonus.Weak,
                Damage.Minor,
                Bonus.Normal, 
                HitPoints.Player,
                new List<Item>(){/*Hier Items rein*/}
            );

            // Create all rooms.
            var AllRooms = new List<Room>();
            AllRooms = Room.CreateRooms(AllRooms);

            GameStart();

            Console.WriteLine(AllRooms[0].Description);
            Combat.Fight(player, AllRooms[0].Monster);
        }
        
        public static void GameStart()
        {
            // Greet the player.
            Console.WriteLine(Message.welcome);

            // Wait for player input to start the game.
            Console.WriteLine("Press ENTER to start.");
            Console.ReadLine();

            Console.WriteLine(Message.adventureIntro);
            Console.WriteLine("ENTER to continue.");
            Console.ReadLine();
        }
    }
}