                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class sysdiagramRepository : GenericDataRepository<sysdiagram>, IsysdiagramRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public sysdiagramRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IsysdiagramRepository.cs file
}
}
