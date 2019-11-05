                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class SiteRepository : GenericDataRepository<Site>, ISiteRepository
{
    private SSOContext _context;
	

    public SiteRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ISiteRepository.cs file
}
}
