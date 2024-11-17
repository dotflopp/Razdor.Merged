using Razdor.Guilds.Entities.Channels;

namespace Razdor.DataAccess.EntityFramework.Entities.Channels;

public abstract class BaseChannel : IChannel
{
    public required EntityId Id { get; init; }
    public required ChannelType Type { get; init; }
}