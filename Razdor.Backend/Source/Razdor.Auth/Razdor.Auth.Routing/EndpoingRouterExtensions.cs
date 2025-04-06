using Microsoft.AspNetCore.Routing.Patterns;

namespace Razdor.Auth.Routing;

public static class EndpoingRouterExtensions
{
    public static IHubEndpointConventionBuilder MapAuth(
        this IEndpointRouteBuilder builder,
        string prefix = "/auth"
    )
    { 
        RouteGroupBuilder group = builder.MapGroup(prefix)
            .WithTags("Auth");
        
        throw new NotImplementedException();
    }
}