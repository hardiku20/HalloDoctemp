using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
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
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "patientlogin", }));
                return;
            }

            var request = context.HttpContext.Request;
            var token = request.Cookies["jwt"];

            if (token == null || !jwtService.ValidateToken(token, out JwtSecurityToken jwtToken))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "patientlogin", }));
                return;
            }

            var roleClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role);
            if (roleClaim == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "patientsubmitrequest", }));
                return;
            }
            if (string.IsNullOrWhiteSpace(_role) || roleClaim.Value != _role)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "patientsubmitrequest", }));
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
}
