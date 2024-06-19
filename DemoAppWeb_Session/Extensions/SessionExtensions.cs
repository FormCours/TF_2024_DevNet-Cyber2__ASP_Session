using DemoAppWeb_Session.BLL.Models;

namespace DemoAppWeb_Session.Extensions
{
    public static class SessionExtensions
    {
        private const string USERNAME_KEY = "username"; 
        private const string MEMBER_ID_KEY = "memberId";
        private const string ROLE_KEY = "role";

        public static void Start(this ISession session, int memberId, string username, Role role)
        {
            session.SetString(USERNAME_KEY, username);
            session.SetInt32(MEMBER_ID_KEY, memberId);
            session.SetInt32(ROLE_KEY, (int)role);
        }

        public static void Stop(this ISession session)
        {
            session.Clear();
        }

        public static string? GetUserName(this ISession session) 
        {
            return session.GetString(USERNAME_KEY);
        }
        public static int? GetMemberId(this ISession session) 
        {
            return session.GetInt32(MEMBER_ID_KEY);
        }

        public static Role? GetRole(this ISession session)
        {
            return (Role?)session.GetInt32(ROLE_KEY);
        } 

        public static bool IsAuthenticated(this ISession session)
        {
            return session.GetInt32(MEMBER_ID_KEY) != null;
        }
    }
}
