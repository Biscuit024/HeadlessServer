namespace HeadlessServer
{
    public interface PlayerInfoContainer
    {
        string SteamID { get; }
        string PilotName { get; }
        int Slot { get; }
        Team Team { get; }
        int EntityID { get; }
        int UnitID { get; }
    }
}