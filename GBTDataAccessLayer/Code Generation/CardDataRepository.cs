                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class CardDataRepository : GenericDataRepository<CardData>, ICardDataRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public CardDataRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ICardDataRepository.cs file
}
}
