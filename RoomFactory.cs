namespace TextAdventure;

public class RoomFactory
{
    private readonly Room _room0 = new (
        // Index
        000,
        // Name.
        "Courtyard",
        // Initial Description.
        "You stand at the entry of a dank crypt, vines " +
        "are\n" + "growing out of old stone, hanging " +
        "partly over the entry.\n" +
        "You see the following creature guarding " +
        "the entrance:\n",
        // Creature.
        new CreatureFactory().BirthSkeleton(),
        // Loot.
        [],
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
        "Entry Hall",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [Create.FlowerKey()],
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
        "Soldiers Graves",
        // Description.
        "This room has alcoves and benches on it's side walls, in\n" +
        "which half rotten corpses are lying. Some of them seem to be fallen\n" + 
        "soldiers from a long lost battle.\n" +
        "On of them seems to not like you entering it's resting place:\n",
        // Creature.
        new CreatureFactory().BirthZombie(),
        // Loot.
        [Create.LeatherArmor()],
        // Description with no fight/after fight
        "This room has alcoves and benches on it's side walls, in\n" +
        "which half rotten corpses are lying. Some of them seem to be fallen\n" + 
        "soldiers from a long lost battle.\n",
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
        "The entry to hell",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
        // Description with no fight/after fight
        "This room seems to be a storage room, where corpses were stripped of their\n" +
        "material possessions before cremation. Racks of half rotten clothes, rusty weapons\n" +
        "and armorpieces are gracing the walls.\n",
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
        "The Liches lair.",
        // Description.
        "",
        // Creature.
        new CreatureFactory().BirthLich(),
        // Loot.
        [],
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
        "Crematory Storage",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [Create.HealingPotion(), Create.Longsword(), Create.Shield()],
        // Description with no fight/after fight
        "This room seems to be a storage room, where corpses were stripped of their\n" +
        "material possessions before cremation. Racks of half rotten clothes, rusty weapons\n" +
        "and armorpieces are gracing the walls.\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreatePassageToRoom(002)},
            {Direction.East, RoomBoundary.CreateWall()}, 
            {Direction.South, RoomBoundary.CreateDoorWithKeyIdAndNextRoom(003,008)},
            {Direction.West, RoomBoundary.CreateWall()}
        }
    );

    public readonly Room _room6 = new (
        // Index.
        006,
        // Name.
        "TBD",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
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
        "TBD",
        // Description.
        "",
        // Creature.
        new Creature("", 0, 0, 0, 0, []),
        // Loot.
        [],
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
        "Creamatory",
        // Description.
        "This Room is the main crematory. It was used to preserve the dead.\n" +
        "One of such dead lies ontop of a large stone table in the middle of the room.\n" +
        "It is clothed in tightly wrapped bandages over with a graceful chainmail is layered.\n" +
        "The mummy greets you welcome in it's temporary home:\n",
        // Creature.
        new CreatureFactory().BirthMummy(),
        // Loot.
        [Create.HealingPotion(), Create.ChainMail()],
        // Description with no fight/after fight
        "This Room is the main crematory. It was used to preserve the dead.\n" +
        "In the middle of the room stands a larage stone table.\n" +
        "On the floor lie the fruits of your vile destruction: The destroyed mummy of\n" +
        "the elven princess Sha'leila, the Fair.\n",
        // Walls. Clockwise, starting from north.
        new Dictionary<Direction, RoomBoundary> {
            {Direction.North, RoomBoundary.CreateDoorWithKeyIdAndNextRoom(null,005)},
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
    