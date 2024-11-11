using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Razdor.DataAccess.EntityFramework.Entities;
using Razdor.Guilds.Entities.Channels;

namespace Razdor.DataAccess.EntityFramework.EntityConfigurations;

public class ChannelsConfiguration : IEntityTypeConfiguration<BaseChannel>
{
    public void Configure(EntityTypeBuilder<BaseChannel> builder)
    {
        builder
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        builder.HasDiscriminator(channel => channel.Type)
            .HasValue<GuildVoiceChannel>(ChannelType.GuildVoiceChannel);
    }
}

public class GuildChannelsConfiguration : IEntityTypeConfiguration<GuildChannel>
{
    public void Configure(EntityTypeBuilder<GuildChannel> builder)
    {
        builder.HasOne<Guild>(channel => channel.Guild)
            .WithMany(guild => guild.Channels)
            .HasForeignKey(channel => channel.GuildId)
            .IsRequired();
    }
}