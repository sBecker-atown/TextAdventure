namespace TextAdventure;

public class Room(string name, string description, 
                 Creature monster, List<Item> loot, bool active,
                 Combat fight, string descriptionAfterFight)
{
    // Name of the room.
    public string Name {get; set;} = name;

    // Initial desctiption of the room.
    public string Description {get;} = description;

    // Monster in the room.
    public Creature Monster {get; set;} = monster;

    // List of available loot in the room.
    public List<Item> Loot {get; set;} = loot;

    // Determines if player is currently in this room.
    public bool Active {get; set;} = active;

    // Instantiates the combat functionality. 
    public Combat Encounter {get; set;} = fight;
    public string DescriptionAfterFight {get;} = descriptionAfterFight;


    // FUNCTIONS in a room can use:

    // Displays the Rooms initial description to the player.
    public void PresentRoom()
    {
        switch (Monster.hp)
        {
            case > 0:
                Console.WriteLine(Description);
                break;
            case <= 0:
                Console.WriteLine(DescriptionAfterFight);
                Console.WriteLine(RoomMessage.whatToDo);
                break;
        }
        
    }

    public void EnterRoom(Creature player)
    {
        Active = true;
        PresentRoom();
        if (Monster.hp > 0)
        {
            Encounter.Fight(player, Monster);
        }
    }

    public static Room LoadRoom1()
    {
        Room room = new (
            // Name.
            "Room 1",
            // Initial Description.
            "You stand at the entry of a dank crypt, vines are\n" +
            "growing out of old stone, hanging partly over the " +
            "entry.\nYou see the following creature guarding" +
            "the entrance:",
            // Creature.
            new Creature(
                "Skeleton",
                Bonus.Weak,
                Damage.Minor,
                Bonus.Weak,
                HitPoints.Low,
                []
            ),
            // Loot.
            [],
            // Active?
            false,
            // Encounter.
            new Combat(),
            // Description after fight.
            "You stand at the entry of a dank crypt, vines are\n" +
            "growing out of old stone, hanging partly over the " +
            "entry.\n"
        );

        return room;
    }

    public static Room LoadRoom2()
    {
        Room room = new (
            // Name.
            "Room 2",
            // Description.
            "You stand at the entry of a dank crypt, vines are\n" +
            "growing out of old stone, hanging partly over the entry.\n" +
            "You see the following creature:",
            // Creature.
            new Creature("", 0, 0, 0, 0, []),
            // Loot.
            [],
            // Active?
            false,
            // Encounter.
            new Combat(),
            // Description after fight.
            ""
        );
        return room;
    }
}