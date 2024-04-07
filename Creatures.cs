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
        public List<Item> inventory;

        
        public Creature(string name, int atk, int dmg, 
        int def, int life, List<Item> inventory)
        {
            creatureName = name;
            attack = atk;
            damage = dmg;
            defense = def;
            hp = life;
            this.inventory = inventory;
        }
        public void CheckMonsterHitPoints()
        {
            if (hp <= 0)
            {
                FightMessage.CreatureDeath(this); // "this" refers to THIS specific creature.
            }
        }
        public void CheckPlayerHitPoints()
        {
            if (hp <= 0)
            {
                Console.Write(Message.dead);
            }
        } 
    }
}