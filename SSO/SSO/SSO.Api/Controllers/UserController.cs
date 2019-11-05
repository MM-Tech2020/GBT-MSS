using SSO.BusinessLayer;
using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSO.Api.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage RegisterUser(User user)
        {
            try
            {

                string msg = string.Empty;
                UserBL userBL = new UserBL();
                user.UserName = user.UserName.ToLower();
                UserInfo userinfo = userBL.RegisterUser(user, out msg);

                if (!string.IsNullOrEmpty(msg))
                    return Request.CreateResponse(HttpStatusCode.OK, msg);

                return Request.CreateResponse(HttpStatusCode.OK, userinfo);
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage AuthenticateUser(Credentials credentials)
        {
            try
            {
                string msg = string.Empty;

                UserBL userBL = new UserBL();
                string token = userBL.Authenticate(credentials.UserName, credentials.Password, out msg);
                if (string.IsNullOrEmpty(token))
                    return Request.CreateResponse(HttpStatusCode.OK, msg);

                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public static bool _Takenisvalid(string token)
        {
            UserBL userBL = new UserBL();
            bool istaklenvalid = userBL.issessionactive(token);
            return istaklenvalid;
        }

        [Route("{userId}/token/{token}")]
        [HttpGet]
        public HttpResponseMessage GetUserByToken(int userId, string token)
        {
            try
            {
                string msg = string.Empty;
                UserBL userBL = new UserBL();
                UserInfo userInfo = userBL.GetUserByToken(userId, token, out msg);
                if (!string.IsNullOrEmpty(msg))
                    return Request.CreateResponse(HttpStatusCode.OK, msg);

                return Request.CreateResponse(HttpStatusCode.OK, userInfo);
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("loggedin/{userId}/token/{token}")]
        [HttpGet]
        public HttpResponseMessage IsUserLoggedIn(int userId, string token)
        {
            try
            {
                string msg = string.Empty;
                UserBL userBL = new UserBL();
                bool isLoggedIn = userBL.IsUserLoggedIn(userId, token, out msg);
                if (!string.IsNullOrEmpty(msg))
                    Request.CreateResponse(HttpStatusCode.OK, msg);

                return Request.CreateResponse(HttpStatusCode.OK, isLoggedIn);
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("Takenisvalid")]
        [HttpGet]
        public HttpResponseMessage Takenisvalid(string token)
        {
            try
            {
                string msg = string.Empty;
                UserBL userBL = new UserBL();
                bool istaklenvalid = userBL.issessionactive(token);


                return Request.CreateResponse(HttpStatusCode.OK, istaklenvalid);
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
