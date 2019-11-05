                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class jobcatogoryRepository : GenericDataRepository<jobcatogory>, IjobcatogoryRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public jobcatogoryRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IjobcatogoryRepository.cs file
}
}
