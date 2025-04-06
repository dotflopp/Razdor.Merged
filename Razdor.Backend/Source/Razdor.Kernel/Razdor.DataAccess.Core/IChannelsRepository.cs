using Razdor.DataAccess.Core.Models;
using Razdor.Entities.Channels;
using Razdor.Entities.Channels.Guild;

namespace Razdor.DataAccess.Core;

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