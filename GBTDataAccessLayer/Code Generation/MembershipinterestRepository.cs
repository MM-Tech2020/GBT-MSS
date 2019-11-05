                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class MembershipinterestRepository : GenericDataRepository<Membershipinterest>, IMembershipinterestRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public MembershipinterestRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IMembershipinterestRepository.cs file
}
}
