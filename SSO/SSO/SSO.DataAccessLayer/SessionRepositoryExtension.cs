using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.DataAccessLayer
{
    public partial  class SessionRepository : GenericDataRepository<Session>, ISessionRepository
    {

        public Session getsessionbytaken(string taken)
        {

            Session _ss = _context.Sessions.Where(s => s.Token.Equals(taken)).FirstOrDefault();
            return _ss;
        }
      

    }
}
