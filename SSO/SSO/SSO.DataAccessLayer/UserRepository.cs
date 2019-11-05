                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class UserRepository : GenericDataRepository<User>, IUserRepository
{
    private SSOContext _context;
	

    public UserRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IUserRepository.cs file
}
}
