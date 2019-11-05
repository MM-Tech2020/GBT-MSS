                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class SessionRepository : GenericDataRepository<Session>, ISessionRepository
{
    private SSOContext _context;
	

    public SessionRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ISessionRepository.cs file
}
}
