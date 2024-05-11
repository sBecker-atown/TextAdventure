namespace TextAdventure;

public class RoomBoundary
{
    public int? KeyID;
    public int? NextRoom;
    public bool? IsADoor;

    public RoomBoundary(int? keyID, int? indexOfRoom, bool? thisIsADoor)
    {
        KeyID = keyID;
        NextRoom = indexOfRoom;
        IsADoor = thisIsADoor;
    }

    public static RoomBoundary CreateWall()
    {
        return new RoomBoundary(null,null,false);
    }

    public static RoomBoundary CreatePassageToRoom(int nextRoomID)
    {
        return new RoomBoundary(null,nextRoomID,false);
    }

    public static RoomBoundary CreateDoorWithKeyIdAndNextRoom(int? keyID, int nextRoomID)
    {
        return new RoomBoundary(keyID,nextRoomID,true);
    }
}