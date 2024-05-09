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

    class FightMessage : Message
    {
        public static string attackBlocked =
            "The attack was blocked.\n\n";

        // Creature was hit for X damage.
        public static void Hit(Creature attacker, Creature defender)
        {
            Console.WriteLine($"\n{defender.CreatureName}" + 
            $" was hit for {attacker.Damage} damage.");
        }
        public static void CreatureAttack(Creature attacker)
        {
            Console.WriteLine($"\n{attacker.CreatureName} attacks!\n");
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
    
