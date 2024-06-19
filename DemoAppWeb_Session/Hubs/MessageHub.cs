using Microsoft.AspNetCore.SignalR;

namespace DemoAppWeb_Session.Hubs
{
    public class MessageHub : Hub
    {

        // qd qqun se connecte 
        public override Task OnConnectedAsync()
        {
            // on déclenche un événement appelé NouvelleConnection qui fournira l'id de connection de la personne qui vient de se connecter
            Clients.All.SendAsync("NouvelleConnection", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
