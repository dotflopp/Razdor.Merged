namespace Razdor.Entities.Channels;

public interface IChannel: IEntity
{
    ChannelType Type { get; }
}

