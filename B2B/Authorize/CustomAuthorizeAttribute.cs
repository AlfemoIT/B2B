using B2B.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace B2B.Authorize
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly int[] _allowedRoles;
        public CustomAuthorizeAttribute(params int[] roles)
        {
            _allowedRoles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var formsIdentity = httpContext.User.Identity as FormsIdentity;
                var ticket = formsIdentity.Ticket;
                var userData = ticket.UserData;
                var user = JsonConvert.DeserializeObject<User>(userData);
                var userRoles = GetUserRoles(user);
                return _allowedRoles.Intersect(userRoles).Any();
            }
            return false;
        }
        private int[] GetUserRoles(User user)
        {
            List<int> roleIDs = new List<int>();
            roleIDs.Add(user.RoleID);
            roleIDs.Add(user.UserGroupID);
            return roleIDs.ToArray();
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Auth/Login");
            }
            else
            {
                filterContext.Result = new RedirectResult("/Error/AccessDenied");
            }
        }
    }
}