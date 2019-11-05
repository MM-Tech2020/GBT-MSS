using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMBranch
    {
        public int ID { get; set; }
        public string BranchName { get; set; }
        public string BrancheTaxID { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public bool IsDeleted { get; set; }
        public int ClubID { get; set; }
        public VMClub Club { get; set; }
    }
}
