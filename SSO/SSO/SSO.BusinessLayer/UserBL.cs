using GBTDataModel.VMDataModel;
using SSO.DataAccessLayer;
using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.BusinessLayer
{
    public class UserBL
    {
        IUnitOfWork _unitOfWork;
        public UserBL()
        {
            _unitOfWork = new UnitOfWork();
        }
        private bool UserNameExists(string userName, out string msg)
        {
            msg = string.Empty;
            bool userExists = _unitOfWork.Users.UserNameExists(userName);

            if (userExists)
                msg = string.Format(Util.Properties.Resources.UsernameAlreadyExists, userName);

            return userExists;
        }
        public UserInfo RegisterUser(User user, out string msg)
        {
            Session newSession = null;
            msg = string.Empty;
            // validate user 
            bool userExists = UserNameExists(user.UserName, out msg);

            if (!string.IsNullOrEmpty(msg))
                return null;

            if (!userExists)
                newSession = CreateNewRegisteredUser(user, out msg);

            if (!string.IsNullOrEmpty(msg))
                return null;

            _unitOfWork.Save();
            UserInfo userinfo = new UserInfo()
            {
                Address = user.Address,
                Country = user.Country,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                SocialSecurityNumber = user.SocialSecurityNumber,
                taken = user.SocialSecurityNumber,
                UserId = user.UserId,
                UserName = user.UserName
            };
            return userinfo;
        }
        public UserInfo EditUser(User user, out string msg)
        {
            User _user = new User();
            msg = string.Empty;
            // validate user 
            bool userExists = UserNameExists(user.UserName, out msg);


            if (userExists)
                _user = EditUserData(user);

            _unitOfWork.Save();
            UserInfo userinfo = new UserInfo() { };
            userinfo.Address = user.Address;
            userinfo.Country = user.Country;
            userinfo.Email = user.Email;
            userinfo.FirstName = user.FirstName;
            userinfo.LastName = user.LastName;
            userinfo.SocialSecurityNumber = user.SocialSecurityNumber;
            userinfo.taken = user.SocialSecurityNumber;
            userinfo.UserId = _user.UserId;
            userinfo.UserName = user.UserName;

            return userinfo;
        }
        private IList<UserSite> GetUserAuthorizedSites(User user, out string msg)
        {
            msg = string.Empty;

            IList<UserSite> userAuthorizedSites = null;

            IList<Site> authorizedSites = _unitOfWork.Sites.GetUserAuthorizedSites(user.UserName);

            if (authorizedSites != null)
                userAuthorizedSites = Util.Helper.BindUsersToSites(user, authorizedSites);

            return userAuthorizedSites;
        }
        public string Authenticate(string userName, string password, out string msg)
        {

            User user = GetUserByUserNameAndPassword(userName, password, out msg);

            if (!string.IsNullOrEmpty(msg))
                return null;

            if (user == null)
            {
                msg = Util.Properties.Resources.IncorrectUserNameOrPassword;
                return null;
            }

            string token = CreateSessionForRegisteredUser(user, out msg);

            //if (!string.IsNullOrEmpty(msg))
            //    return token;

            return token;
        }
        public Responceauthonticate AuthenticateDU(string userName, string password, out string msg)
        {

            User user = GetUserByUserNameAndPassword(userName, password, out msg);

            if (!string.IsNullOrEmpty(msg))
                return null;

            if (user == null)
            {
                msg = Util.Properties.Resources.IncorrectUserNameOrPassword;
                return null;
            }

            string token = CreateSessionForRegisteredUser(user, out msg);

            //if (!string.IsNullOrEmpty(msg))
            //    return token;
            Responceauthonticate _raVM = new Responceauthonticate()
            {
                talken = token,
                SSOID = user.UserId,
            };

            return _raVM;
        }
        private string CreateSessionForRegisteredUser(User user, out string msg)
        {
            if (user == null)
            {
                msg = Util.Properties.Resources.Excpetion_UserArgumentIsNull;
                return null;
            }

            Session userActiveSession = GetUserActiveSession(user.UserId, out msg);

            if (!string.IsNullOrEmpty(msg))
                return null;

            if (userActiveSession != null)
            {
                // Log warning
                msg = string.Format(Util.Properties.Resources.UserHasActiveSessionAlready, user.UserName);
                return userActiveSession.Token;
            }

            Session newSession = GenerateSession(user, out msg);

            if (!string.IsNullOrEmpty(msg))
                return null;

            newSession.UserId = user.UserId;

            _unitOfWork.Sessions.Add(newSession);
            _unitOfWork.Save();
            return newSession.Token;
        }
        private User GetUserByUserNameAndPassword(string userName, string password, out string msg)
        {
            msg = string.Empty;

            string hashedPassword = Util.Helper.GetHashString(password);

            User user = _unitOfWork.Users.GetUserByUserNameAndPassword(userName, hashedPassword);

            if (user == null)
                msg = Util.Properties.Resources.IncorrectUserNameOrPassword;

            return user;

        }
        public User Resetpassword(string userName, string oldpassword, string newpassword)
        {

            string hashedPassword = Util.Helper.GetHashString(oldpassword);

            User user = _unitOfWork.Users.GetUserByUserNameAndPassword(userName, hashedPassword);

            if (user == null)
            {
                //msg = Util.Properties.Resources.IncorrectUserNameOrPassword;
                return null;
            }
            else
            {
                string hashednewPassword = Util.Helper.GetHashString(newpassword);
                user.Password = hashednewPassword.ToString();
                _unitOfWork.Users.Update(user);
                _unitOfWork.Save();
                return user;
            }




        }
        public User Resetpassword(string userName, string newpassword)
        {

            //string hashedPassword = Util.Helper.GetHashString(oldpassword);

            User user = _unitOfWork.Users.UserNameisExists(userName);

            if (user == null)
            {
                //msg = Util.Properties.Resources.IncorrectUserNameOrPassword;
                return null;
            }
            else
            {
                string hashednewPassword = Util.Helper.GetHashString(newpassword);
                user.Password = hashednewPassword.ToString();
                _unitOfWork.Users.Update(user);
                _unitOfWork.Save();
                return user;
            }




        }
        public User EditUserData(User NewUser)
        {

            //string hashedPassword = Util.Helper.GetHashString(oldpassword);

            User user = _unitOfWork.Users.UserNameisExists(NewUser.UserName);

            user.Address = NewUser.Address;
            user.Country = NewUser.Country;
            user.Email = NewUser.Email;
            user.FirstName = NewUser.FirstName;
            user.LastName = NewUser.LastName;
            user.SocialSecurityNumber = NewUser.SocialSecurityNumber;

            if (user == null)
            {
                //msg = Util.Properties.Resources.IncorrectUserNameOrPassword;
                return null;
            }
            else
            {
                _unitOfWork.Save();
                return user;
            }




        }
        public User Resetpassword(int SSOUserID, string newpassword)
        {

            //string hashedPassword = Util.Helper.GetHashString(oldpassword);
            //User user = _unitOfWork.Users.UserNameisExists(userName);
            User user = _unitOfWork.Users.GetById(SSOUserID);
            if (user == null)
            {
                //msg = Util.Properties.Resources.IncorrectUserNameOrPassword;
                return null;
            }
            else
            {
                string hashednewPassword = Util.Helper.GetHashString(newpassword);
                user.Password = hashednewPassword.ToString();
                _unitOfWork.Users.Update(user);
                _unitOfWork.Save();
                return user;
            }
        }
        private Session GetUserActiveSession(int userId, out string msg)
        {
            msg = string.Empty;

            IQueryable<Session> userActiveSession = _unitOfWork.Users.GetUserActiveSession(userId);

            if (userActiveSession == null || userActiveSession.Count() < 1)
            {
                return null;
            }
            else if (userActiveSession.Count() > 1)
            {
                msg = string.Format(Util.Properties.Resources.MultipleActiveSessionsFoundForUser, userId);
                return null;
            }

            Session activeSession = userActiveSession.FirstOrDefault();
            return activeSession;
        }
        private Session CreateNewRegisteredUser(User newRegisteredUser, out string msg)
        {
            if (newRegisteredUser == null)
            {
                msg = Util.Properties.Resources.Excpetion_UserArgumentIsNull;
                return null;
            }
            if (newRegisteredUser.UserConfiguration == null)
            {
                newRegisteredUser.UserConfiguration = new UserConfiguration();
                newRegisteredUser.UserConfiguration.TokenExpireAfterDays = 1;
                // msg = Util.Properties.Resources.Excpetion_UserConfigurationIsNull;
                // return null;
            }
            // Create new session for new registered user
            Session newSession = GenerateSession(newRegisteredUser, out msg);
            if (!string.IsNullOrEmpty(msg))
                return null;
            // Attach session to the user
            newRegisteredUser.Sessions = new List<Session>();
            newRegisteredUser.Sessions.Add(newSession);
            // Get Authorized sites for the user
            IList<UserSite> userAuthorizedSites = GetUserAuthorizedSites(newRegisteredUser, out msg);
            if (!string.IsNullOrEmpty(msg))
                return null;

            if (userAuthorizedSites == null || userAuthorizedSites.Count < 1)
            {
                msg = string.Format(Util.Properties.Resources.UserHasNoAuthorizedSites, newRegisteredUser.UserName);
                return null;
            }

            newRegisteredUser.UserSites = new List<UserSite>();
            foreach (UserSite userSite in userAuthorizedSites)
                newRegisteredUser.UserSites.Add(userSite);

            newRegisteredUser.Password = Util.Helper.GetHashString(newRegisteredUser.Password);
            _unitOfWork.Users.Add(newRegisteredUser);

            return newSession;
        }
        private Session GenerateSession(User user, out string msg)
        {
            msg = string.Empty;

            if (user == null)
            {
                msg = Util.Properties.Resources.Excpetion_UserArgumentIsNull;
                return null;
            }

            if (user.UserConfiguration == null)
            {
                msg = Util.Properties.Resources.Excpetion_UserConfigurationIsNull;
                return null;
            }

            Session session = new Session()
            {
                TokenValidUntil = DateTime.UtcNow.AddDays(user.UserConfiguration.TokenExpireAfterDays),
                Token = Util.Helper.GetHashString(Guid.NewGuid().ToString())
            };

            return session;
        }
        public UserInfo GetUserByToken(int userId, string token, out string msg)
        {
            Session userActiveSession = GetUserActiveSession(userId, out msg);

            if (!string.IsNullOrEmpty(msg))
                return null;

            if (userActiveSession == null)
            {
                msg = string.Format(Util.Properties.Resources.NoActiveSessionsFoundForUserWithID, userId);
                return null;
            }

            if (userActiveSession.Token == token)
            {
                UserInfo userInfo = Util.Mapper.UserInfoMapper.MapUserToUserInfo(userActiveSession.User);
                return userInfo;
            }
            else
            {
                // log warning this user doesn't have active session with this token
                return null;
            }
        }
        public bool IsUserLoggedIn(int userId, string token, out string msg)
        {
            bool isUserLoggedIn = false;
            UserInfo activeUser = GetUserByToken(userId, token, out msg);

            if (string.IsNullOrEmpty(msg))
                isUserLoggedIn = activeUser != null;

            return isUserLoggedIn;
        }

        public bool issessionactive(string token)
        {
            Session session = _unitOfWork.Sessions.getsessionbytaken(token);
            if (session == null)
            {
                return false;
            }
            if (session.TokenValidUntil > DateTime.Now)
            {
                return true;
            }

            return false;
        }

        #region APIForUserId
        public Responceauthonticate APIForUserId(string userName, string Password)
        {

            var user = _unitOfWork.Users.FindOne(a => a.UserName == userName && a.Password == Password);
            if (user != null)
            {
                Responceauthonticate _raVM = new Responceauthonticate()
                {
                    SSOID = user.UserId
                };
                return _raVM;
            }
            else
            {
                return null;
            }
        }
        #endregion

        

    }
}
