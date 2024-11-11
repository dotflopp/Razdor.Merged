using Razdor.Guilds.Entities.Channels.Guild;

namespace Razdor.Guilds.Entities.Guilds;

public interface IGuild : IEntity, INamed
{
    string? Icon { get; }
}