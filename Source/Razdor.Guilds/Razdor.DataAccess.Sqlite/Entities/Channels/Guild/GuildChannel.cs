using System.Text.Json.Serialization;
using Razdor.Guilds.Entities.Channels.Guild;

namespace Razdor.DataAccess.EntityFramework.Entities;

public abstract class GuildChannel : BaseChannel, IGuildChannel
{
    public required string Name { get; init; }
    public required EntityId GuildId { get; init; }
    public required uint Position { get; init; }

    [JsonIgnore]
    internal Guild? Guild { get; set; } = null;
}