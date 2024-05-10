namespace TextAdventure;
using TextAdventure.Values;

public class Create
{
    // Items.

    public static Item Candle()
    {
        Item candle = new
        (
            001,
            1, 
            ItemCategory.Misc,
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
            002,
            1, 
            ItemCategory.Misc,
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
            003,
            1, 
            ItemCategory.Misc,
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
            004,
            1,
            ItemCategory.Healing,
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
            005,
            1, 
            ItemCategory.Armor,
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
            006,
            1, 
            ItemCategory.Armor,
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
            007,
            1, 
            ItemCategory.Shield,
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
            008,
            1, 
            ItemCategory.Ammunition,
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
            009,
            1, 
            ItemCategory.Weapon,
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
            010,
            1, 
            ItemCategory.Weapon,
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
            011,
            1, 
            ItemCategory.Weapon,
            "Longsword", 
            Bonus.Normal, 
            Damage.Normal,
            Bonus.Normal, 
            false
        );
        return longsword;
    }   
}