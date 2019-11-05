                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class CitizenAddressRepository : GenericDataRepository<CitizenAddress>, ICitizenAddressRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public CitizenAddressRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ICitizenAddressRepository.cs file
}
}
