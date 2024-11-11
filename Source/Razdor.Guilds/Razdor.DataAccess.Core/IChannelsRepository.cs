using Razdor.Guilds.DataAccess.Core.Models;
using Razdor.Guilds.Entities.Channels;
using Razdor.Guilds.Entities.Channels.Guild;
using Razdor.Guilds.Entities.Guilds;

namespace Razdor.Guilds.DataAccess.Core;

public interface IChannelsRepository : IRepository<IChannel>
{
    Task<IReadOnlyCollection<IGuildVoiceChannel>> GetGuildChannelsAsync(EntityId guildId);
    
    Task<IGuildChannel?> FindGuildChannelAsync(
        EntityId guildId,
        EntityId channelId
    );

    Task<IGuildChannel> CreateGuildChannelAsync(ulong guildId, ChannelCreationModel model);
    Task<bool> TrySetNewSignalingServiceAsync(IGuildChannel guildChannel, ulong signalingServiceId);
}