namespace Razdor.Guilds.Entities.Users;

public interface IUser
{
    ulong Id { get; }
    string Username { get; }
    ushort Discriminator { get; }
    string? AvatarUrl { get; }
    string? Email { get; }
}