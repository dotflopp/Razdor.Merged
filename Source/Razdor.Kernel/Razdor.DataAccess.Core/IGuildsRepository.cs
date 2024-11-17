using Razdor.Guilds.DataAccess.Core.Models;
using Razdor.Guilds.Entities.Channels.Guild;
using Razdor.Guilds.Entities.Guilds;
using Razdor.Guilds.Entities.Users;

namespace Razdor.Guilds.DataAccess.Core;

public interface IGuildsRepository : IRepository<IGuild>
{
    Task<IReadOnlyCollection<IGuild>> GetUserGuilds(IUser user);
    Task<IGuild> CreateGuildAsync(GuildCreationModel model);
    Task<IReadOnlyCollection<IGuild>> getAllAsync();
}