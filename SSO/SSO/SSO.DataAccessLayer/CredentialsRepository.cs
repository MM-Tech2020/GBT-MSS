
    
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class CredentialsRepository : GenericDataRepository<Credentials>, ICredentialsRepository
{
    private SSOContext _context;
	

    public CredentialsRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ICredentialsRepository.cs file
}
}
