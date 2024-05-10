namespace TextAdventure;

public class RoomFactory
{
    private readonly Room _room0 = new (
        // Index
        000,
        // Name.
        "Room 0",
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
        // Description after fight/after fight
        "You stand at the entry of a dank crypt, vines " +
        "are\n" + "growing out of old stone, hanging " +
        "partly over the entry.\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreateWall()},
            {Direction.East, RoomBoundary.CreatePassageToRoom(001)}, 
            {Direction.South, RoomBoundary.CreateWall()},
            {Direction.West, RoomBoundary.CreatePassageToRoom(000)}
        }
    );

    private readonly Room _room1 = new (
        // Index.
        001,
        // Name.
        "Room 1",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Description with no fight/after fight
        "This empty room is the entrance hall of the crypt.\n" +
        "Boxes are piled up at the walls and some shelves are\n" +
        "storing urns and stone slates intended for gravestones.\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreateWall()},
            {Direction.East, RoomBoundary.CreatePassageToRoom(002)}, 
            {Direction.South, RoomBoundary.CreateWall()},
            {Direction.West, RoomBoundary.CreatePassageToRoom(000)}
        }
    );

    private readonly Room _room2 = new (
        // Index.
        002,
        // Name.
        "Room 2",
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
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines " +
        "are\n" + "growing out of old stone, hanging " +
        "partly over the entry.\n" +
        "You see the following creature:\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreateWall()},
            {Direction.East, RoomBoundary.CreateWall()}, 
            {Direction.South, RoomBoundary.CreatePassageToRoom(005)},
            {Direction.West, RoomBoundary.CreatePassageToRoom(001)}
        }
    );

    public readonly Room _room3 = new (
        // Index.
        003,
        // Name.
        "Room 3",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreateWall()},
            {Direction.East, RoomBoundary.CreateDoorWithKeyIdAndNextRoom(002,004)}, 
            {Direction.South, RoomBoundary.CreatePassageToRoom(006)},
            {Direction.West, RoomBoundary.CreateWall()}
        }
    );

    public readonly Room _room4 = new (
        // Index.
        004,
        // Name.
        "Room 4",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreateWall()},
            {Direction.East, RoomBoundary.CreateWall()}, 
            {Direction.South, RoomBoundary.CreateWall()},
            {Direction.West, RoomBoundary.CreatePassageToRoom(003)}
        }
    );

    public readonly Room _room5 = new (
        // Index.
        005,
        // Name.
        "Room 5",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreatePassageToRoom(002)},
            {Direction.East, RoomBoundary.CreateWall()}, 
            {Direction.South, RoomBoundary.CreatePassageToRoom(008)},
            {Direction.West, RoomBoundary.CreateWall()}
        }
    );

    public readonly Room _room6 = new (
        // Index.
        006,
        // Name.
        "Room 6",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreateDoorWithKeyIdAndNextRoom(003,003)},
            {Direction.East, RoomBoundary.CreatePassageToRoom(007)}, 
            {Direction.South, RoomBoundary.CreateWall()},
            {Direction.West, RoomBoundary.CreateWall()}
        }
    );

    public readonly Room _room7 = new (
        // Index.
        007,
        // Name.
        "Room 7",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreateWall()},
            {Direction.East, RoomBoundary.CreatePassageToRoom(008)}, 
            {Direction.South, RoomBoundary.CreateWall()},
            {Direction.West, RoomBoundary.CreatePassageToRoom(006)}
        }
    );

    private readonly Room _room8 = new (
        // Index.
        008,
        // Name.
        "Room 8",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Active?
        false,
        // Description with no fight/after fight
        "You stand at the entry of a dank crypt, vines are\n" +
        "growing out of old stone, hanging partly over the entry.\n" +
        "You see the following creature:\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreatePassageToRoom(005)},
            {Direction.East, RoomBoundary.CreateWall()}, 
            {Direction.South, RoomBoundary.CreateWall()},
            {Direction.West, RoomBoundary.CreatePassageToRoom(007)}
        }
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
    