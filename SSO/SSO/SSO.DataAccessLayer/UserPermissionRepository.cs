                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class UserPermissionRepository : GenericDataRepository<UserPermission>, IUserPermissionRepository
{
    private SSOContext _context;
	

    public UserPermissionRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IUserPermissionRepository.cs file
}
}
