                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class ModuleRepository : GenericDataRepository<Module>, IModuleRepository
{
    private SSOContext _context;
	

    public ModuleRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IModuleRepository.cs file
}
}
