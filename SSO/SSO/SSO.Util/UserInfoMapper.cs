using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Util.Mapper
{
    public static class UserInfoMapper
    {
        public static UserInfo MapUserToUserInfo(User user)
        {
            UserInfo userInfo = null;

            if (user != null)
                userInfo = new UserInfo()
                {
                    Address = user.Address,
                    Country = user.Country,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    SocialSecurityNumber = user.SocialSecurityNumber,
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email =user.Email
                };



            return userInfo;
        }
    }
}
