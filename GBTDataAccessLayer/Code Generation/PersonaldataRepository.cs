                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class PersonaldataRepository : GenericDataRepository<Personaldata>, IPersonaldataRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public PersonaldataRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPersonaldataRepository.cs file
}
}
