using Razdor.Signaling.Internal;

namespace Razdor.Voices.Services.Signaling;

public record RoomSession(
    string Server,
    string SessionId
) : IRoomSession;