using Razdor.Guilds.Entities.Channels.Guild;

namespace Razdor.DataAccess.EntityFramework.Entities;

public class VoiceRoom : IVoiceRoom
{
    public string SignalingServer { get; }
}