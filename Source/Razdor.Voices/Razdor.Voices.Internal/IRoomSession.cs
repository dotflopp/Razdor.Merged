namespace Razdor.Voices.Internal;

public interface IRoomSession
{
    string SessionId { get; }
    string Server { get; }
}