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
                if (InputAnalysis.WantsToAttack(playerAction))
                {
                    // Player attacks
                    monster.Hp = PlayerAttack(player, monster);

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
                else if (InputAnalysis.WantsToRun(playerAction))
                {
                    Console.WriteLine("\nYou run away.\n");
                    AllRooms[0].EnterRoom(player, AllRooms);
                }
                // Player wants to open Inventory
                else if (InputAnalysis.WantsToOpenInventory(playerAction))
                {
                    Console.WriteLine();
                    player.OpenInventory();
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
    }
    
