using GBTDataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBT.DataAccessLayer
{
    public partial class MembershipdataRepository : GenericDataRepository<Membershipdata>, IMembershipdataRepository
    {
        public VMResponse AddMemberShipData(VMMemberShipData _mberShipData)
        {
            VMResponse _Response = new VMResponse();

            if (_mberShipData.ID == 0)
            {
                int indxDefaultAddressID = 0;
                int indxDefaultCitizenID = 0;
                int indxDefaultContactId = 0;
                int indxCurrentJobInfo = 0;
                using (var trx = _context.Database.BeginTransaction())
                {
                    CardData _carddata = new CardData
                    {
                        Expiringdate = DateTime.Now.AddDays(366),
                        Deliverydate = DateTime.Now,
                        Issuedate = DateTime.Now,
                        Requestdate = DateTime.Now,
                        SerialNumber = DateTime.Now.Year.ToString()+1,
                        MembershipNumber = DateTime.Now.Year+_mberShipData.ID,
                        status = 1

                    };
                    _context.CardDatas.Add(_carddata);
                    _context.SaveChanges();
                    _mberShipData.MembershipID = _carddata.ID;
                    Personaldata prsonalData = new Personaldata
                    {
                        Firstname_EN = _mberShipData.personalData.Firstname_EN,
                        MiddelName_EN = _mberShipData.personalData.MiddelName_EN,
                        Lastname_EN = _mberShipData.personalData.MiddelName_EN,
                        Firstname_Ar = _mberShipData.personalData.Firstname_Ar,
                        MiddelName_Ar = _mberShipData.personalData.MiddelName_Ar,
                        Lastname_Ar = _mberShipData.personalData.Lastname_Ar,
                        Photopath = _mberShipData.personalData.Photopath,
                        Gender = (int)_mberShipData.personalData.Gender,
                        DateofBirth = _mberShipData.personalData.DateofBirth,
                    };
                    _context.Personaldatas.Add(prsonalData);
                    _context.SaveChanges();
                    List<CitizenAddress> listcitizenAddress = new List<CitizenAddress>();

                    foreach (var item in _mberShipData.lstAddressesID)
                    {
                        CitizenAddress _address = new CitizenAddress
                        {
                            Addresse = item.Addresse,
                            Active = true,
                            PersonalID = prsonalData.ID,
                        };
                        if (item.IsDefault)
                        {
                            indxDefaultAddressID = listcitizenAddress.Count();
                        }
                        listcitizenAddress.Add(_address);
                    }

                    List<CitizenID> listCitizen = new List<CitizenID>();
                    foreach (var item in _mberShipData.lstcitizenID)
                    {
                        CitizenID _citizen = new CitizenID
                        {
                            IdentityNumber = item.IdentityNumber,
                            identitytype = item.identitytype,
                            PersonalID = prsonalData.ID,
                        };
                        if (item.IsDefault)
                        {
                            indxDefaultCitizenID = listCitizen.Count();
                        }
                        listCitizen.Add(_citizen);
                    }

                    List<Contactinfo> listContactInfo = new List<Contactinfo>();
                    foreach (var item in _mberShipData.lstContactInfo)
                    {
                        Contactinfo _ContactInfo = new Contactinfo
                        {
                            PersonalID = prsonalData.ID,
                            Active = true,
                            Contactinfo1 = item.Contactinfo1,
                            Contacttype = item.Contacttype,
                        };
                        if (item.IsDefault)
                        {
                            indxDefaultContactId = listContactInfo.Count();
                        }
                        listContactInfo.Add(_ContactInfo);
                    }

                    List<JobInfo> listJobInfo = new List<JobInfo>();
                    foreach (var item in _mberShipData.lstJobInfo)
                    {
                        JobInfo _JobInfo = new JobInfo
                        {
                            Datefrom = item.Datefrom,
                            Dateto = item.Dateto,
                            Jobtitle = item.Jobtitle,
                            Jobdetailes = item.Jobdetailes,
                            jobcotogory = item.jobcotogory,
                            PersonalID = prsonalData.ID,
                        };
                        if (item.IsCurrent)
                        {
                            indxCurrentJobInfo = listJobInfo.Count();
                        }
                        listJobInfo.Add(_JobInfo);
                    }

                    List<Educationsinfo> listEducationsinfo = new List<Educationsinfo>();
                    foreach (var item in _mberShipData.lstEducationsInfo)
                    {
                        Educationsinfo _Educationsinfo = new Educationsinfo
                        {
                            EducationDegreetype = item.EducationDegreetype,
                            EducationAuthority = item.EducationAuthority,
                            Description = item.Description,
                            PersonalID = prsonalData.ID,
                        };
                        listEducationsinfo.Add(_Educationsinfo);
                    }

                    List<PersonalInterest> listPersonalInterest = new List<PersonalInterest>();
                    foreach (var item in _mberShipData.lstPersonalInterest)
                    {
                        PersonalInterest _PersonalInterest = new PersonalInterest
                        {
                            Interestdescription = item.Interestdescription,
                            Active = 1,
                        };
                        listPersonalInterest.Add(_PersonalInterest);
                    }
                    _context.PersonalInterests.AddRange(listPersonalInterest);
                    _context.SaveChanges();

                    List<PersonalInterstsData> listPersonalInterstsData = new List<PersonalInterstsData>();
                    foreach (var item in listPersonalInterest)
                    {
                        PersonalInterstsData _PersonalInterstsData = new PersonalInterstsData
                        {
                            PersonalID = prsonalData.ID,
                            PInterestID = item.ID,
                        };
                        listPersonalInterstsData.Add(_PersonalInterstsData);
                    }

                    _context.PersonalInterstsDatas.AddRange(listPersonalInterstsData);

                    _context.CitizenAddresses.AddRange(listcitizenAddress);

                    _context.CitizenIDs.AddRange(listCitizen);
                    _context.SaveChanges();
                    _context.Contactinfoes.AddRange(listContactInfo);
                    _context.SaveChanges();
                    _context.JobInfoes.AddRange(listJobInfo);
                    _context.SaveChanges();
                    _context.Educationsinfoes.AddRange(listEducationsinfo);

                    _context.SaveChanges();

                    Membershipdata mbrShipData = new Membershipdata()
                    {
                        MembershipID = _mberShipData.MembershipID,
                        PersonalID = prsonalData.ID,
                        FK_defaultNationalId = listCitizen[indxDefaultCitizenID].ID,
                        FK_defaultContactId = listContactInfo[indxDefaultContactId].ID,
                        FK_defaultaddressesId = listcitizenAddress[indxDefaultAddressID].ID,
                        Fk_currentjobid = listJobInfo[indxCurrentJobInfo].ID,
                        FK_educationID = listEducationsinfo.LastOrDefault().ID,
                        Membershipstatus = _mberShipData.Membershipstatus,
                        Membershiptype = _mberShipData.Membershiptype,
                        ClubID = _mberShipData.ClubID,
                        Membershipapplicationreference = _mberShipData.Membershipapplicationreference,
                        Membershipapplicationdate = DateTime.Now,
                        recommeddationMembershipid = _mberShipData.recommeddationMembershipid,
                        Createddate = DateTime.Now,
                    };

                    _context.Membershipdatas.Add(mbrShipData);
                    _context.SaveChanges();
                    List<Membershipinterest> listMembershipinterest = new List<Membershipinterest>();
                    foreach (var item in _mberShipData.lstMembershipinterest)
                    {
                        Membershipinterest _PersonalInterstsData = new Membershipinterest
                        {
                            MembershipId = mbrShipData.ID,
                            clubinterestID = item.clubinterestID,
                        };
                        listMembershipinterest.Add(_PersonalInterstsData);
                    }
                    _context.Membershipinterests.AddRange(listMembershipinterest);
                    

                    RenewalData _renewalData = new RenewalData
                    {
                        MembershipID = mbrShipData.ID,
                        status=1,
                        Renwaldate=DateTime.Now.AddYears(1),
                    };

                    _context.RenewalDatas.Add(_renewalData);

                    _context.SaveChanges();
                    trx.Commit();
                    if (mbrShipData.ID != 0)
                    {
                        _Response.Code = 1;
                        _Response.Message = "Member Ship is Added";
                    }
                    else
                    {
                        _Response.Code = -1;
                        _Response.Message = "Error Try Again!!";
                    }
                }
            }
            else
            {
                var mshpData = _context.Membershipdatas.FirstOrDefault(a => a.ID == _mberShipData.ID);
                mshpData.MembershipID = _mberShipData.MembershipID;
                mshpData.PersonalID = _mberShipData.PersonalID;
                mshpData.MembershipID = _mberShipData.MembershipID;
                mshpData.MembershipID = _mberShipData.MembershipID;
                mshpData.MembershipID = _mberShipData.MembershipID;
                mshpData.MembershipID = _mberShipData.MembershipID;


                _context.SaveChanges();
                if (_mberShipData.ID != 0)
                {
                    _Response.Code = 1;
                    _Response.Message = "Member Ship is Added";
                }
                else
                {
                    _Response.Code = -1;
                    _Response.Message = "Error Try Again!!";
                }
            }

            return _Response;
        }

        public VMResponse EditMemberShipData(VMMemberShipDataSearch _mberShipData)
        {
            VMResponse _Response = new VMResponse();
            //add
            #region
            if (_mberShipData.ID == 0)
            {
                int indxDefaultAddressID = 0;
                int indxDefaultCitizenID = 0;
                int indxDefaultContactId = 0;
                int indxCurrentJobInfo = 0;
                using (var trx = _context.Database.BeginTransaction())
                {
                    Personaldata prsonalData = new Personaldata
                    {
                        Firstname_EN = _mberShipData.personalData.Firstname_EN,
                        MiddelName_EN = _mberShipData.personalData.MiddelName_EN,
                        Lastname_EN = _mberShipData.personalData.MiddelName_EN,
                        Firstname_Ar = _mberShipData.personalData.Firstname_Ar,
                        MiddelName_Ar = _mberShipData.personalData.MiddelName_Ar,
                        Lastname_Ar = _mberShipData.personalData.Lastname_Ar,
                        Photopath = _mberShipData.personalData.Photopath,
                        Gender = (int)_mberShipData.personalData.Gender,
                        DateofBirth = _mberShipData.personalData.DateofBirth,
                    };
                    _context.Personaldatas.Add(prsonalData);
                    _context.SaveChanges();
                    List<CitizenAddress> listcitizenAddress = new List<CitizenAddress>();

                    foreach (var item in _mberShipData.lstAddressesID)
                    {
                        CitizenAddress _address = new CitizenAddress
                        {
                            Addresse = item.Addresse,
                            Active = true,
                            PersonalID = prsonalData.ID,
                        };
                        if (item.IsDefault)
                        {
                            indxDefaultAddressID = listcitizenAddress.Count();
                        }
                        listcitizenAddress.Add(_address);
                    }

                    List<CitizenID> listCitizen = new List<CitizenID>();
                    foreach (var item in _mberShipData.lstcitizenID)
                    {
                        CitizenID _citizen = new CitizenID
                        {
                            IdentityNumber = item.IdentityNumber,
                            identitytype = item.identitytype,
                            PersonalID = prsonalData.ID,
                        };
                        if (item.IsDefault)
                        {
                            indxDefaultCitizenID = listCitizen.Count();
                        }
                        listCitizen.Add(_citizen);
                    }

                    List<Contactinfo> listContactInfo = new List<Contactinfo>();
                    foreach (var item in _mberShipData.lstContactInfo)
                    {
                        Contactinfo _ContactInfo = new Contactinfo
                        {
                            PersonalID = prsonalData.ID,
                            Active = true,
                            Contactinfo1 = item.Contactinfo1,
                            Contacttype = item.Contacttype,
                        };
                        if (item.IsDefault)
                        {
                            indxDefaultContactId = listContactInfo.Count();
                        }
                        listContactInfo.Add(_ContactInfo);
                    }

                    List<JobInfo> listJobInfo = new List<JobInfo>();
                    foreach (var item in _mberShipData.lstJobInfo)
                    {
                        JobInfo _JobInfo = new JobInfo
                        {
                            Datefrom = item.Datefrom,
                            Dateto = item.Dateto,
                            Jobtitle = item.Jobtitle,
                            Jobdetailes = item.Jobdetailes,
                            jobcotogory = item.jobcotogory,
                            PersonalID = prsonalData.ID,
                        };
                        if (item.IsCurrent)
                        {
                            indxCurrentJobInfo = listJobInfo.Count();
                        }
                        listJobInfo.Add(_JobInfo);
                    }

                    List<Educationsinfo> listEducationsinfo = new List<Educationsinfo>();
                    foreach (var item in _mberShipData.lstEducationsInfo)
                    {
                        Educationsinfo _Educationsinfo = new Educationsinfo
                        {
                            EducationDegreetype = item.EducationDegreetype,
                            EducationAuthority = item.EducationAuthority,
                            Description = item.Description,
                            PersonalID = prsonalData.ID,
                        };
                        listEducationsinfo.Add(_Educationsinfo);
                    }

                    List<PersonalInterest> listPersonalInterest = new List<PersonalInterest>();
                    foreach (var item in _mberShipData.lstPersonalInterest)
                    {
                        PersonalInterest _PersonalInterest = new PersonalInterest
                        {
                            Interestdescription = item.Interestdescription,
                            Active = 1,
                        };
                        listPersonalInterest.Add(_PersonalInterest);
                    }
                    _context.PersonalInterests.AddRange(listPersonalInterest);
                    _context.SaveChanges();

                    List<PersonalInterstsData> listPersonalInterstsData = new List<PersonalInterstsData>();
                    foreach (var item in listPersonalInterest)
                    {
                        PersonalInterstsData _PersonalInterstsData = new PersonalInterstsData
                        {
                            PersonalID = prsonalData.ID,
                            PInterestID = item.ID,
                        };
                        listPersonalInterstsData.Add(_PersonalInterstsData);
                    }

                    _context.PersonalInterstsDatas.AddRange(listPersonalInterstsData);

                    _context.CitizenAddresses.AddRange(listcitizenAddress);

                    _context.CitizenIDs.AddRange(listCitizen);
                    _context.SaveChanges();
                    _context.Contactinfoes.AddRange(listContactInfo);
                    _context.SaveChanges();
                    _context.JobInfoes.AddRange(listJobInfo);
                    _context.SaveChanges();
                    _context.Educationsinfoes.AddRange(listEducationsinfo);

                    _context.SaveChanges();

                    Membershipdata mbrShipData = new Membershipdata()
                    {
                        MembershipID = _mberShipData.MembershipID,
                        PersonalID = prsonalData.ID,
                        FK_defaultNationalId = listCitizen[indxDefaultCitizenID].ID,
                        FK_defaultContactId = listContactInfo[indxDefaultContactId].ID,
                        FK_defaultaddressesId = listcitizenAddress[indxDefaultAddressID].ID,
                        Fk_currentjobid = listJobInfo[indxCurrentJobInfo].ID,
                        FK_educationID = listEducationsinfo.LastOrDefault().ID,
                        Membershipstatus = _mberShipData.Membershipstatus,
                        Membershiptype = _mberShipData.Membershiptype,
                        ClubID = _mberShipData.ClubID,
                        Membershipapplicationreference = _mberShipData.Membershipapplicationreference,
                        Membershipapplicationdate = DateTime.Now,
                        recommeddationMembershipid = _mberShipData.recommeddationMembershipid,
                        Createddate = DateTime.Now,
                    };

                    _context.Membershipdatas.Add(mbrShipData);
                    _context.SaveChanges();
                    List<Membershipinterest> listMembershipinterest = new List<Membershipinterest>();
                    foreach (var item in _mberShipData.lstMembershipinterest)
                    {
                        Membershipinterest _PersonalInterstsData = new Membershipinterest
                        {
                            MembershipId = mbrShipData.ID,
                            clubinterestID = item.clubinterestID,
                        };
                        listMembershipinterest.Add(_PersonalInterstsData);
                    }
                    _context.Membershipinterests.AddRange(listMembershipinterest);
                    _context.SaveChanges();
                    trx.Commit();
                    if (mbrShipData.ID != 0)
                    {
                        _Response.Code = 1;
                        _Response.Message = "Member Ship is Added";
                    }
                    else
                    {
                        _Response.Code = -1;
                        _Response.Message = "Error Try Again!!";
                    }
                }
            }
            #endregion
            else
            {
                var mbrShipData = _context.Membershipdatas.FirstOrDefault(a => a.ID == _mberShipData.ID);

                int indxDefaultAddressID = 0;
                int indxDefaultCitizenID = 0;
                int indxDefaultContactId = 0;
                int indxCurrentJobInfo = 0;

                using (var trx = _context.Database.BeginTransaction())
                {
                    var prsonalData = _context.Personaldatas.FirstOrDefault(a => a.ID == _mberShipData.personalData.ID);

                    prsonalData.Firstname_EN = _mberShipData.personalData.Firstname_EN;
                    prsonalData.MiddelName_EN = _mberShipData.personalData.MiddelName_EN;
                    prsonalData.Lastname_EN = _mberShipData.personalData.MiddelName_EN;
                    prsonalData.Firstname_Ar = _mberShipData.personalData.Firstname_Ar;
                    prsonalData.MiddelName_Ar = _mberShipData.personalData.MiddelName_Ar;
                    prsonalData.Lastname_Ar = _mberShipData.personalData.Lastname_Ar;
                    prsonalData.Photopath = _mberShipData.personalData.Photopath;
                    prsonalData.Gender = (int)_mberShipData.personalData.Gender;
                    prsonalData.DateofBirth = _mberShipData.personalData.DateofBirth;

                    List<CitizenAddress> listcitizenAddress = new List<CitizenAddress>();

                    foreach (var item in _mberShipData.lstAddressesID)
                    {
                        if (item.ID == 0)
                        {
                            CitizenAddress _address = new CitizenAddress
                            {
                                Addresse = item.Addresse,
                                Active = true,
                                PersonalID = prsonalData.ID,
                            };
                            if (item.IsDefault)
                            {
                                indxDefaultAddressID = listcitizenAddress.Count();
                                _mberShipData.FK_defaultaddressesId = null;
                            }
                            listcitizenAddress.Add(_address);
                        }
                        else
                        {
                            _context.CitizenAddresses.FirstOrDefault(a => a.ID == item.ID).Addresse = item.Addresse;
                        }
                    }

                    List<CitizenID> listCitizen = new List<CitizenID>();
                    foreach (var item in _mberShipData.lstcitizenID)
                    {
                        if (item.ID == 0)
                        {
                            CitizenID _citizen = new CitizenID
                            {
                                IdentityNumber = item.IdentityNumber,
                                identitytype = item.identitytype,
                                PersonalID = prsonalData.ID,
                            };
                            if (item.IsDefault)
                            {
                                indxDefaultCitizenID = listCitizen.Count();
                                _mberShipData.FK_defaultNationalId = null;
                            }
                            listCitizen.Add(_citizen);
                        }
                        else
                        {
                            _context.CitizenIDs.FirstOrDefault(a => a.ID == item.ID).IdentityNumber = item.IdentityNumber;
                            _context.CitizenIDs.FirstOrDefault(a => a.ID == item.ID).identitytype = item.identitytype;
                        }
                    }

                    List<Contactinfo> listContactInfo = new List<Contactinfo>();
                    foreach (var item in _mberShipData.lstContactInfo)
                    {
                        if (item.ID == 0)
                        {
                            Contactinfo _ContactInfo = new Contactinfo
                            {
                                PersonalID = prsonalData.ID,
                                Active = true,
                                Contactinfo1 = item.Contactinfo1,
                                Contacttype = item.Contacttype,
                            };
                            if (item.IsDefault)
                            {
                                indxDefaultContactId = listContactInfo.Count();
                                _mberShipData.FK_defaultContactId = null;
                            }
                            listContactInfo.Add(_ContactInfo);
                        }
                        else
                        {
                            _context.Contactinfoes.FirstOrDefault(a => a.ID == item.ID).Contactinfo1 = item.Contactinfo1;
                            _context.Contactinfoes.FirstOrDefault(a => a.ID == item.ID).Contacttype = item.Contacttype;
                        }
                    }

                    List<JobInfo> listJobInfo = new List<JobInfo>();
                    foreach (var item in _mberShipData.lstJobInfo)
                    {
                        if (item.ID == 0)
                        {
                            JobInfo _JobInfo = new JobInfo
                            {
                                Datefrom = item.Datefrom,
                                Dateto = item.Dateto,
                                Jobtitle = item.Jobtitle,
                                Jobdetailes = item.Jobdetailes,
                                jobcotogory = item.jobcotogory,
                                PersonalID = prsonalData.ID,
                            };
                            if (item.IsCurrent)
                            {
                                indxCurrentJobInfo = listJobInfo.Count();
                                _mberShipData.Fk_currentjobid = null;
                            }
                            listJobInfo.Add(_JobInfo);
                        }
                        else
                        {
                            _context.JobInfoes.FirstOrDefault(a => a.ID == item.ID).Datefrom = item.Datefrom;
                            _context.JobInfoes.FirstOrDefault(a => a.ID == item.ID).Dateto = item.Dateto;
                            _context.JobInfoes.FirstOrDefault(a => a.ID == item.ID).Jobtitle = item.Jobtitle;
                            _context.JobInfoes.FirstOrDefault(a => a.ID == item.ID).Jobdetailes = item.Jobdetailes;
                            _context.JobInfoes.FirstOrDefault(a => a.ID == item.ID).jobcotogory = item.jobcotogory;
                        }
                    }

                    List<Educationsinfo> listEducationsinfo = new List<Educationsinfo>();
                    foreach (var item in _mberShipData.lstEducationsInfo)
                    {
                        if (item.ID == 0)
                        {
                            Educationsinfo _Educationsinfo = new Educationsinfo
                            {
                                EducationDegreetype = item.EducationDegreetype,
                                EducationAuthority = item.EducationAuthority,
                                Description = item.Description,
                                PersonalID = prsonalData.ID,
                            };
                            listEducationsinfo.Add(_Educationsinfo);
                            _mberShipData.FK_educationID = null;
                        }
                        else
                        {
                            _context.Educationsinfoes.FirstOrDefault(a => a.ID == item.ID).EducationDegreetype = item.EducationDegreetype;
                            _context.Educationsinfoes.FirstOrDefault(a => a.ID == item.ID).EducationAuthority = item.EducationAuthority;
                            _context.Educationsinfoes.FirstOrDefault(a => a.ID == item.ID).Description = item.Description;
                        }
                    }

                    List<PersonalInterest> listPersonalInterest = new List<PersonalInterest>();
                    foreach (var item in _mberShipData.lstPersonalInterest)
                    {
                        if(item.ID == 0)
                        {
                        PersonalInterest _PersonalInterest = new PersonalInterest
                        {
                            Interestdescription = item.Interestdescription,
                            Active = 1,
                        };
                        listPersonalInterest.Add(_PersonalInterest);
                        }
                        else
                        {
                            _context.PersonalInterests.FirstOrDefault(a => a.ID == item.ID).Interestdescription = item.Interestdescription;
                        }
                    }
                    _context.PersonalInterests.AddRange(listPersonalInterest);
                    _context.SaveChanges();

                    List<PersonalInterstsData> listPersonalInterstsData = new List<PersonalInterstsData>();
                    foreach (var item in listPersonalInterest)
                    {
                            PersonalInterstsData _PersonalInterstsData = new PersonalInterstsData
                            {
                                PersonalID = prsonalData.ID,
                                PInterestID = item.ID,
                            };
                            listPersonalInterstsData.Add(_PersonalInterstsData);
                    }

                    _context.PersonalInterstsDatas.AddRange(listPersonalInterstsData);

                    _context.CitizenAddresses.AddRange(listcitizenAddress);

                    _context.CitizenIDs.AddRange(listCitizen);
                    _context.SaveChanges();
                    _context.Contactinfoes.AddRange(listContactInfo);
                    _context.SaveChanges();
                    _context.JobInfoes.AddRange(listJobInfo);
                    _context.SaveChanges();
                    _context.Educationsinfoes.AddRange(listEducationsinfo);

                    _context.SaveChanges();

                    mbrShipData.MembershipID = _mberShipData.MembershipID;
                    mbrShipData.PersonalID = prsonalData.ID;
                    mbrShipData.FK_defaultNationalId = _mberShipData.FK_defaultNationalId == null?listCitizen[indxDefaultCitizenID].ID: _mberShipData.FK_defaultNationalId;
                    mbrShipData.FK_defaultContactId = _mberShipData.FK_defaultContactId == null ?listContactInfo[indxDefaultContactId].ID: _mberShipData.FK_defaultContactId;
                    mbrShipData.FK_defaultaddressesId = _mberShipData.FK_defaultaddressesId == null ? listcitizenAddress[indxDefaultAddressID].ID: _mberShipData.FK_defaultaddressesId;
                    mbrShipData.Fk_currentjobid = _mberShipData.FK_defaultaddressesId == null ? listJobInfo[indxCurrentJobInfo].ID : _mberShipData.Fk_currentjobid;
                    mbrShipData.FK_educationID = listEducationsinfo.Count>0?listEducationsinfo.LastOrDefault().ID: _mberShipData.FK_educationID;
                    mbrShipData.Membershipstatus = _mberShipData.Membershipstatus;
                    mbrShipData.Membershiptype = _mberShipData.Membershiptype;
                    mbrShipData.ClubID = _mberShipData.ClubID;
                    mbrShipData.Membershipapplicationreference = _mberShipData.Membershipapplicationreference;
                    mbrShipData.Membershipapplicationdate = DateTime.Now;
                    mbrShipData.recommeddationMembershipid = _mberShipData.recommeddationMembershipid;
                    mbrShipData.Createddate = DateTime.Now;

                    _context.SaveChanges();
                    List<Membershipinterest> listMembershipinterest = new List<Membershipinterest>();
                    foreach (var item in _mberShipData.lstMembershipinterest)
                    {
                        if (item.ID == 0)
                        {
                            Membershipinterest _PersonalInterstsData = new Membershipinterest
                            {
                                MembershipId = mbrShipData.ID,
                                clubinterestID = item.clubinterestID,
                            };
                            listMembershipinterest.Add(_PersonalInterstsData);
                        }
                        else
                        {
                            _context.Membershipinterests.FirstOrDefault(a => a.ID == item.ID).clubinterestID = item.clubinterestID;
                        }
                    }
                    _context.Membershipinterests.AddRange(listMembershipinterest);
                    _context.SaveChanges();
                    trx.Commit();
                    if (mbrShipData.ID != 0)
                    {
                        _Response.Code = 1;
                        _Response.Message = "Member Ship is Added";
                    }
                    else
                    {
                        _Response.Code = -1;
                        _Response.Message = "Error Try Again!!";
                    }
                }
            }

            return _Response;
        }
    }
}
