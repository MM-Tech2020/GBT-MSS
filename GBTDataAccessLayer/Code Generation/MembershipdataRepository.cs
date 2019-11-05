                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class MembershipdataRepository : GenericDataRepository<Membershipdata>, IMembershipdataRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public MembershipdataRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IMembershipdataRepository.cs file
}
}
