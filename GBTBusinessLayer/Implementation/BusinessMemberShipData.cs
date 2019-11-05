using GBT.DataAccessLayer;
using GBTDataAccessLayer;
using GBTDataModel.VMDataModel;
using SSO.BusinessLayer;
using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessMemberShipData
    {
        IUnitOfWork _uow;
        UserBL _UserBL;
        public BusinessMemberShipData() : this(new UnitOfWork())
        {

        }

        public BusinessMemberShipData(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _UserBL = new UserBL();
        }

        public List<VMMemberShipData> GetMemberShipData(int MemberShipID, int start, int size)
        {
            List<VMMemberShipData> Response = new List<VMMemberShipData>();
            return Response;
        }

        public VMMemberShipDataSearch GetMemberShipDataByCardNo(string CardNo,int userID)
        {
            var cardData = _uow.CardDatas.FindOne(a=>a.SerialNumber == CardNo);
            var membershipData = _uow.Membershipdatas.FindOne(a=>a.MembershipID == cardData.ID);
            var recommedationMembership = _uow.Membershipdatas.FindOne(a => a.ID == membershipData.recommeddationMembershipid);
            var RelationMemberShipData = _uow.Membershipdatas.FindOne(a => a.ID == membershipData.RelationID);
            var varlstJobInfo = _uow.JobInfos.FindList(a => a.PersonalID == membershipData.PersonalID).Select(s => new VMJobInfo
            {
                Datefrom = s.Datefrom,
                Dateto = s.Dateto,
                ID = s.ID,
                Jobtitle = s.Jobtitle,
                jobcotogory = s.jobcotogory,
                Jobdetailes = s.Jobdetailes,
                PersonalID = s.PersonalID,
                jobcotogoryy = new VMjobcatogory { ID = s.jobcatogory.ID, Name = s.jobcatogory.Name },
            }).ToList();

            var varlstAddressesID = _uow.CitizenAddresss.FindList(a => a.PersonalID == membershipData.PersonalID).Select(s => new VMCitizenAddress
            {
                ID = s.ID,
                Active = s.Active ?? false,
                Addresse = s.Addresse,
                PersonalID = s.PersonalID,
            }).ToList();

            var varlstContactInfo = _uow.Contactinfos.FindList(a => a.PersonalID == membershipData.PersonalID).Select(s => new VMContactinfo
            {
                ID = s.ID,
                Active = s.Active,
                PersonalID = s.PersonalID,
                Contactinfo1 = s.Contactinfo1,
                Contacttype = s.Contacttype,
                Contacttypee = new VMContacttype { ID = s.Contacttype1.ID, Contacttypename = s.Contacttype1.Contacttypename },
            }).ToList();

            var varlstcitizenID = _uow.CitizenIDs.FindList(a => a.PersonalID == membershipData.PersonalID).Select(s => new VMCitizenID
            {
                ID = s.ID,
                IdentityNumber = s.IdentityNumber,
                PersonalID = s.PersonalID,
                identitytype = s.identitytype,
                CitisenIDtypee = new VMCitizenIDType { ID = s.CitizenIDType.ID, citizenIdtpename = s.CitizenIDType.citizenIdtpename, Active = s.CitizenIDType.Active }
            }).ToList();

            var varlstEducationsInfo = _uow.Educationsinfos.FindList(a => a.PersonalID == membershipData.PersonalID).Select(s => new VMEducationsinfo
            {
                ID = s.ID,
                Description = s.Description,
                PersonalID = s.PersonalID,
                EducationAuthority = s.EducationAuthority,
                EducationDegreetype = s.EducationDegreetype,
                EducationDegreetypee = new VMEducationdDgreeType { ID = s.educationdegreetype1.ID, Degreename = s.educationdegreetype1.Degreename }
            }).ToList();

            var varlstPersonalInterest = _uow.PersonalInterstsDatas.FindList(a => a.PersonalID == membershipData.PersonalID).Select(s => new VMPersonalInterest
            {
                ID = s.PersonalInterest.ID == 0 ? 0 : s.PersonalInterest.ID,
                Active = s.PersonalInterest.Active == null ? 0 : s.PersonalInterest.Active,
                Interestdescription = s.PersonalInterest.Interestdescription == null ?  "No personal Interest" : s.PersonalInterest.Interestdescription ,
            }).ToList();

            var varlstMembershipinterest = _uow.Membershipinterests.FindList(a => a.MembershipId == membershipData.ID).Select(s => new VMMembershipinterest
            {
                ID = s.ID,
                MembershipId = s.MembershipId,
                clubinterestID = s.clubinterestID,
                clubinterestt = new VMClubInterest { ID = s.ClubInterest.ID, Active = s.ClubInterest.Active, Interestsdescription = s.ClubInterest.Interestsdescription }
            }).ToList();
            VMMemberShipDataSearch Response = new VMMemberShipDataSearch
            {
                ID = membershipData.ID,
                cardData = new VMCardData
                {
                    ID = cardData.ID,
                    CardStatus = new VMCardStatus { ID = cardData.CardStatu.ID, CardStatusname = cardData.CardStatu.CardStatusname },
                    Deliverydate = cardData.Deliverydate,
                    Expiringdate = cardData.Expiringdate,
                    SerialNumber = cardData.SerialNumber,
                    Issuedate = cardData.Issuedate,
                    MembershipNumber = cardData.MembershipNumber,
                    status = cardData.status,
                    Requestdate = cardData.Requestdate,
                },
                ClubID = membershipData.ClubID,
                clubData = new VMClub {
                    ID = membershipData.ClubInfo.ID,
                    Active = membershipData.ClubInfo.Active,
                    Addresses = membershipData.ClubInfo.Addresses,
                    ArabicName = membershipData.ClubInfo.ArabicName,
                    EnglishName = membershipData.ClubInfo.EnglishName,
                    Tel = membershipData.ClubInfo.Tel,
                },
                Createddate = membershipData.Createddate,
                Fk_currentjobid = membershipData.Fk_currentjobid,
                lstJobInfo = varlstJobInfo,
                Membershiptype = membershipData.Membershiptype,
                Membershiptypee = new VMMembershiptype { ID = membershipData.Membershiptype1.ID, Membershiptypename = membershipData.Membershiptype1.Membershiptypename },
                Membershipstatus = membershipData.Membershipstatus,
                Membershipstatuss = new VMMemebershipstatus { ID = membershipData.Memebershipstatu.ID, Statusname = membershipData.Memebershipstatu.Statusname },
                FK_defaultaddressesId = membershipData.FK_defaultaddressesId,
                lstAddressesID = varlstAddressesID,
                FK_defaultContactId = membershipData.FK_defaultContactId,
                lstContactInfo = varlstContactInfo,
                FK_defaultNationalId = membershipData.FK_defaultNationalId,
                lstcitizenID = varlstcitizenID,
                FK_educationID = membershipData.FK_educationID,
                lstEducationsInfo = varlstEducationsInfo,
                Ismainsupplementary = membershipData.Ismainsupplementary,
                MembershipID = membershipData.MembershipID,
                PersonalID = membershipData.PersonalID,
                personalData = new VMPersonaldata
                {
                    ID = membershipData.Personaldata.ID,
                    DateofBirth = membershipData.Personaldata.DateofBirth ?? DateTime.Now,
                    Firstname_Ar = membershipData.Personaldata.Firstname_Ar,
                    Firstname_EN = membershipData.Personaldata.Firstname_EN,
                    Gender = membershipData.Personaldata.Gender == 1 ? Gender.Male : Gender.Female,
                    MiddelName_Ar = membershipData.Personaldata.MiddelName_Ar,
                    MiddelName_EN = membershipData.Personaldata.MiddelName_EN,
                    Lastname_Ar = membershipData.Personaldata.Lastname_Ar,
                    Lastname_EN = membershipData.Personaldata.Lastname_EN,
                    Photopath = membershipData.Personaldata.Photopath,
                },
                Lastrenwelldate = membershipData.Lastrenwelldate,
                Nextrenwelldate = membershipData.Nextrenwelldate,
                recommeddationMembershipid = membershipData.recommeddationMembershipid,
                recommeddationMembership = recommedationMembership ==null ?null: new VMPersonalDataRecommeddation
                {
                    NameArabic = recommedationMembership.Personaldata.Lastname_Ar + " " + recommedationMembership.Personaldata.MiddelName_Ar + " " + recommedationMembership.Personaldata.Lastname_Ar,
                    NameEnglish = recommedationMembership.Personaldata.Lastname_EN + " " + recommedationMembership.Personaldata.MiddelName_EN + " " + recommedationMembership.Personaldata.Lastname_EN,
                    PersonalDataID = recommedationMembership.PersonalID ?? 0,
                    MemberShipDataID = recommedationMembership.ID,
                },
                suspenddate = membershipData.suspenddate,
                Membershipapplicationreference = membershipData.Membershipapplicationreference,
                Membershipapplicationdate = membershipData.Membershipapplicationdate,
                lstMembershipinterest = varlstMembershipinterest,
                lstPersonalInterest = varlstPersonalInterest,
                RelationID=membershipData.RelationID,
                RelationData= RelationMemberShipData ==null? null : new VMPersonaldata
                {
                    DateofBirth= RelationMemberShipData.Personaldata.DateofBirth??DateTime.Now,
                    ID = RelationMemberShipData.Personaldata.ID,
                    Firstname_Ar= RelationMemberShipData.Personaldata.Firstname_Ar,
                    Firstname_EN= RelationMemberShipData.Personaldata.Firstname_EN,
                    Gender= RelationMemberShipData.Personaldata.Gender==1?Gender.Male:Gender.Female,
                    Lastname_Ar= RelationMemberShipData.Personaldata.Lastname_Ar,
                    Lastname_EN= RelationMemberShipData.Personaldata.Lastname_EN,
                    MiddelName_Ar= RelationMemberShipData.Personaldata.MiddelName_Ar,
                    MiddelName_EN= RelationMemberShipData.Personaldata.MiddelName_EN,
                    Photopath= RelationMemberShipData.Personaldata.Photopath
                }
            };
            return Response;
        }

        public VMResponse Add(VMMemberShipData _mberShipData)
        {
            if (_mberShipData.Createddate == null)
            {
                _mberShipData.Createddate = DateTime.Now ;
            }
            if (_mberShipData.Membershipapplicationdate == null)
            {
                _mberShipData.Membershipapplicationdate = DateTime.Now;
            }
            if (_mberShipData.Nextrenwelldate == null)
            {
                _mberShipData.Nextrenwelldate = DateTime.Now.AddDays(366);
            }
            return _uow.Membershipdatas.AddMemberShipData(_mberShipData);
        }
        
        public VMResponse Edit(VMMemberShipDataSearch _mberShipData)
        {
            return _uow.Membershipdatas.EditMemberShipData(_mberShipData);
        }
        #region

        //public VMResponse Add(VMMemberShipData _mberShipData)
        //{
        //    VMResponse _Response = new VMResponse();

        //    if (_mberShipData.ID == 0)
        //    {
        //        int indxDefaultAddressID = 0;
        //        int indxDefaultCitizenID = 0;
        //        int indxDefaultContactId = 0;
        //        int indxCurrentJobInfo = 0;

        //        Personaldata prsonalData = new Personaldata
        //        {
        //            Firstname_EN = _mberShipData.personalData.Firstname_EN,
        //            MiddelName_EN = _mberShipData.personalData.MiddelName_EN,
        //            Lastname_EN = _mberShipData.personalData.MiddelName_EN,
        //            Firstname_Ar = _mberShipData.personalData.Firstname_Ar,
        //            MiddelName_Ar = _mberShipData.personalData.MiddelName_Ar,
        //            Lastname_Ar = _mberShipData.personalData.Lastname_Ar,
        //            Photopath = _mberShipData.personalData.Photopath,
        //            Gender = (int)_mberShipData.personalData.Gender,
        //            DateofBirth = _mberShipData.personalData.DateofBirth,
        //        };
        //        _uow.Personaldatas.Add(prsonalData);
        //        _uow.Save();
        //        List<CitizenAddress> listcitizenAddress = new List<CitizenAddress>();

        //        foreach (var item in _mberShipData.lstAddressesID)
        //        {
        //            CitizenAddress _address = new CitizenAddress
        //            {
        //                Addresse = item.Addresse,
        //                Active = true,
        //                PersonalID = prsonalData.ID,
        //            };
        //            if (item.IsDefault)
        //            {
        //                indxDefaultAddressID = listcitizenAddress.Count();
        //            }
        //            listcitizenAddress.Add(_address);
        //        }

        //        List<CitizenID> listCitizen = new List<CitizenID>();
        //        foreach (var item in _mberShipData.lstcitizenID)
        //        {
        //            CitizenID _citizen = new CitizenID
        //            {
        //                IdentityNumber = item.IdentityNumber,
        //                identitytype = item.identitytype,
        //                PersonalID = prsonalData.ID,
        //            };
        //            if (item.IsDefault)
        //            {
        //                indxDefaultCitizenID = listCitizen.Count();
        //            }
        //            listCitizen.Add(_citizen);
        //        }

        //        List<Contactinfo> listContactInfo = new List<Contactinfo>();
        //        foreach (var item in _mberShipData.lstContactInfo)
        //        {
        //            Contactinfo _ContactInfo = new Contactinfo
        //            {
        //                PersonalID = prsonalData.ID,
        //                Active = true,
        //                Contactinfo1 = item.Contactinfo1,
        //                Contacttype = item.Contacttype,
        //            };
        //            if (item.IsDefault)
        //            {
        //                indxDefaultContactId = listContactInfo.Count();
        //            }
        //            listContactInfo.Add(_ContactInfo);
        //        }

        //        List<JobInfo> listJobInfo = new List<JobInfo>();
        //        foreach (var item in _mberShipData.lstJobInfo)
        //        {
        //            JobInfo _JobInfo = new JobInfo
        //            {
        //                Datefrom = item.Datefrom,
        //                Dateto = item.Dateto,
        //                Jobtitle = item.Jobtitle,
        //                Jobdetailes = item.Jobdetailes,
        //                jobcotogory = item.jobcotogory,
        //                PersonalID = prsonalData.ID,
        //            };
        //            if (item.IsCurrent)
        //            {
        //                indxCurrentJobInfo = listJobInfo.Count();
        //            }
        //            listJobInfo.Add(_JobInfo);
        //        }

        //        List<Educationsinfo> listEducationsinfo = new List<Educationsinfo>();
        //        foreach (var item in _mberShipData.lstEducationsInfo)
        //        {
        //            Educationsinfo _Educationsinfo = new Educationsinfo
        //            {
        //                EducationDegreetype = item.EducationDegreetype,
        //                EducationAuthority = item.EducationAuthority,
        //                Description = item.Description,
        //                PersonalID = prsonalData.ID,
        //            };
        //            listEducationsinfo.Add(_Educationsinfo);
        //        }

        //        _uow.CitizenAddresss.Add(listcitizenAddress);

        //        _uow.CitizenIDs.Add(listCitizen);
        //        _uow.Save();
        //        _uow.Contactinfos.Add(listContactInfo);
        //        _uow.Save();
        //        _uow.JobInfos.Add(listJobInfo);
        //        _uow.Save();
        //        _uow.Educationsinfos.Add(listEducationsinfo);

        //        _uow.Save();

        //        Membershipdata mbrShipData = new Membershipdata()
        //        {
        //            MembershipID = _mberShipData.MembershipID,
        //            PersonalID = prsonalData.ID,
        //            FK_defaultNationalId = listCitizen[indxDefaultCitizenID].ID,
        //            FK_defaultContactId = listContactInfo[indxDefaultContactId].ID,
        //            FK_defaultaddressesId = listcitizenAddress[indxDefaultAddressID].ID,
        //            Fk_currentjobid = listJobInfo[indxCurrentJobInfo].ID,
        //            FK_educationID = listEducationsinfo.LastOrDefault().ID,
        //            Membershipstatus = _mberShipData.Membershipstatus,
        //            Membershiptype = _mberShipData.Membershiptype,
        //            ClubID = _mberShipData.ClubID,
        //            Membershipapplicationreference = _mberShipData.Membershipapplicationreference,
        //            Membershipapplicationdate = DateTime.Now,
        //            Createddate = DateTime.Now,
        //        };

        //        _uow.Membershipdatas.Add(mbrShipData);
        //        _uow.Save();
        //        if (mbrShipData.ID != 0)
        //        {
        //            _Response.Code = 1;
        //            _Response.Message = "Member Ship is Added";
        //        }
        //        else
        //        {
        //            _Response.Code = -1;
        //            _Response.Message = "Error Try Again!!";
        //        }
        //    }
        //    else
        //    {
        //        var mshpData = _uow.Membershipdatas.FindOne(a => a.ID == _mberShipData.ID);
        //        mshpData.MembershipID = _mberShipData.MembershipID;
        //        mshpData.PersonalID = _mberShipData.PersonalID;
        //        mshpData.MembershipID = _mberShipData.MembershipID;
        //        mshpData.MembershipID = _mberShipData.MembershipID;
        //        mshpData.MembershipID = _mberShipData.MembershipID;
        //        mshpData.MembershipID = _mberShipData.MembershipID;


        //        _uow.Save();
        //        if (_mberShipData.ID != 0)
        //        {
        //            _Response.Code = 1;
        //            _Response.Message = "Member Ship is Added";
        //        }
        //        else
        //        {
        //            _Response.Code = -1;
        //            _Response.Message = "Error Try Again!!";
        //        }
        //    }

        //    return _Response;
        //}
        #endregion

        public VMResponse CreateMemberShipLogin(VMCreateLogin MemberShipLogin)
        {
            VMMemberShipDataSearch memberShipUser = GetMemberShipDataByCardNo(MemberShipLogin.CardNo.ToString(), 1);
            VMResponse v = new VMResponse();
            string msg = string.Empty;
            User user = new User()
            {
                FirstName = memberShipUser.personalData.Firstname_EN,
                LastName = memberShipUser.personalData.Lastname_EN,
                UserName = MemberShipLogin.UserName,
                Password = MemberShipLogin.Password,
                SocialSecurityNumber = memberShipUser.FK_defaultNationalId.Value.ToString(),
                Email = memberShipUser.FK_defaultContactId.Value.ToString()
            };
            var result = _UserBL.RegisterUser(user, out msg);
            var e = _uow.Membershipdatas.FindOne(a => a.MembershipID == memberShipUser.MembershipID);
            if (e == null)
            {
                return null;
            }
            Membershipdata _mbmdata = _uow.Membershipdatas.GetById(memberShipUser.ID);
            _mbmdata.SSOID = result.UserId;
            //{
              
            //    MembershipID = memberShipUser.MembershipID,
            //    PersonalID = memberShipUser.PersonalID,
            //    FK_defaultNationalId = Convert.ToInt32( memberShipUser.FK_defaultNationalId.Value.ToString()),
            //    FK_defaultContactId = memberShipUser.FK_defaultContactId.Value,
            //    FK_defaultaddressesId = memberShipUser.FK_defaultaddressesId.Value,
            //    Fk_currentjobid = memberShipUser.Fk_currentjobid.Value,
            //    FK_educationID=memberShipUser.FK_educationID.Value,
            //    Membershipstatus = memberShipUser.Membershipstatus.Value,
            //    //Membershiptype = Convert.ToInt32(memberShipUser.Membershiptypee.Membershiptypename),
            //    Membershiptype = memberShipUser.Membershiptype,
            //    Membershipapplicationdate = DateTime.Now,
            //    recommeddationMembershipid=memberShipUser.MembershipID,
            //    Createddate=DateTime.Now,
            //    ClubID = memberShipUser.ClubID,
            //    SSOID = result.UserId,
            //    ID = memberShipUser.ID ,
            //};
            
            _uow.Membershipdatas.Update(_mbmdata);
            //_uow.Membershipdatas.Add(_mbmdata);

            _uow.Save();
            v.Code = 1;
            v.Message = "Done";
            return v;
        }

    }
}
