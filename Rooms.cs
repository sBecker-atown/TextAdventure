using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace TextAdventure;

public class Room
{
    public string Description { get; set; } = string.Empty;
    public Creature Monster;
    public List<Item> Loot;

    public Room(string description, Creature monster, List<Item> loot)
    {
        Description = description;
        Monster = monster;
        Loot = loot;
    }

    public static List<Room> CreateRooms(List<Room> rooms)
    {
        Room room1 = new Room
        (
            "You stand at the entry of a dank crypt, vines are\n" +
            "growing out of old stone, hanging partly over the entry.\n" +
            "You see the following creature:",
            new Creature(
                "Wolf",
                Bonus.Weak,
                Damage.Minor,
                Bonus.Weak,
                HitPoints.Low,
                []
            ),
            []
        );
        rooms.Add(room1);
        return rooms;
    }
}