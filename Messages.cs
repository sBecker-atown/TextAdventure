using System.Xml.Serialization;

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
        
        // Player Death.
        public static string gameOver = 
            "GAME OVER! Thank you for playing!\n";

        // Creature description
        public static void CreatureStats(Creature creature)
        {
            string description = 
                $"{creature.CreatureName}\n" +
                $"Atk: {creature.Attack} / Def: {creature.Defense}" + 
                $"\nHP: {creature.Hp}\n";
            Console.WriteLine(description);
        }
    }

    class RoomMessage : Message
    {
        // Facing a wall.
        public static string wall = 
            "You are facing a wall.\n" +
            "There is no way forward here.\n" + Ask.WhatToDo() + ";\n";
            
        // Facing a corridor.
        public static string corridor = 
            "You are facing a corridor.\n" + Ask.WhatToDo() + ";\n";

        // Facing a door.
        public static string door = 
            "You are facing a door.\n" + Ask.WhatToDo() +
            ", (O)pen door\n";        
    }

    class FightMessage : Message
    {
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

    class Ask
    {
        public static string WhatToDo()
        {
            // What do you want to do in this Room?
            string whatToDo =
            "What do you want to do?\n\n" +
            "Open (I)nventory, (G)o (direction),\n" + 
            "(S)earch Room, (L)eave dungeon\n";
            
            Console.WriteLine(whatToDo);

            string choice;
            do
            {
                choice = Console.ReadLine()!;
            }
            while (string.IsNullOrEmpty(choice));
            
            return choice;
        }

        public static string InventoryOptions()
        {
            string inventoryOptions =
            "What do you want to do?\n\n" +
            "(E)quip (Item), (U)nequipt (Item), (C)lose Inventory\n";

            Console.WriteLine(inventoryOptions);

            string choice;
            do
            {
                choice = Console.ReadLine()!;
            }
            while (string.IsNullOrEmpty(choice));
            
            return choice;
        }

        public static string LootOptions()
        {
            string lootOptions =
            "What do you want to do?\n\n" +
            "(P)ick up (Item), (S)top looting\n";

            Console.WriteLine(lootOptions);

            string choice;
            do
            {
                choice = Console.ReadLine()!;
            }
            while (string.IsNullOrEmpty(choice));
            
            return choice;
        }

        public static string FightOptions()
        { 
            string fightOptions = 
            "What do you want to do?\n" +
            "(A)ttack, (R)un, Open (I)nventory\n";

            Console.WriteLine(fightOptions);

            string choice;
            do
            {
                choice = Console.ReadLine()!;
            }
            while (string.IsNullOrEmpty(choice));
            
            return choice;
        }
    }
