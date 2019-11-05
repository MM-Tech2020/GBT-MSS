                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class UserConfigurationRepository : GenericDataRepository<UserConfiguration>, IUserConfigurationRepository
{
    private SSOContext _context;
	

    public UserConfigurationRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IUserConfigurationRepository.cs file
}
}
