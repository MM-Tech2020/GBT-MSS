                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class PermissionRepository : GenericDataRepository<Permission>, IPermissionRepository
{
    private SSOContext _context;
	

    public PermissionRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPermissionRepository.cs file
}
}
