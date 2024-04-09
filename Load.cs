namespace TextAdventure;

public class Load
{
    public static Room Room0()
    {
        Room room = new (
            // Name.
            "Room 0",
            // Initial Description.
            "You stand at the entry of a dank crypt, vines are\n" +
            "growing out of old stone, hanging partly over the " +
            "entry.\nYou see the following creature guarding" +
            "the entrance:\n",
            // Creature.
            new Creature(
                "Skeleton",
                Bonus.Weak,
                Damage.Minor,
                Bonus.Weak,
                HitPoints.Low,
                []
            ),
            // Loot.
            [],
            // Active?
            false,
            // Encounter.
            new Combat(),
            // Description after fight.
            "You stand at the entry of a dank crypt, vines are\n" +
            "growing out of old stone, hanging partly over the " +
            "entry.\n"
        );

        return room;
    }

    public static Room Room1()
    {
        Room room = new (
            // Name.
            "Room 1",
            // Description.
            "You stand at the entry of a dank crypt, vines are\n" +
            "growing out of old stone, hanging partly over the entry.\n" +
            "You see the following creature:\n",
            // Creature.
            new Creature("", 0, 0, 0, 0, []),
            // Loot.
            [],
            // Active?
            false,
            // Encounter.
            new Combat(),
            // Description after fight.
            ""
        );
        return room;
    }
}

public class Create
{
    public static Item Candle()
    {
        Item candle = new
        (
            1, 
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
            1, 
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
            1, 
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
            1,
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
            1, 
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
            1, 
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
            1, 
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
            1, 
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
            1, 
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
            1, 
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
            1, 
            "Longsword", 
            Bonus.Normal, 
            Damage.Normal,
            Bonus.Normal, 
            false
        );
        return longsword;
    }   
}
