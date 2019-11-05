using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMMemberShipData
    {
        public int ID { get; set; }
        public string cardserialno { get; set; }
        public int? PersonalID { get; set; }
        public VMPersonaldata personalData { get; set; }
        public int? FK_defaultNationalId { get; set; }

        public List<VMCitizenID> lstcitizenID { get; set; }
        public int? FK_defaultContactId { get; set; }
        public List<VMContactinfo> lstContactInfo { get; set; }
        public int? FK_defaultaddressesId { get; set; }
        public List<VMCitizenAddress> lstAddressesID { get; set; }
        public int? Fk_currentjobid { get; set; }
        public List<VMJobInfo> lstJobInfo { get; set; }
        public int? FK_educationID { get; set; }
        public List<VMEducationsinfo> lstEducationsInfo { get; set; }
        public int? Membershipstatus { get; set; }
        public int? Membershiptype { get; set; }
        public int? ClubID { get; set; }
        public string Membershipapplicationreference { get; set; }
        public DateTime? Membershipapplicationdate { get; set; }
        public int? recommeddationMembershipid { get; set; }
        public bool? Ismainsupplementary { get; set; }
        public int? RelationID { get; set; }
        public DateTime? Lastrenwelldate { get; set; }
        public DateTime? Nextrenwelldate { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? suspenddate { get; set; }
        public int? MembershipID { get; set; }
        public List<VMPersonalInterest> lstPersonalInterest { get; set; }
        public List<VMMembershipinterest> lstMembershipinterest { get; set; }
    }
}
