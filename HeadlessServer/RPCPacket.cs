namespace HeadlessServer.Networking
{
    public interface RPCPacket
    {
        string ClassName { get; }
        string Method { get; }
        object[] Arguments { get; }
        string? Id { get; }
        double? Timestamp { get; }
        double? PID { get; }
    }
}