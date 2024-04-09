namespace TextAdventure;

public class Item(int number, string name, int atk, int dmg,
int def, bool act)
{
        public int Amount {get; set;} = number;
        public string Name { get; set; } = name;
        public int AttackBonus {get;} = atk;
        public int Damage {get;} = dmg;
        public int DefenseBonus {get;} = def;
        public bool Active {get; set;} = act;
}