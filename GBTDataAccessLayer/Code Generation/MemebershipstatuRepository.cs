                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class MemebershipstatuRepository : GenericDataRepository<Memebershipstatu>, IMemebershipstatuRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public MemebershipstatuRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IMemebershipstatuRepository.cs file
}
}
