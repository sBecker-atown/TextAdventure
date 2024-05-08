namespace TextAdventure;

public class Gameworld
{
    private Creature player = new(
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

    public void Start()
    {
        // Start Game with welcome message & intro text
        GameStart();
        var GameMap = new Map().CreateMap();
        // Set Room as active / entered.
        GameMap[0].EnterRoom(player, GameMap);
    }

    private static void GameStart()
    {
        // Greet the player.
        Console.WriteLine(Message.welcome);
        // Wait for player input to start the game.
        Console.WriteLine("Press ENTER to start.");
        Console.ReadLine();
        Console.WriteLine(Message.adventureIntro);
        Console.ReadLine();
    }

    // TODO 
    // Make new without States and WallTypes. 
    public static string WhatToDo(Room room)
        {
            int activeWalls = 0;
            foreach (var Wall in room.Walls)
            {
                if (Wall.State == State.CurrentLocation)
                {
                    if (Wall.Type == WallType.Door)
                    {
                        Console.WriteLine(Ask.whatToDoDoor);
                        activeWalls++;
                    }
                    else if (Wall.Type == WallType.Wall)
                    {
                        Console.WriteLine(Ask.whatToDoWall);
                        activeWalls++;
                    }
                    else if (Wall.Type == WallType.Passage)
                    {
                        Console.WriteLine(Ask.whatToDoPassage);
                        activeWalls++;
                    }
                }
            }
            if (activeWalls == 0) 
            {
                Console.WriteLine(Ask.whatToDo);
            }

            string choice;
            do
            {
                choice = Console.ReadLine()!;
            }
            while (string.IsNullOrEmpty(choice));
            
            return choice;
        }
}