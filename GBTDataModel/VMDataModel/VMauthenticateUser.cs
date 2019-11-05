using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMauthenticateUser
    {
        public int RoleID { get; set; }
        public string Tolken { get; set; }
        public int? Branchid { get; set; }
        public int? ClubID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public bool IsActive { get; set; }
        public bool Isresetpassword { get; set; }
    }
}
