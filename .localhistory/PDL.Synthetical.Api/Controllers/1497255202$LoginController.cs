using PDL.Synthetical.Common;
using PDL.Synthetical.TokenManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PDL.Synthetical.Api.Controllers
{
    public class LoginController : NoAuthorizeController
    {
        [HttpGet]
        public string GetToken(string UserName, string PassWrod)
        {
            var request = HttpContext.Current.Request;
            return SecurityManager.GenerateToken(UserName, PassWrod, CommonManager.GetIP(request), request.UserAgent, Tools.ticks);
        }
    }
}
