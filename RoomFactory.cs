namespace TextAdventure;

public class RoomFactory
{
    private readonly Room _room0 = new (
        // Name.
        "Room 0",
        // Walls. Clockwise, starting from north.
        new List<RoomBoundary> {Create.Wall(), Create.UnlockedDoor(), Create.Wall(), Create.Passage()},
        // Initial Description.
        "You stand at the entry of a dank crypt, vines " +
        "are\n" + "growing out of old stone, hanging " +
        "partly over the entry.\n" +
        "You see the following creature guarding " +
        "the entrance:\n",
        // Creature.
        new CreatureFactory().BirthSkeleton(),
        // Loot.
        [Create.SkullKey()],
        // Active?
        false,
        // Encounter.
        new Combat(),
        // Description after fight/after fight
        "You stand at the entry of a dank crypt, vines " +
        "are\n" + "growing out of old stone, hanging " +
        "partly over the entry.\n"
    );

    private readonly Room _room1 = new (
        // Name.
        "Room 1",
        // Walls.
        [Create.Wall(), Create.Passage(), 
         Create.Wall(), Create.UnlockedDoor()],
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Encounter.
        new Combat(),
        // Description with no fight/after fight
        "This empty room is the entrance hall of the crypt.\n" +
        "Boxes are piled up at the walls and some shelves are\n" +
        "storing urns and stone slates intended for gravestones.\n"
    );

    private readonly Room _room2 = new (
        // Name.
        "Room 2",
        // Walls.
        [Create.Wall(), Create.Wall(), 
         Create.FlowerDoor(), Create.Passage()],
        // Description.
        "You stand at the entry of a dank crypt, vines " +
        "are\n" + "growing out of old stone, hanging " +
        "partly over the entry.\n" +
        "You see the following creature:\n",
        // Creature.
        new CreatureFactory().BirthZombie(),
        // Loot.
        [],
        // Active?
        false,
        // Encounter.
        new Combat(),
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines " +
        "are\n" + "growing out of old stone, hanging " +
        "partly over the entry.\n" +
        "You see the following creature:\n"
    );

    public readonly Room _room3 = new (
        // Name.
        "Room 3",
        // Walls.
        [Create.Wall(), Create.SkullDoor(), 
         Create.UnlockedDoor(), Create.Wall()],
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Encounter.
        new Combat(),
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n"
    );

    public readonly Room _room4 = new (
        // Name.
        "Room 4",
        // Walls.
        [Create.Wall(), Create.Wall(), 
         Create.Wall(), Create.SkullDoor()],
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Encounter.
        new Combat(),
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n"
    );

    public readonly Room _room5 = new (
        // Name.
        "Room 5",
        // Walls.
        [Create.FlowerDoor(), Create.Wall(), 
         Create.UnlockedDoor(), Create.Wall()],
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Encounter.
        new Combat(),
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n"
    );

    public readonly Room _room6 = new (
        // Name.
        "Room 6",
        // Walls.
        [Create.UnlockedDoor(), Create.UnlockedDoor(), 
         Create.Wall(), Create.Wall()],
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Encounter.
        new Combat(),
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n"
    );

    public readonly Room _room7 = new (
        // Name.
        "Room 7",
        // Walls.
        [Create.Wall(), Create.Passage(), 
         Create.Wall(), Create.UnlockedDoor()],
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Encounter.
        new Combat(),
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n"
    );

    private readonly Room _room8 = new (
        // Name.
        "Room 8",
        // Walls.
        [Create.UnlockedDoor(), Create.Wall(), 
         Create.Wall(), Create.Passage()],
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Encounter.
        new Combat(),
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n"
    );

    public List<Room> CreateRooms()
    {
        var all = new List<Room>
        {
            _room0,
            _room1,
            _room2,
            _room3,
            _room4,
            _room5,
            _room6,
            _room7,
            _room8
        };

        return all;
    }
        
}
    