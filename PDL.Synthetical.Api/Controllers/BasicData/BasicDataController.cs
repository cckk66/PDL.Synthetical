using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PDL.Synthetical.Api.Controllers.BasicData
{
    public class BasicDataController : AuthorizeController
    {
        private readonly IUserInfoService userInfoService;

        [HttpPost]
        public IHttpActionResult BasicDataCount() {
           
    }
    }
}
