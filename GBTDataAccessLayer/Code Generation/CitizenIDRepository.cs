                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class CitizenIDRepository : GenericDataRepository<CitizenID>, ICitizenIDRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public CitizenIDRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ICitizenIDRepository.cs file
}
}
