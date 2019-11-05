                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class CitizenIDTypeRepository : GenericDataRepository<CitizenIDType>, ICitizenIDTypeRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public CitizenIDTypeRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ICitizenIDTypeRepository.cs file
}
}
