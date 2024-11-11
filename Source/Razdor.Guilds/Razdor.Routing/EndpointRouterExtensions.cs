using Razdor.Guilds.Routing.Guilds;

namespace Razdor.Guilds.Routing;

public static class EndpointRouterExtensions
{
    public static IEndpointRouteBuilder MapRazdorApi(
        this IEndpointRouteBuilder builder,
        string pattern = "/"
    ) {
        return builder.MapGuilds();
    }
}