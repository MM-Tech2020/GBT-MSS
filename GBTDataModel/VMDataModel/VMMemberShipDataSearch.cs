using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMMemberShipDataSearch
    {
        public int ID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public VMPersonaldata personalData { get; set; }
        public Nullable<int> FK_defaultNationalId { get; set; }
        public List<VMCitizenID> lstcitizenID { get; set; }
        public Nullable<int> FK_defaultContactId { get; set; }
        public List<VMContactinfo> lstContactInfo { get; set; }
        public Nullable<int> FK_defaultaddressesId { get; set; }
        public List<VMCitizenAddress> lstAddressesID { get; set; }
        public Nullable<int> Fk_currentjobid { get; set; }
        public List<VMJobInfo> lstJobInfo { get; set; }
        public Nullable<int> FK_educationID { get; set; }
        public List<VMEducationsinfo> lstEducationsInfo { get; set; }
        public Nullable<int> Membershipstatus { get; set; }
        public VMMemebershipstatus Membershipstatuss { get; set; }
        public Nullable<int> Membershiptype { get; set; }
        public VMMembershiptype Membershiptypee { get; set; }
        public Nullable<int> ClubID { get; set; }
        public VMClub clubData { get; set; }
        public string Membershipapplicationreference { get; set; }
        public Nullable<System.DateTime> Membershipapplicationdate { get; set; }
        public Nullable<int> recommeddationMembershipid { get; set; }
        public VMPersonalDataRecommeddation recommeddationMembership { get; set; }
        public Nullable<bool> Ismainsupplementary { get; set; }
        public Nullable<int> RelationID { get; set; }
        public VMPersonaldata RelationData { get; set; }
        public Nullable<System.DateTime> Lastrenwelldate { get; set; }
        public Nullable<System.DateTime> Nextrenwelldate { get; set; }
        public Nullable<System.DateTime> Createddate { get; set; }
        public Nullable<System.DateTime> suspenddate { get; set; }
        public Nullable<int> MembershipID { get; set; }
        public VMCardData cardData { get; set; }
        public List<VMPersonalInterest> lstPersonalInterest { get; set; }
        public List<VMMembershipinterest> lstMembershipinterest { get; set; }
    }
}
