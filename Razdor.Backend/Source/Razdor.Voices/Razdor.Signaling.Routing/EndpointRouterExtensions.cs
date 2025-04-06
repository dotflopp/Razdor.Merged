using System.Runtime.InteropServices;

using Razdor.Voices.Routing.Signaling;

namespace Razdor.Voices.Routing
{
    public static class EndpointRouterExtensions
    {
        public static HubEndpointConventionBuilder MapSignalingHub(
            this IEndpointRouteBuilder routeBuilder,
            string pattern = "/signaling"
        ){
             return routeBuilder.MapHub<SignalingHub>(pattern);
        }
    }
}
