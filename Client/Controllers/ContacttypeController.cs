﻿using GBTBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Client.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Contacttype")]
    public class ContacttypeController : ApiController
    {
        BusinessContacttype _ContacttypeBusiness;
        public ContacttypeController()
        {
            _ContacttypeBusiness = new BusinessContacttype();
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
        [Route("GetAll")]
        public HttpResponseMessage getcardDataByCardNo()
        {
            try
            {
                //if (!Authonticatesession())
                //{
                //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
                //}
                var data = _ContacttypeBusiness.GetAl();

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
