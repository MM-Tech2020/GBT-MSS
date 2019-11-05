                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class RoleRepository : GenericDataRepository<Role>, IRoleRepository
{
    private SSOContext _context;
	

    public RoleRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IRoleRepository.cs file
}
}
