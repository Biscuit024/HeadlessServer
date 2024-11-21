using Steamworks;

namespace HeadlessServer
{
    static class Program
    {
        const int port = 27015;
        const bool isDedicatedServer = true;

        static void CheckLobbies()
        {
            CallResult<LobbyMatchList_t> res = CallResult<LobbyMatchList_t>.Create();
            Console.WriteLine("Requesting Lobby List...");
            var call = SteamMatchmaking.RequestLobbyList();
            res.Set(call, (LobbyMatchList_t result, bool ioFail) =>
            {
                Console.WriteLine($"Found {result.m_nLobbiesMatching} lobbies.");
                for (int i = 0; i < result.m_nLobbiesMatching; i++)
                {
                    Console.WriteLine($"Getting data for lobby {i}");
                    CSteamID id = SteamMatchmaking.GetLobbyByIndex(i);
                    int dataCount = SteamMatchmaking.GetLobbyDataCount(id);
                    Console.WriteLine($"STEAM ID: {id}, DATACOUNT: {dataCount}");
                    for (int j = 0; j < dataCount; j++)
                    {
                        string key;
                        string value;
                        bool good = SteamMatchmaking.GetLobbyDataByIndex(id, j, out key, 1000, out value, 1000);
                        if (good)
                        {
                            Console.WriteLine($"For ID: {id}, Key = {key}, Value = {value}");
                        }
                        else
                        {
                            Console.WriteLine($"No Good.");
                        }
                    }
                    //var ver = SteamMatchmaking.GetLobbyData(id, "ver");
                    //var name = SteamMatchmaking.GetLobbyData(id, "lName");
                    //Console.WriteLine($"Name: {name}, Ver: {ver}");
                }
            });
        }
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("STEAM_DEBUG", "1", EnvironmentVariableTarget.Process);
            bool success = SteamAPI.Init();
            if (!success)
            {
                Console.WriteLine("Failed.");
                return;
            }
            else
            {
                Console.WriteLine("Steamworks API Succesfully Initialized.");
            }
            Console.WriteLine(success);
            Thread.Sleep(5000);
            Console.WriteLine("Running request...");
            
            bool run = true;
            CallResult<LobbyCreated_t> callRes = CallResult<LobbyCreated_t>.Create();
            var call = SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, 16);
            callRes.Set(call, (LobbyCreated_t result, bool ioFailure) =>
            {
                if (ioFailure || result.m_eResult != EResult.k_EResultOK)
                {
                    Console.WriteLine($"Failed to create lobby! BIOFAILURE: {ioFailure}, RESULT: {result.m_eResult}");
                    return;
                }
                Console.WriteLine($"Successfully created lobby. {result.m_eResult}, {result.m_ulSteamIDLobby}");
                var lobbyID = new CSteamID(result.m_ulSteamIDLobby);
                SteamMatchmaking.SetLobbyData(lobbyID, "brtype", "0");
                SteamMatchmaking.SetLobbyData(lobbyID, "cLivs", "True");
                SteamMatchmaking.SetLobbyData(lobbyID, "envIdx", "0");
                SteamMatchmaking.SetLobbyData(lobbyID, "feature", "0");
                SteamMatchmaking.SetLobbyData(lobbyID, "gState", "0");
                SteamMatchmaking.SetLobbyData(lobbyID, "hs", "1");
                SteamMatchmaking.SetLobbyData(lobbyID, "lName", "Headless Testing");
                SteamMatchmaking.SetLobbyData(lobbyID, "lReady", "1");
                SteamMatchmaking.SetLobbyData(lobbyID, "maxP", "16");
                SteamMatchmaking.SetLobbyData(lobbyID, "oId", "76561199120753014");
                SteamMatchmaking.SetLobbyData(lobbyID, "oName", "HS");
                SteamMatchmaking.SetLobbyData(lobbyID, "plc", "HST");
                SteamMatchmaking.SetLobbyData(lobbyID, "pwh", "0");
                SteamMatchmaking.SetLobbyData(lobbyID, "scId", "w,Liberation Day 1,3300369267");
                SteamMatchmaking.SetLobbyData(lobbyID, "scn", "Liberation Day 1");
                SteamMatchmaking.SetLobbyData(lobbyID, "specOpt", "0");
                SteamMatchmaking.SetLobbyData(lobbyID, "ver", "1.11.1f1");
                SteamMatchmaking.SetLobbyData(lobbyID, "wsUploadVersion", "16");
                SteamMatchmaking.SetLobbyJoinable(lobbyID, true);
                Console.WriteLine("Lobby data set. Checking in 5 seconds...");
                Thread.Sleep(5000);
                CheckLobbies();
            });
            //CheckLobbies();

            while (run)
            {
                Thread.Sleep(50);
                SteamAPI.RunCallbacks();
            }
            SteamAPI.Shutdown();
            Console.ReadLine();
        }    
    }
}