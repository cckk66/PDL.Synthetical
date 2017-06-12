using PDL.Synthetical.TokenManager;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PDL.Synthetical.Api
{
    /// <summary>
    /// Token-based authentication for ASP .NET MVC REST web services.
    /// Copyright (c) 2015 Kory Becker
    /// http://primaryobjects.com/kory-becker
    /// License MIT
    /// </summary>
    public class RESTAuthorizeAttribute : AuthorizeAttribute
    {
        private const string _securityToken = "token";

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }

            HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        private bool Authorize(HttpActionContext filterContext)
        {
            try
            {
                var request = filterContext.Request;
                string token = request.Params[_securityToken];

                return SecurityManager.IsTokenValid(token, CommonManager.GetIP(request), request.UserAgent);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}