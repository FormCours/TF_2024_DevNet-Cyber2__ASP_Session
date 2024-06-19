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
        private static Signe? SigneEnMemoire;
        private static string? NomJoueurMemoire; 

        public void Jouer(Signe signe)
        {
            if(SigneEnMemoire == null)
            {
                SigneEnMemoire = signe;
                NomJoueurMemoire = Context.GetHttpContext()?.Session.GetUserName();
                Clients.All.SendAsync("PartieEnCours", NomJoueurMemoire);
            }
            else
            {
                string joueur2 = Context.GetHttpContext()?.Session.GetUserName();
                if(joueur2 == NomJoueurMemoire)
                {
                    Clients.Caller.SendAsync("Error", "Vous ne pouvez pas jouer contre vous même");
                    return;
                }
                if (SigneEnMemoire == signe)
                {
                    // égalité
                    Clients.All.SendAsync("IssuePartie", "Egalite");
                }
                else if(SigneEnMemoire == Signe.Pierre)
                {
                    if(signe == Signe.Papier)
                    {
                        // joueur2 gagne
                        Clients.All.SendAsync("IssuePartie", joueur2);
                    }
                    else
                    {
                        // joueur1 gagne 
                        Clients.All.SendAsync("IssuePartie", NomJoueurMemoire);
                    }
                }
                else if (SigneEnMemoire == Signe.Papier)
                {
                    if (signe == Signe.Ciseaux)
                    {
                        // joueur2 gagne
                        Clients.All.SendAsync("IssuePartie", joueur2);
                    }
                    else
                    {
                        // joueur1 gagne 
                        Clients.All.SendAsync("IssuePartie", NomJoueurMemoire);
                    }
                }
                else if (SigneEnMemoire == Signe.Ciseaux)
                {
                    if (signe == Signe.Pierre)
                    {
                        // joueur2 gagne
                        Clients.All.SendAsync("IssuePartie", joueur2);
                    }
                    else
                    {
                        // joueur1 gagne 
                        Clients.All.SendAsync("IssuePartie", NomJoueurMemoire);
                    }
                }
                SigneEnMemoire = null;
                NomJoueurMemoire = null;
            }
        }
    }
}
