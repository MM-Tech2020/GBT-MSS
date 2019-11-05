                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class BranchRepository : GenericDataRepository<Branch>, IBranchRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public BranchRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IBranchRepository.cs file
}
}
