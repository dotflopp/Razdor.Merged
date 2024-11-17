using System.Text.Json.Serialization;
using Razdor.DataAccess.EntityFramework.Entities.Channels.Guild;
using Razdor.Guilds.Entities.Guilds;

namespace Razdor.DataAccess.EntityFramework.Entities;

public class Guild : IGuild
{
    public required EntityId Id { get; init; }
    public required string Name { get; init; }
    public required string? Icon { get; init; }
    
    internal IReadOnlyCollection<User>? Users { get; set; }
    internal IReadOnlyCollection<GuildChannel>? Channels { get; set; }
}
