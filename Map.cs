namespace TextAdventure;

public class Map
{
    private List<Room> GameMap = new RoomFactory().CreateRooms();

    public List<Room> CreateMap()
    {
        return GameMap;
    }
}
