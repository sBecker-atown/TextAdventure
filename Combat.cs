using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace TextAdventure;

    static class Combat
    {
        public static int Fight(Creature player, Creature monster)
        {
            string choice;
            do 
            {
                // Present monster and prompt for player action.
                Message.CreatureStats(monster);
                Console.Write(FightMessage.fightOptions);

                // Get Player Choice
                choice = Console.ReadLine()!;

                // Check player choice and execute player action.
                if (String.Compare(choice, "A") == 0 || 
                String.Compare(choice, "Attack") == 0)
                {
                    monster.hp = PlayerAttack(player, monster);
                }
                else if (String.Compare(choice, "R") == 0 || 
                String.Compare(choice, "Run") == 0)
                {
                    // TODO
                }

                
                if (monster.hp <= 0)
                {
                    FightMessage.CreatureDeath(monster);
                }
                else if (player.hp <= 0)
                {
                    Console.Write(Message.dead);
                }
            }
            while (player.hp > 0 && monster.hp > 0 &&
                  String.Compare(choice, "R") != 0 && 
                  String.Compare(choice, "Run") != 0);
            return player.hp;
        }

        // Player attacks monster.
        public static int PlayerAttack(Creature player, Creature monster)
        {
                if (player.attack >= monster.defense) 
                {
                    monster.hp -= player.damage;
                    FightMessage.CreatureHit(player, monster);
                }
                else if (player.attack < monster.defense)
                {
                    Console.Write(FightMessage.attackBlocked);
                }
                return monster.hp;
        }

        // Monster attacks player.
        public static int MonsterAttack(Creature player, Creature monster)
        {
                if (player.attack >= monster.defense) 
                {
                    player.hp -= monster.damage;
                    FightMessage.CreatureHit(monster);
                }
                else if (player.attack < monster.defense)
                {
                    Console.Write(FightMessage.attackBlocked);
                }
                return monster.hp;
        }

        // Checks if player survives 
        // (returns true if player wins fight)
        public static bool CheckWinner(Creature player, Creature monster)
        {
            if (monster.hp <= 0)
            {
                FightMessage.CreatureDeath(monster);
                return true;
            }    
            else if (player.hp <= 0)
            {
                Console.Write(Message.dead);
                return false;
            }
            else 
            {
                return true;
            }
        }        
    }
