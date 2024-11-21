namespace HeadlessServer
{
    public static class CampaignSelector
    {
        public delegate void CampaignInfoDelegate(CampaignInfo campaignInfo);

        public static Campaign
    }
    public class ScenarioInfo
    {
        public ConfigNode Config;
        public GameVersion Version;
        public string FilePath;
        public string DirectoryPath;
        public CampaignInfo Campaign;
        public string CampaignId = string.Empty;
        public int CampaignOrderIndex;
        public string MapId;
        public float BaseBudget = 100000f;
        public bool IsTraining;
        public bool ForceEquips;
        public float NormalForcedFuel = 1f;
        public bool EquipsConfigurable = true;
        public List<string> AllowedEquips = new();
        public List<string> ForcedEquips = new();
        public List<string> EquipsOnComplete = new();
        public bool HasSpawns = true;
        public int PlayerCount;
        public bool SeparateBriefings;
        public bool AutoPlayerCount = true;
        public int OverrideAlliedPlayerCount = 1;
        public int OverrideEnemyPlayerCount = 1;
        public string EnvironmentName;
        public bool IsEnvironmentSelectable;
        public float CustomTimeOfDay;
        public bool IsWorkshop;
        

    }
}
