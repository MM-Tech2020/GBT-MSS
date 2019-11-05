using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMMembershipinterest
    {
        public int ID { get; set; }
        public Nullable<int> MembershipId { get; set; }
        public Nullable<int> clubinterestID { get; set; }
        public VMClubInterest clubinterestt { get; set; }
    }
}
