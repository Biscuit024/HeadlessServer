namespace HeadlessServer.Networking
{
    public class RPCController
    {
        public static RPCController Instance { get; private set; } = new RPCController();

        private RPCController()
        {

        }

        private RPCHandler[] _newInRpcs = [];
        private RPCHandler[] _rpcs = [];

        private Dictionary<string, RPCHandler> rpcs = new();


    }
}
