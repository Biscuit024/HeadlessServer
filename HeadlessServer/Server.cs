using Steamworks;

namespace HeadlessServer
{

    static class Server
    {
        private const int SERVERPORT = 27015;

        private static bool s_isServerRunning = false;

        private static void LaunchMPGameForScenario()

        private static void OnServerCreated(LobbyCreated_t lobbyData, bool ioFailure)
        {
            if (ioFailure || lobbyData.m_eResult != EResult.k_EResultOK)
            {
                Console.WriteLine($"Failed to create lobby! Is bIOFailure: {ioFailure}, Result: {lobbyData.m_eResult}");
                return;
            }
            Console.WriteLine("Successfully created lobby.");
            CSteamID lobbyId = new(lobbyData.m_ulSteamIDLobby);
            SteamMatchmaking.SetLobbyData(lobbyId, "brtype", "0");
            SteamMatchmaking.SetLobbyData(lobbyId, "cLivs", "True");
            SteamMatchmaking.SetLobbyData(lobbyId, "envIdx", "0");
            SteamMatchmaking.SetLobbyData(lobbyId, "feature", "0");
            SteamMatchmaking.SetLobbyData(lobbyId, "gState", "0");
            SteamMatchmaking.SetLobbyData(lobbyId, "hs", "1");
            SteamMatchmaking.SetLobbyData(lobbyId, "lName", "Headless Testing");
            SteamMatchmaking.SetLobbyData(lobbyId, "lReady", "1");
            SteamMatchmaking.SetLobbyData(lobbyId, "maxP", "16");
            SteamMatchmaking.SetLobbyData(lobbyId, "oId", "76561199120753014");
            SteamMatchmaking.SetLobbyData(lobbyId, "oName", "HS");
            SteamMatchmaking.SetLobbyData(lobbyId, "plc", "HST");
            SteamMatchmaking.SetLobbyData(lobbyId, "pwh", "0");
            SteamMatchmaking.SetLobbyData(lobbyId, "scId", "w,Liberation Day 1,3300369267");
            SteamMatchmaking.SetLobbyData(lobbyId, "scn", "Liberation Day 1");
            SteamMatchmaking.SetLobbyData(lobbyId, "specOpt", "0");
            SteamMatchmaking.SetLobbyData(lobbyId, "ver", "1.11.1f1");
            SteamMatchmaking.SetLobbyData(lobbyId, "wsUploadVersion", "16");
            SteamMatchmaking.SetLobbyData(lobbyId, "isServer", "true");
            SteamMatchmaking.SetLobbyJoinable(lobbyId, true);

            s_isServerRunning = true;
        }

        public static void StartServer()
        {
            if (s_isServerRunning)
                return;

            CallResult<LobbyCreated_t> serverCreatedRes = new();
            var callRef = SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, 16);
            serverCreatedRes.Set(callRef, OnServerCreated);
        }
    }
}
