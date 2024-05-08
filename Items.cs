namespace TextAdventure;

    public enum ItemCategory
    {
        Healing, Armor, Shield, Ammunition, Weapon, Misc
    }
    public class Item(int id, int amount, ItemCategory category, 
    string name, int atk, int dmg,
    int def, bool act)
    {
        public int ID {get;} = id;
        public int Amount {get; set;} = amount;
        public ItemCategory Category {get; set;} = category;
        public string Name {get;} = name;
        public int AttackBonus {get;} = atk;
        public int Damage {get;} = dmg;
        public int DefenseBonus {get;} = def;
        public bool Active {get; set;} = act;
    }