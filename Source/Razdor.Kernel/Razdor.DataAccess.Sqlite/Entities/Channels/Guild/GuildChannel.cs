using Razdor.Guilds.Entities.Channels.Guild;

namespace Razdor.DataAccess.EntityFramework.Entities.Channels.Guild;

public abstract class GuildChannel : BaseChannel, IGuildChannel
{
    public required string Name { get; init; }
    public required EntityId GuildId { get; init; }
    public required uint Position { get; init; }
    
    internal Entities.Guild? Guild { get; set; } = null;
}