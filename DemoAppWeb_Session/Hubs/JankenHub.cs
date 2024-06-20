using DemoAppWeb_Session.Extensions;
using Microsoft.AspNetCore.SignalR;

namespace DemoAppWeb_Session.Hubs
{
    public enum Signe
    {
        Pierre, Papier, Ciseaux
    }

    public class JankenHub: Hub
    {
        private static Signe? Signe1;
        private static string? Joueur1; 

        public void Jouer(Signe signe)
        {
            if(Signe1 == null)
            {
                Signe1 = signe;
                Joueur1 = Context.GetHttpContext()?.Session.GetUserName();
                Clients.All.SendAsync("PartieEnCours", Joueur1);
            }
            else
            {
                string? joueur2 = Context.GetHttpContext()?.Session.GetUserName();
                if(joueur2 == Joueur1)
                {
                    Clients.Caller.SendAsync("Error", "Vous ne pouvez pas jouer contre vous même");
                    return;
                }
                if (Signe1 == signe)
                {
                    // égalité
                    Clients.All.SendAsync("IssuePartie", "Egalite");
                }
                else if(Signe1 == Signe.Pierre)
                {
                    if(signe == Signe.Papier)
                    {
                        // joueur2 gagne
                        Clients.All.SendAsync("IssuePartie", joueur2);
                    }
                    else
                    {
                        // joueur1 gagne 
                        Clients.All.SendAsync("IssuePartie", Joueur1);
                    }
                }
                else if (Signe1 == Signe.Papier)
                {
                    if (signe == Signe.Ciseaux)
                    {
                        // joueur2 gagne
                        Clients.All.SendAsync("IssuePartie", joueur2);
                    }
                    else
                    {
                        // joueur1 gagne 
                        Clients.All.SendAsync("IssuePartie", Joueur1);
                    }
                }
                else if (Signe1 == Signe.Ciseaux)
                {
                    if (signe == Signe.Pierre)
                    {
                        // joueur2 gagne
                        Clients.All.SendAsync("IssuePartie", joueur2);
                    }
                    else
                    {
                        // joueur1 gagne 
                        Clients.All.SendAsync("IssuePartie", Joueur1);
                    }
                }
                Signe1 = null;
                Joueur1 = null;
            }
        }
    }
}
