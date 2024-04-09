namespace TextAdventure;

    class Message
    {
        // Welcome at program start.
        public static string welcome = 
            "\n" +
            "Welcome to TextAdventure!\n" + 
            "Enjoy the adventures of learning C# " +
            "which lie ahead." +
            "\n";

        public static string adventureIntro = 
            "Adventure intro text here.\n" + 
            "ENTER to continue.";

        // Player Death.
        public static string dead = 
            "GAME OVER! YOU DIED!\n";
        
        // Creature description
        public static void CreatureStats(Creature creature)
        {
            string description = 
                $"{creature.CreatureName}\n" +
                $"Atk: {creature.Attack} / Def: {creature.Defense}" + 
                $"\nHP: {creature.Hp}\n";
            Console.WriteLine(description);
        }
        public static string inventoryOptions =
            "What do you want to do?\n\n" +
            "(E)quip (Item), Go (direction),\n" + 
            "(S)earch Room, (L)eave dungeon\n";
    }
    class RoomMessage : Message
    {
        // What do you want to do in this Room?
        public static string whatToDo =
            "What do you want to do?\n\n" +
            "Open (I)nventory, Go (direction),\n" + 
            "(S)earch Room, (L)eave dungeon\n";

        // Facing a wall.
        public static string wall = 
            "You are facing a wall.\n" +
            "There is no way forward here.\n" + whatToDo + ";\n";
            
        // Facing a corridor.
        public static string corridor = 
            "You are facing a corridor.\n" + whatToDo + ";\n";

        // Facing a door.
        public static string door = 
            "You are facing a door.\n" + whatToDo +
            ", (O)pen door\n";        
    }

    class FightMessage : Message
    {
        // What do you want to do in this Fight? 
        public static string fightOptions = 
            "What do you want to do?\n" +
            "(A)ttack, (R)un, Open (I)nventory\n";

        public static string attackBlocked =
            "The attack was blocked.\n\n";

        // Creature was hit for X damage.
        public static void CreatureHit(Creature player, Creature monster)
        {
            Console.WriteLine($"\n{monster.CreatureName}" + 
            $" was hit for {player.Damage} damage.");
        }

        // Creature Death.
        public static void CreatureDeath(Creature monster)
        {
            Console.WriteLine($"{monster.CreatureName} died!\n");
        }

        // Player was hit for X damage.
        public static void PlayerHit(Creature monster)
        {
            Console.WriteLine($"You were hit for {monster.Damage}\n");
        }
    }
