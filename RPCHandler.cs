namespace HeadlessServer.Networking
{
    public enum RPCMode
    {
        Static,
        SingleInstance,
        Instance
    }
    public interface RPCHandler
    {
        RPCMode Type { get; }
        string Target { get; }
        string Name { get; }
    }
}
