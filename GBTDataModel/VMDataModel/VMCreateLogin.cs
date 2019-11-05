using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMCreateLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> CardNo { get; set; }
    }
}
