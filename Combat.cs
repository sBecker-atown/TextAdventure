using Microsoft.VisualBasic;

namespace TextAdventure;

    public class Combat
    {
        public void Fight(Creature player, Creature monster)
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
                    // Player attacks
                    monster.hp = PlayerAttack(player, monster);
                    // Wait for enter, cause programm would be 
                    // too fast.
                    Console.ReadLine();

                    // Check if Monster is Dead.
                    monster.CheckMonsterHitPoints();
                    
                    // TODO
                    // Needs an if to exit loop if Monster is Dead.
                    // Could make CheckHitPoints a bool and name 
                    // it CheckIfDead. 

                    // Monster attacks if monster still alive
                    player.hp = MonsterAttack(player, monster);
                    
                    // Check player HP.
                    player.CheckPlayerHitPoints();
                }
                else if (String.Compare(choice, "R") == 0 || 
                        String.Compare(choice, "Run") == 0)
                {
                    // TODO
                    // Reset player to room1.
                }
                else if (String.Compare(choice, "I") == 0 ||
                        String.Compare(choice, "Inventory") == 0)
                {
                    // TODO 
                    // Open and use Inventory.
                }
            }
            while (player.hp > 0 && monster.hp > 0);
        }

        // Player attacks monster.
        public int PlayerAttack
        (Creature player, Creature monster)
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
        public int MonsterAttack
        (Creature player, Creature monster)
        {
            Console.WriteLine($"{monster.creatureName} attacks!");
            if (monster.attack >= player.defense) 
            {
                player.hp -= monster.damage;
                FightMessage.PlayerHit(monster);
            }
            else if (monster.attack < player.defense)
            {
                Console.Write(FightMessage.attackBlocked);
            }
            return player.hp;
        }

        // Checks if player survives 
        // (returns true if player wins fight)
        // Currently unused.
        public bool CheckWinner
        (Creature player, Creature monster)
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
