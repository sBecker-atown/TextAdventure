using System;
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

    public class Room
    {
        public string Description { get; set; } = string.Empty;
        public Direction direction;
    }
    public enum Direction
    {
        none, north, east, south, west,
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Message.welcome);
            Console.WriteLine(RoomMessage.wall);
            Console.WriteLine(RoomMessage.door);
            Message.CreatureStats(Creature.player);
            Creature.CheckHitPoints(Creature.player);
        }
    }
}