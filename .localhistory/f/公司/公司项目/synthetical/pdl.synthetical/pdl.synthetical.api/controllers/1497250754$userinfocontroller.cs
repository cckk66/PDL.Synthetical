﻿using PDL.Synthetical.Domain;
using PDL.Synthetical.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PDL.Synthetical.Api.Controllers
{
    public class UserInfoController : AuthorizeController
    {
        private readonly IUserInfoService userInfoService;
        public UserInfoController(IUserInfoService userInfoService)
        {
            this.userInfoService = userInfoService;
        }

        [Route("api/adduserinfo")]
        [HttpPost]
        public IHttpActionResult Add(UserInfo entity)
        {
            userInfoService.Add(entity);
            return Ok();
        }

        [Route("api/deleteuserinfo")]
        [HttpPost]
        public IHttpActionResult Delete(UserInfo entity)
        {
            userInfoService.Delete(entity);
            return Ok();
        }

        [Route("api/updateuserinfo")]
        [HttpPost]
        public IHttpActionResult Update(UserInfo entity)
        {
            userInfoService.Update(entity);
            return Ok();
        }
        [Route("api/updateuserinfo1")]
        [HttpPost]
        public IHttpActionResult Update1(UserInfo entity)
        {
            userInfoService.Update(entity);
            return Ok();
        }
    }
}
