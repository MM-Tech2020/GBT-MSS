using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMContactinfo
    {
        public int ID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public int Contacttype { get; set; }
        public VMContacttype Contacttypee { get; set; }
        public string Contactinfo1 { get; set; }
        public bool Active { get; set; }
        public bool IsDefault { get; set; }
    }
}
