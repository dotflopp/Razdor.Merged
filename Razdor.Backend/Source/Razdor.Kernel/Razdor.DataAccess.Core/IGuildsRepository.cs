using Razdor.DataAccess.Core.Models;
using Razdor.Entities.Guilds;
using Razdor.Entities.Users;

namespace Razdor.DataAccess.Core;

public interface IGuildsRepository : IRepository<IGuild>
{
    Task<IReadOnlyCollection<IGuild>> GetUserGuilds(IUser user);
    Task<IGuild> CreateGuildAsync(GuildCreationModel model);
    Task<IReadOnlyCollection<IGuild>> getAllAsync();
}