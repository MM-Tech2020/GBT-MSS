using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMCitizenID
    {
        public int ID { get; set; }
        public string IdentityNumber { get; set; }
        public Nullable<int> identitytype { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public VMCitizenIDType CitisenIDtypee { get; set; }
        public bool IsDefault { get; set; }
    }
}
