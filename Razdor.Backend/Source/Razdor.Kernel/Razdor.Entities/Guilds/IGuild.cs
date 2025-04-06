namespace Razdor.Entities.Guilds;

public interface IGuild : IEntity, INamed
{
    string? Icon { get; }
}