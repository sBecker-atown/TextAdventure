using System.Security.Cryptography.X509Certificates;

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
            "Adventure intro text here.";

        // Player Death.
        public static string dead = 
            "\n" +
            "GAME OVER! YOU DIED!\n";
        
        // Creature description
        public static void CreatureStats(Creature creature)
        {
            string description = 
                $"\n{creature.creatureName}\n" +
                $"Atk: {creature.attack} / Def: {creature.defense}" + 
                $"\nHP: {creature.hp}\n";
            Console.WriteLine(description);
        }
    }
    class RoomMessage : Message
    {
        // What do you want to do in this Room?
        public static string whatToDo =
            "What do you want to do?\n\n" +
            "Open (I)nventory, Go (direction),\n" + 
            "(S)earch Room, (L)eave dungeon";

        // Facing a wall.
        public static string wall = 
            "\n" + "You are facing a wall.\n" +
            "There is no way forward here.\n" + whatToDo + ";";
            
        // Facing a corridor.
        public static string corridor = 
            "\n" + "You are facing a corridor.\n" + whatToDo + ";";

        // Facing a door.
        public static string door = 
            "\n" + "You are facing a door.\n" + whatToDo +
            ", (O)pen door";        
    }

    class FightMessage : Message
    {
        // What do you want to do in this Fight? 
        public static string fightOptions = 
            "What do you want to do?\n" +
            "(A)ttack, (R)un\n";

        public static string attackBlocked =
            "The attack was blocked.";

        // Creature was hit for X damage.
        public static void CreatureHit(Creature player, Creature monster)
        {
            Console.WriteLine($"\n{monster.creatureName}" + 
            $" was hit for {player.damage} damage.");
        }

        // Creature Death.
        public static void CreatureDeath(Creature monster)
        {
            Console.WriteLine($"{monster.creatureName} died!\n");
        }

        // Player was hit for X damage.
        public static void CreatureHit(Creature monster)
        {
            Console.WriteLine($"You were hit for {monster.damage}");
        }
    }
