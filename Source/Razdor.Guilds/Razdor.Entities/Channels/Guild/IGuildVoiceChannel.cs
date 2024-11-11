namespace Razdor.Guilds.Entities.Channels.Guild;

public interface IGuildVoiceChannel : IGuildChannel
{
    string SignalingServer { get; }
    uint Bitrate { get; }
    uint UserLimit { get; }
}
