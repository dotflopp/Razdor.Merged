using Razdor.Guilds.Entities.Guilds;

namespace Razdor.Guilds.Entities.Channels.Guild;

public interface IGuildChannel : IGuildEntity, IChannel, INamed
{
    uint Position { get; }
  
}