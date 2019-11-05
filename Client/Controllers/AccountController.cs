using GBTBusinessLayer.Implementation;
using GBTDataModel.VMDataModel;
using SSO.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GBTMembershipSolution.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Http.RoutePrefix("api/DU")]
    public class AccountController : ApiController
    {
        BusinessUser _userbussiness;

        public AccountController()
        {
            _userbussiness = new BusinessUser();
        }

        public bool Authonticatesession()
        {
            bool result = false;
            IEnumerable<string> headerValues = Request.Headers.GetValues("Token");

            var readed = headerValues.FirstOrDefault();
            result = AccountController._Takenisvalid(readed.ToString());
            return result;
        }

        [HttpPost]
        [Route("AuthenticateDU")]
        public HttpResponseMessage Login(VMCredentials VMauthentication)
        {
            try
            {
                var result = _userbussiness.authonticateduser(VMauthentication);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public static bool _Takenisvalid(string token)
        {
            UserBL userBL = new UserBL();
            bool istaklenvalid = userBL.issessionactive(token);
            return istaklenvalid;
        }

    }

}
