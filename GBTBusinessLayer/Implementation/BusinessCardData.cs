using GBT.DataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessCardData
    {
        IUnitOfWork _uow;
        public BusinessCardData() : this(new UnitOfWork())
        {

        }

        public BusinessCardData(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public VMCardData GetCardDataByCardNo(string cardNo)
        {
            var crdData = _uow.CardDatas.FindOne(c => c.SerialNumber == cardNo);
            VMCardData _response = new VMCardData
            {
                ID=crdData.ID,
                Deliverydate= crdData.Deliverydate,
                Expiringdate= crdData.Expiringdate,
                Issuedate= crdData.Issuedate,
                MembershipNumber= crdData.MembershipNumber,
                Requestdate= crdData.Requestdate,
                SerialNumber= crdData.SerialNumber,
                 status= crdData.status,
                 CardStatus=new VMCardStatus
                 {
                     ID= crdData.CardStatu.ID,
                     CardStatusname= crdData.CardStatu.CardStatusname
                 }
            };
            return _response;
        }

        public VMPersonalDataRecommeddation GetPersonalDataRecommedationByCardNo(string cardNo)
        {
            var _crdData = _uow.CardDatas.FindOne(c => c.SerialNumber == cardNo);
            var _MemberShipData = _uow.Membershipdatas.FindOne(c=>c.MembershipID == _crdData.ID);
            var _personalData = _uow.Personaldatas.FindOne(c=>c.ID == _MemberShipData.PersonalID);
            VMPersonalDataRecommeddation _response = new VMPersonalDataRecommeddation
            {
                NameArabic = _personalData.Firstname_Ar + " "+ _personalData.MiddelName_Ar + " "+ _personalData.Lastname_Ar,
                NameEnglish = _personalData.Firstname_EN + " " + _personalData.MiddelName_EN + " " + _personalData.Lastname_EN,
                PersonalDataID=_personalData.ID,
                MemberShipDataID=_MemberShipData.ID,
            };
            return _response;
        }

        public List<VMSearchCardDataResult> SearchByCardNo(string key,int status ,int start,int size)
        {
            status = status == 0 ? 2 : status;
            return _uow.CardDatas.FindList(c=>c.SerialNumber.Contains(key) && c.status== status)?.Skip(start-1).Take(size).Select(a=>
            new VMSearchCardDataResult
            {             
                name = a?.SerialNumber,
                id   = a?.ID.ToString(),
            }).ToList();
        }

    }
}
