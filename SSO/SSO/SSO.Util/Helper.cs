using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Util
{
    public static class Helper
    {
        public static List<UserSite> BindUsersToSites(User user, ICollection<Site> sites)
        {

            List<UserSite> userSites = null;

            if (sites != null && sites.Count > 0 && user != null)
            {
                userSites = new List<UserSite>();
                foreach (Site site in sites)
                    userSites.Add(new UserSite() { SiteId = site.SiteId, User = user });
            }
            else
            {
                // log exception
            }
            return userSites;

        }
        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
