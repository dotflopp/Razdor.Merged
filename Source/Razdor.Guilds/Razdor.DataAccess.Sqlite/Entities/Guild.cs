using System.Text.Json.Serialization;
using Razdor.Guilds.Entities.Guilds;

namespace Razdor.DataAccess.EntityFramework.Entities;

public class Guild : IGuild
{
    public required EntityId Id { get; init; }
    public required string Name { get; init; }
    public required string? Icon { get; init; }
    
    [JsonIgnore]
    internal IReadOnlyCollection<User>? Users { get; set; }
    [JsonIgnore]
    internal IReadOnlyCollection<GuildChannel>? Channels { get; set; }
}
