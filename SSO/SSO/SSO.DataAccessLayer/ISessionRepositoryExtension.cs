using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.DataAccessLayer
{
    public partial interface ISessionRepository 
    {

        Session getsessionbytaken(string taken);
    }
}
