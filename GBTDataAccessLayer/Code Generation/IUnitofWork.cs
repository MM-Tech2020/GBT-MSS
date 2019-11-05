            using System;
namespace GBT.DataAccessLayer
{
public partial interface IUnitOfWork : IDisposable
{
    ICardStatuRepository CardStatus { get; }
    IPersonalInterstsDataRepository PersonalInterstsDatas { get; }
    IPersonalInterestRepository PersonalInterests { get; }
    IClubInfoRepository ClubInfos { get; }
    IClubInterestRepository ClubInterests { get; }
    IPaymentsduesRepository Payments_duess { get; }
    IContacttypeRepository Contacttypes { get; }
    ICitizenIDRepository CitizenIDs { get; }
    IPersonaldataRepository Personaldatas { get; }
    IMemebershipstatuRepository Memebershipstatus { get; }
    IEducationsinfoRepository Educationsinfos { get; }
    IContactinfoRepository Contactinfos { get; }
    IPremesisLimitRepository PremesisLimits { get; }
    IMembershiptypeRepository Membershiptypes { get; }
    ICardDataRepository CardDatas { get; }
    ICitizenIDTypeRepository CitizenIDTypes { get; }
    ICitizenAddressRepository CitizenAddresss { get; }
    IMembershipinterestRepository Membershipinterests { get; }
    IjobcatogoryRepository jobcatogorys { get; }
    IMembershipdataRepository Membershipdatas { get; }
    IsysdiagramRepository sysdiagrams { get; }
    IRenewalDataRepository RenewalDatas { get; }
    IRelationTypeRepository RelationTypes { get; }
    IeducationdegreetypeRepository educationdegreetypes { get; }
    IJobInfoRepository JobInfos { get; }
    IBranchRepository Branchs { get; }
    void Save();
}
}
