namespace TextAdventure;
using TextAdventure.Values;

public class Gameworld
{
    // This is the player:
    private Creature _player = new (
            "Player 1", 
            Bonus.Normal,
            Damage.Minor,
            Bonus.Normal, 
            HitPoints.Player,
            new List<Item>()
                {
                Create.Candle(), 
                Create.HealingPotion()
                /*Hier Items rein*/ 
                }
        );

    // Which room is the player in? 
    private Room _activeRoom = null!;

    // Where is the player in relation to the walls. (Which wall are we going to?)
    private Direction _playerLocation = Direction.None;

    // Create Gamemap.
    private List<Room> _gameMap = new Map().CreateMap();



    // Main Gameworld Method.

    public void Start()
    {
        // Start Game with welcome message & intro text
        Introduction();
        
        // Enter first room.
        EnterRoom(_gameMap[0]);

        if (!_activeRoom.Monster.IsDead)
        {
            StartEncounter();
        }
        PlayerAction();
    }
    

    // Methods to use.

    private static void Introduction()
    {
        // Greet the player.
        Console.WriteLine(Message.welcome);
        // Wait for player input to start the game.
        Console.WriteLine("Press ENTER to start.");
        Console.ReadLine();
        Console.WriteLine(Message.adventureIntro);
        Console.ReadLine();
    }
    

    // What does the player want to do? 

    private string WhatToDo()
    {
        // TryGetValue returns a bool, which is true if value for specific key exists in dictionary. If not it is false.
        if (_activeRoom.RoomBoundaries.TryGetValue(_playerLocation, out var currentWall))
        {
            if (currentWall.KeyID == null && currentWall.NextRoom == null)
            {
                AskForInput.WhatToDoAtWall();
            }
            else if (currentWall.KeyID == null && currentWall.NextRoom != null)
            {
                AskForInput.WhatToDoAtPassage();
            }
            else if (currentWall.KeyID != null && currentWall.NextRoom != null)
            {
                AskForInput.WhatToDoAtDoor();
            }
        }
        AskForInput.WhatToDo();

        string choice;
        do
        {
            choice = Console.ReadLine()!;
        }
        while (string.IsNullOrEmpty(choice));
        
        return choice;
    }


    // Entering a room.

    public void EnterRoom(Room newRoom)
    {
        _activeRoom = newRoom;
        _activeRoom.PresentRoom();
    }


    // Begin an encounter and fight.

    private void StartEncounter()
    {
        Fight();
        if (_player.IsDead)
        {
            return;
        }
        _activeRoom.PresentRoom();
    }


    // How a fight works.

    private void Fight()
    {
        // Fight while both player and monster are alive.
        do 
        {
            // Present monster and prompt for player action.
            Message.CreatureStats(_activeRoom.Monster);
            string playerAction = AskForInput.FightOptions();

            // Check player choice and execute player action:
            
            // Player wants to attack: 
            if (InputAnalysis.WantsToAttack(playerAction))
            {
                // Player attacks
                _activeRoom.Monster.TakeDamage(_player);
                
                // Wait 300 ms 
                Thread.Sleep(300);
                
                // Check if Monster is Dead and do appropriate
                // actions. If monster alive, monster attacks.
                // If monster dead, report death to player.
                if (!_activeRoom.Monster.IsDead)
                {
                    FightMessage.CreatureAttack(_activeRoom.Monster);
                    _player.TakeDamage(_activeRoom.Monster);
                    
                    // Check if player is alive. If not, display 
                    // Game Over Message.
                    if (_player.IsDead)
                    {
                        Console.WriteLine(Message.dead);
                        break;
                    }
                }
                else if (_activeRoom.Monster.IsDead)
                {
                    FightMessage.CreatureDeath(_activeRoom.Monster);
                }
            }

            // Player wants to run:
            else if (InputAnalysis.WantsToRun(playerAction))
            {
                Console.WriteLine("\nYou run away.\n");
                _activeRoom = _gameMap[0];
            }
            
            // Player wants to open Inventory
            else if (InputAnalysis.WantsToOpenInventory(playerAction))
            {
                Console.WriteLine();
                _player.OpenInventory();
            }
        }
        while (_player.Hp > 0 && _activeRoom.Monster.Hp > 0);
    }


    // What does the player do, when he is not in a fight? 

    private void PlayerAction()
    {
        // Ask player what to do till player 
        // leaves this room or the dungeon.
        do 
        {
            string playerAction = WhatToDo();

            // TODO
            // Go in direction
            // Needs to load the next room, if player walks through door.
            if (InputAnalysis.WantsToGoTo(playerAction))
            {
                if (playerAction.ToUpper().Contains("NORTH"))
                {
                    _playerLocation = Direction.North;
                    playerAction = WhatToDo();
                }
                else if (playerAction.ToUpper().Contains("EAST"))
                {
                    _playerLocation = Direction.East;
                    playerAction = WhatToDo();
                }
                else if (playerAction.ToUpper().Contains("SOUTH"))
                {
                    _playerLocation = Direction.South;
                    playerAction = WhatToDo();
                }
                else if (playerAction.ToUpper().Contains("WEST"))
                {
                    _playerLocation = Direction.West;
                    playerAction = WhatToDo();
                }
                else
                {
                    Console.WriteLine("No valid direction!\n");
                }
            }

            // Open door.
            if (InputAnalysis.WantsToOpen(playerAction))
            {
                // _activeRoom.OpenDoor(_player);
            }

            // Leave dungeon.
            if (InputAnalysis.WantsToLeave(playerAction))
            {
                // Display GAME OVER.
                Console.WriteLine(Message.gameOver);

                // Exit Programm.
                System.Environment.Exit(0);
            }

            // Search room.
            if (InputAnalysis.WantsToSearch(playerAction))
            {
                _activeRoom.SearchRoom(_player);
            }

            // Open Inventory
            if (InputAnalysis.WantsToOpenInventory(playerAction))
            {
                Console.WriteLine();
                _player.OpenInventory();
            }
        }
        while (!_player.IsDead);
    }
}