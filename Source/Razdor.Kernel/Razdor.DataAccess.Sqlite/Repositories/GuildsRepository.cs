using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Razdor.DataAccess.EntityFramework.Entities;
using Razdor.Guilds.DataAccess.Core;
using Razdor.Guilds.DataAccess.Core.Models;
using Razdor.Guilds.Entities.Guilds;
using Razdor.Guilds.Entities.Users;

namespace Razdor.DataAccess.EntityFramework.Repositories;

public class GuildsRepository : IGuildsRepository
{
    private readonly RazdorDataContext _context;

    public GuildsRepository(RazdorDataContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<IGuild>> GetUserGuilds(IUser user)
    {
        if (user is User efUser && efUser.Guilds != null) 
        {
            return efUser.Guilds;
        }

        return await _context.Guilds
            .Where(guild => guild.Users!.Any(guildUser => guildUser.Id == user.Id))
            .ToListAsync();
    }

    public async Task<IGuild> CreateGuildAsync(GuildCreationModel model)
    {
        Guild guild = new Guild()
        {
            Id = 0,
            Name = model.Name,
            Icon = model.Icon,
        };
        EntityEntry<Guild> result = await _context.Guilds.AddAsync(guild);
        await _context.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task<IReadOnlyCollection<IGuild>> getAllAsync()
    {
        return await _context.Guilds.ToListAsync();
    }
}