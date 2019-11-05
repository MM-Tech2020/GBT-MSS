                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class ContacttypeRepository : GenericDataRepository<Contacttype>, IContacttypeRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public ContacttypeRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IContacttypeRepository.cs file
}
}
