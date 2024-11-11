using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Razdor.DataAccess.EntityFramework;
using Razdor.DataAccess.EntityFramework.Entities;
using Razdor.Guilds.DataAccess.Core;
using Razdor.Guilds.DataAccess.Core.Models;
using Razdor.Guilds.Entities.Channels;
using Razdor.Guilds.Entities.Channels.Guild;

namespace Razdor.DataAccess.EntityFramework.Repositories;

public class ChannelsRepository : IChannelsRepository
{
    private readonly RazdorDataContext _context;

    public ChannelsRepository(RazdorDataContext context)
    {
        _context = context;
    }

    public async Task<IGuildChannel?> FindGuildChannelAsync(
        EntityId guildId,
        EntityId channelId
    ){
        return await _context.GuildChannels
            .Where(channel => channel.Id == channelId && channel.GuildId == guildId)
            .FirstOrDefaultAsync();
    }

    public async Task<IGuildChannel> CreateGuildChannelAsync(ulong guildId, ChannelCreationModel model)
    {
        GuildChannel channel = new GuildVoiceChannel()
        {
            Id = 0,
            SignalingServer = null,
            Name = model.Name,
            Position = model.Position,
            Type = model.Type,
            UserLimit = model.UserLimit,
            GuildId = guildId,
            Bitrate = model.Bitrate,
        };
        
        EntityEntry<GuildChannel> entity = await _context.GuildChannels.AddAsync(channel);
        await _context.SaveChangesAsync();
        
        return entity.Entity;
    }

    public async Task<IReadOnlyCollection<IGuildChannel>> GetGuildChannelsAsync(
        EntityId guildId
    ){
        return await _context.GuildChannels
            .Where(channel => channel.GuildId == guildId)
            .ToListAsync();
    }
}