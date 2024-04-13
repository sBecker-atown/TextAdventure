namespace TextAdventure;

    public class Creature
    {
        public string CreatureName { get; set; } = string.Empty;
        public int Attack;
        public int Damage;
        public int Defense;
        public int Hp;
        public List<Item> Inventory;

        // Constructor.
        public Creature(string name, int atk, int dmg, 
        int def, int life, List<Item> inventory)
        {
            CreatureName = name;
            Attack = atk;
            Damage = dmg;
            Defense = def;
            Hp = life;
            Inventory = inventory;
        }

        // Checks if creature is dead (HP <= 0). Returns a bool.
        public bool Dead()
        {
            if (Hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }