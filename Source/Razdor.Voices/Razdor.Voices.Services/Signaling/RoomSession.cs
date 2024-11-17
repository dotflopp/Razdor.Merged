using Razdor.Voices.Internal;

namespace Razdor.Voices.Services.Signaling;

public record RoomSession(
    string Server,
    string SessionId
) : IRoomSession;