using Razdor.Guilds.Entities.Guilds;

namespace Razdor.Guilds.DataAccess.Core.Models;

public class GuildCreationModel
{
    public string Name { get; set; }
    public string? Icon { get; }
}