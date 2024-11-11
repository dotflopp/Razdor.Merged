using Razdor.Guilds.Entities.Channels;
using Razdor.Guilds.Entities.Channels.Guild;

namespace Razdor.Guilds.DataAccess.Core.Models;

public class ChannelCreationModel
{
    public ChannelType Type { get; set; }
    public ulong ParentId { get; set; }
    public string Name { get; set; }
    public uint Position { get; set; }
    public uint Bitrate { get; set; }
    public uint UserLimit { get; set; }
}