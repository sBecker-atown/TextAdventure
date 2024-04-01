namespace TextAdventure
{
    public class HitPoints
    {
        public const int Low = 5;
        public const int Medium = 10;
        public const int High = 15;
        public const int MiniBoss = 20;
        public const int Boss = 30;
        public const int Player = 15;
    }
    public class Creature
    {
        public string creatureName { get; set; } = string.Empty;
        public int attack;
        public int damage;
        public int defense;
        public int hp;

        
        public Creature(string name, int atk, int dmg, 
        int def, int Life)
        {
            creatureName = name;
            attack = atk;
            damage = dmg;
            defense = def;
            hp = Life;
        }
        public static void CheckHitPoints (Creature creature)
        {
            if (creature.hp == 0)
            {
                FightMessage.CreatureDeath(creature);
            }
        }

        // List of all Creatures that appear in the game.
        public static Creature player = new Creature
        (
            "Player 1", 
            Bonus.Weak,
            Damage.Minor,
            Bonus.Normal, 
            HitPoints.Player
        );
    }
}