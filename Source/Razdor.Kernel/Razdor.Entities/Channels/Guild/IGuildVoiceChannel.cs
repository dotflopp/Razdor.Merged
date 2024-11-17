using System.Text.Json.Serialization;

namespace Razdor.Guilds.Entities.Channels.Guild;

public interface IGuildVoiceChannel : IGuildChannel
{
    [JsonIgnore]
    ulong? SignalingId { get; }
    uint Bitrate { get; }
    uint UserLimit { get; }
}
