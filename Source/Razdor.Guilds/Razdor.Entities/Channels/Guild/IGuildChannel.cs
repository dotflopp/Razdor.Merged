using System.Text.Json.Serialization;
using Razdor.Guilds.Entities.Guilds;

namespace Razdor.Guilds.Entities.Channels.Guild;

[JsonPolymorphic(
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor,
    TypeDiscriminatorPropertyName = nameof(Type)
)]
[JsonDerivedType(typeof(IGuildVoiceChannel), (int)ChannelType.GuildVoiceChannel)]
[JsonDerivedType(typeof(IMessageChannel), (int)ChannelType.GuildTextChannel)]
public interface IGuildChannel : IGuildEntity, IChannel, INamed
{
    uint Position { get; }
  
}