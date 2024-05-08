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

        // Load all rooms.
        var AllRooms = new RoomFactory().CreateRooms();

        // Set Room as active / entered.
        AllRooms[0].EnterRoom(player, AllRooms);
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
}