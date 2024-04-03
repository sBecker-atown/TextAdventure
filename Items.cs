namespace TextAdventure;

    public class Item
    {
        public int amount;
        public string itemName { get; set; } = string.Empty;
        public int attackBonus;
        public int damage;
        public int defenseBonus;
        public bool active;

        // public int ItemHitpoints;

        public Item(int number, string name, int atk, int dmg,
        int def, bool act)
        {
            amount = number;
            itemName = name;
            attackBonus = atk;
            damage = dmg;
            defenseBonus = def;
            active = act;
        }
    }
    public class Items
    {
        public Item candle = new Item
        (
            1, 
            "Candle", 
            Bonus.None,
            Damage.None,
            Bonus.None, 
            false
        );
        public Item skullKey = new Item
        (
            1, 
            "Skull Key", 
            Bonus.None,
            Damage.None,
            Bonus.None, 
            false
        );
        public Item flowerKey = new Item
        (
            1, 
            "Flower Key", 
            Bonus.None, 
            Damage.None,
            Bonus.None, 
            false
        );
        public Item healingPotion = new Item
        (
            1,
            "Healing Potion",
            Bonus.None,
            Damage.Major,
            Bonus.None,
            true
        );

    }
    public class Armor : Items
    {
        public Item leatherArmor = new Item
        (
            1, 
            "Leather Armor", 
            Bonus.None, 
            Damage.None,
            Bonus.Normal, 
            false
        );
        public Item chainMail = new Item
        (
            1, 
            "Chain Mail", 
            Bonus.None, 
            Damage.None,
            Bonus.Strong, 
            false
        );
        public Item shield = new Item
        (
            1, 
            "Shield", 
            Bonus.None, 
            Damage.None,
            Bonus.Normal, 
            false
        );
    }
    public class Weapon : Items
    {
        public Item arrow = new Item
        (
            1, 
            "Arrow", 
            Bonus.None,
            Damage.None,
            Bonus.None, 
            true
        );
        public Item axe = new Item
        (
            1, 
            "Battle Axe", 
            Bonus.Weak, 
            Damage.Normal,
            Bonus.None, 
            false
        );
        public Item bow = new Item
        (
            1, 
            "Longbow", 
            Bonus.Normal, 
            Damage.Normal,
            Bonus.None, 
            false
        );
        public Item longsword = new Item
        (
            1, 
            "Longsword", 
            Bonus.Normal, 
            Damage.Normal,
            Bonus.Normal, 
            false
        );
    }