                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class ClubInterestRepository : GenericDataRepository<ClubInterest>, IClubInterestRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public ClubInterestRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IClubInterestRepository.cs file
}
}
