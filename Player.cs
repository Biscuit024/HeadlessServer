namespace HeadlessServer
{
    public class Player : PlayerInfoContainer
    {
        public string SteamID { get; private set; }
        public string PilotName { get; private set; }
        public int Slot { get; private set; }
        public Team Team { get; private set; }
        public int EntityID { get; private set; }
        public int UnitID { get; private set; }

        public Player(string steamID, string pilotName, int slot, Team team, int entityID, int unitID)
        {
            SteamID = steamID;
            PilotName = pilotName;
            Slot = slot;
            Team = team;
            EntityID = entityID;
            UnitID = unitID;
        }
        public static Player Empty = new("None", "Unknown", -1, Team.A, -1, -1);
    }
}
