using System.Text.Json.Serialization;
using Razdor.Entities.Guilds;

namespace Razdor.Entities.Channels.Guild;

[JsonPolymorphic(
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor,
    TypeDiscriminatorPropertyName = "type"
)]
[JsonDerivedType(typeof(IGuildVoiceChannel), (int)ChannelType.GuildVoiceChannel)]
[JsonDerivedType(typeof(IMessageChannel), (int)ChannelType.GuildTextChannel)]
public interface IGuildChannel : IGuildEntity, IChannel, INamed
{
    uint Position { get; }
}