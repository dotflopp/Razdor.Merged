namespace Razdor.Guilds.Entities.Channels;

public interface IChannel: IEntity
{
    ChannelType Type { get; }
}

