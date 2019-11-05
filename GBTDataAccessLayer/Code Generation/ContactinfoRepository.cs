                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class ContactinfoRepository : GenericDataRepository<Contactinfo>, IContactinfoRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public ContactinfoRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IContactinfoRepository.cs file
}
}
