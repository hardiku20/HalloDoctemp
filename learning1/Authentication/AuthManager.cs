using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace learning1.Authentication
{
    partial interface IAuthManager
    {
       
    }


    public class AuthManager : IAuthManager
    {
       
    }

    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        private readonly string _role;
        public CustomAuthorize(string role ="") // Constructor to inject the required role
        {
            _role = this._role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = SessionUtils.GetLoggedInUser(context.HttpContext.Session);
           

            //Redirect to login if not logged in
            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
                return;
            }
            //Redirect to access denied only if roles mismatch
            if (!string.IsNullOrEmpty(_role))
            {
                if (!(user?.Role == _role))
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
                }

            }
        }
    }
}
