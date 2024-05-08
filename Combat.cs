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
                    monster.TakeDamage(player);

                    Thread.Sleep(300);

                    // Check if Monster is Dead and do appropriate
                    // actions. If monster alive, monster attacks.
                    // If monster dead, report death to player.
                    if (!monster.IsDead)
                    {
                        FightMessage.CreatureAttack(monster);
                        player.TakeDamage(monster);
                        
                        // Check if player is alive. If not, display 
                        // Game Over Message.
                        if (player.IsDead)
                        {
                            Console.WriteLine(Message.dead);
                            break;
                        }
                    }
                    else if (monster.IsDead)
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
    }
    
