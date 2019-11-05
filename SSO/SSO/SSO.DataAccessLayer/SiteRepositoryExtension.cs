using SSO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.DataAccessLayer
{
    public partial class SiteRepository : GenericDataRepository<Site> , ISiteRepository
    {
        public IList<Site> GetUserAuthorizedSites(string userName)
        {
            // might be changed later
            IList<Site> authorizedSites = GetAll();
            return authorizedSites;
        }
    }
}
