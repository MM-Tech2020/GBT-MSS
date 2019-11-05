                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class PersonalInterestRepository : GenericDataRepository<PersonalInterest>, IPersonalInterestRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public PersonalInterestRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPersonalInterestRepository.cs file
}
}
