using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PDL.Synthetical.Api.Controllers
{
    public class LoginController : NoAuthorizeController
    {
        [HttpGet]
        public string GetToken(string UserName, string PassWrod)
        {

        }
    }
}
