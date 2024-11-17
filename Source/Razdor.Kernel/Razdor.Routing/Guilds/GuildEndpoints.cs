using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Razdor.Guilds.DataAccess.Core;
using Razdor.Guilds.DataAccess.Core.Models;
using Razdor.Guilds.Entities.Guilds;
using Razdor.Guilds.Routing.Guilds.Channels;

namespace Razdor.Guilds.Routing.Guilds
{
    public static class GuildEndpoints
    {
        public static IEndpointRouteBuilder MapGuilds(
            this IEndpointRouteBuilder builder,
            [StringSyntax("Route")] string prefix = "/guilds"
        ) {
            var groupBuilder = builder.MapGroup(prefix)
                .WithTags("Гильдии");
            
            groupBuilder.MapGet("/@my", GetUserGuildsAsync)
                .WithSummary("Получить гильдии пользователя");

            groupBuilder.MapPost("/", CreateGuildAsync)
                .WithSummary("Создать новую гильдию");
            
            groupBuilder.MapGuildChannels();
            
            return builder;
        }

        internal static async Task<IResult> GetUserGuildsAsync(
            [FromServices] IGuildsRepository guilds
        ) {
            return Results.Ok(
                await guilds.getAllAsync()
            );
        }
        
        internal static async Task<IResult> CreateGuildAsync(
            [FromServices] IGuildsRepository guilds,
            [FromBody] GuildCreationModel guildModel
        ){
            IGuild guild = await guilds.CreateGuildAsync(guildModel);
            return Results.Created($"guilds/{guild.Id}", guild);
        }
    }
}
