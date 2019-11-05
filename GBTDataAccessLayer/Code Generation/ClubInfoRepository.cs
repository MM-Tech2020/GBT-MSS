                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class ClubInfoRepository : GenericDataRepository<ClubInfo>, IClubInfoRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public ClubInfoRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IClubInfoRepository.cs file
}
}
