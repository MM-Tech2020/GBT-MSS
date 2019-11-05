                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class UserRoleRepository : GenericDataRepository<UserRole>, IUserRoleRepository
{
    private SSOContext _context;
	

    public UserRoleRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IUserRoleRepository.cs file
}
}
