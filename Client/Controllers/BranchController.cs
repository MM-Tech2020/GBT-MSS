
using GBTBusinessLayer;
using GBTDataAccessLayer;
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
    [RoutePrefix("api/Branch")]
    public class BranchController : ApiController
    {
        BusinessBranch _BranchBusiness;
        public BranchController()
        {
            _BranchBusiness = new BusinessBranch();

        }
        //public bool Authonticatesession()
        //{
        //    bool result = false;
        //    IEnumerable<string> headerValues = Request.Headers.GetValues("Token");

        //    var readed = headerValues.FirstOrDefault();
        //    result = SSO.Api.Controllers.UserController._Takenisvalid(readed.ToString());
        //    return result;
        //}


        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage branchById(int id)
        {
           // try
           // {
                //if (!Authonticatesession())
                //{
                //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
                //}
                var data = _BranchBusiness.GetFirstBranch(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            //}
            //catch (Exception ex)
            //{
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
        }

        [HttpGet]
        [Route("GetByClub")]
        public HttpResponseMessage branchByClub(int clubID,int start,int size)
        {
            try
            {
                //if (!Authonticatesession())
                //{
                //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
                //}
                var data = _BranchBusiness.GetBranchByClub(clubID, start, size);

            return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                //Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
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
            var data = _BranchBusiness.DeActiveBranch(ID);

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
        public HttpResponseMessage add(Branch branch)
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _BranchBusiness.Add(branch);

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
