using learning1.DBEntities.ViewModel;

namespace learning1.Utils
{
    public class SessionUtils
    {
        public static UserInfoViewModel GetLoggedInUser(ISession session)
        {
            UserInfoViewModel loggedInUser = null;
            if (!string.IsNullOrEmpty(session.GetString("userId")))
            {
                loggedInUser = new UserInfoViewModel()
                {
                    UserId = session.GetString("userId"),
                    Email = session.GetString("email"),
                    //Name = session.GetString("name"),
                    Role = session.GetString("role")
                };
            }
            return loggedInUser;
        }
        public static void SetLoggedInUser(ISession session, UserInfoViewModel user)
        {
            if (user != null)
            {
                session.SetString("userId", user.UserId);
                session.SetString("email", user.Email);
                //session.SetString("name", user.Name);
                session.SetString("role", user.Role);
            }
        }


    }
}
