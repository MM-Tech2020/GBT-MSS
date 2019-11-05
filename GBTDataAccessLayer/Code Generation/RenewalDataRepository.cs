                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class RenewalDataRepository : GenericDataRepository<RenewalData>, IRenewalDataRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public RenewalDataRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IRenewalDataRepository.cs file
}
}
