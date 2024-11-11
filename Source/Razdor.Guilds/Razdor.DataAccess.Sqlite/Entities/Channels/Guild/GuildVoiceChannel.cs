using Razdor.Guilds.Entities.Channels.Guild;

namespace Razdor.DataAccess.EntityFramework.Entities;

public class GuildVoiceChannel : GuildChannel, IGuildVoiceChannel
{
    public string? SignalingServer { get; set; } = null;
    public required uint Bitrate { get; set; }
    public required uint UserLimit { get; set; }
}