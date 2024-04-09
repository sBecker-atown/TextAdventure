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
        switch (Monster.Hp)
        {
            case > 0:
                Console.WriteLine(Description);
                break;
            case <= 0:
                Console.WriteLine(DescriptionAfterFight);
                Console.WriteLine(RoomMessage.whatToDo);
                Console.ReadLine();
                break;
        }
        
    }

    public void EnterRoom(Creature player, List<Room> AllRooms)
    {
        Active = true;
        PresentRoom();
        if (!Monster.Dead())
        {
            Encounter.Fight(player, Monster, AllRooms);
        }
        if (!player.Dead())
        {
            PresentRoom();
        }
    }
}