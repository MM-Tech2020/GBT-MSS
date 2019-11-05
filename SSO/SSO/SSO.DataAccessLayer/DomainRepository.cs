                
using SSO.Model;
namespace SSO.DataAccessLayer
{              
public partial class DomainRepository : GenericDataRepository<Domain>, IDomainRepository
{
    private SSOContext _context;
	

    public DomainRepository(SSOContext entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IDomainRepository.cs file
}
}
