using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMPersonalInterest
    {
        public int ID { get; set; }
        public string Interestdescription { get; set; }
        public Nullable<int> Active { get; set; }
    }
}
