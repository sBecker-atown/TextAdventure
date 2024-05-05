namespace TextAdventure;

    public class Load
    {
        public static void Rooms(List<Room> all)
        {
            var room0 = Room0();
            var room1 = Room1();
            var room2 = Room2();
            var room3 = Room3();
            var room4 = Room4();
            var room5 = Room5();
            var room6 = Room6();
            var room7 = Room7();
            var room8 = Room8();
            all.Add(room0);
            all.Add(room1);
            all.Add(room2);
            all.Add(room3);
            all.Add(room4);
            all.Add(room5);
            all.Add(room6);
            all.Add(room7);
            all.Add(room8);
        }
        
        public static Room Room0()
        {
            Room room = new (
                // Name.
                "Room 0",
                // Walls. Clockwise, starting from north.
                [Create.Wall(), Create.UnlockedDoor(), 
                 Create.Wall(), Create.Passage()],
                // Initial Description.
                "You stand at the entry of a dank crypt, vines " +
                "are\n" + "growing out of old stone, hanging " +
                "partly over the entry.\n" +
                "You see the following creature guarding " +
                "the entrance:\n",
                // Creature.
                Birth.Skeleton(),
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
    
            return room;
        }
    
        public static Room Room1()
        {
            Room room = new (
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
            return room;
        }

        public static Room Room2()
        {
            Room room = new (
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
                Birth.Zombie(),
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
            return room;
        }

        public static Room Room3()
        {
            Room room = new (
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
            return room;
        }

        public static Room Room4()
        {
            Room room = new (
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
            return room;
        }

        public static Room Room5()
        {
            Room room = new (
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
            return room;
        }

        public static Room Room6()
        {
            Room room = new (
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
            return room;
        }

        public static Room Room7()
        {
            Room room = new (
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
            return room;
        }

        public static Room Room8()
        {
            Room room = new (
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
            return room;
        }
        
    }
    
    public class Create
    {
        // Walltypes.
        public static RoomBoundary Wall()
        {
            RoomBoundary wallType = new
            (
                WallType.Wall,
                false,
                false,
                000,
                "",
                State.Locked,
                0
            );
            return wallType;
        }

        public static RoomBoundary UnlockedDoor()
        {
            RoomBoundary wallType = new
            (
                WallType.Door,
                false,
                false,
                000,
                "",
                State.Unlocked,
                0
            );
            return wallType;
        }

        public static RoomBoundary SkullDoor()
        {
            RoomBoundary wallType = new
            (
                WallType.Door,
                false,
                true,
                002,
                "Skull Key",
                State.Locked,
                0
            );
            return wallType;
        }

        public static RoomBoundary FlowerDoor()
        {
            RoomBoundary wallType = new
            (
                WallType.Door,
                false,
                true,
                003,
                "Flower Key",
                State.Locked,
                0
            );
            return wallType;
        }

        public static RoomBoundary Passage()
        {
            RoomBoundary wallType = new
            (
                WallType.None,
                false,
                false,
                000,
                "",
                State.Open,
                0
            );
            return wallType;
        }


        // Items.
        public static Item Candle()
        {
            Item candle = new
            (
                001,
                1, 
                ItemCategory.Misc,
                "Candle", 
                Bonus.None,
                Damage.None,
                Bonus.None, 
                false
            );
            return candle;
        }
    
        public static Item SkullKey()
        {
            Item skullKey = new
            (
                002,
                1, 
                ItemCategory.Misc,
                "Skull Key", 
                Bonus.None,
                Damage.None,
                Bonus.None, 
                false
            );
            return skullKey;
        }
    
        public static Item flowerKey()
        {
            Item flowerKey = new
            (
                003,
                1, 
                ItemCategory.Misc,
                "Flower Key", 
                Bonus.None, 
                Damage.None,
                Bonus.None, 
                false
            );
            return flowerKey;
        }
    
        public static Item HealingPotion()
        {
            Item healingPotion = new
            (
                004,
                1,
                ItemCategory.Healing,
                "Healing Potion",
                Bonus.None,
                Damage.Major,
                Bonus.None,
                true
            );
            return healingPotion;
        }
    
        public static Item LeatherArmor()
        {
            Item leatherArmor = new
            (
                005,
                1, 
                ItemCategory.Armor,
                "Leather Armor", 
                Bonus.None, 
                Damage.None,
                Bonus.Normal, 
                false
            );
            return leatherArmor;
        }
        
        public static Item ChainMail()
        {
            Item chainMail = new
            (
                006,
                1, 
                ItemCategory.Armor,
                "Chain Mail", 
                Bonus.None, 
                Damage.None,
                Bonus.Strong, 
                false
            );
            return chainMail;
        }
    
        public static Item Shield()
        {
            Item shield = new
            (
                007,
                1, 
                ItemCategory.Shield,
                "Shield", 
                Bonus.None, 
                Damage.None,
                Bonus.Normal, 
                false
            );
            return shield;
        }
    
        public static Item Arrow()
        {
            Item arrow = new
            (
                008,
                1, 
                ItemCategory.Ammunition,
                "Arrow", 
                Bonus.None,
                Damage.None,
                Bonus.None, 
                true
            );
            return arrow;
        }
        
        public static Item Axe()
        {
            Item axe = new
            (
                009,
                1, 
                ItemCategory.Weapon,
                "Battle Axe", 
                Bonus.Weak, 
                Damage.Normal,
                Bonus.None, 
                false
            );
            return axe;
        }
    
        public static Item Bow()
        {
            Item bow = new
            (
                010,
                1, 
                ItemCategory.Weapon,
                "Longbow", 
                Bonus.Normal, 
                Damage.Normal,
                Bonus.None, 
                false
            );
            return bow;
        }
            
        public static Item Longsword()
        {
            Item longsword = new
            (
                011,
                1, 
                ItemCategory.Weapon,
                "Longsword", 
                Bonus.Normal, 
                Damage.Normal,
                Bonus.Normal, 
                false
            );
            return longsword;
        }   
    }

    public class Birth
    {
        public static Creature Player()
        {
            Creature player = new
            (
                "Player 1", 
                Bonus.Normal,
                Damage.Minor,
                Bonus.Normal, 
                HitPoints.Player,
                new List<Item>()
                    {
                    Create.Candle(), 
                    Create.HealingPotion()
                    /*Hier Items rein*/ 
                    }
            );
            return player;
        }

        public static Creature Skeleton()
        {
            Creature skeleton = new
            (
                "Skeleton",
                Bonus.Weak,
                Damage.Minor,
                Bonus.Weak,
                HitPoints.Low,
                []
            );
        return skeleton;
        }

        public static Creature Zombie()
        {
            Creature zombie = new
            (
                "Zombie",
                Bonus.Normal,
                Damage.Normal,
                Bonus.Normal,
                HitPoints.Low,
                []
            );
        return zombie;
        }

        public static Creature Mummy()
        {
            Creature mummy = new
            (
                "Mummy",
                Bonus.Strong,
                Damage.Major,
                Bonus.Strong,
                HitPoints.High,
                []
            );
        return mummy;
        }

        public static Creature Lich()
        {
            Creature lich = new
            (
                "Lich",
                Bonus.Magic,
                Damage.Heavy,
                Bonus.Magic,
                HitPoints.MiniBoss,
                []
            );
        return lich;
        }
    }
    