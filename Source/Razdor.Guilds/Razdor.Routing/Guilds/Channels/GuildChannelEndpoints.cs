using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Razdor.Guilds.DataAccess.Core;
using Razdor.Guilds.DataAccess.Core.Models;
using Razdor.Guilds.Entities.Channels.Guild;

namespace Razdor.Guilds.Routing.Guilds.Channels
{
    public static class GuildChannelEndpoints
    {
        public static IEndpointRouteBuilder MapGuildChannels(
            this IEndpointRouteBuilder builder,
            [StringSyntax("Route")] string prefix = "{guildId:ulong}/channels/"
        ){
            RouteGroupBuilder groupBuilder = builder.MapGroup(prefix)
                .WithTags("Каналы гильдий");
            
            groupBuilder.MapGet("/", GetGuildAllChannelsAsync)
                .WithSummary("Получить все каналы гильдии");
            
            groupBuilder.MapPut("/", CreateGuildChannelAsync)
                .WithSummary("Создать новый канал в гильдии");
            
            groupBuilder.MapGet("/{channelId:ulong}", FindGuildChannelAsync)
                .WithSummary("Получить информацию об одном канале гильдии");
            
            groupBuilder.MapPost("/{channelId:ulong}/join", JoinGuildChannelAsync)
                .WithSummary("Создать сессию, если существует, вернется существующая");
            
            return builder;
        }

        internal static Task<IResult> JoinGuildChannelAsync(HttpContext context)
        {
            return Task.FromResult(Results.Ok());
        }

        internal static async Task<IResult> CreateGuildChannelAsync(
            [FromServices] IChannelsRepository channels,
            [FromRoute] ulong guildId,
            [FromBody] ChannelCreationModel channelModel
        )
        {
            IGuildChannel guildChannel = await channels.CreateGuildChannelAsync(guildId, channelModel);
            
            return Results.Created(
                $"guilds/{guildId}/channels/{guildChannel.GuildId}", 
                guildChannel
            );
        }

        internal static async Task<IResult> GetGuildAllChannelsAsync(
            ulong guildId,
            [FromServices] IChannelsRepository channels
        ){
            return Results.Ok(
                await channels.GetGuildChannelsAsync(guildId)
            );
        }
        
        internal static async Task<IResult> FindGuildChannelAsync(
            [FromHeader] ulong guildId, 
            [FromHeader] ulong channelId, 
            [FromServices] IChannelsRepository channels
        ){
            return Results.Ok(
                await channels.FindGuildChannelAsync(guildId, channelId)
            );
        }
    }
}
