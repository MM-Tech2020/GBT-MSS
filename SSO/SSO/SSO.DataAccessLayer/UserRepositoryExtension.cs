using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SSO.DataAccessLayer
{
    public partial class UserRepository : GenericDataRepository<User>, IUserRepository
    {
        public bool UserNameExists(string userName)
        {
            string trimmedUserName = userName.Trim();
            return _context.Users.Where(u => u.UserName == trimmedUserName).Count() > 0;
        }
        public User UserNameisExists(string userName)
        {
            string trimmedUserName = userName.Trim();
            User _user = _context.Users.Where(u => u.UserName == trimmedUserName).First();
            return _user;
        }
        public User GetUserByUserNameAndPassword(string userName, string password)
        {

            User user = base.FindOne(u => u.UserName.ToLower() == userName.ToLower() && u.Password == password);
            return user;
        }
        public IQueryable<Session> GetUserActiveSession(int userId)
        {
            IQueryable<Session> activeSession =  _context.Sessions.Include( s => s.User).Where(s => s.UserId == userId && s.TokenValidUntil >= DateTime.Now);
        

            return activeSession;
        }
    }
}
