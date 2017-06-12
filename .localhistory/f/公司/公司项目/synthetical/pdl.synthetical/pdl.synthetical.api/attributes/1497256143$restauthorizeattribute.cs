using PDL.Synthetical.TokenManager;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;

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
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Authorize(actionContext))
            {
                return;
            }

            var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Forbidden;
            var content = new
            {
                success = false,
                errs = new[] { "服务端拒绝访问：你没有权限，或者掉线了" }
            };
            response.Content = new StringContent(Json.Encode(content), Encoding.UTF8, "application/json");
            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {

                HttpRequest request = HttpContext.Current.Request;
                string token = request.Params[_securityToken];
                return SecurityManager.IsTokenValid(token, CommonManager.GetIP(request), request.UserAgent);
                // return SecurityManager.IsTokenValid(token, CommonManager.GetIP(request), request.UserAgent);
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///// <summary>
        /////   获取IP地址
        ///// </summary>
        ///// <returns></returns>
        //public static string GetIpaddress()
        //{
        //    string result = String.Empty;
        //    result = HttpContext.Current.Request.ServerVariables["HTTP_CDN_SRC_IP"];
        //    if (string.IsNullOrEmpty(result))
        //        result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        //    if (string.IsNullOrEmpty(result))
        //        result = HttpContext.Current.Request.UserHostAddress;

        //    if (string.IsNullOrEmpty(result) || !IsIP(result))
        //        return "127.0.0.1";

        //    return result;
        //}
        //public static bool IsIP(string ip)
        //{
        //    return Regex.IsMatch(ip, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$");
        //}
    }
}