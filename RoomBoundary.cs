namespace TextAdventure;

public class RoomBoundary
{
    public int? KeyID;
    public int? NextRoom;

    public RoomBoundary(int? keyID, int? indexOfRoom)
    {
        KeyID = keyID;
        NextRoom = indexOfRoom;
    }
}