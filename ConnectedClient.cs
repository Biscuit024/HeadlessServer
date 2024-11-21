
using Steamworks;

namespace HeadlessServer.Networking
{
    public class ConnectedClient
    {
        public CSteamID SteamId { get; private set; }
        public Connection Connection { get; private set; }
        public bool CompletedInitialSync;

        public ConnectedClient(CSteamID steamId, Connection connection)
        {
            SteamId = steamId;
            Connection = connection;
            CompletedInitialSync = false;
        }
    }

    public delegate void MessageDelete(Connection connection, NetIdentity identity, byte[] data, int size, long messageId, long receiveTime, int channel);
}
