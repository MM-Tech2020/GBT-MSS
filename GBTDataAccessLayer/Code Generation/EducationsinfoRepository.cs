                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class EducationsinfoRepository : GenericDataRepository<Educationsinfo>, IEducationsinfoRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public EducationsinfoRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IEducationsinfoRepository.cs file
}
}
