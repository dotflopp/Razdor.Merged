using Razdor.Guilds.Entities.Channels.Guild;

namespace Razdor.DataAccess.EntityFramework.Entities;

public class GuildVoiceChannel : GuildChannel, IGuildVoiceChannel
{
    public ulong? SignalingId { get; set; } = null;
    public required uint Bitrate { get; set; }
    public required uint UserLimit { get; set; }
}