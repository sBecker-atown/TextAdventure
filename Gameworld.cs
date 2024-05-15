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

    private RoomBoundary _wallAtPlayerLocation = null!;



    // Main Gameworld Method.

    public void Start()
    {
        // Start Game with welcome message & intro text
        Introduction();

        // Set Room 0 as active.
        _activeRoom = _gameMap[0];

        while (!_player.IsDead)
        {
            // Present active room.
            _activeRoom.PresentRoom();

            if (!_activeRoom.Monster.IsDead)
            {
                StartEncounter();
            }
            PlayerAction();
        }
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
            _wallAtPlayerLocation = currentWall;
            if (currentWall.KeyID == null && currentWall.NextRoom == null)
            {
                AskForInput.WhatToDoAtWall();
            }
            else if (currentWall.KeyID == null && currentWall.NextRoom != null)
            {
                AskForInput.WhatToDoAtPassage(currentWall.IsADoor);
            }
            else if (currentWall.KeyID != null && currentWall.NextRoom != null)
            {
                AskForInput.WhatToDoAtDoor();
            }
        }
        else 
        {
            AskForInput.WhatToDo();
        }

        string choice;
        do
        {
            choice = Console.ReadLine()!;
        }
        while (string.IsNullOrEmpty(choice));
        
        return choice;
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

            // Player wants to see Health
            if (InputAnalysis.WantsToSeePlayerStats(playerAction))
            {
                Message.CreatureStats(_player);
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
                if (playerAction.Contains("North", StringComparison.OrdinalIgnoreCase))
                {
                    _playerLocation = Direction.North;
                }
                else if (playerAction.Contains("East", StringComparison.OrdinalIgnoreCase))
                {
                    _playerLocation = Direction.East;
                }
                else if (playerAction.Contains("South", StringComparison.OrdinalIgnoreCase))
                {
                    _playerLocation = Direction.South;
                }
                else if (playerAction.Contains("West", StringComparison.OrdinalIgnoreCase))
                {
                    _playerLocation = Direction.West;
                }
                else
                {
                    Console.WriteLine("No valid direction!\n");
                }
            }

            // Open door.
            if (InputAnalysis.WantsToOpen(playerAction))
            {
                OpenDoor();
            }

            // Leave Room.
            if (InputAnalysis.WantsToLeave(playerAction))
            {
                for (int i = 0; i < _gameMap.Count; i++)
                {
                    if (_gameMap[i].RoomIndex == _wallAtPlayerLocation.NextRoom)
                    {
                        _activeRoom = _gameMap[i];
                        _playerLocation = Direction.None;
                        return;
                    }
                }
            }

            // Exit dungeon.
            if (InputAnalysis.WantsToExit(playerAction))
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

            // Show PlayerHealth
            if (InputAnalysis.WantsToSeePlayerStats(playerAction))
            {
                Message.CreatureStats(_player);
            }
        }
        while (!_player.IsDead);
    }

    private void OpenDoor()
    {
        var playerHasKey = false;
        
        foreach (var item in _player.Inventory)
        {
            if (item.ID == _wallAtPlayerLocation.KeyID)
            {
                playerHasKey = true;
            }
        }

        switch (playerHasKey)
        {
            case true:
                _wallAtPlayerLocation.KeyID = null;
                Console.WriteLine("You open the door.");
                break; 
            case false: 
                Console.WriteLine("You don't have " +
                "the Key for that.");
                break;
        }
    }
}