                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class PaymentsduesRepository : GenericDataRepository<Payments_dues>, IPaymentsduesRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public PaymentsduesRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPaymentsduesRepository.cs file
}
}
