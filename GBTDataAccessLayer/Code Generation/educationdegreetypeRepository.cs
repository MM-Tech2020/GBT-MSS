                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class educationdegreetypeRepository : GenericDataRepository<educationdegreetype>, IeducationdegreetypeRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public educationdegreetypeRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IeducationdegreetypeRepository.cs file
}
}
