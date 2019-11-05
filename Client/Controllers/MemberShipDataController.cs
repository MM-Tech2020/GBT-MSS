using GBTBusinessLayer;
using GBTBusinessLayer.Implementation;
using GBTDataModel.VMDataModel;
using SSO.BusinessLayer;
using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI;

namespace Client.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/MemberShipData")]
    public class MemberShipDataController : ApiController
    {
        BusinessMemberShipData _MemberShipDataBusiness;
        UserBL _UserBL;
        BusinessUser _userbussiness;
        public MemberShipDataController()
        {
            _MemberShipDataBusiness = new BusinessMemberShipData();
            _UserBL = new UserBL();
            _userbussiness = new BusinessUser();
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
        [Route("GetMemberShip")]
        public HttpResponseMessage GetMemberShip(int MemberShipID, int start, int size)
        {
            // try
            // {
            //if (!Authonticatesession())
            //{
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
            //}
            var data = _MemberShipDataBusiness.GetMemberShipData(MemberShipID, start, size);

            return Request.CreateResponse(HttpStatusCode.OK, data);

            //}
            //catch (Exception ex)
            //{
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
        }


        [HttpGet]
        [Route("GetMemberShipByCardNo")]
        public HttpResponseMessage GetMemberShipByCardNo(string cardNo,int userId)
        {
            try
            {
                //if (!Authonticatesession())
                //{
                //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
                //}
                var data = _MemberShipDataBusiness.GetMemberShipDataByCardNo(cardNo, userId);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
            //    Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
               return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage add(VMMemberShipData MbrShipData)
        {
            try
            {
                //if (!Authonticatesession())
                //{
                //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
                //}
                var data = _MemberShipDataBusiness.Add(MbrShipData);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                //Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Edit")]
        public HttpResponseMessage Edit(VMMemberShipDataSearch MbrShipData)
        {
            try
            {
                //if (!Authonticatesession())
                //{
                //    return Request.CreateResponse(HttpStatusCode.Unauthorized, Authonticatesession().ToString());
                //}
                var data = _MemberShipDataBusiness.Edit(MbrShipData);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                //Logging.Exceptionlogger.LogException(ex.Message, ex.ToString(), 1);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        #region CreateUser
        [HttpPost]
        [Route("CreateMemberShipLogin")]
        public HttpResponseMessage CreateUser(VMCreateLogin user)
        {
            try
            {
                string msg = string.Empty;
                
                var result = _MemberShipDataBusiness.CreateMemberShipLogin(user);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion


        #region API Take UserId 
        [HttpGet]
        [Route("APIForUserId")]
        public HttpResponseMessage APIForUserId(string UserName, string Password)
        {
            try
            {
                string u = UserName.ToLower();
                var result = _userbussiness.APIForUserId(u, Password);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion



        #region API For Retrive Data
        [HttpPost]
        [Route("DataOfUser")]
        public HttpResponseMessage DataOfUser(User u,string cardNo)
        {
            try
            {
                var result = _userbussiness.GetAllData(u.UserName,u.Password);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion



        #region API
        [HttpGet]
        [Route("DataOfUser2")]
        public HttpResponseMessage DataOfUser2(string userName, string Password)
        {
            try
            {
                var uu = _userbussiness.GetAllData(userName, Password);
                //User w = new User()
                //{
                //    UserName = uu.UserName,
                //    Password = uu.Password
                //};
                //var result = _userbussiness.GetAllData(w, cardNo);

                return Request.CreateResponse(HttpStatusCode.OK, uu);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion


    }
}
