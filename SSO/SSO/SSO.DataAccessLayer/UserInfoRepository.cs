                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class UserInfoRepository : GenericDataRepository<UserInfo>, IUserInfoRepository
{
    private SSOContext _context;
	

    public UserInfoRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IUserInfoRepository.cs file
}
}
