                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class PremesisLimitRepository : GenericDataRepository<PremesisLimit>, IPremesisLimitRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public PremesisLimitRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPremesisLimitRepository.cs file
}
}
