using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using learning1.Services.IServices;
using learning1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
       public readonly string _role;
        public CustomAuthorize(string role = "")
        {
            this._role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var jwtService = context.HttpContext.RequestServices.GetService<IJWTService>();
            if (jwtService == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "patientsite", }));
                return;
            }

            var request = context.HttpContext.Request;
            var token = request.Cookies["jwt"];

            if (token == null || !jwtService.ValidateToken(token, out JwtSecurityToken jwtToken))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "patientsite", }));
                return;
            }

            var roleClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role);
            if (roleClaim == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "patientsite", }));
                return;
            }
            if (string.IsNullOrWhiteSpace(_role) || roleClaim.Value != _role)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "patientsite", }));
                return;
            }
            //var user = SessionUtils.GetLoggedInUser(context.HttpContext.Session);
           

            ////Redirect to login if not logged in
            //if (user == null)
            //{
            //    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            //    return;
            //}
            ////Redirect to access denied only if roles mismatch
            //if (!string.IsNullOrEmpty(_role))
            //{
            //    if (!(user?.Role == _role))
            //    {
            //        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            //    }

            //}
        }
    }

    public class RequiresMenu : Attribute, IAuthorizationFilter
    {
        public readonly string _menu;

        public RequiresMenu(string menu)
        {
            this._menu = menu;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var jwtService = context.HttpContext.RequestServices.GetService<IJWTService>();
            var adminRepo = context.HttpContext.RequestServices.GetService<IAdminRepo>();
            if (jwtService == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login", }));
                return;
            }

            var request = context.HttpContext.Request;
            var token = request.Cookies["jwt"];

            if (_menu !=
                null)
            {
                var cookie = jwtService.getDetails(token);
                List<string> roleMenu = adminRepo.getListOfRoleMenu(cookie.RoleId);
                bool f = false;
                if (roleMenu.Any(r => r == _menu))
                {
                    f = true;
                }
                if (!f)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "home", action = "patientsite" }));
                    return;
                }
            }
        }
    }
}
