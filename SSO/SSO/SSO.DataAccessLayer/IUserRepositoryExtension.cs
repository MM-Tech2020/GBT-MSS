using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.DataAccessLayer
{
    public partial interface IUserRepository
    {
        bool UserNameExists(string userName);
        User GetUserByUserNameAndPassword(string userName, string password);
        IQueryable<Session> GetUserActiveSession(int userId);
        User UserNameisExists(string userName);
    }
}
