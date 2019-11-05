                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class JobInfoRepository : GenericDataRepository<JobInfo>, IJobInfoRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public JobInfoRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IJobInfoRepository.cs file
}
}
