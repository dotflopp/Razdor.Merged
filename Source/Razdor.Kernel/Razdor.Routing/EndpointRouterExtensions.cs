using Razdor.Routing.Guilds;

namespace Razdor.Routing;

public static class EndpointRouterExtensions
{
    public static IEndpointRouteBuilder MapRazdorApi(
        this IEndpointRouteBuilder builder,
        string pattern = "/"
    ) {
        return builder.MapGuilds();
    }
}