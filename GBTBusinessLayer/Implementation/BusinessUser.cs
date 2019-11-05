using GBT.DataAccessLayer;
using GBTDataModel.VMDataModel;
using SSO.BusinessLayer;
using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer.Implementation
{
    public class BusinessUser
    {
        IUnitOfWork _uow;
        UserBL _userBL;
        BusinessMemberShipData _MemberShipDataBusiness;
        //LogBusiness _logging;


        public BusinessUser() : this(new UnitOfWork())
        {
            //_FTRepository = new GBT.DataAccessLayer.FinancialTransactionRepository();
        }
        public BusinessUser(IUnitOfWork unitOfWork)
        {
            // TODO Repositories should be removed from the business layer
            _uow = unitOfWork;
            _userBL  = new UserBL();
            _MemberShipDataBusiness = new BusinessMemberShipData();
        }

        public VMauthenticateUser authonticateduser(VMCredentials credential)
        {
            string msg = string.Empty;
            UserBL userBL = new UserBL();

            var _responseSSOVM = userBL.AuthenticateDU(credential.UserName, credential.Password, out msg);

            //var _duvar = _uow.Users.FindOne(x => x.SSOUserID == _responseSSOVM.SSOID);
            //Customer _cust = new Customer();
            //if (_duvar == null)
            //{
            //    _cust = _uow.Customers.FindOne(x => x.SSOID == _responseSSOVM.SSOID);
            //}

            VMauthenticateUser _du = new VMauthenticateUser()
            {

                RoleID = 1,
                UserID = 1,
                Name ="",
                ClubID=1,
                Branchid=1,
                
                Tolken = _responseSSOVM.talken,
            };
            
            return _du;
        }


        #region APIForSSO
        public User APIForUserId(string userName, string Password)
        {
           

            var _response = _userBL.APIForUserId(userName, Password);

            User us = new User()
            {
                UserName=userName,
                Password = Password,
                UserId = _response.SSOID
            };

            //get card no of membershipdata by ssoid
         
            //getmembershipdata by card no
            return us;
        }
        #endregion

        #region API For Retrieve Data
        public VMMemberShipDataSearch GetAllData(string UserName, string Password)
        {
             string messsg1 = string.Empty ;
            var result = _userBL.AuthenticateDU(UserName, Password,out messsg1);
            
            if (result != null)
            {
                var _membershipdatarow = _uow.Membershipdatas.FindOne(a => a.SSOID == result.SSOID);
                var _carddatamembership = _uow.CardDatas.GetById(_membershipdatarow.MembershipID);
               
                VMMemberShipDataSearch res = _MemberShipDataBusiness.GetMemberShipDataByCardNo(_carddatamembership.SerialNumber , result.SSOID);
                return res;
            }
            return null;
        }
        #endregion
    }
}
