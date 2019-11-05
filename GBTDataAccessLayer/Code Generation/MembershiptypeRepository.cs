                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class MembershiptypeRepository : GenericDataRepository<Membershiptype>, IMembershiptypeRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public MembershiptypeRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IMembershiptypeRepository.cs file
}
}
