using GBTBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Client.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/CardData")]
    public class CardDataController : ApiController
    {
        BusinessCardData _CardDataBusiness;
        public CardDataController()
        {
            _CardDataBusiness = new BusinessCardData();

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
        [Route("GetByCardNo")]
        public HttpResponseMessage getcardDataByCardNo(string cardNo)
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _CardDataBusiness.GetCardDataByCardNo(cardNo);

            return Request.CreateResponse(HttpStatusCode.OK, data);

            //}
            //catch (Exception ex)
            //{
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
        }

        [HttpGet]
        [Route("GetPersonalDataByCardNo")]
        public HttpResponseMessage getPersonalDataByCardNo(string cardNo)
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _CardDataBusiness.GetPersonalDataRecommedationByCardNo(cardNo);

            return Request.CreateResponse(HttpStatusCode.OK, data);

            //}
            //catch (Exception ex)
            //{
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
        }

        [HttpGet]
        [Route("SearchByCardNo")]
        public HttpResponseMessage SearchByCardNo(string key,int status, int start, int size)
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _CardDataBusiness.SearchByCardNo(key, status,start, size);

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