                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class UserSiteRepository : GenericDataRepository<UserSite>, IUserSiteRepository
{
    private SSOContext _context;
	

    public UserSiteRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IUserSiteRepository.cs file
}
}
