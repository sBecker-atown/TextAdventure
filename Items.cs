namespace TextAdventure;

public enum ItemCategory
{
    Healing, Armor, Shield, Ammunition, Weapon, Misc
}
public class Item(int number, ItemCategory category, string name, int atk, int dmg,
int def, bool act)
{
        public int Amount {get; set;} = number;
        public  ItemCategory Category {get; set;} = category;
        public string Name {get;} = name;
        public int AttackBonus {get;} = atk;
        public int Damage {get;} = dmg;
        public int DefenseBonus {get;} = def;
        public bool Active {get; set;} = act;

        // Checks if Iteam is a Healing Item, if so applies
        // the Value stored in "Damage" to player.Hp and then
        // reduces amount in inventory by 1. If amount results in
        // 0, item is removed from inventory.
        // If item is not a Healing Item, applies all item boni
        // to player stats and sets Active status to true.
        // If item is already active, returns console message
        // informing player of such.
        public void UseItem(Creature player)
        {
            if (Category == ItemCategory.Healing)
            {
                // Add Healing "Damage" to player HP
                // but don't go over max player hp. 
                player.Hp += Damage;
                Console.WriteLine($"You were healed for {Damage} HP\n");
                if (player.Hp > HitPoints.Player)
                {
                    player.Hp = HitPoints.Player;
                }
                Amount--;
                if (Amount <=0)
                {
                    player.Inventory.Remove(this);
                }   
            }
            else if (Active == true)
            {
                Console.WriteLine("Item is already equiped.\n");
                return;
            }
            else
            {
                Active = true;
                player.Attack += AttackBonus;
                player.Damage += Damage;
                player.Defense += DefenseBonus;
                Console.WriteLine($"{Name} equiped.\n");
            }
        }

        // Checks if item is active, if it is not returns console
        // message, informing player that item is already unequiped.
        // If item is active and not a Healing Item, removes all 
        // item boni from players stats and sets Active status
        // to false.
        public void UnequipItem(Creature player)
        {
            if (Active == false)
            {
                Console.WriteLine("Item is not equiped.\n");
                return;
            }
            else if (Active == true 
                    && Category != ItemCategory.Healing)
            {
                Active = false;
                player.Attack -= AttackBonus;
                player.Damage -= Damage;
                player.Defense -= DefenseBonus;
                Console.WriteLine($"{Name} unequiped.\n");
            }
        }

        public void AddToInventory(Creature creature)
        {
            creature.Inventory.Add(this);
        }
}