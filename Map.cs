namespace TextAdventure;

public class Map
{
    public List<Room> GameMap = new RoomFactory().CreateRooms();

    public List<Room> CreateMap()
    {
        return GameMap;
    }
}
