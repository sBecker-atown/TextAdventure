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

    public static RoomBoundary CreateWall()
    {
        return new RoomBoundary(null,null);
    }

    public static RoomBoundary CreatePassageToRoom(int nextRoomID)
    {
        return new RoomBoundary(null,nextRoomID);
    }

    public static RoomBoundary CreateDoorWithKeyIdAndNextRoom(int keyID, int nextRoomID)
    {
        return new RoomBoundary(keyID,nextRoomID);
    }
}