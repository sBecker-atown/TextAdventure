namespace TextAdventure;

    public class Combat
    {
        public void Fight(Creature player, Creature monster,
        List<Room> AllRooms)
        {
            // Fight while both player and monster are alive.
            do 
            {
                // Present monster and prompt for player action.
                Message.CreatureStats(monster);
                string playerAction = Ask.FightOptions();

                // Check player choice and execute player action.
                
                // Player wants to attack: 
                if (playerAction.StartsWith('A') || playerAction.StartsWith('a'))
                {
                    // Player attacks
                    monster.Hp = PlayerAttack(player, monster);

                    // Wait for enter, cause programm would be 
                    // too fast.
                    Console.ReadLine();

                    // Check if Monster is Dead and do appropriate
                    // actions. If monster alive, monster attacks.
                    // If monster dead, report death to player.
                    if (!monster.Dead())
                    {
                        player.Hp = MonsterAttack(player, monster);
                        
                        // Check if player is alive. If not, display 
                        // Game Over Message.
                        if (player.Dead())
                        {
                            Console.WriteLine(Message.dead);
                            break;
                        }
                    }
                    else if (monster.Dead())
                    {
                        FightMessage.CreatureDeath(monster);
                    }
                }
                // Player wants to run:
                else if (playerAction.StartsWith('R') || 
                        playerAction.StartsWith('r'))
                {
                    Console.WriteLine("\nYou run away.\n");
                    AllRooms[0].EnterRoom(player, AllRooms);
                }
                // Player wants to open Inventory
                else if (playerAction.StartsWith('I') ||
                        playerAction.StartsWith('i'))
                {
                    Console.WriteLine();
                    Program.Inventory(player);
                }
            }
            while (player.Hp > 0 && monster.Hp > 0);
        }

        // Player attacks monster.
        public int PlayerAttack
        (Creature player, Creature monster)
        {
            if (player.Attack >= monster.Defense) 
            {
                monster.Hp -= player.Damage;
                FightMessage.CreatureHit(player, monster);
            }
            else if (player.Attack < monster.Defense)
            {
                Console.Write(FightMessage.attackBlocked);
            }
            return monster.Hp;
        }

        // Monster attacks player.
        public int MonsterAttack
        (Creature player, Creature monster)
        {
            Console.WriteLine($"{monster.CreatureName} attacks!\n");
            if (monster.Attack >= player.Defense) 
            {
                player.Hp -= monster.Damage;
                FightMessage.PlayerHit(monster);
            }
            else if (monster.Attack < player.Defense)
            {
                Console.Write(FightMessage.attackBlocked);
            }
            return player.Hp;
        }

        // Checks if player survives 
        // (returns true if player wins fight)
        // Currently unused.
        /* 
        public bool CheckWinner
        (Creature player, Creature monster)
        {
            if (monster.Hp <= 0)
            {
                FightMessage.CreatureDeath(monster);
                return true;
            }    
            else if (player.Hp <= 0)
            {
                Console.Write(Message.dead);
                return false;
            }
            else 
            {
                return true;
            }
        }        
        */
    }
    
