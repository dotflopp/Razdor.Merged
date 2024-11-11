using Microsoft.AspNetCore.SignalR;

namespace Razdor.Voices.Routing.Signaling
{
    public class SignalingHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine("Disconected {0}", exception);
            return base.OnDisconnectedAsync(exception);
        }
       
        [HubMethodName("SendMessage")]
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
