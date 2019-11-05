
    
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class CardStatuRepository : GenericDataRepository<CardStatu>, ICardStatuRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public CardStatuRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ICardStatuRepository.cs file
}
}
