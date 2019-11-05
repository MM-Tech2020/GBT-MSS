                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class PersonalInterstsDataRepository : GenericDataRepository<PersonalInterstsData>, IPersonalInterstsDataRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public PersonalInterstsDataRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPersonalInterstsDataRepository.cs file
}
}
