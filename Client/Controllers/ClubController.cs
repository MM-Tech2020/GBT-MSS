using GBTBusinessLayer;
using GBTDataAccessLayer;
using GBTDataModel.VMDataModel;
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
    [RoutePrefix("api/Club")]
    public class ClubController : ApiController
    {
        BusinessClub _ClubBusiness;
        public ClubController()
        {
            _ClubBusiness = new BusinessClub();
        }
        [HttpGet]
        [Route("get")]
        public HttpResponseMessage getClub(int ID)
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _ClubBusiness.GetClub(ID);
            return Request.CreateResponse(HttpStatusCode.OK, data);
            //}
            //catch (Exception ex)
            //{
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
        }

        [HttpGet]
        [Route("getAll")]
        public HttpResponseMessage getAll()
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _ClubBusiness.GetAllClub();
            return Request.CreateResponse(HttpStatusCode.OK, data);
            //}
            //catch (Exception ex)
            //{
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
        }


        [HttpGet]
        [Route("GetClub")]
        public HttpResponseMessage branchByClub(int clubID, int start, int size)
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _ClubBusiness.GetClubs(clubID, start, size);

            return Request.CreateResponse(HttpStatusCode.OK, data);

            //}
            //catch (Exception ex)
            //{
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
        }

        [HttpGet]
        [Route("DeActive")]
        public HttpResponseMessage DeActivebranch(int ID)
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _ClubBusiness.DeActiveBranch(ID);

            return Request.CreateResponse(HttpStatusCode.OK, data);

            //}
            //catch (Exception ex)
            //{
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
        }


        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage add(ClubInfo club)
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _ClubBusiness.Add(club);

            return Request.CreateResponse(HttpStatusCode.OK, data);

            //}
            //catch (Exception ex)
            //{
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
        }

    }
}
