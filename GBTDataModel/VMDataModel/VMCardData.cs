using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMCardData
    {
        public int ID { get; set; }
        public string SerialNumber { get; set; }
        public Nullable<System.DateTime> Issuedate { get; set; }
        public Nullable<System.DateTime> Deliverydate { get; set; }
        public Nullable<System.DateTime> Expiringdate { get; set; }
        public Nullable<System.DateTime> Requestdate { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> MembershipNumber { get; set; }
        public VMCardStatus CardStatus { get; set; }
    }
}
