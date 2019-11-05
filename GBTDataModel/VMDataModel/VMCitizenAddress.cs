using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMCitizenAddress
    {
        public int ID { get; set; }
        public string Addresse { get; set; }
        public int? PersonalID { get; set; }
        public bool Active { get; set; }
        public bool IsDefault { get; set; }
    }
}
